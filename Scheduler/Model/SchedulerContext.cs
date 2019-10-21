using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Model
{
    class SchedulerContext : DbContext
    {
        public SchedulerContext() : base("DbConnection")
        {

        }
        public DbSet<Auditory> Auditories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Day> Days { get; set; }
    }
}
