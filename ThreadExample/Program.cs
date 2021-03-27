using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitArray;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            using (HttpClient httpClient = new HttpClient())
            {
                ObjRepository<string> obj = new ObjRepository<string>(Enumerable.Repeat<string>("-", 300).ToList());
                Worker<string, string> worker = new Worker<string, string>(obj, a =>
                {
                    //try
                    {
                        Console.WriteLine(count++);
                        string result = httpClient.GetAsync("https://spac1.net/files/search/")
                         .Result.Content.ReadAsStringAsync()
                         .Result;
                        return Regex.Match(result, "<title>[^<>]+</title>").Value;
                    }
                    //catch(0 { return "" }
                });
                foreach (var item in worker.Start(4))
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadLine();
        }
    }
  
}
