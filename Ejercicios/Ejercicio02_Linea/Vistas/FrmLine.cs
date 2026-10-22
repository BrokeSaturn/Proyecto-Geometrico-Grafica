using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp2.Ejercicios.Linea.Vistas
{
    public partial class FrmLine : Form
    {
        // Coordenadas de posición
        private double ax = 100;
        private double ay = 300;
        private double bx = 500;
        private double by = 100;
        private double origenAx = 100;
        private double origenAy = 300;

        // Coordenadas de los puntos P, P2 y P3 para clasificación
        private double p1x = 300, p1y = 150;
        private double p2x = 400, p2y = 350;
        private double p3x = 300, p3y = 200;

        private string resP1 = "Sin clasificar", resP2 = "Sin clasificar", resP3 = "Sin clasificar";
        private Color colP1 = Color.DarkMagenta, colP2 = Color.DarkOrange, colP3 = Color.DeepSkyBlue;

        private double velocidad = 5;
        private int contadorClicks = 0;

        private List<Point> puntosRecorridos = new List<Point>();

        // Controles de interfaz
        private Panel pnlControles;
        private NumericUpDown numAx, numAy;
        private NumericUpDown numBx, numBy;
        private NumericUpDown numP1x, numP1y;
        private NumericUpDown numP2x, numP2y;
        private NumericUpDown numP3x, numP3y;
        private NumericUpDown numPaso;
        private Button btnAvanzar;
        private Button btnReiniciar;
        private Button btnClasificar;
        private Label lblEstado;
        private Label lblResultadoP1, lblResultadoP2, lblResultadoP3;

        public FrmLine()
        {
            InitializeComponent();
            this.ClientSize = new Size(1180, 680);
            this.DoubleBuffered = true;

            ConstruirInterfaz();
            Reiniciar();
            ClasificarTodosLosPuntos();
        }

        private void ConstruirInterfaz()
        {
            pnlControles = new Panel
            {
                Dock = DockStyle.Top,
                Height = 115,
                BackColor = Color.FromArgb(242, 244, 247),
                BorderStyle = BorderStyle.FixedSingle
            };

            Font fontNegrita = new Font("Arial", 8.5f, FontStyle.Bold);
            Font fontMono = new Font("Consolas", 8.2f, FontStyle.Regular);

            Label lblA = new Label { Text = "Origen A:", Location = new Point(10, 10), AutoSize = true, Font = fontNegrita };
            Label lblAx = new Label { Text = "X:", Location = new Point(75, 10), AutoSize = true };
            numAx = new NumericUpDown { Location = new Point(93, 8), Width = 55, Minimum = 0, Maximum = 1500, Value = 100 };
            Label lblAy = new Label { Text = "Y:", Location = new Point(153, 10), AutoSize = true };
            numAy = new NumericUpDown { Location = new Point(171, 8), Width = 55, Minimum = 0, Maximum = 1500, Value = 300 };

            Label lblB = new Label { Text = "Destino B:", Location = new Point(240, 10), AutoSize = true, Font = fontNegrita };
            Label lblBx = new Label { Text = "X:", Location = new Point(305, 10), AutoSize = true };
            numBx = new NumericUpDown { Location = new Point(323, 8), Width = 55, Minimum = 0, Maximum = 1500, Value = 500 };
            Label lblBy = new Label { Text = "Y:", Location = new Point(383, 10), AutoSize = true };
            numBy = new NumericUpDown { Location = new Point(401, 8), Width = 55, Minimum = 0, Maximum = 1500, Value = 100 };

            Label lblV = new Label { Text = "Paso (t):", Location = new Point(470, 10), AutoSize = true, Font = fontNegrita };
            numPaso = new NumericUpDown { Location = new Point(528, 8), Width = 50, Minimum = 1, Maximum = 500, Value = 5 };

            btnAvanzar = new Button { Text = "▶ Avanzar", Location = new Point(590, 6), Width = 80, Height = 25, BackColor = Color.LightSkyBlue };
            btnReiniciar = new Button { Text = "↺ Reiniciar", Location = new Point(675, 6), Width = 75, Height = 25 };
            btnClasificar = new Button { Text = "★ Clasificar Puntos", Location = new Point(760, 6), Width = 135, Height = 25, BackColor = Color.Lavender };

            // Punto P1
            Label lblP1 = new Label { Text = "P1:", Location = new Point(10, 38), AutoSize = true, Font = fontNegrita, ForeColor = colP1 };
            Label lblP1x = new Label { Text = "X:", Location = new Point(35, 38), AutoSize = true };
            numP1x = new NumericUpDown { Location = new Point(53, 36), Width = 50, Minimum = 0, Maximum = 1500, Value = 300 };
            Label lblP1y = new Label { Text = "Y:", Location = new Point(108, 38), AutoSize = true };
            numP1y = new NumericUpDown { Location = new Point(125, 36), Width = 50, Minimum = 0, Maximum = 1500, Value = 150 };

            // Punto P2
            Label lblP2 = new Label { Text = "P2:", Location = new Point(190, 38), AutoSize = true, Font = fontNegrita, ForeColor = colP2 };
            Label lblP2x = new Label { Text = "X:", Location = new Point(215, 38), AutoSize = true };
            numP2x = new NumericUpDown { Location = new Point(233, 36), Width = 50, Minimum = 0, Maximum = 1500, Value = 400 };
            Label lblP2y = new Label { Text = "Y:", Location = new Point(288, 38), AutoSize = true };
            numP2y = new NumericUpDown { Location = new Point(305, 36), Width = 50, Minimum = 0, Maximum = 1500, Value = 350 };

            // Punto P3
            Label lblP3 = new Label { Text = "P3:", Location = new Point(370, 38), AutoSize = true, Font = fontNegrita, ForeColor = colP3 };
            Label lblP3x = new Label { Text = "X:", Location = new Point(395, 38), AutoSize = true };
            numP3x = new NumericUpDown { Location = new Point(413, 36), Width = 50, Minimum = 0, Maximum = 1500, Value = 300 };
            Label lblP3y = new Label { Text = "Y:", Location = new Point(468, 38), AutoSize = true };
            numP3y = new NumericUpDown { Location = new Point(485, 36), Width = 50, Minimum = 0, Maximum = 1500, Value = 200 };

            // Resultados de clasificación
            lblResultadoP1 = new Label { Location = new Point(550, 38), AutoSize = true, Font = fontNegrita, ForeColor = colP1, Text = "P1: -" };
            lblResultadoP2 = new Label { Location = new Point(730, 38), AutoSize = true, Font = fontNegrita, ForeColor = colP2, Text = "P2: -" };
            lblResultadoP3 = new Label { Location = new Point(910, 38), AutoSize = true, Font = fontNegrita, ForeColor = colP3, Text = "P3: -" };

            lblEstado = new Label
            {
                Location = new Point(10, 68),
                AutoSize = true,
                Font = fontMono,
                ForeColor = Color.DarkSlateGray,
                Text = "Estado: Listo."
            };

            // Eventos
            btnAvanzar.Click += (s, e) => AvanzarPaso();
            btnReiniciar.Click += (s, e) => Reiniciar();
            btnClasificar.Click += (s, e) => ClasificarTodosLosPuntos();

            numAx.ValueChanged += (s, e) => { origenAx = (double)numAx.Value; ClasificarTodosLosPuntos(); this.Invalidate(); };
            numAy.ValueChanged += (s, e) => { origenAy = (double)numAy.Value; ClasificarTodosLosPuntos(); this.Invalidate(); };
            numBx.ValueChanged += (s, e) => { bx = (double)numBx.Value; ActualizarEstado(); ClasificarTodosLosPuntos(); this.Invalidate(); };
            numBy.ValueChanged += (s, e) => { by = (double)numBy.Value; ActualizarEstado(); ClasificarTodosLosPuntos(); this.Invalidate(); };
            numPaso.ValueChanged += (s, e) => { velocidad = (double)numPaso.Value; ActualizarEstado(); };

            numP1x.ValueChanged += (s, e) => { p1x = (double)numP1x.Value; ClasificarTodosLosPuntos(); this.Invalidate(); };
            numP1y.ValueChanged += (s, e) => { p1y = (double)numP1y.Value; ClasificarTodosLosPuntos(); this.Invalidate(); };
            numP2x.ValueChanged += (s, e) => { p2x = (double)numP2x.Value; ClasificarTodosLosPuntos(); this.Invalidate(); };
            numP2y.ValueChanged += (s, e) => { p2y = (double)numP2y.Value; ClasificarTodosLosPuntos(); this.Invalidate(); };
            numP3x.ValueChanged += (s, e) => { p3x = (double)numP3x.Value; ClasificarTodosLosPuntos(); this.Invalidate(); };
            numP3y.ValueChanged += (s, e) => { p3y = (double)numP3y.Value; ClasificarTodosLosPuntos(); this.Invalidate(); };

            pnlControles.Controls.AddRange(new Control[] {
                lblA, lblAx, numAx, lblAy, numAy,
                lblB, lblBx, numBx, lblBy, numBy,
                lblV, numPaso,
                btnAvanzar, btnReiniciar, btnClasificar,
                lblP1, lblP1x, numP1x, lblP1y, numP1y,
                lblP2, lblP2x, numP2x, lblP2y, numP2y,
                lblP3, lblP3x, numP3x, lblP3y, numP3y,
                lblResultadoP1, lblResultadoP2, lblResultadoP3,
                lblEstado
            });

            this.Controls.Add(pnlControles);
        }

        public double CalcularAnguloRadianes(double x1, double y1, double x2, double y2)
        {
            return Math.Atan2(y2 - y1, x2 - x1);
        }

        public double CalcularAnguloGrados(double x1, double y1, double x2, double y2)
        {
            return CalcularAnguloRadianes(x1, y1, x2, y2) * (180.0 / Math.PI);
        }

        // Determinante con inversión del eje Y (GDI+ crece hacia abajo; cartesiano estándar hacia arriba)
        public string ClasificarOrientacion(double ax, double ay, double bx, double by, double px, double py, out double d)
        {
            double dx = bx - ax;
            double dy = by - ay;

            if (Math.Abs(dx) < 1e-9 && Math.Abs(dy) < 1e-9)
            {
                d = 0;
                return "Trayectoria no definida (A = B)";
            }

            // Adaptación cartesiana para pantalla: Y_cart = -Y_gdi
            d = dx * (-(py - ay)) - (-dy) * (px - ax);

            double tolerancia = 1e-5;
            if (Math.Abs(d) <= tolerancia)
            {
                return "Sobre recta AB";
            }
            else if (d > 0)
            {
                return "A la izquierda";
            }
            else
            {
                return "A la derecha";
            }
        }

        private void ClasificarTodosLosPuntos()
        {
            p1x = (double)numP1x.Value;
            p1y = (double)numP1y.Value;
            p2x = (double)numP2x.Value;
            p2y = (double)numP2y.Value;
            p3x = (double)numP3x.Value;
            p3y = (double)numP3y.Value;

            double d1, d2, d3;
            resP1 = ClasificarOrientacion(origenAx, origenAy, bx, by, p1x, p1y, out d1);
            resP2 = ClasificarOrientacion(origenAx, origenAy, bx, by, p2x, p2y, out d2);
            resP3 = ClasificarOrientacion(origenAx, origenAy, bx, by, p3x, p3y, out d3);

            ActualizarTextoResultado(lblResultadoP1, "P1", resP1, d1);
            ActualizarTextoResultado(lblResultadoP2, "P2", resP2, d2);
            ActualizarTextoResultado(lblResultadoP3, "P3", resP3, d3);

            this.Invalidate();
        }

        private void ActualizarTextoResultado(Label lbl, string nombre, string res, double d)
        {
            if (res.StartsWith("Trayectoria"))
            {
                lbl.Text = string.Format("{0}: {1}", nombre, res);
            }
            else
            {
                lbl.Text = string.Format("{0}: {1} (D={2:F0})", nombre, res, d);
            }
        }

        public void ActualizarPosicion(double t)
        {
            double dx = bx - ax;
            double dy = by - ay;
            double distancia = Math.Sqrt(dx * dx + dy * dy);

            if (distancia < 0.0001)
            {
                ActualizarEstado("Origen y destino coinciden (distancia = 0). Vector unitario nulo.");
                return;
            }

            double anguloRad = CalcularAnguloRadianes(ax, ay, bx, by);
            double anguloGrados = CalcularAnguloGrados(ax, ay, bx, by);

            double ux = Math.Cos(anguloRad);
            double uy = Math.Sin(anguloRad);

            contadorClicks++;

            if (distancia <= t)
            {
                ax = bx;
                ay = by;
                ActualizarEstado("¡Llegada a destino! (Distancia restante cubierta sin sobrepaso).", dx, dy, distancia, ux, uy, anguloGrados, anguloRad);
            }
            else
            {
                ax += t * ux;
                ay += t * uy;
                ActualizarEstado(string.Format("Avanzando: Paso = ({0:F2}, {1:F2}) px", t * ux, t * uy), dx, dy, distancia, ux, uy, anguloGrados, anguloRad);
            }

            puntosRecorridos.Add(new Point((int)Math.Round(ax), (int)Math.Round(ay)));
            this.Invalidate();
        }

        private void AvanzarPaso()
        {
            velocidad = (double)numPaso.Value;
            ActualizarPosicion(velocidad);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Y > pnlControles.Height)
            {
                AvanzarPaso();
            }
        }

        private void Reiniciar()
        {
            origenAx = (double)numAx.Value;
            origenAy = (double)numAy.Value;
            ax = origenAx;
            ay = origenAy;
            bx = (double)numBx.Value;
            by = (double)numBy.Value;
            velocidad = (double)numPaso.Value;
            contadorClicks = 0;

            puntosRecorridos.Clear();
            puntosRecorridos.Add(new Point((int)Math.Round(ax), (int)Math.Round(ay)));

            ActualizarEstado("Escenario reiniciado.");
            ClasificarTodosLosPuntos();
            this.Invalidate();
        }

        private void ActualizarEstado(string mensaje = "", double dx = 0, double dy = 0, double dist = 0, double ux = 0, double uy = 0, double anguloGrados = 0, double anguloRad = 0)
        {
            if (dist == 0)
            {
                dx = bx - ax; dy = by - ay;
                dist = Math.Sqrt(dx * dx + dy * dy);
                if (dist > 0.0001)
                {
                    anguloGrados = CalcularAnguloGrados(ax, ay, bx, by);
                    anguloRad = CalcularAnguloRadianes(ax, ay, bx, by);
                    ux = Math.Cos(anguloRad);
                    uy = Math.Sin(anguloRad);
                }
            }

            lblEstado.Text = string.Format(
                "Vector: ({0:F0}, {1:F0}) | Dist: {2:F1}px | Ángulo: {3:F2}° ({4:F4} rad) | u: ({5:F3}, {6:F3}) | Clics: {7} | {8}",
                dx, dy, dist, anguloGrados, anguloRad, ux, uy, contadorClicks, mensaje
            );

            this.Text = string.Format("Línea A({0:F0}, {1:F0}) -> B({2:F0}, {3:F0}) | Ángulo: {4:F2}° ({5:F4} rad)", 
                                      ax, ay, bx, by, anguloGrados, anguloRad);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. Trayectoria dirigida A -> B con flecha indicativa
            using (AdjustableArrowCap flecha = new AdjustableArrowCap(5, 5))
            using (Pen lapizTrayectoria = new Pen(Color.SteelBlue, 2))
            {
                lapizTrayectoria.CustomEndCap = flecha;
                g.DrawLine(lapizTrayectoria, (float)origenAx, (float)origenAy, (float)bx, (float)by);
            }

            // Línea discontinua hacia el destino desde la posición actual en movimiento
            using (Pen lapizActivo = new Pen(Color.CornflowerBlue, 1) { DashStyle = DashStyle.Dash })
            {
                g.DrawLine(lapizActivo, (float)ax, (float)ay, (float)bx, (float)by);
            }

            // Eje de referencia angular horizontal
            using (Pen lapizReferencia = new Pen(Color.Silver, 1) { DashStyle = DashStyle.Dot })
            {
                g.DrawLine(lapizReferencia, (float)origenAx, (float)origenAy, (float)origenAx + 100, (float)origenAy);
            }

            // Rastro de avance del punto móvil
            foreach (Point pt in puntosRecorridos)
            {
                g.FillEllipse(Brushes.LightSkyBlue, pt.X - 3, pt.Y - 3, 6, 6);
            }

            // 2. Puntos A, B y posición actual móvil
            g.FillEllipse(Brushes.RoyalBlue, (float)origenAx - 6, (float)origenAy - 6, 12, 12);
            g.FillEllipse(Brushes.SeaGreen, (float)bx - 6, (float)by - 6, 12, 12);
            g.FillEllipse(Brushes.Crimson, (float)ax - 5, (float)ay - 5, 10, 10);

            // 3. Dibujo de puntos P1, P2 y P3
            DibujarPuntoClasificado(g, p1x, p1y, colP1, "P1");
            DibujarPuntoClasificado(g, p2x, p2y, colP2, "P2");
            DibujarPuntoClasificado(g, p3x, p3y, colP3, "P3");

            // 4. Etiquetas y textos
            double anguloGrados = CalcularAnguloGrados(origenAx, origenAy, bx, by);
            double anguloRad = CalcularAnguloRadianes(origenAx, origenAy, bx, by);

            using (Font fuente = new Font("Arial", 8.5f, FontStyle.Bold))
            using (Font fuenteLeyenda = new Font("Arial", 8.0f, FontStyle.Regular))
            {
                g.DrawString(string.Format("A ({0:F0}, {1:F0})", origenAx, origenAy), fuente, Brushes.RoyalBlue, (float)origenAx - 30, (float)origenAy + 10);
                g.DrawString(string.Format("θ = {0:F2}° ({1:F4} rad)", anguloGrados, anguloRad), fuente, Brushes.DarkBlue, (float)origenAx + 15, (float)origenAy - 22);
                g.DrawString(string.Format("B ({0:F0}, {1:F0})", bx, by), fuente, Brushes.SeaGreen, (float)bx - 15, (float)by - 20);

                if (Math.Abs(ax - origenAx) > 1 || Math.Abs(ay - origenAy) > 1)
                {
                    g.DrawString(string.Format("Móvil ({0:F1}, {1:F1})", ax, ay), fuente, Brushes.Crimson, (float)ax + 8, (float)ay + 8);
                }

                // Leyenda visual
                int leyX = this.ClientSize.Width - 225;
                int leyY = pnlControles.Height + 15;
                g.FillRectangle(new SolidBrush(Color.FromArgb(235, 255, 255, 255)), leyX - 10, leyY - 5, 220, 130);
                g.DrawRectangle(Pens.LightGray, leyX - 10, leyY - 5, 220, 130);

                g.FillEllipse(Brushes.RoyalBlue, leyX, leyY + 2, 8, 8);
                g.DrawString("A (Inicio)", fuenteLeyenda, Brushes.Black, leyX + 15, leyY);

                g.FillEllipse(Brushes.SeaGreen, leyX, leyY + 20, 8, 8);
                g.DrawString("B (Destino)", fuenteLeyenda, Brushes.Black, leyX + 15, leyY + 18);

                g.FillEllipse(new SolidBrush(colP1), leyX, leyY + 38, 8, 8);
                g.DrawString(string.Format("P1: {0}", resP1), fuenteLeyenda, Brushes.Black, leyX + 15, leyY + 36);

                g.FillEllipse(new SolidBrush(colP2), leyX, leyY + 56, 8, 8);
                g.DrawString(string.Format("P2: {0}", resP2), fuenteLeyenda, Brushes.Black, leyX + 15, leyY + 54);

                g.FillEllipse(new SolidBrush(colP3), leyX, leyY + 74, 8, 8);
                g.DrawString(string.Format("P3: {0}", resP3), fuenteLeyenda, Brushes.Black, leyX + 15, leyY + 72);

                g.FillEllipse(Brushes.Crimson, leyX, leyY + 94, 8, 8);
                g.DrawString("Punto móvil actual", fuenteLeyenda, Brushes.Black, leyX + 15, leyY + 92);
            }
        }

        private void DibujarPuntoClasificado(Graphics g, double x, double y, Color color, string etiqueta)
        {
            using (Brush brocha = new SolidBrush(color))
            using (Pen lapiz = new Pen(Color.Black, 1.2f))
            using (Font fuente = new Font("Arial", 8.5f, FontStyle.Bold))
            {
                g.FillEllipse(brocha, (float)x - 6, (float)y - 6, 12, 12);
                g.DrawEllipse(lapiz, (float)x - 6, (float)y - 6, 12, 12);
                g.DrawString(string.Format("{0} ({1:F0}, {2:F0})", etiqueta, x, y), fuente, brocha, (float)x + 8, (float)y - 8);
            }
        }

        private void FrmLine_Load(object sender, EventArgs e)
        {
        }
    }
}
