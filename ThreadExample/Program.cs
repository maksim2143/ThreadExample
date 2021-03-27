using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitArray;
namespace ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjRepository<string> obj = new ObjRepository<string>(Enumerable.Repeat<string>("-", 100).ToList());
            Worker<string, string> worker = new Worker<string, string>(obj, a => "1)" + a);
            foreach (var item in worker.Start(4))
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
  
}
