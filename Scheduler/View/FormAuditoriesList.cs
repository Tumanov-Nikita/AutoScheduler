using Scheduler.Controller;
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
    public partial class FormAuditoriesList : Form
    {
        Checkers check = new Checkers();
        AuditoryController Controller;
        static SchedulerContext db;
        List<TextBox> TextBoxes;
        public FormAuditoriesList()
        {
            InitializeComponent();
            db = new SchedulerContext();
            TextBoxes = new List<TextBox>();
            TextBoxes.Add(textBoxNumber);
        }

        public static void refreshForm(DataGridView dataGridView, List<TextBox> textBoxes)
        {
            db.Auditories.Load();
            dataGridView.DataSource = db.Auditories.Local.ToBindingList();
            dataGridView.Update();
            dataGridView.Refresh();
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c > 'A' && c < 'я') && c != '\b' && c != ' ')
            {
                e.Handled = true;
            }
        }

        private void CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CurrentRow = dataGridView.SelectedCells[0].RowIndex;
            string nameId1 = dataGridView[1, CurrentRow].Value.ToString();
            textBoxNumber.Text = nameId1;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controller.Add(textBoxNumber.Text);
            refreshForm(dataGridView, TextBoxes);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int CurrentRow = dataGridView.SelectedCells[0].RowIndex;
            int valueId = Convert.ToInt32(dataGridView[0, CurrentRow].Value);
            string changeMark = textBoxNumber.Text;
            Controller.Edit(changeMark, valueId);
            refreshForm(dataGridView, TextBoxes);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedId = dataGridView.SelectedCells[0].RowIndex;
            int rowId = Convert.ToInt32(dataGridView[0, selectedId].Value);
            Controller.DeleteByIndex(rowId);
            refreshForm(dataGridView, TextBoxes);
        }

        private void FormAuditoriesList_Load(object sender, EventArgs e)
        {
            Controller = new AuditoryController(db);
            db.Auditories.Load();
            dataGridView.DataSource = db.Auditories.Local.ToBindingList();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
