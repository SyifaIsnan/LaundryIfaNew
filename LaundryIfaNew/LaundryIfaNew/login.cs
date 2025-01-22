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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

        }

        SqlConnection conn = Properti.conn;


        //untuk mengontrol visibilitas karakter textbox2 (bagian password)
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        //untuk proses login ke halaman utama
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
                    var mess = MessageBox.Show("Apakah data yang ingin diinput sudah benar?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (mess == DialogResult.Yes) {
                        SqlCommand cmd = new SqlCommand("select * from [User] where email = @email and password = @password", conn);
                        conn.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@email", textBox1.Text);
                        cmd.Parameters.AddWithValue("@password", Properti.enkripsi(textBox2.Text));
                        SqlDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            this.Hide();
                            string namauser = rd["namauser"].ToString();
                            formutama u = new formutama(namauser);
                            u.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan!");
                        }
                        
                        conn.Close();
                    }   
                }
            }
            catch (Exception ex) 
            {
               MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}
