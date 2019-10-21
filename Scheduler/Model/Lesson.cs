using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Lesson : ILesson
    {
        public int Id { get; set; }
        public int HoursPlan { get; set; }
        public Lector Lector { get; set; }
        public string Name { get; set; }

        public Lesson(string name, Lector lector, int hoursPlan)
        {
            this.Name = name;
            this.Lector = lector;
            this.HoursPlan = hoursPlan;
        }

        public Lesson()
        {
        }

        public void EditLector(Lector lector)
        {
            this.Lector = lector;
        }

        public Lesson Get(List<Lesson> Lessons, int index)
        {
            return Lessons.ElementAt(index);
        }

        public void Add(List<Lesson> Lessons, string name, Lector lector, int hoursPlan)
        {
            Lessons.Add(new Lesson(name, lector, hoursPlan));
        }

        public void Edit(List<Lesson> Lessons, Lesson newLesson, int index)
        {
            Lessons.Insert(index, newLesson);
        }

        public void DeleteByIndex(List<Lesson> Lessons, int index)
        {
            Lessons.RemoveAt(index);
        }

        public void DeleteLast(List<Lesson> Lessons)
        {
            Lessons.RemoveAt(Lessons.Count - 1);
        }

        public void DeleteByName(List<Lesson> Lessons, string name)
        {
            Lessons.Remove(Lessons.First(x => x.Name == name));
        }
    }
}
