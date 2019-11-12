using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Discipline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Lector Lector { get; set; }

        public int HoursPlan { get; set; }

        public string Groups { get; set; }

        public Discipline(string name, Lector lector, int hoursPlan, string groups)
        {
            Name = name;
            Lector = lector;
            HoursPlan = hoursPlan;
            Groups = groups;
        }

        public Discipline() { }
    }
}
