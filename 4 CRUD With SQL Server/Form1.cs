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

        private void clear()
        {
            tbKodeBarang.Clear();
            tbNama.Clear();
            tbHrgBeli.Text = "0";
            tbHrgJual.Text = "0";
            tbJumlah.Text = "0";
            tbSatuan.Clear();
        }

        private void showData()
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

        private void createData()
        {
            if (tbKodeBarang.Text.Trim() == "" || tbNama.Text.Trim() == "" || tbHrgBeli.Text.Trim() == "" || tbHrgJual.Text.Trim() == "" || tbJumlah.Text.Trim() == "" || tbSatuan.Text.Trim() == "")
            {
                MessageBox.Show("Data Harus Lengkap!");
            }
            else
            {
                SqlConnection conn = connection.GetConn();
                try
                {
                    conn.Open();
                    sc = new SqlCommand("INSERT INTO TBL_BARANG VALUES('" + tbKodeBarang.Text + "', '" + tbNama.Text + "', '" + tbHrgBeli.Text + "', '" + tbHrgJual.Text + "', '" + tbJumlah.Text + "', '" + tbSatuan.Text + "')", conn);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Ditambahkan!");
                    showData();
                    clear();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void updateData()
        {
            if (tbKodeBarang.Text.Trim() == "" || tbNama.Text.Trim() == "" || tbHrgBeli.Text.Trim() == "" || tbHrgJual.Text.Trim() == "" || tbJumlah.Text.Trim() == "" || tbSatuan.Text.Trim() == "")
            {
                MessageBox.Show("Data Harus Lengkap!");
            }
            else
            {
                SqlConnection conn = connection.GetConn();
                try
                {
                    conn.Open();
                    sc = new SqlCommand("UPDATE TBL_BARANG SET NamaBarang = '" + tbNama.Text + "', HargaBeli = '" + tbHrgBeli.Text + "', HargaJual = '" + tbHrgJual.Text + "', JumlahBarang = '" + tbJumlah.Text + "', SatuanBarang = '" + tbSatuan.Text + "' WHERE KodeBarang = '" + tbKodeBarang.Text + "'", conn);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Diupdate!");
                    showData();
                    clear();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showData();
            clear();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            createData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                tbKodeBarang.Text = row.Cells["KodeBarang"].Value.ToString();
                tbNama.Text = row.Cells["NamaBarang"].Value.ToString();
                tbHrgBeli.Text = row.Cells["HargaBeli"].Value.ToString();
                tbHrgJual.Text = row.Cells["HargaJual"].Value.ToString();
                tbJumlah.Text = row.Cells["JumlahBarang"].Value.ToString();
                tbSatuan.Text = row.Cells["SatuanBarang"].Value.ToString();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateData();
        }
    }
}
