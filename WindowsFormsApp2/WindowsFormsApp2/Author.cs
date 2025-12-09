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

namespace WindowsFormsApp2
{
    public partial class Author : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-LU4U2FNQ;Initial Catalog=Digital_Library;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        SqlDataAdapter DA;
        DataTable DT = new DataTable();
        SqlCommandBuilder cmd;

        public Author()
        {
            InitializeComponent();
            DA = new SqlDataAdapter("Select * from Author" , con);
            DA.Fill(DT);
            dataGridView1.DataSource = DT;
        }

        private void Author_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digital_LibraryDataSet.Author' table. You can move, or remove it, as needed.
            this.authorTableAdapter.Fill(this.digital_LibraryDataSet.Author);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommandBuilder(DA);
            DA.Update(DT);
            MessageBox.Show("Changes Saved" , "Saved!" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }
    }
}
