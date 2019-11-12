using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interface
{
    interface IGroup
    {
        void Add(string GroupName, int Year);

        void Edit(string name, int year, int index);

        void DeleteByIndex(int index);

        void DeleteLast();
    }
}
