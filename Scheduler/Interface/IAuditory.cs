using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interface
{
    interface IAuditory
    {
        void Add(string number);

        void Edit(string number, int index);

        void DeleteByIndex(int index);

        void DeleteLast();
    }
}
