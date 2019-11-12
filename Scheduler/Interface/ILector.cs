using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interface
{
    interface ILector
    {

        void Add(string FIO);

        void Edit(string FIO, int index);

        void DeleteByIndex(int index);

        void DeleteLast();
    }
}
