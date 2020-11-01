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
        SqlCommand cmd;
        SqlCommandBuilder scb;
        DataTable dt;
        SqlConnection con = new SqlConnection("Data Source=VALY-DESKTOP\\SQLEXPRESS;Initial Catalog=Companie;Integrated Security=True");
        int ID = 0;



        private void creareConexiune()
        {

        }


        public useri()
        {
            InitializeComponent();
            display_data();

        }

        public void Form1_Load(object sender, EventArgs e)
        {
        }

        private void handler_btnUpdate(object sender, EventArgs e)
        {
            if (txtNume.Text != "" && txtPrenume.Text != "" && txtEmail.Text != "")
            {
                string string_update = "UPDATE Persoane SET nume=@nume,prenume=@prenume,email=@email WHERE Id=@id";
                con.Open();
                cmd = new SqlCommand(string_update, con);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@nume", txtNume.Text);
                cmd.Parameters.AddWithValue("@prenume", txtPrenume.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datele au fost actualizate cu succes!");
                con.Close();
                display_data();
                clearData();
            }
            else
            {
                MessageBox.Show("Va rugam selectati un ser pentru actualizare!");
            }

        }

        private void handler_btnView(object sender, EventArgs e)
        {
            display_data();
        }

        //Insert Data  
        private void handler_btnAdd(object sender, EventArgs e)
        {
            if (txtNume.Text != "" && txtPrenume.Text != "" && txtEmail.Text != "")
            {
                con.Open();
                string insert_query = "INSERT INTO Persoane (nume,prenume,email) VALUES (@nume,@prenume,@email)";
                cmd = new SqlCommand(insert_query, con);
                cmd.Parameters.AddWithValue("@nume", txtNume.Text);
                cmd.Parameters.AddWithValue("@prenume", txtPrenume.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Userul a fost adaugat cu succes!");
                display_data();
                clearData();
            }
            else { 
                MessageBox.Show("Va rugam introduceti date!");           
            }

        }

        //Delete Record 
        private void handler_btnDelete(object sender, EventArgs e)
        {if (ID != 0)
            {
                cmd = new SqlCommand("DELETE Persoane WHERE ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Userul a fost sters cu succes!");
                display_data();
                clearData();
            }else
            {
                MessageBox.Show("Va rog selectati un user pentru stergere!");
            }
        }

        //Display Data in DataGridView 
        public void display_data()
        {
            string select_string = "SELECT Id,Nume,Prenume, Email FROM Persoane";
            con.Open();
            cmd = new SqlCommand(select_string, con);
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            txtNume.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtPrenume.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }

        //Clear Data 
        private void btnReset_Click(object sender, EventArgs e)
        {
            
            txtEmail.Clear();
            txtNume.Clear();
            txtPrenume.Clear();

            ID = 0;
        }

        //Clear Data 
        private void clearData()
        {
            
            txtEmail.Text="";
            txtNume.Text="";
            txtPrenume.Text="";

            ID = 0;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtNume.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrenume.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }
    }
}
