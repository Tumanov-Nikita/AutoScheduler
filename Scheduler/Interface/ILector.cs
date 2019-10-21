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
        Lector Get(List<Lector> Lectors, int index);

        Lector GetByFIO(List<Lector> Lectors, string FIO);

        void Add(List<Lector> Lectors, string FIO);

        void Edit(List<Lector> Lectors, string FIO, int index);

        void DeleteByIndex(List<Lector> Lectors, int index);

        void DeleteLast(List<Lector> Lectors);
    }
}
