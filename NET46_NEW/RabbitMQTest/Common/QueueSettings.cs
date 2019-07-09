using MongoDB.Driver;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public static class QueueSettings
    {
        public const string QueueName = "queue_test";

        public static IConnectionFactory GetConnectionFactory()
        {
            var fac = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "192.168.1.210",//IP地址
                Port = 5672,//端口号
                UserName = "admin",//用户账号
                Password = "admin",//用户密码
                VirtualHost = "admin",
                Protocol = Protocols.DefaultProtocol,
                AutomaticRecoveryEnabled = true,//断线重连
                UseBackgroundThreadsForIO = true

            };

            return fac;
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

                    var num = 1;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while (true)
                    {
                        var message = new SMSlog
                        {
                            Num = Snowflake64.CreateId().ToString(),
                            TD = 1,
                            SH = 1,
                            SJ = "13683461619",
                            NR = "短信测试内容一二十三十五六七八九短信测试内容一二十三十五六七八九短信测试内容一二十三十五六七八九短信测试内容一二十三十五六七八九",
                            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        //消息内容
                        byte[] body = Encoding.UTF8.GetBytes(message.M5_ObjectToJson());
                        //发送消息
                        channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: props, body: body);
                        num++;
                        //Console.WriteLine($"成功发送消息{message.Id}");
                        if (num > 100000)
                        {
                            num = 1;
                            stopwatch.Stop();
                            Console.WriteLine($"成功发送消息:100000条,耗时：{stopwatch.ElapsedMilliseconds} 毫秒。");
                            stopwatch.Restart();
                        }
                    }
                }
            }
        }
    }

    public class QueueReceive
    {
        private QueueReceiveArgs _sets { get; set; }
        public QueueReceive(QueueReceiveArgs sets)
        {
            _sets = sets;
        }
        private QueueReceive() { }

        public void Run()
        {
            //using (IConnection conn = QueueSettings.GetConnectionFactory().CreateConnection())
            //{
            using (IModel channel = _sets.RabbitCon.CreateModel())
            {
                var queueName = QueueSettings.QueueName;

                //预读
                channel.BasicQos(0, 280, false);

                //创建消费者对象

                var consumer = new EventingBasicConsumer(channel);
                //var num = 1;
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();
                consumer.Received += (model, ea) =>
                 {

                     try
                     {
                         //模拟上游网络请求耗时
                         Thread.Sleep(100);

                         var message = Encoding.UTF8.GetString(ea.Body).M5_JsonToObject<SMSlog>();
                         _sets.mongoConnection.InsertOne(message);
                         //手动确认消费完毕
                         channel.BasicAck(ea.DeliveryTag, false);
                         
                         //var result = Client.GetAsync("http://www.baidu.com").Result;


                         //Console.WriteLine($"线程{ThredNum}已消费:{message.Num}");
                         //num++;
                         //if (num > 200)
                         //{
                         //    num = 1;
                         //    stopwatch.Stop();
                         //    Console.WriteLine($"线程{ThredNum}已消费:10000条,耗时：{stopwatch.ElapsedMilliseconds} 毫秒。");
                         //    stopwatch.Restart();
                         //}

                     }
                     catch (AlreadyClosedException ex)
                     {
                         Console.WriteLine($"线程{_sets.ThredNum}接收信息时连接已关闭。");
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine($"线程{_sets.ThredNum}接收信息时出现异常{ex.Message}。");
                     }
                     finally
                     {
                         
                     }

                 };
                //消费者开启监听
                channel.BasicConsume(queueName, false, consumer);
                Console.ReadKey();
            }
            //}
        }
    }

    public class QueueReceiveArgs
    {
        public int ThredNum { get; set; }

        public IConnection RabbitCon { get; set; }

        public HttpClient client { get; set; }

        public IMongoCollection<SMSlog> mongoConnection { get; set; }
    }
}
