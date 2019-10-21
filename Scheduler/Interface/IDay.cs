using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Interface
{
    interface IDay
    {
        void AddLesson(Lesson lesson);

        Lesson Get(int index);

        void ReplaceLesson(Lesson newLesson, int index);

        void DeleteLessonByIndex(int index);

        void DeleteLastLesson();
    }
}
