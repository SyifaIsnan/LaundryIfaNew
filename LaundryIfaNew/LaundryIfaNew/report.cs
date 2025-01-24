using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LaundryIfaNew
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
            chart1.Series.Clear();
            string[] from = new string[12];
            string[] to = new string[12];

            for (int i = 0; i < from.Length; i++)
            {
                from[i] = new DateTime(DateTime.Now.Year, i + 1, 1).ToString("MMMM");
                to[i] = new DateTime(DateTime.Now.Year, i + 1, 1).ToString("MMMM");

            }

            for (int i = 0; i < to.Length; i++)
            {
                comboBox1.Items.Add(from[i]);
                comboBox2.Items.Add(to[i]);
            }
        }

        SqlConnection conn = Properti.conn;

        private void report_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ambil bulan awal dan bulan akhir dari ComboBox
            string from = comboBox1.SelectedItem.ToString();
            string to = comboBox2.SelectedItem.ToString();

            // Query untuk menghitung pendapatan per bulan
            string query = "SELECT MONTH([Order].tanggalorder) AS Bulan, SUM(jumlahunit * biaya) AS Income " +
                           "FROM [Order] " +
                           "INNER JOIN Detailorder ON [Order].kodeorder = Detailorder.kodeorder " +
                           "WHERE tanggalorder >= @from AND tanggalorder <= @to " +
                           "GROUP BY MONTH(tanggalorder)";

            // Buat command SQL dan tambahkan parameter
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@from", new DateTime(DateTime.Now.Year, DateTime.ParseExact(from, "MMMM", CultureInfo.CurrentCulture).Month, 1));
            cmd.Parameters.AddWithValue("@to", new DateTime(DateTime.Now.Year, DateTime.ParseExact(to, "MMMM", CultureInfo.CurrentCulture).Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.ParseExact(to, "MMMM", CultureInfo.CurrentCulture).Month)));

            // Eksekusi query dan muat data ke DataTable
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            // Tampilkan data di DataGridView
            dataGridView1.DataSource = dt.AsEnumerable().Select(d => new
            {
                Bulan = new DateTime(DateTime.Now.Year, d.Field<int>("Bulan"), 1).ToString("MMMM"),
                Income = d.Field<int>("Income").ToString("C", CultureInfo.GetCultureInfo("id-ID")),
            }).ToList();

            // Tambahkan data ke chart
            chart1.Series.Clear();
            var series = chart1.Series.Add("Pendapatan");
            series.ChartType = SeriesChartType.Column;

            foreach (DataRow row in dt.Rows)
            {
                // Cek apakah bulan valid (1-12)
                int bulanNumber = row.Field<int>("Bulan");
                string bulan = string.Empty;

                if (bulanNumber >= 1 && bulanNumber <= 12)
                {
                    bulan = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(bulanNumber); // Mengonversi angka bulan menjadi nama bulan
                }
                else
                {
                    bulan = "Bulan Tidak Valid"; // Menangani kasus jika bulan tidak valid
                }

                int income = row.Field<int>("Income");

                // Tambahkan data ke chart
                series.Points.AddXY(bulan, income);
            }


        }
    }
}
