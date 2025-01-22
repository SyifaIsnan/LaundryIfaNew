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
    public partial class datauser : Form
    {
        public datauser()
        {
            InitializeComponent();
            tampildata();
        }

        //untuk mengaitkan koneksi
        SqlConnection conn = Properti.conn;

        //untuk menambahkan data ke dalam database
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properti.validasi(this.Controls))
                {
                    MessageBox.Show("Data yang ingin diinput tidak boleh kosong!");
                } else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [User] VALUES(@namauser,@email,@password)", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@namauser", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@password", Properti.enkripsi(textBox3.Text));
                    //cmd.Parameters.AddWithValue("@password", textBox3.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    tampildata();
                    MessageBox.Show("Data berhasil ditambahkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close() ;
            }
           
        }

        //untuk menghapus
        private void clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        //untuk menampilkan data pada gridview 
        private void tampildata()
        {
            SqlCommand cmd = new SqlCommand("select * from [User]", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        //saat menekan data pada table, data akan masuk ke textbox
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow.Cells;
            textBox1.Text = row["namauser"].Value.ToString();
            textBox2.Text = row["email"].Value.ToString();
            textBox3.Text = row["password"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properti.validasi(this.Controls))
                {
                    MessageBox.Show("Data yang ingin diinput tidak boleh kosong!");
                }
                else
                {
                    var row = dataGridView1.CurrentRow;
                    int kodeuser = Convert.ToInt32(row.Cells["kodeuser"].Value.ToString());
                    SqlCommand cmd = new SqlCommand("update [User] set namauser=@namauser, email=@email, password=@password where kodeuser=@kodeuser", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@kodeuser", kodeuser);
                    cmd.Parameters.AddWithValue("@namauser", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@password", textBox3.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil ditambahkan!");
                    tampildata();
                    clear();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                    MessageBox.Show("Data yang ingin diinput tidak boleh kosong!");
                }
                else
                {
                    var row = dataGridView1.CurrentRow;
                    int kodeuser = Convert.ToInt32(row.Cells["kodeuser"].Value.ToString());
                    SqlCommand cmd = new SqlCommand("delete from [User] where kodeuser = @kodeuser", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@kodeuser", kodeuser);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil dihapus!");
                    tampildata();
                    clear();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close() ;
            }
            
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
