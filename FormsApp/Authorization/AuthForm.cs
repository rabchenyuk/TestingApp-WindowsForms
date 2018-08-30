using System;
using System.Linq;
using System.Windows.Forms;
using DBLibrary.EF.Context;
using System.Data.Entity;
using FormsApp.Administrator;
using FormsApp.Test;

namespace FormsApp.Authorization
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxLogin.Text == string.Empty || textBoxPassword.Text == string.Empty)
            {
                MessageBox.Show("Заповніть всі поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (TestingAppEntities context = new TestingAppEntities())
                {
                    var user = context.Users.FirstOrDefault(u => u.Login == textBoxLogin.Text && u.Password == textBoxPassword.Text);

                    if (user != null)
                    {
                        MessageBox.Show("Привіт " + user.Login, "Вітаємо", MessageBoxButtons.OK);
                        
                        if(user.Login == "admin")
                        {
                            new AdminForm().Show();
                            this.Hide();
                        }
                        else
                        {
                            new StartTestForm(user).Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильний логін/пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxLogin.Text = string.Empty;
                        textBoxPassword.Text = string.Empty;
                    }
                }
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            new RegForm().ShowDialog();
        }
    }
}
