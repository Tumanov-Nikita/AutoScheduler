using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Auditory
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public Auditory(string number)
        {
            this.Number = number;
        }

        public Auditory(){}   
    }
}
