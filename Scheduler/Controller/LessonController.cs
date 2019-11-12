using Scheduler.Interface;
using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.Controller
{
    class LessonController : ILesson
    {
        Checkers check = new Checkers();
        static SchedulerContext DB;

        public LessonController(SchedulerContext db)
        {
            DB = db;
        }

        public void Add(string discipline, string group, string auditory, bool lecture)
        {
            var findDiscipline = DB.Disciplines.Where(l => l.Name == discipline);
            var findGroup = DB.Groups.Where(l => l.Name == group);
            var findAuditory = DB.Auditories.Where(l => l.Number == auditory);
            if (findDiscipline.Any() && findAuditory.Any() && findGroup.Any())
            {
                try
                {
                    Discipline lessonDiscipline = findDiscipline.FirstOrDefault();
                    Group lessonGroup = findGroup.FirstOrDefault();
                    Auditory lessonAuditory = findAuditory.FirstOrDefault();
                    Lesson newRow = new Lesson(lessonDiscipline, lessonGroup, lessonAuditory, lecture);
                    DB.Lessons.Add(newRow);
                    DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка добавления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Edit(string discipline, string group, string auditory, int index)
        {
            var findDiscipline = DB.Disciplines.Where(l => l.Name == discipline);
            var findGroup = DB.Groups.Where(l => l.Name == group);
            var findAuditory = DB.Auditories.Where(l => l.Number == auditory);
            if (findDiscipline.Any() && findAuditory.Any() && findGroup.Any())
            {
                try
                {
                    Discipline lessonDiscipline = findDiscipline.FirstOrDefault();
                    Group lessonGroup = findGroup.FirstOrDefault();
                    Auditory lessonAuditory = findAuditory.FirstOrDefault();

                    var EditedValue = DB.Lessons.Where(c => c.Id == index)
                        .FirstOrDefault();
                    EditedValue.Discipline = lessonDiscipline;
                    EditedValue.Group = lessonGroup;
                    EditedValue.Auditory = lessonAuditory;
                    DB.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка редактирования\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteByIndex(int index)
        {
            try
            {
                Lesson DelitedValue = DB.Lessons.Where(l => l.Id == index).FirstOrDefault();
                DB.Lessons.Remove(DelitedValue);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка удаления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteLast()
        {
            try
            {
                Lesson DelitedValue = DB.Lessons.Last();
                DB.Lessons.Remove(DelitedValue);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка удаления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
