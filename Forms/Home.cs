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
    
        private void aREAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArea frmArea = new FrmArea();
            frmArea.MdiParent = this;
            frmArea.Show();
        }

        private void distanciaMinimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Distancia.FrmDistanciaMinima frmDistanciaMinima = new Distancia.FrmDistanciaMinima();
            frmDistanciaMinima.MdiParent = this;
            frmDistanciaMinima.WindowState = FormWindowState.Maximized;
            frmDistanciaMinima.Show();
        }
}
}

