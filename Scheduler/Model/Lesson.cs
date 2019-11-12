using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Lesson
    {
        public int Id { get; set; }

        public Discipline Discipline { get; set; }

        public Group Group { get; set; }

        public Auditory Auditory { get; set; }

        public bool Lecture { get; set; }
        
        public Lesson(Discipline discipline, Group group, Auditory auditory, bool lecture)
        {
            Discipline = discipline;
            Group = group;
            Auditory = auditory;
            Lecture = lecture;
        }

        public Lesson(){}

       
    }
}
