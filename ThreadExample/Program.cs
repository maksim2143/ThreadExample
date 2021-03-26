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
            var result = Enumerable.Range(0, 2000)
            .Split(2)
            .Select(h => new Obj(h.ToList()))
            .Select(j => Task.Run(() =>
             {
              j.Start();
                 return j;
             })).ToArray();
            Task.WaitAll(result);
            var obj = result.SelectMany(h => h.Result.Result).ToList();
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey(); 
        }
    }
    class Obj
    {
        public void Start()
        {
            this.Result = ls.Select(q => "1) " + q).ToList();
        }
        public List<string> Result { private set; get; }
        List<int> ls;
        public Obj(List<int> ls)
        {
            this.ls = ls;
        }
    }
}
