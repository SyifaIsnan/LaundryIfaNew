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
    public partial class datalayanan : Form
    {
        public datalayanan()
        {
            InitializeComponent();
            tampildata();
        }

        SqlConnection conn = Properti.conn;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow.Cells;
            textBox1.Text = row["namalayanan"].Value.ToString();
            textBox2.Text = row["biaya"].Value.ToString();
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
                    int kodelayanan = Convert.ToInt32(row["kodelayanan"].Value.ToString());
                    SqlCommand cmd = new SqlCommand("delete from [Layanan] where kodelayanan = @kodelayanan", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@kodelayanan", kodelayanan);
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
                    int kodelayanan = Convert.ToInt32(row["kodelayanan"].Value.ToString());
                    SqlCommand cmd = new SqlCommand("update [Layanan] set namalayanan = @namalayanan, biaya = @biaya where kodelayanan = @kodelayanan", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@kodelayanan", kodelayanan);
                    cmd.Parameters.AddWithValue("@namalayanan", textBox1.Text);
                    cmd.Parameters.AddWithValue("@biaya", textBox2.Text);
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
                    SqlCommand cmd = new SqlCommand("insert into [Layanan] values (@namalayanan, @biaya)", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@namalayanan", textBox1.Text);
                    cmd.Parameters.AddWithValue("@biaya", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambahkan!");
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
            SqlCommand cmd = new SqlCommand("select * from [Layanan]", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["biaya"].DefaultCellStyle.Format = "C";
            dataGridView1.Columns["biaya"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("id-ID");
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
