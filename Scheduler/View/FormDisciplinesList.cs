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
    public partial class FormDisciplinesList : Form
    {
        Checkers check = new Checkers();
        DisciplineController Controller;
        static SchedulerContext db;
        List<TextBox> TextBoxes;
        public FormDisciplinesList()
        {
            InitializeComponent();
            db = new SchedulerContext();
            TextBoxes = new List<TextBox>();
            TextBoxes.Add(textBoxHoursPlan);
            TextBoxes.Add(textBoxName);
        }

        public static void refreshForm(DataGridView dataGridView, DataGridView dataGridViewGroups, List<TextBox> textBoxes)
        {
            db.Disciplines.Load();
            dataGridView.DataSource = db.Disciplines.Local.ToBindingList();
            dataGridView.Update();
            dataGridView.Refresh();

            db.Groups.Load();
            dataGridViewGroups.DataSource = db.Groups.ToList();
            dataGridViewGroups.Columns[1].Visible = false;
            dataGridViewGroups.Columns[3].Visible = false;
            dataGridViewGroups.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }
            
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!Char.IsDigit(c) && c != '\b')
            {
                e.Handled = true;
            }
        }

        private void FormLessonsList_Load(object sender, EventArgs e)
        {
            Controller = new DisciplineController(db);
            db.Disciplines.Load();
            dataGridView.DataSource = db.Disciplines.Local.ToBindingList();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            comboBoxLector.DataSource = db.Lectors.ToList();
            comboBoxLector.DisplayMember = "FIO";
            RefreshDGVGroups(dataGridViewGroups);
        }

        private static void RefreshDGVGroups(DataGridView dataGridViewGroups)
        {
            db.Groups.Load();
            dataGridViewGroups.DataSource = db.Groups.ToList();
            dataGridViewGroups.Columns[1].Visible = false;
            dataGridViewGroups.Columns[3].Visible = false;
            dataGridViewGroups.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            List<Group> groups = new List<Group>();
            foreach (DataGridViewRow row in dataGridViewGroups.Rows)
            {
                if (Convert.ToBoolean(((DataGridViewCheckBoxCell)row.Cells["CheckBox"]).Value) == true)
                {
                    groups.Add(db.Groups.Where(g => g.Id == row.Index).FirstOrDefault());
                }
            }
            Controller.Add(textBoxName.Text, comboBoxLector.SelectedItem.ToString(), Convert.ToInt16(textBoxHoursPlan.Text), groups);
            refreshForm(dataGridView, dataGridViewGroups, TextBoxes);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            List<Group> groups = new List<Group>();
            foreach (DataGridViewRow row in dataGridViewGroups.Rows)
            {
                if (Convert.ToBoolean(((DataGridViewCheckBoxCell)row.Cells["CheckBox"]).Value) == true)
                {
                    groups.Add(db.Groups.Where(g => g.Id == row.Index).FirstOrDefault());
                }
            }
            //if ()
            int CurrentRow = dataGridView.SelectedCells[0].RowIndex;
            int valueId = Convert.ToInt32(dataGridView[0, CurrentRow].Value);
            string name = textBoxName.Text;
            string lec = comboBoxLector.SelectedItem.ToString();
            int plan = Convert.ToInt16(textBoxHoursPlan.Text);

            Controller.Edit(textBoxName.Text, comboBoxLector.SelectedItem.ToString(), Convert.ToInt16(textBoxHoursPlan.Text), groups, valueId);
            refreshForm(dataGridView, dataGridViewGroups, TextBoxes);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selectedId = dataGridView.SelectedCells[0].RowIndex;
            int rowId = Convert.ToInt32(dataGridView[0, selectedId].Value);
            Controller.DeleteByIndex(rowId);
            refreshForm(dataGridView, dataGridViewGroups, TextBoxes);
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CurrentRow = dataGridView.SelectedCells[0].RowIndex;
            string nameId1 = dataGridView[1, CurrentRow].Value.ToString();
            string nameId2 = dataGridView[2, CurrentRow].Value.ToString();
            string nameId3 = dataGridView[3, CurrentRow].Value.ToString();
            int nameId4 = 0;
            //string[] groups = dataGridView[3, CurrentRow].Value.ToString().Split(',');
            //List<int> groupsInds = new List<int>();
            //foreach (string group in groups)
            //{
            //    var gr = db.Groups.Where(g => g.Name == group);
            //    groupsInds.Add((int)db.Groups.Local.IndexOf((Group)gr));
            //}
            //foreach (int index in groupsInds)
            //{
            //    dataGridView.Rows[index].Cells[0].Value = CheckBox.;
            //}
            string selectedLector = dataGridView[3, CurrentRow].Value.ToString();
            for (int i = 0; i < comboBoxLector.Items.Count; i++)
            {
                if (comboBoxLector.Items[i].ToString() == selectedLector)
                {
                    nameId4 = i;
                }
            }

            textBoxName.Text = nameId1;
            textBoxHoursPlan.Text = nameId3;
            comboBoxLector.SelectedIndex = nameId4;
        }
    }
}
