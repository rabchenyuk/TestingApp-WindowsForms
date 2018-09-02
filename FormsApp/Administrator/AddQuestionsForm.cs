using DBLibrary.EF.Context;
using System;
using System.Linq;
using System.Windows.Forms;
using DBLibrary.EF.Models;
using System.Data.Entity;

namespace FormsApp.Administrator
{
    public partial class AddQuestionsForm : Form
    {
        private bool radio = false;
        private bool radio1_checked = false;
        private bool radio2_checked = false;

        public AddQuestionsForm()
        {
            InitializeComponent();
        }

        private void AddTestForm_Load(object sender, EventArgs e)
        {
            using (TestingAppEntities context = new TestingAppEntities())
            {
                var test = context.Categories.ToList();
                selectList.DataSource = test;
                selectList.DisplayMember = "TestName";
                selectList.ValueMember = "Id";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int curr_select_id = Convert.ToInt32(selectList.SelectedItem.ToString());
            
            if(textBoxQuestion.Text == string.Empty || textBoxAnswer.Text == string.Empty)
            {
                MessageBox.Show("Заповніть всі поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        Question q = new Question
                        {
                            Text = textBoxQuestion.Text,
                            CategoryId = curr_select_id
                        };

                        int id = q.Id;

                        if (radioButton1.Checked)
                        {
                            radio = true;
                        }

                        Answer a = new Answer
                        {
                            Text = textBoxAnswer.Text,
                            IsTrue = radio,
                            QuestionId = q.Id
                        };

                        context.Questions.Add(q);
                        context.Answers.Add(a);
                        context.SaveChanges();

                        MessageBox.Show("Додано");
                        
                        textBoxQuestion.Text = string.Empty;
                        textBoxAnswer.Text = string.Empty;

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
    }
}
