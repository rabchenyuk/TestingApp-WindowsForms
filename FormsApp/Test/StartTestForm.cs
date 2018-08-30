using System.Windows.Forms;
using DBLibrary.EF.Context;
using System.Linq;
using System;
using DBLibrary.EF.Models;

namespace FormsApp.Test
{
    public partial class StartTestForm : Form
    {
        private int select_id;
        private User user;

        public StartTestForm(User _user)
        {
            InitializeComponent();
            user = _user;
        }

        private void StartTestForm_Load(object sender, EventArgs e)
        {
            using (TestingAppEntities context = new TestingAppEntities())
            {
                var test = context.Categories.ToList();
                selectList.DataSource = test;
                selectList.DisplayMember = "TestName";
            }
        }

        private void buttonPassTest_Click(object sender, EventArgs e)
        {
            select_id = Convert.ToInt32(selectList.SelectedItem.ToString());
            new TestingProcessForm(select_id, user).ShowDialog();
        }

        private void StartTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
