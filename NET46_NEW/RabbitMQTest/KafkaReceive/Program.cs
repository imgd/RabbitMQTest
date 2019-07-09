using Common;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaReceive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("已启动消费者模式");
            var thredCount = 12;
            for (int i = 0; i < thredCount; i++)
            {
                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    var thredNum = Convert.ToInt32(state);
                    Console.WriteLine($"消费者{thredNum}已就绪.");

                    var conf = new ConsumerConfig
                    {
                        GroupId = "test-consumer-group2",
                        BootstrapServers = "localhost:9092",
                        // Note: The AutoOffsetReset property determines the start offset in the event
                        // there are not yet any committed offsets for the consumer group for the
                        // topic/partitions of interest. By default, offsets are committed
                        // automatically, so in this example, consumption will only start from the
                        // earliest message in the topic 'my-topic' the first time you run the program.
                        AutoOffsetReset = AutoOffsetReset.Earliest
                    };

                    var con = new MongoBase().GetConnection();

                    using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
                    {
                        c.Subscribe("test");                       
                        CancellationTokenSource cts = new CancellationTokenSource();
                        Console.CancelKeyPress += (_, e) =>
                        {
                            e.Cancel = true; // prevent the process from terminating.
                            cts.Cancel();
                        };

                        try
                        {
                            while (true)
                            {
                                try
                                {
                                    var cr = c.Consume(cts.Token);
                                    var message = cr.Value.M5_JsonToObject<SMSlog>();
                                    con.InsertOne(message);
                                    Console.WriteLine($"消费者{thredNum} 消费：{message.Num}  [Partition/Offset]: [ {cr.Partition.Value} / {cr.TopicPartitionOffset.Offset} ] ");
                                }
                                catch (ConsumeException e)
                                {
                                    Console.WriteLine($"消费者{thredNum} Error occured: {e.Error.Reason}");
                                }
                                finally {
                                    Thread.Sleep(100);
                                }
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            // Ensure the consumer leaves the group cleanly and final offsets are committed.
                            c.Close();
                        }
                    }

                }, i);
            }

            Console.ReadLine();
        }
    }
}
