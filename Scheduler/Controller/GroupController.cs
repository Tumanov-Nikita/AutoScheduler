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
    class GroupController : IGroup
    {
        Checkers check = new Checkers();
        static SchedulerContext GroupDB;

        public GroupController(SchedulerContext db)
        {
            GroupDB = db;
        }

        public void Add(string name, int year)
        {
            if (check.Firmness(name) && check.IntegerValidation(year))
            {
                try
                {
                    Group newRow = new Group(name, year);
                    var equalRecords = GroupDB.Groups.Where(l => l.Name.Equals(name) && l.Year.Equals(year));
                    if (equalRecords.Any())
                    {
                        MessageBox.Show("Такая учебная группа уже существует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        GroupDB.Groups.Add(newRow);
                        GroupDB.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка добавления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Edit(string newName, int newYear, int rowId)
        {
            if (check.Firmness(newName) && check.IntegerValidation(newYear))
            {
                try
                {
                    Group newRow = new Group(newName, newYear);
                    var equalRecords = GroupDB.Groups.Where(l => l.Name.Equals(newName) && l.Year.Equals(newYear));
                    if (equalRecords.Any())
                    {
                        MessageBox.Show("Такая учебная группа уже существует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var EditedValue = GroupDB.Groups.Where(c => c.Id == rowId)
                            .FirstOrDefault();
                        EditedValue.Name = newName;
                        EditedValue.Year = newYear;
                        GroupDB.SaveChanges();
                    }
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
                Group DelitedValue = GroupDB.Groups.Where(l => l.Id == index).FirstOrDefault();
                GroupDB.Groups.Remove(DelitedValue);
                GroupDB.SaveChanges();
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
                Group DelitedValue = GroupDB.Groups.Last();
                GroupDB.Groups.Remove(DelitedValue);
                GroupDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка удаления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
