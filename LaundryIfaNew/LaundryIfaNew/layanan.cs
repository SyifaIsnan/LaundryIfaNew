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
    public partial class layanan : Form
    {
        private string kodeorder;

        public layanan(string kodeorder)
        {
            InitializeComponent();

            this.kodeorder = kodeorder;
            tampildata();

            SqlCommand cmd = new SqlCommand("SELECT kodelayanan , namalayanan FROM Layanan", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "namalayanan";
            comboBox1.ValueMember = "kodelayanan";
            comboBox1.SelectedIndex = -1;

            conn.Close();
        }

        private void tampildata()
        {
            SqlCommand cmd = new SqlCommand("select * from [Detailorder] ", conn);
            conn.Open();
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        SqlConnection conn = Properti.conn;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow.Cells;
            comboBox1.SelectedValue = row["kodelayanan"].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(row["jumlahunit"].Value.ToString());

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT biaya FROM Layanan WHERE kodelayanan = @kodelayanan", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@kodelayanan", comboBox1.SelectedValue);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox1.Text = dr["biaya"].ToString();
                    }
                }
                catch
                {
                    conn.Close();
                }


            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Detailorder VALUES(@kodeorder,@kodelayanan,@jumlahunit,@biaya)", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.AddWithValue("@kodeorder", kodeorder);
                cmd.Parameters.AddWithValue("@kodelayanan", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@jumlahunit", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@biaya", textBox1.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil ditambahkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tampildata();
                clear();

            }
            catch
            {
                conn.Close();


            }
        }

        private void clear()
        {
            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            textBox1.Text = "";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridView1.CurrentRow;
                int kodeorder = Convert.ToInt32(row.Cells["kodeorder"].Value.ToString());
                SqlCommand cmd = new SqlCommand("UPDATE Detailorder SET kodeorder=@kodeorder, kodelayanan = @kodelayanan, jumlahunit = @jumlahunit , biaya = @biaya WHERE kodeorder= @kodeorder", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.AddWithValue("@kodeorder", kodeorder);
                cmd.Parameters.AddWithValue("@kodelayanan", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@jumlahunit", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@biaya", textBox1.Text);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                conn.Close();
                tampildata();
                MessageBox.Show("Data berhasil diubah", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            order o = new order();
            o.Show();
        }
    }
}
