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
    public partial class formutama : Form
    {
        public formutama(string namauser)
        {
            InitializeComponent();
            if (namauser == "Admin")
            {
                lOGINToolStripMenuItem.Enabled = false;
                dATAToolStripMenuItem.Enabled = false;
                bIAYATAMBAHANToolStripMenuItem.Enabled = false;
            }
            else if (namauser == "kasir")
            {
                lOGINToolStripMenuItem.Enabled = false;
            }
        }

        private void formutama_Load(object sender, EventArgs e)
        {

        }

        private void lOGINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();  
            login.ShowDialog();
        }

        private void uSERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datauser user = new datauser();
            user.ShowDialog();
        }

        private void pETUGASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datapetugas datapetugas = new datapetugas();
            datapetugas.ShowDialog();
        }

        private void pELANGGANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datapelanggan dp = new datapelanggan();
            dp.ShowDialog();
        }

        private void lAYANANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datalayanan an = new datalayanan();
            an.Show();
        }

        private void bIAYATAMBAHANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            biayatambahan bt = new biayatambahan(); 
            bt.Show();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mess = MessageBox.Show("Apakah anda yakin ingin logout?", "Question", MessageBoxButtons.YesNo);
            if (mess == DialogResult.Yes)
            {
                this.Hide();
                login login = new login();  
                login.ShowDialog();
            }
        }

        private void oRDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order o = new order();
            o.Show();
        }

        private void dETAILORDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailorder o = new detailorder();
            o.Show();
        }

        private void rEPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report report = new report();
            report.Show();
        }
    }
}
