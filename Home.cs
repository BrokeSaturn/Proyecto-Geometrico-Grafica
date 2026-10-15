using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pOINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPoint frmPoint = new FrmPoint();
            frmPoint.MdiParent = this;
            frmPoint.Show();
        }

        private void lIEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLine frmLine = new FrmLine();
            frmLine.MdiParent = this;
            frmLine.Show();
        }

        private void sTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStar frmStar = new FrmStar();
            frmStar.MdiParent = this;
            frmStar.Show();
        }
    }
}
