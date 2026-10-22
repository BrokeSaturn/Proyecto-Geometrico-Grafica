using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Ejercicios.Area.Vistas;
using WindowsFormsApp2.Ejercicios.DistanciaMinima.Vistas;
using WindowsFormsApp2.Ejercicios.Estrella.Vistas;
using WindowsFormsApp2.Ejercicios.Linea.Vistas;
using WindowsFormsApp2.Ejercicios.Punto.Vistas;
using WindowsFormsApp2.Ejercicios.Triangulacion.Vistas;

namespace WindowsFormsApp2
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
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
            FrmDistanciaMinima frmDistanciaMinima = new FrmDistanciaMinima();
            frmDistanciaMinima.MdiParent = this;
            frmDistanciaMinima.WindowState = FormWindowState.Maximized;
            frmDistanciaMinima.Show();
        }

        private void triangulacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FrmTriangulacion frmTriangulacion = new FrmTriangulacion();
            frmTriangulacion.MdiParent = this;
            frmTriangulacion.WindowState = FormWindowState.Maximized;
            frmTriangulacion.Show();
        }
}
}

