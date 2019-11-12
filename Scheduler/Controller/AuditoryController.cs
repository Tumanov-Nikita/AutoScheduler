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
    class AuditoryController : IAuditory
    {
        Checkers check = new Checkers();
        static SchedulerContext DB;

        public AuditoryController(SchedulerContext db)
        {
            DB = db;
        }

        public void Add(string newNumber)
        {
            if (check.Firmness(newNumber) && check.TexboxValidation(newNumber))
            {
                try
                {
                    Auditory newRow = new Auditory(newNumber);
                    var equalRecords = DB.Auditories.Where(l => l.Number.Equals(newNumber));
                    if (equalRecords.Any())
                    {
                        MessageBox.Show("Такая аудитория уже существует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DB.Auditories.Add(newRow);
                        DB.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка добавления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Edit(string newNumber, int rowId)
        {
            if (check.Firmness(newNumber) && check.TexboxValidation(newNumber))
            {
                try
                {
                    Auditory newRow = new Auditory(newNumber);
                    var equalRecords = DB.Auditories.Where(l => l.Number.Equals(newNumber));
                    if (equalRecords.Any())
                    {
                        MessageBox.Show("Такая аудитория уже существует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var EditedValue = DB.Auditories.Where(c => c.Id == rowId)
                            .FirstOrDefault();
                        EditedValue.Number = newNumber;
                        DB.SaveChanges();

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
                Auditory DelitedValue = DB.Auditories.Where(l => l.Id == index).FirstOrDefault();
                DB.Auditories.Remove(DelitedValue);
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
                Auditory DelitedValue = DB.Auditories.Last();
                DB.Auditories.Remove(DelitedValue);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка удаления\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

