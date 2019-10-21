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
        Auditory Get(List<Auditory> Auditories, int index);

        void Add(List<Auditory> Auditories, int number);

        void Edit(List<Auditory> Auditories, int index, int number);

        void DeleteByIndex(List<Auditory> Auditories, int index);

        void DeleteLast(List<Auditory> Auditories);
    }
}
