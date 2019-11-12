using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Lector
    {
        public int Id { get; set; }
        public string FIO { get; set; }

        public Lector(string FIO)
        {
            this.FIO = FIO;
        }

        public Lector(){}

        public override string ToString()
        {
            return FIO; 
        }
    }
}
