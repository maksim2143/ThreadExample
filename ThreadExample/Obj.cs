using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExample
{
    class Obj<T,R>
    {
        public void Start()
        {
            foreach (var item in ls)
            {
               this.Result.Add(action.Invoke(item));
            }
            
        }
        public List<R> Result { private set; get; }
        List<T> ls;
        Func<T, R> action;
        public Obj(List<T> ls,Func<T,R> action)
        {
            this.ls = ls;
            this.action = action;
            this.Result = new List<R>();    
        }
    }
}
