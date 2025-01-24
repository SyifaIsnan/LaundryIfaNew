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
    public partial class biayatambahan : Form
    {
        public biayatambahan()
        {
            InitializeComponent();
            tampildata();
        }

        private void tampildata()
        {
            SqlCommand cmd = new SqlCommand("select * from [BiayaTambahan]", conn);
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

        SqlConnection conn = Properti.conn;

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
                    SqlCommand cmd = new SqlCommand("insert into [Biayatambahan] (keterangan, biaya) values (@keterangan, @biaya)", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@keterangan", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@biaya", textBox1.Text);   
                    cmd.ExecuteNonQuery();
                    conn.Close();
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

        private void clear()
        {
            richTextBox1.Text = "";
            textBox1.Text = "";
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
                    int kodebiaya = Convert.ToInt32(row["kodebiaya"].Value.ToString());
                    SqlCommand cmd = new SqlCommand("update [Biayatambahan] set keterangan = @keterangan, biaya = @biaya where kodebiaya = @kodebiaya", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@kodebiaya", kodebiaya);
                    cmd.Parameters.AddWithValue("@keterangan", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@biaya", textBox1.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            using (var konek = Properti.konek())
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
                        int kodebiaya = Convert.ToInt32(row["kodebiaya"].Value.ToString());
                        SqlCommand cmd = new SqlCommand("delete from [Biayatambahan] where kodebiaya = @kodebiaya", conn);
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        cmd.Parameters.AddWithValue("@kodebiaya", kodebiaya);
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow.Cells;
            richTextBox1.Text = row["keterangan"].Value.ToString();
            textBox1.Text = row["biaya"].Value.ToString();
        }
    }
}
