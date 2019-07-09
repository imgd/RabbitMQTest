using Common;
using Confluent.Kafka;
using RdKafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaPush
{
    class Program
    {
        static void Main(string[] args)
        {
            Snowflake64.InitData(11, 2);
            Console.WriteLine($"Delivery failed: 消费者已启动");
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                for (int i = 0; i < 10000000; i++)
                {
                    try
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
                        p.Produce("test", new Message<Null, string> { Value = message.M5_ObjectToJson() });
                        Console.WriteLine($"生产消息：{message.Num}");
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                    }
                    finally
                    {
                        Thread.Sleep(1);
                    }
                }

                p.Flush(TimeSpan.FromSeconds(1));

            }

            Console.ReadLine();
        }
    }
}
