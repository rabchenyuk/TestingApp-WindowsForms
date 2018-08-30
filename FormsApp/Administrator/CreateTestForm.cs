using System;
using System.Windows.Forms;
using DBLibrary.EF.Context;
using DBLibrary.EF.Models;
using System.Data.Entity;
using System.Linq;

namespace FormsApp.Administrator
{
    public partial class CreateTestForm : Form
    {
        private bool radio = false;
        private bool radio1_checked = false;
        private bool radio2_checked = false;

        public CreateTestForm()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (textBoxTestName.Text == string.Empty || textBoxQuestion.Text == string.Empty ||
                textBoxAnswer.Text == string.Empty)
            {
                MessageBox.Show("Всі поля мають бути заповнені", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!radio1_checked && !radio2_checked)
            {
                MessageBox.Show("Оберіть варіант відповіді", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (TestingAppEntities context = new TestingAppEntities())
                {
                    context.Categories.ToList();
                    var category = context.Categories.FirstOrDefault(cat => cat.TestName == textBoxTestName.Text);
                    if (category != null)
                    {
                        MessageBox.Show("Така категорія вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Category c = new Category
                        {
                            TestName = textBoxTestName.Text
                        };

                        Question q = new Question
                        {
                            Text = textBoxQuestion.Text,
                            CategoryId = c.Id
                        };

                        if (radioButton1.Text == "Правильна")
                        {
                            radio = true;
                        }
                        Answer a = new Answer
                        {
                            Text = textBoxAnswer.Text,
                            IsTrue = radio,
                            QuestionId = q.Id
                        };

                        try
                        {
                            context.Categories.Add(c);
                            context.Questions.Add(q);
                            context.Answers.Add(a);

                            context.SaveChanges();
                            MessageBox.Show(c.TestName + " створено");

                            textBoxTestName.Text = string.Empty;
                            textBoxQuestion.Text = string.Empty;
                            textBoxAnswer.Text = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
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
