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
    }
}
