using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQQueueTest;
using System;
using System.Text;
using System.Threading;

namespace ReceiveClinet2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("消费者2队列接受中...");

            var receive = new QueueReceive(1);
            receive.Run();

            Console.ReadLine();

        }
    }
}
