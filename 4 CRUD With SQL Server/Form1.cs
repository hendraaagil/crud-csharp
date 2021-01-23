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

namespace _4_CRUD_With_SQL_Server
{
    public partial class Form1 : Form
    {
        private SqlCommand sc;
        private DataSet ds;
        private SqlDataAdapter sda;

        Connection connection = new Connection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.GetConn();
            try
            {
                conn.Open();
                sc = new SqlCommand("SELECT * FROM TBL_BARANG", conn);
                ds = new DataSet();
                sda = new SqlDataAdapter(sc);
                sda.Fill(ds, "TBL_BARANG");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TBL_BARANG";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
