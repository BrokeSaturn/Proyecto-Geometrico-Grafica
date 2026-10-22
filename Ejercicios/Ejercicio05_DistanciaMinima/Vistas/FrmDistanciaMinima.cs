using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Comun;
using WindowsFormsApp2.Ejercicios.DistanciaMinima.Modelos;
using WindowsFormsApp2.Ejercicios.DistanciaMinima.Servicios;

namespace WindowsFormsApp2.Ejercicios.DistanciaMinima.Vistas
{
    public partial class FrmDistanciaMinima : Form
    {
        private const double doubleLimiteCoordenada = 1000000.0;
        private const string strSinValor = "-";

        private static readonly Color colorCampoValido = Color.White;
        private static readonly Color colorCampoInvalido = Color.FromArgb(254, 226, 226);

        private enum EstadoMensaje { Informacion, Exito, Advertencia, Error }

        private readonly clsCalculadoraGeometrica objCalculadora = new clsCalculadoraGeometrica();
        private readonly clsGraficadorTrayectoria objGraficador = new clsGraficadorTrayectoria();

        private clsSegmento objSegmentoActual;
        private clsPunto objObstaculoActual;
        private clsResultadoProyeccion objResultadoActual;

        public FrmDistanciaMinima()
        {
            InitializeComponent();
        }

        private void FrmDistanciaMinima_Load(object sender, EventArgs e)
        {
            CargarEjemplo();
            EjecutarCalculo();
        }

        private void btnCalcularDistancia_Click(object sender, EventArgs e)
        {
            EjecutarCalculo();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (TextBox txtCampo in ObtenerCampos())
            {
                txtCampo.Clear();
                txtCampo.BackColor = colorCampoValido;
            }
            LimpiarResultados();
            MostrarMensaje("Ingrese las coordenadas de A, B y P y presione Calcular distancia.", EstadoMensaje.Informacion);
            txtCoordenadaAx.Focus();
        }

        private void btnRestablecerEjemplo_Click(object sender, EventArgs e)
        {
            CargarEjemplo();
            EjecutarCalculo();
        }

        private void txtCoordenada_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool boolCaracterPermitido = char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) ||
                                         e.KeyChar == '-' || e.KeyChar == '.' || e.KeyChar == ',';
            e.Handled = !boolCaracterPermitido;
        }

        private void txtCoordenada_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = colorCampoValido;
        }

        private void pnlGraficoTrayectoria_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectArea = pnlGraficoTrayectoria.ClientRectangle;
            if (objResultadoActual == null)
            {
                objGraficador.DibujarMensaje(e.Graphics, rectArea, "Ingrese datos validos y presione Calcular distancia");
                return;
            }
            objGraficador.Dibujar(e.Graphics, rectArea, objSegmentoActual, objObstaculoActual, objResultadoActual);
        }

        private TextBox[] ObtenerCampos()
        {
            return new[] { txtCoordenadaAx, txtCoordenadaAy, txtCoordenadaBx, txtCoordenadaBy, txtCoordenadaPx, txtCoordenadaPy };
        }

        private void CargarEjemplo()
        {
            txtCoordenadaAx.Text = "2";
            txtCoordenadaAy.Text = "2";
            txtCoordenadaBx.Text = "8";
            txtCoordenadaBy.Text = "4";
            txtCoordenadaPx.Text = "5";
            txtCoordenadaPy.Text = "6";
        }

        // Flujo de calculo
        private void EjecutarCalculo()
        {
            LimpiarResultados();

            double[] arrCoordenadas;
            string strMensajeError;
            if (!LeerCoordenadas(out arrCoordenadas, out strMensajeError))
            {
                MostrarMensaje(strMensajeError, EstadoMensaje.Error);
                return;
            }

            objSegmentoActual = new clsSegmento(new clsPunto(arrCoordenadas[0], arrCoordenadas[1]),
                                             new clsPunto(arrCoordenadas[2], arrCoordenadas[3]));
            objObstaculoActual = new clsPunto(arrCoordenadas[4], arrCoordenadas[5]);
            objResultadoActual = objCalculadora.CalcularProyeccion(objSegmentoActual, objObstaculoActual);

            MostrarResultado(objResultadoActual);
            pnlGraficoTrayectoria.Invalidate();
        }

        // Validacion de coordenadas
        private bool LeerCoordenadas(out double[] arrCoordenadas, out string strMensajeError)
        {
            TextBox[] arrCampos = ObtenerCampos();
            arrCoordenadas = new double[arrCampos.Length];
            strMensajeError = string.Empty;
            TextBox txtPrimerInvalido = null;

            for (int i = 0; i < arrCampos.Length; i++)
            {
                string strError = ValidarCampo(arrCampos[i], out arrCoordenadas[i]);
                if (strError == null) continue;

                arrCampos[i].BackColor = colorCampoInvalido;
                if (txtPrimerInvalido == null)
                {
                    txtPrimerInvalido = arrCampos[i];
                    strMensajeError = strError;
                }
            }

            if (txtPrimerInvalido == null) return true;

            txtPrimerInvalido.Focus();
            txtPrimerInvalido.SelectAll();
            return false;
        }

        private static string ValidarCampo(TextBox txtCampo, out double doubleValor)
        {
            string strNombre = txtCampo.AccessibleName;
            if (string.IsNullOrWhiteSpace(txtCampo.Text))
            {
                doubleValor = 0.0;
                return "El campo " + strNombre + " esta vacio. Ingrese un numero, por ejemplo 2 o -3.5.";
            }
            if (!clsConversorNumerico.IntentarConvertir(txtCampo.Text, out doubleValor))
            {
                return "El valor \"" + txtCampo.Text.Trim() + "\" en " + strNombre +
                       " no es un numero valido. Use digitos con punto o coma decimal, por ejemplo 5.9 o 5,9.";
            }
            if (Math.Abs(doubleValor) > doubleLimiteCoordenada)
            {
                return "El valor de " + strNombre + " esta fuera de rango. Use valores entre -1000000 y 1000000.";
            }
            return null;
        }

        private void MostrarResultado(clsResultadoProyeccion resultado)
        {
            bool boolDegenerado = resultado.Tipo == TipoProyeccion.SegmentoDegenerado;

            lblVectorAB.Text = resultado.VectorAB.ObtenerCoordenadas();
            lblVectorAP.Text = resultado.VectorAP.ObtenerCoordenadas();
            lblParametroOriginal.Text = boolDegenerado ? "No definido (A = B)" : clsConversorNumerico.Formatear(resultado.ParametroOriginal);
            lblParametroRestringido.Text = clsConversorNumerico.Formatear(resultado.ParametroRestringido);
            lblPuntoQ.Text = resultado.PuntoMasCercano.ObtenerCoordenadas();
            lblDistanciaMinima.Text = clsConversorNumerico.Formatear(resultado.DistanciaMinima) + " u";
            lblClasificacion.Text = resultado.ObtenerDescripcionTipo();
            lblPertenencia.Text = resultado.PerteneceAlSegmento ? "Si (0 <= t <= 1)" : "No";

            if (boolDegenerado)
            {
                MostrarMensaje("A y B coinciden: el segmento tiene longitud cero, por eso Q = A y d = |AP|.", EstadoMensaje.Advertencia);
            }
            else
            {
                MostrarMensaje("Calculo realizado. Q es el punto de AB mas cercano al obstaculo P.", EstadoMensaje.Exito);
            }
        }

        private void LimpiarResultados()
        {
            objSegmentoActual = null;
            objObstaculoActual = null;
            objResultadoActual = null;

            foreach (Label lblValor in new[] { lblVectorAB, lblVectorAP, lblParametroOriginal, lblParametroRestringido,
                                               lblPuntoQ, lblDistanciaMinima, lblClasificacion, lblPertenencia })
            {
                lblValor.Text = strSinValor;
            }
            pnlGraficoTrayectoria.Invalidate();
        }

        private void MostrarMensaje(string strMensaje, EstadoMensaje estado)
        {
            switch (estado)
            {
                case EstadoMensaje.Exito:
                    lblMensajeValidacion.Text = "Correcto: " + strMensaje;
                    lblMensajeValidacion.BackColor = Color.FromArgb(220, 252, 231);
                    lblMensajeValidacion.ForeColor = Color.FromArgb(22, 101, 52);
                    break;
                case EstadoMensaje.Advertencia:
                    lblMensajeValidacion.Text = "Aviso: " + strMensaje;
                    lblMensajeValidacion.BackColor = Color.FromArgb(254, 243, 199);
                    lblMensajeValidacion.ForeColor = Color.FromArgb(146, 64, 14);
                    break;
                case EstadoMensaje.Error:
                    lblMensajeValidacion.Text = "Error: " + strMensaje;
                    lblMensajeValidacion.BackColor = Color.FromArgb(254, 226, 226);
                    lblMensajeValidacion.ForeColor = Color.FromArgb(153, 27, 27);
                    break;
                default:
                    lblMensajeValidacion.Text = strMensaje;
                    lblMensajeValidacion.BackColor = Color.FromArgb(226, 232, 240);
                    lblMensajeValidacion.ForeColor = Color.FromArgb(30, 41, 59);
                    break;
            }
        }
    }
}
