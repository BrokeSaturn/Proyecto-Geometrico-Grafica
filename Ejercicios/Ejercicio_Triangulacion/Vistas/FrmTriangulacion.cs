using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp2.Ejercicios.Triangulacion.Modelos;
using WindowsFormsApp2.Ejercicios.Triangulacion.Servicios;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Vistas
{
    public partial class FrmTriangulacion : Form
    {
        private const string strSinValor = "-";
        private const string strFormatoArea = "0.####";

        private enum EstadoMensaje { Informacion, Exito, Advertencia, Error }

        private readonly clsPoligono objPoligono = new clsPoligono();
        private readonly clsTriangulador objTriangulador = new clsTriangulador();
        private readonly clsDibujanteTriangulacion objDibujante = new clsDibujanteTriangulacion();

        private clsResultadoTriangulacion objResultado;
        private int intTriangulosVisibles;

        public FrmTriangulacion()
        {
            InitializeComponent();
        }

        private void FrmTriangulacion_Load(object sender, EventArgs e)
        {
            LimpiarResultado();
            MostrarMensaje("Haga clic en el lienzo para agregar vertices. Clic derecho cierra el poligono.", EstadoMensaje.Informacion);
        }

        private void pnlLienzoPoligono_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CerrarPoligono();
                return;
            }
            if (e.Button != MouseButtons.Left) return;

            clsPunto2D ptoVertice = objDibujante.ConvertirAMundo(e.Location, pnlLienzoPoligono.ClientRectangle, chkAjustarCuadricula.Checked);
            string strMensajeError;
            if (!objPoligono.AgregarVertice(ptoVertice, out strMensajeError))
            {
                MostrarMensaje(strMensajeError, EstadoMensaje.Error);
                return;
            }
            LimpiarResultado();
            MostrarMensaje("Vertice V" + (objPoligono.IntCantidadVertices - 1) + " agregado en " + ptoVertice + ".", EstadoMensaje.Informacion);
        }

        private void pnlLienzoPoligono_MouseMove(object sender, MouseEventArgs e)
        {
            clsPunto2D ptoCursor = objDibujante.ConvertirAMundo(e.Location, pnlLienzoPoligono.ClientRectangle, chkAjustarCuadricula.Checked);
            lblCoordenadas.Text = "Cursor: " + ptoCursor + "   |   Vertices: " + objPoligono.IntCantidadVertices;
        }

        private void pnlLienzoPoligono_Paint(object sender, PaintEventArgs e)
        {
            objDibujante.Dibujar(e.Graphics, pnlLienzoPoligono.ClientRectangle, objPoligono, objResultado, intTriangulosVisibles);
        }

        private void btnTriangular_Click(object sender, EventArgs e)
        {
            tmrAnimacion.Stop();
            if (objPoligono.IntCantidadVertices < 3)
            {
                LimpiarResultado();
                MostrarMensaje("Se necesitan al menos 3 vertices para triangular (hay " + objPoligono.IntCantidadVertices + ").", EstadoMensaje.Error);
                return;
            }
            if (!objPoligono.BlnCerrado && !CerrarPoligono()) return;

            objResultado = objTriangulador.Triangular(objPoligono.LstVertices);
            MostrarResultado();

            bool blnAnimar = chkPasoAPaso.Checked && objResultado.BlnExito;
            intTriangulosVisibles = blnAnimar ? 0 : objResultado.LstTriangulos.Count;
            if (blnAnimar) tmrAnimacion.Start();
            pnlLienzoPoligono.Invalidate();
        }

        private void btnCerrarPoligono_Click(object sender, EventArgs e)
        {
            CerrarPoligono();
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (!objPoligono.EliminarUltimoVertice())
            {
                MostrarMensaje("No hay vertices para deshacer.", EstadoMensaje.Advertencia);
                return;
            }
            LimpiarResultado();
            MostrarMensaje("Ultimo vertice eliminado. Quedan " + objPoligono.IntCantidadVertices + ".", EstadoMensaje.Informacion);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            objPoligono.Limpiar();
            LimpiarResultado();
            MostrarMensaje("Lienzo limpio. Haga clic para agregar vertices.", EstadoMensaje.Informacion);
        }

        private void btnCargarEjemplo_Click(object sender, EventArgs e)
        {
            objPoligono.CargarVertices(new[]
            {
                new clsPunto2D(0, 0), new clsPunto2D(4, 0), new clsPunto2D(4, 3), new clsPunto2D(2, 1), new clsPunto2D(0, 3)
            });
            string strMensajeError;
            objPoligono.Cerrar(out strMensajeError);
            LimpiarResultado();
            MostrarMensaje("Ejemplo concavo cargado (n = 5). Presione Triangular.", EstadoMensaje.Informacion);
        }

        private void tmrAnimacion_Tick(object sender, EventArgs e)
        {
            intTriangulosVisibles++;
            if (objResultado == null || intTriangulosVisibles >= objResultado.LstTriangulos.Count) tmrAnimacion.Stop();
            pnlLienzoPoligono.Invalidate();
        }

        private bool CerrarPoligono()
        {
            string strMensajeError;
            if (!objPoligono.Cerrar(out strMensajeError))
            {
                MostrarMensaje(strMensajeError, EstadoMensaje.Error);
                return false;
            }
            pnlLienzoPoligono.Invalidate();
            MostrarMensaje("Poligono cerrado con " + objPoligono.IntCantidadVertices + " vertices. Presione Triangular.", EstadoMensaje.Informacion);
            return true;
        }

        private void MostrarResultado()
        {
            if (!objResultado.BlnExito)
            {
                LimpiarEtiquetas();
                MostrarVerificacion(false);
                txtResultados.Text = "Sin triangulacion: " + objResultado.StrMensajeError;
                MostrarMensaje(objResultado.StrMensajeError, EstadoMensaje.Error);
                return;
            }

            lblValorVertices.Text = objResultado.IntCantidadVertices.ToString();
            lblValorTriangulos.Text = objResultado.LstTriangulos.Count.ToString();
            lblValorEsperados.Text = objResultado.IntTriangulosEsperados.ToString();
            lblValorAreaPoligono.Text = Formatear(objResultado.DblAreaPoligono);
            lblValorSumaAreas.Text = Formatear(objResultado.DblAreaTriangulos);
            lblValorDiferencia.Text = objResultado.DblDiferencia.ToString("0.000000", CultureInfo.InvariantCulture);
            lblValorTipo.Text = objResultado.BlnEsConvexo ? "Convexo" : "Concavo";
            lblValorOrientacion.Text = objResultado.BlnOrientacionHoraria ? "Horaria (normalizada)" : "Antihoraria";
            MostrarVerificacion(objResultado.BlnAreaConservada);
            txtResultados.Text = ConstruirDetalle();

            string strMensaje = "Triangulacion completa: " + objResultado.LstTriangulos.Count + " triangulos.";
            if (!string.IsNullOrEmpty(objResultado.StrAdvertencia))
            {
                MostrarMensaje(strMensaje + " " + objResultado.StrAdvertencia, EstadoMensaje.Advertencia);
            }
            else
            {
                MostrarMensaje(strMensaje + (objResultado.BlnAreaConservada ? " El area se conserva." : " Revise la verificacion."),
                               objResultado.BlnAreaConservada ? EstadoMensaje.Exito : EstadoMensaje.Error);
            }
        }

        private string ConstruirDetalle()
        {
            StringBuilder sbDetalle = new StringBuilder();
            sbDetalle.AppendLine("TRIANGULOS (orden de recorte)");
            for (int intI = 0; intI < objResultado.LstTriangulos.Count; intI++)
            {
                clsTriangulo objTriangulo = objResultado.LstTriangulos[intI];
                sbDetalle.AppendLine("T" + (intI + 1) + ": " + objTriangulo.ObtenerNombre() + "   area = " + Formatear(objTriangulo.dblCalcularArea()));
            }
            sbDetalle.AppendLine();
            sbDetalle.AppendLine("VERTICES");
            for (int intI = 0; intI < objPoligono.IntCantidadVertices; intI++)
            {
                sbDetalle.AppendLine("V" + intI + " = " + objPoligono.LstVertices[intI]);
            }
            return sbDetalle.ToString();
        }

        private void MostrarVerificacion(bool blnCorrecto)
        {
            lblValorVerificacion.Text = blnCorrecto ? "AREA CONSERVADA OK" : "ERROR";
            lblValorVerificacion.ForeColor = blnCorrecto ? Color.FromArgb(22, 101, 52) : Color.FromArgb(185, 28, 28);
        }

        private void LimpiarResultado()
        {
            tmrAnimacion.Stop();
            objResultado = null;
            intTriangulosVisibles = 0;
            LimpiarEtiquetas();
            lblValorVerificacion.Text = strSinValor;
            lblValorVerificacion.ForeColor = Color.FromArgb(30, 41, 59);
            txtResultados.Clear();
            pnlLienzoPoligono.Invalidate();
        }

        private void LimpiarEtiquetas()
        {
            foreach (Label lblValor in new[] { lblValorVertices, lblValorTriangulos, lblValorEsperados, lblValorAreaPoligono,
                                               lblValorSumaAreas, lblValorDiferencia, lblValorTipo, lblValorOrientacion })
            {
                lblValor.Text = strSinValor;
            }
        }

        private static string Formatear(double dblValor)
        {
            return dblValor.ToString(strFormatoArea, CultureInfo.InvariantCulture);
        }

        private void MostrarMensaje(string strMensaje, EstadoMensaje enmEstado)
        {
            switch (enmEstado)
            {
                case EstadoMensaje.Exito:
                    lblEstado.Text = "Correcto: " + strMensaje;
                    lblEstado.BackColor = Color.FromArgb(220, 252, 231);
                    lblEstado.ForeColor = Color.FromArgb(22, 101, 52);
                    break;
                case EstadoMensaje.Advertencia:
                    lblEstado.Text = "Aviso: " + strMensaje;
                    lblEstado.BackColor = Color.FromArgb(254, 243, 199);
                    lblEstado.ForeColor = Color.FromArgb(146, 64, 14);
                    break;
                case EstadoMensaje.Error:
                    lblEstado.Text = "Error: " + strMensaje;
                    lblEstado.BackColor = Color.FromArgb(254, 226, 226);
                    lblEstado.ForeColor = Color.FromArgb(153, 27, 27);
                    break;
                default:
                    lblEstado.Text = strMensaje;
                    lblEstado.BackColor = Color.FromArgb(226, 232, 240);
                    lblEstado.ForeColor = Color.FromArgb(30, 41, 59);
                    break;
            }
        }
    }
}
