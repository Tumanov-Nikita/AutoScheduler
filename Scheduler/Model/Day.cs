using Scheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    public class Day : IDay
    {
        public int Id { get; set; }
        public int MaxLessons { get; set; }
        public List<Lesson> Lessons;

        public Day(int MaximumLessons)
        {
            this.MaxLessons = MaximumLessons;
            this.Lessons = new List<Lesson>();
        }

        public Day()
        {
            this.Lessons = new List<Lesson>();
        }

        public void AddLesson(Lesson lesson)
        {
            Lessons.Add(lesson);
        }

        public Lesson Get(int index)
        {
            return Lessons.ElementAt(index);
        }

        public void ReplaceLesson(Lesson newLesson, int index)
        {
            Lessons.Insert(index, newLesson);
        }

        public void DeleteLessonByIndex(int index)
        {
            Lessons.RemoveAt(index);
        }

        public void DeleteLastLesson()
        {
            Lessons.RemoveAt(Lessons.Count - 1);
        }
    }
}
