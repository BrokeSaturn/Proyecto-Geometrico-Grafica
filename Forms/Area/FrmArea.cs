using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    // Formulario interactivo para calculo de area
    public partial class FrmArea : Form
    {
        private clsPoligono objPoligono = new clsPoligono();
        private clsCalculadoraArea objCalculadora = new clsCalculadoraArea();

        // Pixeles equivalentes a 1 unidad matematica
        private double dblEscala = 20.0;

        public FrmArea()
        {
            InitializeComponent();
            ActualizarResultado("", false);
        }

        // Origen (0,0) centrado en el panel
        private PointF ObtenerOrigen()
        {
            return new PointF(pnlDibujo.ClientSize.Width / 2f, pnlDibujo.ClientSize.Height / 2f);
        }

        // Coordenadas matematicas a pantalla (Y crece hacia abajo)
        private PointF MatematicasAPantalla(double dblX, double dblY)
        {
            PointF ptOrigen = ObtenerOrigen();
            float sngX = ptOrigen.X + (float)(dblX * dblEscala);
            float sngY = ptOrigen.Y - (float)(dblY * dblEscala);
            return new PointF(sngX, sngY);
        }

        // Coordenadas de pantalla a matematicas (Y crece hacia arriba)
        private clsPunto PantallaAMatematicas(Point ptMouse)
        {
            PointF ptOrigen = ObtenerOrigen();
            double dblX = (ptMouse.X - ptOrigen.X) / dblEscala;
            double dblY = (ptOrigen.Y - ptMouse.Y) / dblEscala;
            return new clsPunto(Math.Round(dblX, 1), Math.Round(dblY, 1));
        }

        private void pnlDibujo_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfxLienzo = e.Graphics;
            gfxLienzo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (chkMostrarCuadricula.Checked)
            {
                DibujarCuadricula(gfxLienzo);
            }
            DibujarEjes(gfxLienzo);
            DibujarRelleno(gfxLienzo);
            DibujarLineas(gfxLienzo);
            if (chkMostrarPuntos.Checked)
            {
                DibujarPuntos(gfxLienzo);
            }
        }

        private void DibujarCuadricula(Graphics gfxLienzo)
        {
            using (Pen penCuadricula = new Pen(Color.Gainsboro, 1))
            {
                PointF ptOrigen = ObtenerOrigen();
                int intAncho = pnlDibujo.ClientSize.Width;
                int intAlto = pnlDibujo.ClientSize.Height;
                float sngPaso = (float)dblEscala;

                for (float sngX = ptOrigen.X; sngX < intAncho; sngX += sngPaso)
                    gfxLienzo.DrawLine(penCuadricula, sngX, 0, sngX, intAlto);
                for (float sngX = ptOrigen.X - sngPaso; sngX > 0; sngX -= sngPaso)
                    gfxLienzo.DrawLine(penCuadricula, sngX, 0, sngX, intAlto);

                for (float sngY = ptOrigen.Y; sngY < intAlto; sngY += sngPaso)
                    gfxLienzo.DrawLine(penCuadricula, 0, sngY, intAncho, sngY);
                for (float sngY = ptOrigen.Y - sngPaso; sngY > 0; sngY -= sngPaso)
                    gfxLienzo.DrawLine(penCuadricula, 0, sngY, intAncho, sngY);
            }
        }

        private void DibujarEjes(Graphics gfxLienzo)
        {
            PointF ptOrigen = ObtenerOrigen();
            int intAncho = pnlDibujo.ClientSize.Width;
            int intAlto = pnlDibujo.ClientSize.Height;

            using (Pen penEje = new Pen(Color.Black, 2))
            using (Font fntTexto = new Font("Segoe UI", 8))
            {
                gfxLienzo.DrawLine(penEje, 0, ptOrigen.Y, intAncho, ptOrigen.Y);
                gfxLienzo.DrawLine(penEje, ptOrigen.X, 0, ptOrigen.X, intAlto);
                gfxLienzo.DrawString("X", fntTexto, Brushes.Black, intAncho - 15, ptOrigen.Y + 3);
                gfxLienzo.DrawString("Y", fntTexto, Brushes.Black, ptOrigen.X + 4, 2);

                int intMaxX = (int)(ptOrigen.X / dblEscala);
                int intMaxY = (int)(ptOrigen.Y / dblEscala);
                for (int intK = -intMaxX; intK <= intMaxX; intK += 5)
                {
                    if (intK == 0) continue;
                    PointF ptMarca = MatematicasAPantalla(intK, 0);
                    gfxLienzo.DrawString(intK.ToString(), fntTexto, Brushes.DimGray, ptMarca.X - 6, ptOrigen.Y + 3);
                }
                for (int intK = -intMaxY; intK <= intMaxY; intK += 5)
                {
                    if (intK == 0) continue;
                    PointF ptMarca = MatematicasAPantalla(0, intK);
                    gfxLienzo.DrawString(intK.ToString(), fntTexto, Brushes.DimGray, ptOrigen.X + 4, ptMarca.Y - 7);
                }
            }
        }

        private PointF[] ObtenerPuntosPantalla()
        {
            PointF[] arrPuntos = new PointF[objPoligono.Cantidad];
            for (int intI = 0; intI < objPoligono.Cantidad; intI++)
            {
                clsPunto objPunto = objPoligono.Vertices[intI];
                arrPuntos[intI] = MatematicasAPantalla(objPunto.X, objPunto.Y);
            }
            return arrPuntos;
        }

        private void DibujarRelleno(Graphics gfxLienzo)
        {
            if (objPoligono.Cantidad < 3 || !objPoligono.Cerrado) return;

            PointF[] arrPuntos = ObtenerPuntosPantalla();
            using (Brush brsRelleno = new SolidBrush(Color.FromArgb(90, Color.DodgerBlue)))
            {
                gfxLienzo.FillPolygon(brsRelleno, arrPuntos);
            }
        }

        private void DibujarLineas(Graphics gfxLienzo)
        {
            if (objPoligono.Cantidad < 2) return;

            PointF[] arrPuntos = ObtenerPuntosPantalla();
            using (Pen penLinea = new Pen(Color.Navy, 2))
            {
                gfxLienzo.DrawLines(penLinea, arrPuntos);
                if (objPoligono.Cerrado)
                {
                    gfxLienzo.DrawLine(penLinea, arrPuntos[arrPuntos.Length - 1], arrPuntos[0]);
                }
            }
        }

        private void DibujarPuntos(Graphics gfxLienzo)
        {
            // Omitir puntos individuales si son demasiados
            if (objPoligono.Cantidad > 200) return;

            PointF[] arrPuntos = ObtenerPuntosPantalla();
            using (Font fntTexto = new Font("Segoe UI", 8, FontStyle.Bold))
            {
                for (int intI = 0; intI < arrPuntos.Length; intI++)
                {
                    Brush brsPunto = (intI == 0) ? Brushes.Green : Brushes.Red;
                    gfxLienzo.FillEllipse(brsPunto, arrPuntos[intI].X - 4, arrPuntos[intI].Y - 4, 8, 8);
                    gfxLienzo.DrawString("V" + (intI + 1), fntTexto, Brushes.Black, arrPuntos[intI].X + 5, arrPuntos[intI].Y - 16);
                }
            }
        }

        private void pnlDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            clsPunto objPunto = PantallaAMatematicas(e.Location);
            objPoligono.AgregarVertice(objPunto.X, objPunto.Y);
            RefrescarTodo();
        }

        private void pnlDibujo_MouseMove(object sender, MouseEventArgs e)
        {
            clsPunto objPunto = PantallaAMatematicas(e.Location);
            lblCoordenadas.Text = "Mouse: (" + objPunto.X.ToString("0.#") + ", " + objPunto.Y.ToString("0.#") + ")";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double dblX;
            double dblY;

            bool blnXValido = double.TryParse(txtX.Text.Trim(), out dblX);
            bool blnYValido = double.TryParse(txtY.Text.Trim(), out dblY);

            if (!blnXValido || !blnYValido)
            {
                MostrarError("Escriba numeros validos en X e Y.");
                return;
            }

            objPoligono.AgregarVertice(dblX, dblY);
            txtX.Clear();
            txtY.Clear();
            txtX.Focus();
            RefrescarTodo();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (!objPoligono.Cerrar())
            {
                MostrarError(objPoligono.UltimoError);
                return;
            }
            lblMensaje.Text = "Poligono cerrado correctamente.";
            lblMensaje.ForeColor = Color.DarkGreen;
            pnlDibujo.Invalidate();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!objPoligono.EsValido())
            {
                MostrarError(objPoligono.UltimoError);
                return;
            }

            double dblArea = objCalculadora.CalcularArea(objPoligono.Vertices);
            string strSentido = objCalculadora.ObtenerSentido(objPoligono.Vertices);
            lblArea.Text = "Area = " + dblArea.ToString("0.####") + " unidades cuadradas";
            lblSentido.Text = "Sentido del contorno: " + strSentido;
            lblArea.ForeColor = Color.Black;
            lblMensaje.Text = "";
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            objPoligono.EliminarUltimoVertice();
            RefrescarTodo();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            objPoligono.Limpiar();
            txtPasos.Clear();
            RefrescarTodo();
        }

        private void btnPasoAPaso_Click(object sender, EventArgs e)
        {
            if (!objPoligono.EsValido())
            {
                MostrarError(objPoligono.UltimoError);
                return;
            }
            txtPasos.Text = objCalculadora.ObtenerPasoAPaso(objPoligono.Vertices);
        }

        // Prueba de rendimiento con poligono circular de 1000 lados
        private void btnProbarMil_Click(object sender, EventArgs e)
        {
            int intCantidad = 1000;
            double dblRadio = 10.0;

            objPoligono.Limpiar();
            GenerarCirculo(intCantidad, dblRadio);
            objPoligono.Cerrar();

            if (!objPoligono.EsValido())
            {
                MostrarError(objPoligono.UltimoError);
                return;
            }

            double dblArea = objCalculadora.CalcularArea(objPoligono.Vertices);
            double dblTeorica = Math.PI * dblRadio * dblRadio;
            double dblError = Math.Abs(dblTeorica - dblArea);

            RefrescarTodo();
            lblArea.Text = "Area = " + dblArea.ToString("0.#####") + " unidades cuadradas";
            lblSentido.Text = "Sentido: " + objCalculadora.ObtenerSentido(objPoligono.Vertices);
            txtPasos.Text = "PRUEBA CON " + intCantidad + " VERTICES (circulo r = " + dblRadio + ")" + Environment.NewLine +
                            "Area calculada (Gauss) = " + dblArea.ToString("0.#####") + Environment.NewLine +
                            "Area teorica (pi*r^2)  = " + dblTeorica.ToString("0.#####") + Environment.NewLine +
                            "Diferencia             = " + dblError.ToString("0.#####") + Environment.NewLine +
                            "Complejidad O(n): calculo instantaneo.";
        }

        private void GenerarCirculo(int intCantidad, double dblRadio)
        {
            for (int intI = 0; intI < intCantidad; intI++)
            {
                double dblAngulo = 2.0 * Math.PI * intI / intCantidad;
                objPoligono.AgregarVertice(dblRadio * Math.Cos(dblAngulo), dblRadio * Math.Sin(dblAngulo));
            }
        }

        private void chkOpcion_CheckedChanged(object sender, EventArgs e)
        {
            pnlDibujo.Invalidate();
        }

        private void RefrescarTodo()
        {
            RefrescarLista();
            ActualizarResultado("", false);
            pnlDibujo.Invalidate();
        }

        private void RefrescarLista()
        {
            lbxVertices.BeginUpdate();
            lbxVertices.Items.Clear();
            for (int intI = 0; intI < objPoligono.Cantidad; intI++)
            {
                lbxVertices.Items.Add("V" + (intI + 1) + ": " + objPoligono.Vertices[intI].ToString());
            }
            lbxVertices.EndUpdate();
            if (lbxVertices.Items.Count > 0)
            {
                lbxVertices.TopIndex = lbxVertices.Items.Count - 1;
            }
        }

        private void ActualizarResultado(string strMensaje, bool blnError)
        {
            lblArea.Text = "Area = ? unidades cuadradas";
            lblSentido.Text = "Sentido: ?";
            lblMensaje.Text = strMensaje;
            lblMensaje.ForeColor = blnError ? Color.Red : Color.DarkGreen;
        }

        private void MostrarError(string strMensaje)
        {
            lblMensaje.Text = strMensaje;
            lblMensaje.ForeColor = Color.Red;
            MessageBox.Show(strMensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
