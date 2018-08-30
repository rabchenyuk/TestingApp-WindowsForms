using DBLibrary.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;

namespace DBLibrary.EF.Context
{
    public class MyContextInitializer : DropCreateDatabaseIfModelChanges<TestingAppEntities>
    {
        protected override void Seed(TestingAppEntities db)
        {
            using (db = new TestingAppEntities())
            {
                try
                {
                    User u1 = new User
                    {
                        Id = 1,
                        FirstName = "test",
                        LastName = "Test",
                        Email = "test@gmail.com",
                        Login = "admin",
                        Password = "111"
                    };

                    User u2 = new User
                    {
                        Id = 2,
                        FirstName = "John",
                        LastName = "Wild",
                        Email = "john5wild@gmail.com",
                        Login = "wild",
                        Password = "555"
                    };
                    db.Users.AddRange(new List<User> { u1, u2 });

                    Category c = new Category { Id = 1, TestName = "SQL" };
                    db.Categories.Add(c);

                    Question q1 = new Question { Id = 1, Text = "Що таке INSERT?", CategoryId = 1 };
                    Question q2 = new Question { Id = 2, Text = "Що таке SELECT?", CategoryId = 1 };
                    Question q3 = new Question { Id = 3, Text = "Що таке DELETE?", CategoryId = 1 };
                    db.Questions.AddRange(new List<Question> { q1, q2, q3 });

                    Answer a1 = new Answer { Text = "Оператор, який додає дані в таблицю.", IsTrue = true, QuestionId = 1 };
                    Answer a2 = new Answer { Text = "Оператор, який cтворює таблиці в базі даних", IsTrue = false, QuestionId = 1 };
                    Answer a3 = new Answer { Text = "Оператор вибірки даних ", IsTrue = true, QuestionId = 2 };
                    Answer a4 = new Answer { Text = "Обирає базу даних", IsTrue = false, QuestionId = 2 };
                    Answer a5 = new Answer { Text = "Оператор видалення даних", IsTrue = true, QuestionId = 3 };
                    Answer a6 = new Answer { Text = "Видаляє акаунт користувача MS SQL Management Studio", IsTrue = false, QuestionId = 3 };
                    db.Answers.AddRange(new List<Answer> { a1, a2, a3, a4, a5, a6 });

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
