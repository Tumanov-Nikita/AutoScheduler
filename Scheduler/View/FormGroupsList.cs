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
    public partial class FormGroupsList : Form
    {
        Checkers check = new Checkers();
        GroupController Controller;
        static SchedulerContext db;
        List<TextBox> TextBoxes;
        public FormGroupsList()
        {
            InitializeComponent();
            db = new SchedulerContext();
            TextBoxes = new List<TextBox>();
            TextBoxes.Add(textBoxName);
            comboBoxYear.SelectedIndex = 0;
        }

        public static void refreshForm(DataGridView dataGridView, List<TextBox> textBoxes)
        {
            db.Groups.Load();
            dataGridView.DataSource = db.Groups.Local.ToBindingList();
            dataGridView.Update();
            dataGridView.Refresh();
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }

        private void CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CurrentRow = dataGridView.SelectedCells[0].RowIndex;
            string nameId1 = dataGridView[1, CurrentRow].Value.ToString();
            string nameId2 = dataGridView[2, CurrentRow].Value.ToString();
            textBoxName.Text = nameId1;
            comboBoxYear.SelectedIndex = Convert.ToInt16(nameId2)-1;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Controller.Add(textBoxName.Text, Convert.ToInt16(comboBoxYear.SelectedItem.ToString()));
            refreshForm(dataGridView,TextBoxes);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int CurrentRow = dataGridView.SelectedCells[0].RowIndex;
            Controller.Edit(textBoxName.Text, Convert.ToInt16(comboBoxYear.SelectedItem.ToString()), CurrentRow);
            refreshForm(dataGridView,TextBoxes);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedId = dataGridView.SelectedCells[0].RowIndex;
            int rowId = Convert.ToInt32(dataGridView[0, selectedId].Value);
            Controller.DeleteByIndex(rowId);
            refreshForm(dataGridView, TextBoxes);
        }

        private void FormGroupsList_Load(object sender, EventArgs e)
        {
            Controller = new GroupController(db);
            db.Groups.Load();
            dataGridView.DataSource = db.Groups.Local.ToBindingList();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
