using AutoScheduler.View;
using Scheduler.Model;
using Scheduler.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //using (SchedulerContext db = new SchedulerContext())
            //{
            //    // создаем два объекта User
            //    Lector lector1 = new Lector("Абырвалг 1");
            //    Lector lector2 = new Lector("Абырвалг 2");

            //    // добавляем их в бд
            //    db.Lectors.Add(lector1);
            //    db.Lectors.Add(lector2);
            //    db.SaveChanges();


            //    Console.WriteLine("Объекты успешно сохранены");

            //    var Lectors = db.Lectors;
            //    Console.WriteLine("Список объектов:");
            //    foreach (Lector u in Lectors)
            //    {
            //        Console.WriteLine("{0},", u.FIO);
            //    }
            //}


            Application.Run(new FormСatalogue());

            
        }
    }
}
