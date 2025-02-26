﻿using System;
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
    public partial class datapelanggan : Form
    {
        public datapelanggan()
        {
            InitializeComponent();
            tampildata();
        }

        SqlConnection conn = Properti.conn;

        private void tampildata()
        {
            SqlCommand cmd = new SqlCommand("select * from [Pelanggan]", conn);
            conn.Open();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow.Cells;
            textBox1.Text = row["nomortelepon"].Value.ToString();
            textBox2.Text = row["nama"].Value.ToString();
            richTextBox1.Text = row["alamat"].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
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
                    MessageBox.Show("Inputan tidak boleh kosong!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("delete from [Pelanggan] where nomortelepon = @nomortelepon", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@nomortelepon", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data berhasil dihapus!");
                    clear();
                    tampildata();
                    

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
                    SqlCommand cmd = new SqlCommand("update [Pelanggan] set nomortelepon = @nomortelepon, nama = @nama, alamat = @alamat where nomortelepon=@nomortelepon", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@nomortelepon", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nama", textBox2.Text);
                    cmd.Parameters.AddWithValue("@alamat", richTextBox1.Text);
                    cmd.ExecuteNonQuery();                                             
                    conn.Close();
                    MessageBox.Show("Data berhasil diubah!");
                    clear();
                    tampildata();

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
                    SqlCommand cmd = new SqlCommand("insert into [Pelanggan] values (@nomortelepon, @nama, @alamat)", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@nomortelepon", textBox1.Text);
                    cmd.Parameters.AddWithValue("@nama", textBox2.Text);
                    cmd.Parameters.AddWithValue("@alamat", richTextBox1.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data berhasil ditambahkan!");
                    clear();
                    tampildata();


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
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
