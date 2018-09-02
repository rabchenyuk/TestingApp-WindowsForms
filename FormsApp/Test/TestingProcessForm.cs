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
        private int selected_id;
        private Button btn;
        private RadioButton[] rb;
        private List<Answer> listAnswers;

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
                var question_text_id = question.Select(q => new { Text = q.Text, Id = q.Id }).ToArray();

                listAnswers = new List<Answer>();
                foreach (var itemQ in question)
                {
                    if (itemQ.Answers == null) return;

                    foreach (var itemA in itemQ.Answers)
                    {
                        listAnswers.Add(itemA);
                    }
                }

                GroupBox[] gb = new GroupBox[question.Count];

                rb = new RadioButton[listAnswers.Count];

                FlowLayoutPanel fp = new FlowLayoutPanel();
                fp.Size = new Size(450, 30);
                fp.Dock = DockStyle.Bottom;
                fp.FlowDirection = FlowDirection.LeftToRight;

                btn = new Button();
                btn.Text = "Завершити";

                fp.Controls.Add(btn);

                for (int i = 0; i < question.Count; i++)
                {
                    int count = 0;
                    gb[i] = new GroupBox();
                    gb[i].Tag = question_text_id[i].Id;
                    gb[i].Margin = new Padding(8);
                    gb[i].Text = question_text_id[i].Text;
                    gb[i].AutoSize = true;
                    gb[i].AutoSizeMode = AutoSizeMode.GrowAndShrink;

                    int top = 30;
                    for (int j = 0; j < listAnswers.Count; j++)
                    {
                        rb[j] = new RadioButton();
                        rb[j].Text = listAnswers[j].Text;
                        rb[j].Tag = listAnswers[j].IsTrue;
                        rb[j].AutoSize = true;
                        rb[j].Checked = false;

                        if (listAnswers[j].QuestionId == question_text_id[i].Id)
                        {
                            count++;
                            if (count > 1)
                            {
                                top += 30;
                            }
                            rb[j].Location = new Point(15, top);
                            gb[i].Controls.Add(rb[j]);
                            
                        }
                    }

                    flowLayoutPanel1.Controls.Add(gb[i]);
                }

                flowLayoutPanel1.Controls.Add(fp);

                btn.Click += new EventHandler(EndTestClick);
            }
        }

        private void EndTestClick(object sender, EventArgs e)
        {
            int right_answers = 0;
            int wrong_answers = 0;

            foreach (var gb in flowLayoutPanel1.Controls)
            {
                if(gb is GroupBox)
                {
                    GroupBox currGB = gb as GroupBox;
                    bool answerIs = false;
                    foreach (var r in currGB.Controls)
                    {
                        if(r is RadioButton)
                        {
                            RadioButton radio = r as RadioButton;
                            if((bool)radio.Tag)
                            {
                                if (radio.Checked)
                                {
                                    answerIs = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if(answerIs)
                    {
                        right_answers++;
                    }
                    else
                    {
                        wrong_answers++;
                    }
                }
                
            }

            MessageBox.Show($"Шановний {user.Login}!\n Ви закінчили проходження тесту!\n\n Правильних відповідей: {right_answers}. Неправильних: {wrong_answers}");

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

            this.Close();
        }
    }
}
