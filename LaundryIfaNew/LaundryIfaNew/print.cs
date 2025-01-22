using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaundryIfaNew
{
    public partial class print : Form
    {
        private string kodeorder;
        private string kodelayanan;
        private string jumlahunit;
        private string biaya;

        public print(string kodeorder, string kodelayanan, string jumlahunit, string biaya)
        {
            InitializeComponent();

            this.kodeorder = kodeorder;
            this.kodelayanan = kodelayanan;
            this.jumlahunit = jumlahunit;
            this.biaya = biaya;
            string html = p();
            webBrowser1.DocumentText = html;

        }

        private string p()
        {
            return "<!DOCTYPE html> <html lang='en'> <head> <meta charset='UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Document</title> <style> .container{ text-align: center; font-size:  18px; margin-top: 10%; } </style> </head> <body>" +
            $"<div class='container'> <h3> Nota Dari LaundryIfa </h3><span> Kode Order : {kodeorder}</span><br> <span> Kode layanan : {kodelayanan}</span><br> <span> Jumlah Unit : {jumlahunit}</span><br> <span> Biaya : {biaya}</span><br> </div> </body> </html>";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = p();
            html += "<script> window.print() </script>";
            webBrowser1.DocumentText = html;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
