using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaundryIfaNew
{
    public partial class datapetugas : Form
    {
        public datapetugas()
        {
            InitializeComponent();
            tampildata();
        }

        SqlConnection conn = Properti.conn;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow.Cells;
            textBox1.Text = row["namapetugas"].Value.ToString();
            textBox2.Text = row["nomortelepon"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properti.validasi(this.Controls))
                {
                    MessageBox.Show("Inputan tidak boleh kosong!");
                }
                else
                {
                    var row = dataGridView1.CurrentRow.Cells;
                    int kodepetugas = Convert.ToInt32(row["kodepetugas"].Value.ToString());
                    SqlCommand cmd = new SqlCommand("delete from [petugasantar] where kodepetugas = @kodepetugas", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@kodepetugas", kodepetugas);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus!");
                    clear();
                    tampildata();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properti.validasi(this.Controls))
                {
                    MessageBox.Show("Inputan tidak boleh kosong!");
                }
                else
                {
                    var row = dataGridView1.CurrentRow.Cells;
                    int kodepetugas = Convert.ToInt32(row["kodepetugas"].Value.ToString());
                    SqlCommand cmd = new SqlCommand("update [petugasantar] set namapetugas = @namapetugas, nomortelepon = @nomortelepon where kodepetugas = @kodepetugas", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@kodepetugas", kodepetugas);
                    cmd.Parameters.AddWithValue("@namapetugas", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nomortelepon", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diubah!");
                    clear();
                    tampildata();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properti.validasi(this.Controls))
                {
                    MessageBox.Show("Inputan tidak boleh kosong!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into [petugasantar] values (@namapetugas, @nomortelepon)", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@namapetugas", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nomortelepon", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambah!");
                    clear();
                    tampildata();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void tampildata()
        {
            SqlCommand cmd = new SqlCommand("select * from [PetugasAntar]", conn);
            conn.Open();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
