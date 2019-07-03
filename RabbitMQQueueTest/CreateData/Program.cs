using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CreateData
{
    class Program
    {
        static void Main(string[] args)
        {
            string template = "{0},{1},{2},{3},{4},{5}";
            var stream = File.Create("F:\\bigdata.txt");
            StreamWriter streamWriter = new StreamWriter(stream,Encoding.UTF8);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            for (int i = 0; i < 100000000; i++)
            {
                streamWriter.WriteLine(string.Format(template, i, "1", "1", "18180653097", "一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十一二三四五六七八九十", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            stopwatch.Stop();
            streamWriter.Close();
            stream.Close();
            Console.WriteLine("完成,总用时:" + stopwatch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
        }
    }
}
