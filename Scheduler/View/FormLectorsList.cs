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
    public partial class FormLectorsList : Form
    {
        Checkers check = new Checkers();
        LectorController Controller;
        static SchedulerContext db;
        List<TextBox> TextBoxes;
        public FormLectorsList()
        {
            InitializeComponent();
            db = new SchedulerContext();
            TextBoxes = new List<TextBox>();
            TextBoxes.Add(textBoxFIO);
        }

        private void FormLectorsList_Load(object sender, EventArgs e)
        {
            Controller = new LectorController(db);
            db.Lectors.Load();
            dataGridView1.DataSource = db.Lectors.Local.ToBindingList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public static void refreshForm(DataGridView dataGridView, List<TextBox> textBoxes)
        {
            db.Lectors.Load();
            dataGridView.DataSource = db.Lectors.Local.ToBindingList();
            dataGridView.Update();
            dataGridView.Refresh();
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }

        private void CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            string nameId1 = dataGridView1[1, CurrentRow].Value.ToString();
            textBoxFIO.Text = nameId1;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c < 'A' || c > 'я') && c != '\b' && c !=' ')
            {
                e.Handled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controller.Add(textBoxFIO.Text);
            refreshForm(dataGridView1, TextBoxes);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            int valueId = Convert.ToInt32(dataGridView1[0, CurrentRow].Value);
            string changeMark = textBoxFIO.Text;
            Controller.Edit(changeMark, valueId);
            refreshForm(dataGridView1, TextBoxes);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedId = dataGridView1.SelectedCells[0].RowIndex;
            int rowId = Convert.ToInt32(dataGridView1[0, selectedId].Value);
            Controller.DeleteByIndex(rowId);
            refreshForm(dataGridView1, TextBoxes);
        }
    }
}
