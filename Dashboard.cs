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
    public partial class Dashboard : Form
    {
        private object uC_addItems1;

        public Dashboard()
        {
            InitializeComponent();
            BindDataFoodItem();
        }

        public Dashboard(string user)
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l1 = new Login();
            this.Hide();
            l1.Show();
        }

        private void BindDataFoodItem()
        {
            Connection.sqlCon.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Food", Connection.sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Connection.sqlCon.Close();
            dataGridViewFood.DataSource = dt;
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            String name = nameBox.Text;
            MessageBox.Show(name + " Ordered");
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            Connection.sqlCon.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Food(foodID, foodName, foodPrice) VALUES (@id, @name, @price)", Connection.sqlCon);
            cmd.Parameters.AddWithValue("@id", idBox.Text);
            cmd.Parameters.AddWithValue("@name", nameBox.Text);
            cmd.Parameters.AddWithValue("@price", priceBox.Text);
            cmd.ExecuteNonQuery();
            Connection.sqlCon.Close();
            idBox.Text = "";
            nameBox.Text = "";
            priceBox.Text = "";
            MessageBox.Show("Successfully Added");
            BindDataFoodItem();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            Connection.sqlCon.Open();

            SqlCommand cmd = new SqlCommand("DELETE from Food WHERE foodID=@id", Connection.sqlCon);
            cmd.Parameters.AddWithValue("@id", int.Parse(idBox.Text));
            cmd.ExecuteNonQuery();
            Connection.sqlCon.Close();
            idBox.Text = "";
            nameBox.Text = "";
            priceBox.Text = "";
            MessageBox.Show("Successfully Deleted");
            BindDataFoodItem();
        }
    }
}
