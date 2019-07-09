using Common;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQReceive
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("消费者客户端已启动,正在分配线程消费...");
            var thredCount = 32;
            var client = new HttpClient();
            var mongoCon = new MongoBase().GetConnection();
            var rabbitConnection = QueueSettings.GetConnectionFactory().CreateConnection();

            for (int i = 0; i < thredCount; i++)
            {
                ThreadPool.QueueUserWorkItem((object state) =>
                 {
                     var sets = state as QueueReceiveArgs;
                     Console.WriteLine($"线程{sets.ThredNum}已启动消费者模式.");

                     var receive = new QueueReceive(sets);
                     receive.Run();
                 }, new QueueReceiveArgs
                 {
                     ThredNum = i,
                     RabbitCon = rabbitConnection,
                     client = client,
                     mongoConnection = mongoCon
                 });
            }

            Console.ReadLine();
        }


    }
}
