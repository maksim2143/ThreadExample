using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExample
{
    class ObjRepository<T> : Repository<T>
    {
        public override List<T> Current { set; get; }
        public ObjRepository(List<T> ls)
        {
            this.Current = ls;
        }
    }
}
