using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.View
{
    public partial class FormСatalogue : Form
    {
        int row;
        Checkers check = new Checkers();
        SchedulerContext db;
        public FormСatalogue()
        {
            InitializeComponent();

            db = new SchedulerContext();
        }

        private void listBoxCatalogues_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBoxCatalogues.SelectedItem.ToString())
            {
                case "Преподаватели":
                    db.Lectors.Load();
                    dataGridViewCurrentCatalogue.DataSource = db.Lectors.Local.ToBindingList();
                    this.dataGridViewCurrentCatalogue.RowsAdded += LectorsValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= GroupValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= AuditoryValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= LessonValidating;
                    break;
                case "Учебные группы":
                    db.Groups.Load();
                    dataGridViewCurrentCatalogue.DataSource = db.Groups.Local.ToBindingList();
                    this.dataGridViewCurrentCatalogue.RowsAdded -= LectorsValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= GroupValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded += AuditoryValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= LessonValidating;
                    break;
                case "Аудитории":
                    db.Auditories.Load();
                    dataGridViewCurrentCatalogue.DataSource = db.Auditories.Local.ToBindingList();
                    this.dataGridViewCurrentCatalogue.RowsAdded -= LectorsValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= GroupValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded += AuditoryValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= LessonValidating;
                    break;
                case "Дисциплины":
                    db.Lessons.Load();
                    dataGridViewCurrentCatalogue.DataSource = db.Lessons.Local.ToBindingList();
                    this.dataGridViewCurrentCatalogue.RowsAdded -= LectorsValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= GroupValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded -= AuditoryValidating;
                    this.dataGridViewCurrentCatalogue.RowsAdded += LessonValidating;
                    break;
                default:
                    break;
            }

        }


        private void LectorsValidating(object sender, EventArgs e)
        {
            if (check.FIOvalidation(dataGridViewCurrentCatalogue.SelectedRows[1].ToString()))
            {
                db.Lectors.Add(new Lector(dataGridViewCurrentCatalogue.SelectedRows[1].ToString()));
            }
        }

        private void LessonValidating(object sender, EventArgs e)
        { // ++++++++++++++++++++++++
            if (check.FIOvalidation(dataGridViewCurrentCatalogue.SelectedRows[1].ToString()))
            {
                db.Lectors.Add(new Lector(dataGridViewCurrentCatalogue.SelectedRows[1].ToString()));
            }
        }

        private void GroupValidating(object sender, EventArgs e)
        { // ++++++++++++++++++++++++
            if (check.FIOvalidation(dataGridViewCurrentCatalogue.SelectedRows[1].ToString()))
            {
                db.Lectors.Add(new Lector(dataGridViewCurrentCatalogue.SelectedRows[1].ToString()));
            }
        }

        private void AuditoryValidating(object sender, EventArgs e)
        { // ++++++++++++++++++++++++
            if (check.FIOvalidation(dataGridViewCurrentCatalogue.SelectedRows[1].ToString()))
            { 
                db.Lectors.Add(new Lector(dataGridViewCurrentCatalogue.SelectedRows[1].ToString()));
            }
        }
    }
}
