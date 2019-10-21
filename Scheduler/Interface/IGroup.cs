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
        Group Get(List<Group> Groups, int index);

        void Add(List<Group> Groups, string GroupName, int Year);

        void Edit(List<Group> Groups, string name, int year, int index);

        void DeleteByIndex(List<Group> Groups, int index);

        void DeleteLast(List<Group> Groups);
    }
}
