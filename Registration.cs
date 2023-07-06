using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Foodville
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l1 = new Login();
            this.Hide();
            l1.Show();
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
            Connection.sqlCon.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO admin(username, password) VALUES (@name, @pass)", Connection.sqlCon);
            cmd.Parameters.AddWithValue("@name", nameBox.Text);
            cmd.Parameters.AddWithValue("@pass", passBox.Text);
            cmd.ExecuteNonQuery();
            Connection.sqlCon.Close();
            MessageBox.Show("Successfully Inserted");
        }
    }
}
