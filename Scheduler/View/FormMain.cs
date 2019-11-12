using Scheduler.Controller;
using Scheduler.Model;
using Scheduler.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScheduler.View
{
    public partial class FormMain : Form
    {
        static SchedulerContext DB;

        public FormMain()
        {
            InitializeComponent();
            DB = new SchedulerContext();
        }

        private void преподавателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLectorsList formLectors = new FormLectorsList();
            formLectors.ShowDialog();
        }

        private void аудиторииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuditoriesList formAuditories = new FormAuditoriesList();
            formAuditories.ShowDialog();
        }

        private void учебныеГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGroupsList formGroups = new FormGroupsList();
            formGroups.ShowDialog();
        }

        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDisciplinesList formLessons = new FormDisciplinesList();
            formLessons.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScheduleMaker scheduleMaker = new ScheduleMaker(DB);
            scheduleMaker.CreateSchedule();
        }
    }
}
