using DBLibrary.EF.Context;
using DBLibrary.EF.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace FormsApp.Authorization
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            if(textBoxFName.Text == string.Empty || textBoxLName.Text == string.Empty || textBoxEmail.Text == string.Empty ||
                textBoxLogin.Text == string.Empty || textBoxPassword.Text == string.Empty)
            {
                MessageBox.Show("Заповніть всі поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (TestingAppEntities context = new TestingAppEntities())
                {
                    context.Users.Load();

                    var user = context.Users.FirstOrDefault(u => u.Login == textBoxLogin.Text && u.Email == textBoxEmail.Text);

                    if(user != null)
                    {
                        MessageBox.Show("Такий користувач вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBoxFName.Text = string.Empty;
                        textBoxLName.Text = string.Empty;
                        textBoxEmail.Text = string.Empty;
                        textBoxLogin.Text = string.Empty;
                        textBoxPassword.Text = string.Empty;
                    }
                    else
                    {
                        try
                        {
                            context.Users.Add(new User
                            {
                                FirstName = textBoxFName.Text,
                                LastName = textBoxLName.Text,
                                Email = textBoxEmail.Text,
                                Login = textBoxLogin.Text,
                                Password = textBoxPassword.Text
                            });

                            context.SaveChanges();

                            MessageBox.Show("Ви успішно зареєструвались", "Вітаємо", MessageBoxButtons.OK);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
