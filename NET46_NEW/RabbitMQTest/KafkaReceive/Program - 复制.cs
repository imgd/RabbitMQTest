using RdKafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaReceive
{
    class Program2
    {
        static void Main2(string[] args)
        {
            Console.WriteLine("已启动消费者模式");
            var thredCount = 1;
            for (int i = 0; i < thredCount; i++)
            {
                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    var thredNum = Convert.ToInt32(state);
                    Console.WriteLine($"消费者{thredNum}已就绪.");

                    var config = new Config() { GroupId = "Kafka_Test_g_1" };
                    using (var consumer = new EventConsumer(config, "127.0.0.1:9092"))
                    {
                        consumer.OnMessage += (obj, msg) =>
                        {
                            string text = Encoding.UTF8.GetString(msg.Payload, 0, msg.Payload.Length);
                            Console.WriteLine($"消费者{thredNum} 消费：{text} , Offset: {msg.Offset}");
                            consumer.Commit(msg);
                        };

                        consumer.Subscribe(new List<string> { "test" });
                        consumer.Start();
                    }

                }, i);
            }

            Console.ReadLine();
        }
    }
}
