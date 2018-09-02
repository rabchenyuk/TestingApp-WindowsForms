using System;
using System.Windows.Forms;
using DBLibrary.EF.Context;
using System.Linq;
using DBLibrary.EF.Models;

namespace FormsApp.Administrator
{
    public partial class AddAnswersForm : Form
    {
        private bool radio = false;
        private bool radio1_checked = false;
        private bool radio2_checked = false;

        public AddAnswersForm()
        {
            InitializeComponent();
        }

        private void AddAnswersForm_Load(object sender, EventArgs e)
        {
            using (TestingAppEntities context = new TestingAppEntities())
            {
                var category = context.Categories.ToList();
                selectListCategory.DataSource = category;
                selectListCategory.DisplayMember = "TestName";

                var question = context.Questions.Where(q => q.CategoryId == 1).ToList();
                selectListQuestion.DataSource = question;
                selectListQuestion.DisplayMember = "Text";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int curr_select_id = Convert.ToInt32(selectListQuestion.SelectedItem.ToString());

            if (textBoxAnswer.Text == string.Empty)
            {
                MessageBox.Show("Заповніть усі поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!radio1_checked && !radio2_checked)
            {
                MessageBox.Show("Оберіть варіант відповіді", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (TestingAppEntities context = new TestingAppEntities())
                {
                    try
                    {
                        if (radioButton1.Checked)
                        {
                            radio = true;
                        }

                        Answer a = new Answer
                        {
                            QuestionId = curr_select_id,
                            Text = textBoxAnswer.Text,
                            IsTrue = radio,
                        };

                        context.Answers.Add(a);
                        context.SaveChanges();

                        MessageBox.Show("Додано");

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radio1_checked = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radio2_checked = true;
        }

        private void selectListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = Convert.ToInt32(selectListCategory.SelectedItem.ToString());

            using (TestingAppEntities context = new TestingAppEntities())
            {
                var question = context.Questions.Where(q => q.CategoryId == selected_id).ToList();
                selectListQuestion.DataSource = question;
                selectListQuestion.DisplayMember = "Text";
            }
        }
    }
}
