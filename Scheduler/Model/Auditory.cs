using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    class Auditory : IAuditory
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public Auditory(int number)
        {
            this.Number = number;
        }

        public Auditory()
        {
        }

        public void Add(List<Auditory> Auditories, int number)
        {
            Auditories.Add(new Auditory(number));
        }

        public void DeleteByIndex(List<Auditory> Auditories, int index)
        {
            Auditories.RemoveAt(index);
        }

        public void DeleteByNumber(List<Auditory> Auditories, int number)
        {
            Auditories.Remove(Auditories.First(x => x.Number == number));
        }

        public void DeleteLast(List<Auditory> Auditories)
        {
            Auditories.RemoveAt(Auditories.Count - 1);
        }

        public void Edit(List<Auditory> Auditories, int index, int number)
        {
            Auditories.Insert(index, new Auditory(number));
        }

        public Auditory Get(List<Auditory> Auditories, int index)
        {
            return Auditories.ElementAt(index);
        }
    }
}
