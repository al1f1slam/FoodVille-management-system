using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Foodville
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (nameBox.Text == "Username")
            {
                nameBox.Text = "";
                nameBox.ForeColor = Color.Black;
            }

        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                nameBox.Text = "Username";
                nameBox.ForeColor = Color.Black;
            }

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (passBox.Text == "Password")
            {
                passBox.Text = "";
                passBox.ForeColor = Color.Black;
            }

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (passBox.Text == "")
            {
                passBox.Text = "Password";
                passBox.ForeColor = Color.Black;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passBox.UseSystemPasswordChar = false;
            }
            else
            {
                passBox.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration r1 = new Registration();
            this.Hide();
            r1.Show();

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard ds = new Dashboard("Guest");
            ds.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.sqlCon.Open();
            string query = "Select * from admin where username='" + nameBox.Text.Trim() + "' and password = '" + passBox.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Connection.sqlCon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            Connection.sqlCon.Close();

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (dtbl.Rows.Count == 1)
                {
                    Dashboard a1 = new Dashboard();
                    this.Hide();
                    a1.Show();
                }

                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
        }
    }
}
