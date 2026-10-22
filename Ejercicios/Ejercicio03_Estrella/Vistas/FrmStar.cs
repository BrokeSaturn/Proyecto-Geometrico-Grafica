using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2.Ejercicios.Estrella.Vistas
{
    public partial class FrmStar : Form
    {
        public FrmStar()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //entro y radios de la circunferencia
            int centroX = 300;
            int centroY = 250;
            int radioExterior = 180;
            int radioInterior = 75;

            //  Arreglo para almacenar los 10 puntos 
            Point[] puntos = new Point[10];

            // x = centroX + radio * cos(angulo)
            // y = centroY + radio * sin(angulo)
            for (int i = 0; i < 10; i++)
            {
                // Alternar radio: posiciones pares son exteriores (0, 2, 4, 6, 8)
                // y posiciones impares son interiores (1, 3, 5, 7, 9)
                double radio = (i % 2 == 0) ? radioExterior : radioInterior;

                // Cada vertice avanza 36 grados (360° / 10 = 36°)
                double anguloGrados = i * 36.0;

                // y conversión de grados a radianes: radianes = grados * (PI / 180)
                double anguloRadianes = (anguloGrados - 90.0) * (Math.PI / 180.0);

                // formula matemtica para obtener valores desde el centro
                int x = (int)Math.Round(centroX + radio * Math.Cos(anguloRadianes));
                int y = (int)Math.Round(centroY + radio * Math.Sin(anguloRadianes));

                puntos[i] = new Point(x, y);
            }

           
            using (Pen lapiz = new Pen(Color.Blue, 3))
            {
                for (int i = 0; i < 10; i++)
                {
                    Point puntoActual = puntos[i];
                    Point puntoSiguiente = puntos[(i + 1) % 10];

                    e.Graphics.DrawLine(lapiz, puntoActual, puntoSiguiente);
                }
            }
        }

        private void FrmStar_Load(object sender, EventArgs e)
        {

        }
    }
}
