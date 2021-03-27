using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitArray;

namespace ThreadExample
{
    class Worker<T,R> 
    {
        public List<R> Start(int count)
        {
            var result = this.repository
           .Current
           .Split(count)
           .Select(h => new Obj<T,R>(h.ToList(),this.action))
           .Select(j => Task.Run(() =>
           {
               j.Start();
               return j;
           })).ToArray();
            Task.WaitAll(result);
            return result
                .SelectMany(q => q?.Result?.Result)
                //.ToList()
                .Where(q => q != null)
                .ToList();
        }
        Repository<T> repository;
        Func<T, R> action;
        public Worker(Repository<T> repository,Func<T,R> action)
        {
            this.action = action;
            this.repository = repository;
        }
    }
}
