using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interface
{
    interface IDiscipline
    {
        void Add(string name, string lector, int hoursPlan, List<Group> groups);

        void Edit(string name, string lector, int hoursPlan, List<Group> groups, int index);

        void DeleteByIndex(int index);

        void DeleteByName(string name);

        void DeleteLast();
    }
}
