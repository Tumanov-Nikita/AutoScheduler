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
    class LectorController : ILector
    {
        Checkers check = new Checkers();
        static SchedulerContext LectorDB;

        public LectorController(SchedulerContext db)
        {
            LectorDB = db;
        }

        public void Add(string newFIO)
        {
            if (check.Firmness(newFIO) && check.FIOvalidation(newFIO))
            {
                try
                {
                    Lector newRow = new Lector(newFIO);
                    var equalRecords = LectorDB.Lectors.Where(l => l.FIO.Equals(newFIO));
                    if (equalRecords.Any())
                    {
                        MessageBox.Show("Такой преподаватель уже существует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LectorDB.Lectors.Add(newRow);
                        LectorDB.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка добавления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Edit(string newFIO, int rowId)
        {
            if (check.Firmness(newFIO) && check.FIOvalidation(newFIO))
            {
                try
                {
                    Lector newRow = new Lector(newFIO);
                    var equalRecords = LectorDB.Lectors.Where(l => l.FIO.Equals(newFIO));
                    if (equalRecords.Any())
                    {
                        MessageBox.Show("Такой преподаватель уже существует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var EditedValue = LectorDB.Lectors.Where(c => c.Id == rowId)
                            .FirstOrDefault();
                        EditedValue.FIO = newFIO;
                        LectorDB.SaveChanges();

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
                Lector DelitedValue = LectorDB.Lectors.Where(l => l.Id == index).FirstOrDefault();
                LectorDB.Lectors.Remove(DelitedValue);
                LectorDB.SaveChanges();
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
                Lector DelitedValue = LectorDB.Lectors.Last();
                LectorDB.Lectors.Remove(DelitedValue);
                LectorDB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка удаления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
