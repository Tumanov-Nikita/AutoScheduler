using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Lector : ILector
    {
        public int Id { get; set; }
        public string FIO { get; set; }

        public Lector(string FIO)
        {
            this.FIO = FIO;
        }

        public Lector()
        {
        }

        public Lector Get(List<Lector> Lectors, int ind)
        {
            return Lectors.ElementAt(ind);
        }

        public Lector GetByFIO(List<Lector> Lectors, string findFIO)
        {
            return Lectors.Find(x => x.FIO.Contains(findFIO));
        }

        public void Add(List<Lector> Lectors, string FIO)
        {
            Lectors.Add(new Lector(FIO));
        }

        public void Edit(List<Lector> Lectors, string FIO, int ind)
        {
            Lectors.Insert(ind, new Lector(FIO));
        }

        public void DeleteByIndex(List<Lector> Lectors, int index)
        {
            Lectors.RemoveAt(index);
        }

        public void DeleteLast(List<Lector> Lectors)
        {
            Lectors.RemoveAt(Lectors.Count - 1);
        }
    }
}
