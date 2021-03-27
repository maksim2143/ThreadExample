using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExample
{
    abstract class Repository<T>
    {
        public abstract List<T> Current { set; get; }
    }
}
