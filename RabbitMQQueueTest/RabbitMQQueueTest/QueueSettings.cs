using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQQueueTest
{
    public static class QueueSettings
    {
        public const string QueueName = "queue_test";

        public static IConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory//创建连接工厂对象
            {
                HostName = "192.168.41.246",//IP地址
                Port = 5672,//端口号
                UserName = "admin",//用户账号
                Password = "admin",//用户密码
                VirtualHost = "admin",
                Protocol = Protocols.DefaultProtocol,
                AutomaticRecoveryEnabled = true//断线重连
            };
        }
    }

    public class QueuePush
    {
        public void Run()
        {
            using (IConnection con = QueueSettings.GetConnectionFactory().CreateConnection())//创建连接对象
            {
                using (IModel channel = con.CreateModel())//创建连接会话对象
                {

                    var queueName = QueueSettings.QueueName;

                    //声明一个队列
                    channel.QueueDeclare(
                      queue: queueName,//消息队列名称
                      durable: true,//队列持久化
                      exclusive: false,
                      autoDelete: false,
                      arguments: null);

                    //设置消息持久化
                    var props = channel.CreateBasicProperties();
                    props.DeliveryMode = 2;

                    while (true)
                    {
                        var message = Console.ReadLine() ?? $"test{System.Guid.NewGuid()}";
                        //消息内容
                        byte[] body = Encoding.UTF8.GetBytes(message);
                        //发送消息
                        channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: props, body: body);
                        Console.WriteLine("成功发送消息:" + message);
                    }
                }
            }
        }
    }

    public class QueueReceive
    {
        private int ThredNum { get; set; }
        public QueueReceive(int num)
        {
            ThredNum = num;
        }
        private QueueReceive() { }

        public void Run()
        {
            using (IConnection conn = QueueSettings.GetConnectionFactory().CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    var queueName = QueueSettings.QueueName;
                    channel.QueueDeclare(
                      queue: queueName,//消息队列名称
                      durable: true,//队列持久化
                      exclusive: false,
                      autoDelete: false,
                      arguments: null);

                    //预读
                    channel.BasicQos(0, 1, false);

                    //创建消费者对象
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        try
                        {
                            byte[] message = ea.Body;//接收到的消息
                            Console.WriteLine($"线程{ThredNum} 接收到信息为:{Encoding.UTF8.GetString(message)}");
                            //手动确认消费完毕
                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                        catch (AlreadyClosedException ex)
                        {
                            Console.WriteLine($"线程{ThredNum}接收信息时连接已关闭。");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"线程{ThredNum}接收信息时出现异常{ex.Message}。");
                        }

                    };
                    //消费者开启监听
                    channel.BasicConsume(queueName, false, consumer);
                    Console.ReadKey();
                }
            }
        }
    }
}
