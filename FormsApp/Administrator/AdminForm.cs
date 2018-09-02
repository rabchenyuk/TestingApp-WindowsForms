using DBLibrary.EF.Context;
using System;
using System.Windows.Forms;
using System.Linq;
using DBLibrary.EF.Models;
using System.Data.Entity;

namespace FormsApp.Administrator
{
    public partial class AdminForm : Form
    {
        private int select_id;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            using (TestingAppEntities context = new TestingAppEntities())
            {
                var test = context.Categories.ToList();
                selectList.DataSource = test;
                selectList.DisplayMember = "TestName";
            }
        }

        private void selectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            select_id = Convert.ToInt32(selectList.SelectedItem.ToString());

            using (TestingAppEntities context = new TestingAppEntities())
            {
                context.Questions.Load();

                foreach (var item in context.Questions.Local.Where(i => i.CategoryId == select_id).ToList())
                {
                    object[] row = { item.Id, item.Text };
                    dataGridView1.Rows.Add(row);
                    dataGridView1.Refresh();
                }

                int curr_id = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                dataGridView2.Rows.Clear();
                foreach (var item in context.Answers.Where(i => i.QuestionId == curr_id))
                {
                    object[] row = { item.Id, item.Text };
                    dataGridView2.Rows.Add(row);
                    dataGridView2.Refresh();
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            select_id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

            dataGridView2.Rows.Clear();
            using (TestingAppEntities context = new TestingAppEntities())
            {
                context.Answers.Load();

                foreach (var item in context.Answers.Local.Where(i => i.QuestionId == select_id))
                {
                    object[] row = { item.Id, item.Text };
                    dataGridView2.Rows.Add(row);
                }
            }
        }

        private void buttonAddTest_Click(object sender, EventArgs e)
        {
            new AddQuestionsForm().ShowDialog();
        }

        private void selectList_MouseClick(object sender, MouseEventArgs e)
        {
            using (TestingAppEntities context = new TestingAppEntities())
            {
                context.Categories.Load();
                var test = context.Categories.Local;
                selectList.DataSource = test;
            }
        }

        private void buttonCreateTest_Click(object sender, EventArgs e)
        {
            new CreateTestForm().ShowDialog();
        }

        private void buttonAddAnswer_Click(object sender, EventArgs e)
        {
            new AddAnswersForm().ShowDialog();
        }
    }
}
