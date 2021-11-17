using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m9
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            frmGenerateKey frm = new frmGenerateKey();
            frm.ShowDialog();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            frmConvert frm = new frmConvert();
            frm.ShowDialog();
        }

        private void btnGenerateKey_MouseHover(object sender, EventArgs e)
        {
            btnGenerateKey.BackColor = Color.White;

        }

        private void btnGenerateKey_MouseLeave(object sender, EventArgs e)
        {
            btnGenerateKey.BackColor = Color.Black;
        }

        private void btnConvert_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
