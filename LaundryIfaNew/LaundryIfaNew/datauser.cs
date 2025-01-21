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
                    SqlCommand cmd = new SqlCommand("insert into [User] (namauser, email, password) values (@namauser, @email, @password)", conn);
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@namauser", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@password", Properti.enkripsi(textBox3.Text));
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
            }
            finally
            {
                conn.Close(); 
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
    }
}
