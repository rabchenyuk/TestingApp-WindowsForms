using System;
using System.Windows.Forms;
using DBLibrary.EF.Context;
using System.Linq;
using DBLibrary.EF.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;

namespace FormsApp.Test
{
    public partial class TestingProcessForm : Form
    {
        private User user;

        /// <summary>
        /// id of current category
        /// </summary>
        private int selected_id;

        /// <summary>
        /// contains all answers for selected category
        /// </summary>
        private List<Answer> listAnswers;

        private int page_load_counter = 1;
        private int question_count;
        private Button btnNext = new Button();
        private Button btnBack = new Button();

        /// <summary>
        /// This collection is used to check what radiobutton is checked, and for removing flag from old radio to new
        /// </summary>
        private List<string> radio_text = new List<string>();

        /// <summary>
        /// This collection is used to sum final result of true/false answers
        /// </summary>
        private List<bool> radio_bool = new List<bool>();

        public TestingProcessForm(int _selected_id, User _user)
        {
            InitializeComponent();
            selected_id = _selected_id;
            user = _user;
        }

        private void TestingProcessForm_Load(object sender, EventArgs e)
        {
            using (TestingAppEntities context = new TestingAppEntities())
            {
                var question = context.Questions.Include(q => q.Answers).Where(q => q.CategoryId == selected_id).ToList();
                question_count = question.Count;

                listAnswers = new List<Answer>();
                foreach (var itemQ in question)
                {
                    if (itemQ.Answers == null) return;

                    foreach (var itemA in itemQ.Answers)
                    {
                        listAnswers.Add(itemA);
                    }
                }

                var current_answers = listAnswers.Where(l => l.QuestionId == question[0].Id).Select(q => new { Text = q.Text, Id = q.Id, IsTrue = q.IsTrue }).ToArray();

                int count_answers = 0;

                foreach (var item in current_answers)
                {
                    count_answers++;
                }

                Label label = new Label();
                label.Text = $"Питання {page_load_counter} з {question_count}";
                flowLayoutPanel1.Controls.Add(label);

                GroupBox gb = new GroupBox();
                gb.Size = new Size(480, 250);
                gb.Text = question[0].Text;

                RadioButton[] rb = new RadioButton[count_answers];

                int top = 30;
                for (int i = 0; i < count_answers; i++)
                {
                    rb[i] = new RadioButton();
                    if(i >= 1)
                    {
                        top += 30;
                    }
                    rb[i].Location = new Point(15, top);
                    rb[i].AutoSize = true;
                    rb[i].Text = current_answers[i].Text;
                    rb[i].Tag = current_answers[i].IsTrue;
                    rb[i].CheckedChanged += RadioChecked;

                    gb.Controls.Add(rb[i]);
                }

                flowLayoutPanel1.Controls.Add(gb);

                btnNext.Text = "Далі";
                btnNext.Click += BtnNext_Click;
                btnBack.Text = "Назад";
                btnBack.Click += BtnBack_Click;
                if (page_load_counter == 1)
                {
                    btnBack.Enabled = false;
                }

                flowLayoutPanel1.Controls.AddRange(new Button[] { btnBack, btnNext });
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            page_load_counter--;

            using (TestingAppEntities context = new TestingAppEntities())
            {
                flowLayoutPanel1.Controls.Clear();

                var question = context.Questions.Include(q => q.Answers).Where(q => q.CategoryId == selected_id).ToList();
                var current_answers = listAnswers.Where(l => l.QuestionId == question[page_load_counter - 1].Id).Select(q => new { Text = q.Text, Id = q.Id, IsTrue = q.IsTrue }).ToArray();

                int count_answers = 0;

                foreach (var item in current_answers)
                {
                    count_answers++;
                }

                Label label = new Label();
                label.Text = $"Питання {page_load_counter} з {question.Count}";
                flowLayoutPanel1.Controls.Add(label);

                GroupBox gb = new GroupBox();
                gb.Text = question[page_load_counter - 1].Text;
                gb.Size = new Size(480, 250);

                RadioButton[] rb = new RadioButton[count_answers];

                int top = 30;
                for (int i = 0; i < count_answers; i++)
                {
                    rb[i] = new RadioButton();
                    if (i >= 1)
                    {
                        top += 30;
                    }
                    rb[i].Location = new Point(15, top);
                    rb[i].AutoSize = true;
                    rb[i].Text = current_answers[i].Text;
                    rb[i].Tag = current_answers[i].IsTrue;

                    foreach (var item in radio_text)
                    {
                        if (item == rb[i].Text)
                        {
                            rb[i].Checked = true;
                        }
                    }

                    rb[i].CheckedChanged += RadioChecked;
                    gb.Controls.Add(rb[i]);
                }

                flowLayoutPanel1.Controls.Add(gb);

                btnNext.Text = "Далі";
                btnBack.Text = "Назад";

                if (page_load_counter == 1)
                {
                    btnBack.Enabled = false;
                    btnNext.Enabled = true;
                }
                else
                {
                    btnBack.Enabled = true;
                    btnNext.Enabled = true;
                }

                flowLayoutPanel1.Controls.AddRange(new Button[] { btnBack, btnNext });
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            page_load_counter++;

            using (TestingAppEntities context = new TestingAppEntities())
            {
                flowLayoutPanel1.Controls.Clear();

                var question = context.Questions.Include(q => q.Answers).Where(q => q.CategoryId == selected_id).ToList();
                var current_answers = listAnswers.Where(a => a.QuestionId == question[page_load_counter - 1].Id).ToArray();

                int count_answers = 0;

                foreach (var item in current_answers)
                {
                    count_answers++;
                }

                Label label = new Label();
                label.Text = $"Питання {page_load_counter} з {question.Count}";
                flowLayoutPanel1.Controls.Add(label);

                GroupBox gb = new GroupBox();
                gb.Text = question[page_load_counter - 1].Text;
                gb.Size = new Size(480, 250);

                RadioButton[] rb = new RadioButton[count_answers];

                int top = 30;
                for (int i = 0; i < count_answers; i++)
                {

                    rb[i] = new RadioButton();
                    if (i >= 1)
                    {
                        top += 30;
                    }
                    rb[i].Location = new Point(15, top);
                    rb[i].AutoSize = true;
                    rb[i].Text = current_answers[i].Text;
                    rb[i].Tag = current_answers[i].IsTrue;

                    foreach (var item in radio_text)
                    {
                        if (item == rb[i].Text)
                        {
                            rb[i].Checked = true;
                        }
                    }

                    rb[i].CheckedChanged += RadioChecked;

                    gb.Controls.Add(rb[i]);
                }

                flowLayoutPanel1.Controls.Add(gb);

                btnNext.Text = "Далі";
                if(page_load_counter == question_count)
                {
                    btnNext.Enabled = false;
                }
                btnBack.Text = "Назад";
                btnBack.Enabled = true;

                flowLayoutPanel1.Controls.AddRange(new Button[] { btnBack, btnNext });

                Button btnEnd = new Button();
                if (page_load_counter == question_count)
                {
                    btnEnd.Text = "Завершити";
                    flowLayoutPanel1.Controls.Add(btnEnd);
                }

                btnEnd.Click += EndTestClick;
            }
        }

        private void RadioChecked(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            if (radio.Checked)
            {
                radio_text.Add(radio.Text);
                radio_bool.Add((bool)radio.Tag);
            }
            if(!radio.Checked)
            {
                radio_text.Remove(radio.Text);
                radio_bool.Remove((bool)radio.Tag);
            }
        }

        private void EndTestClick(object sender, EventArgs e)
        {
            int right_answers = 0;
            int wrong_answers = 0;
            
            foreach (var rb in radio_bool)
            {
                if (rb == true)
                {
                    right_answers++;
                }
                else
                {
                    wrong_answers++;
                }
            }

            using (TestingAppEntities context = new TestingAppEntities())
            {
                try
                {
                    context.Results.Add(new Result
                    {
                        CountRightAnswers = right_answers,
                        CountWrongAnswers = wrong_answers,
                        CategoryId = selected_id,
                        UserId = user.Id
                    });

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            MessageBox.Show($"Шановний {user.Login}!\n Ви закінчили проходження тесту!\n\n Правильних відповідей: {right_answers}. Неправильних: {wrong_answers}");

            this.Close();
        }
    }
}
