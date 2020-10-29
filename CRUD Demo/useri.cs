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

        public useri()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void handler_btnUpdate(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Companie;Integrated Security=True");
            sda = new SqlDataAdapter("");


        }

        private void handler_btnView(object sender, EventArgs e)
        {

        }

        private void handler_btnAdd(object sender, EventArgs e)
        {


        }
    }
}
