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
    class DisciplineController : IDiscipline
    {

        Checkers check = new Checkers();
        static SchedulerContext DB;

        public DisciplineController(SchedulerContext db)
        {
            DB = db;
        }

        public void Add(string name, string lector, int hoursPlan, List<Group> groups)
        {
            var findLector = DB.Lectors.Where(l => l.FIO == lector);
            if (check.Firmness(name) && check.IntegerValidation(hoursPlan) && findLector.Any())
            {
                try
                {
                    string groupsStr = "";
                    foreach (Group group in groups)
                    {
                        groupsStr += group.Name + ";";
                    }
                    Lector lessonLector = DB.Lectors.Where(l => l.FIO.Equals(lector)).FirstOrDefault();
                    Discipline newRow = new Discipline(name, lessonLector, hoursPlan, groupsStr);
                    var equalRecords = DB.Disciplines.Where(l => l.Name.Equals(name) && l.HoursPlan.Equals(hoursPlan) && l.Lector.FIO == lector);
                    if (equalRecords.Any())
                    {
                        MessageBox.Show("Такая дисциплина уже существует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DB.Disciplines.Add(newRow);
                        DB.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка добавления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteByIndex(int index)
        {
            try
            {
                Discipline DelitedValue = DB.Disciplines.Where(l => l.Id == index).FirstOrDefault();
                DB.Disciplines.Remove(DelitedValue);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка удаления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteByName(string name)
        {
            try
            {
                Discipline DelitedValue = DB.Disciplines.Where(l => l.Name == name).FirstOrDefault();
                DB.Disciplines.Remove(DelitedValue);
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
                Discipline DelitedValue = DB.Disciplines.Last();
                DB.Disciplines.Remove(DelitedValue);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка удаления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Edit(string name, string lector, int hoursPlan, List<Group> groups, int index)
        {
            var findLector = DB.Lectors.Where(l => l.FIO == lector);
            if (check.Firmness(name) && check.IntegerValidation(hoursPlan) && findLector.Any())
            {
                try
                {
                    string groupsStr = "";
                    foreach (Group group in groups)
                    {
                        groupsStr += group.Name + ";";
                    }
                    Lector lessonLector = DB.Lectors.Where(l => l.FIO.Equals(lector)).FirstOrDefault();
                    Discipline newRow = new Discipline(name, lessonLector, hoursPlan, groupsStr);
                    var equalRecords = DB.Disciplines.Where(l => l.Name.Equals(name) && l.HoursPlan.Equals(hoursPlan) && l.Groups.Equals(groupsStr));
                    if (equalRecords.Any())
                    {
                        MessageBox.Show("Такая дисциплина уже существует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var EditedValue = DB.Disciplines.Where(c => c.Id == index)
                            .FirstOrDefault();
                        EditedValue.Name = name;
                        EditedValue.HoursPlan = hoursPlan;
                        EditedValue.Lector = lessonLector;
                        EditedValue.Groups = groupsStr;
                        DB.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка редактирования\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
