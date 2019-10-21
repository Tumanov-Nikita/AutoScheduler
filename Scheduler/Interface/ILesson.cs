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
        void EditLector(Lector lector);

        Lesson Get(List<Lesson> Lessons, int index);

        void Add(List<Lesson> Lessons, string name, Lector lector, int hoursPlan);

        void Edit(List<Lesson> Lessons, Lesson newLesson, int index);

        void DeleteByIndex(List<Lesson> Lessons, int index);

        void DeleteByName(List<Lesson> Lessons, string name);

        void DeleteLast(List<Lesson> Lessons);
    }
}
