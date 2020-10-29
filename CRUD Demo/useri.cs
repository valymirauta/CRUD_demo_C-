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

namespace CRUD_Demo
{
    public partial class useri : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        SqlConnection con = new SqlConnection("Data Source=VALY-DESKTOP\\SQLEXPRESS;Initial Catalog=Companie;Integrated Security=True");


        public useri()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void handler_btnUpdate(object sender, EventArgs e)
        {
            


        }

        private void handler_btnView(object sender, EventArgs e)
        {

        }

        private void handler_btnAdd(object sender, EventArgs e)
        {
            con.Open();
            string insert_query = "INSERT INTO Persoane ( nume,prenume,email) VALUES (@nume,@prenume,@email) SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(insert_query, con);
            cmd.Parameters.AddWithValue("@nume", txtNume.Text);
            cmd.Parameters.AddWithValue("@prenume", txtPrenume.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            display_data();

            MessageBox.Show("Userul a fost adaugat cu succes!");

        }

        private void handler_btnDelete(object sender, EventArgs e)
        {

        }

        public void display_data()
        {
            string select_string = "SELECT nume,prenume, email FROM Persoane";
            con.Open();
            SqlCommand cmd = new SqlCommand(select_string, con);
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
