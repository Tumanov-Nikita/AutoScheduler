using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interface
{
    interface ILesson
    {
        void Add(string discipline, string group, string auditory, bool lecture);

        void Edit(string discipline, string group, string auditory, int index);

        void DeleteByIndex(int index);

        void DeleteLast();
    }
}
