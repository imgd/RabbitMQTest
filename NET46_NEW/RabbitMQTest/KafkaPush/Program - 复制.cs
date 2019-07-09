using RdKafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaPush
{
    class Program2
    {
        static void Main2(string[] args)
        {
            
            using (Producer producer = new Producer("127.0.0.1:9092"))
            using (Topic topic = producer.Topic("test"))
            {
                while (true)
                {
                    var inputmsg = Console.ReadLine();
                    byte[] data = Encoding.UTF8.GetBytes(inputmsg);
                    Task.Run(async () =>
                    {
                        DeliveryReport deliveryReport = await topic.Produce(data);
                        Console.WriteLine($"Produced to Partition: {deliveryReport.Partition}, Offset: {deliveryReport.Offset}");
                    });
                }
                
                
            }

            Console.ReadLine();
        }
    }
}
