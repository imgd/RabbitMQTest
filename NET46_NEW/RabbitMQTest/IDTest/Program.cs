using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<long>();
            Snowflake64.InitData(10, 2);
            for (int i = 0; i < 2000000; i++)
            {
                data.Add(Snowflake64.CreateId());
            }

            //data = new List<long> {
            //    1,1,2
            //};

            Console.WriteLine($"总条数:{data.Count},去重后的条数：{data.Distinct().Count()}");
            Console.ReadLine();
        }
    }
}
