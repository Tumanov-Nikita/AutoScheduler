using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Group(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }

        public Group(){}
    }
}
