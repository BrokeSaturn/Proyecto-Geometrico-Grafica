using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace WindowsFormsApp2.Distancia
{
    public class clsGraficadorTrayectoria
    {
        private const int intMargen = 56;
        private const int intRadioPunto = 6;
        private const int intMaximoLineasCuadricula = 200;

        private static readonly Color colorPuntoA = Color.FromArgb(22, 163, 74);
        private static readonly Color colorPuntoB = Color.FromArgb(124, 58, 237);
        private static readonly Color colorObstaculo = Color.FromArgb(220, 38, 38);
        private static readonly Color colorPuntoQ = Color.FromArgb(234, 88, 12);
        private static readonly Color colorSegmento = Color.FromArgb(37, 99, 235);
        private static readonly Color colorCuadricula = Color.FromArgb(232, 236, 241);
        private static readonly Color colorEjes = Color.FromArgb(148, 163, 184);
        private static readonly Color colorTextoSecundario = Color.FromArgb(100, 116, 139);

        private readonly Font fntEtiqueta = new Font("Segoe UI", 9F, FontStyle.Bold);
        private readonly Font fntPequena = new Font("Segoe UI", 8F);

        private Rectangle rectArea;
        private double doubleEscala;
        private double doubleCentroX;
        private double doubleCentroY;

        public void DibujarMensaje(Graphics grafico, Rectangle area, string mensaje)
        {
            grafico.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (StringFormat formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (Brush brochaTexto = new SolidBrush(colorTextoSecundario))
            {
                grafico.DrawString(mensaje, fntEtiqueta, brochaTexto, area, formato);
            }
        }

        public void Dibujar(Graphics grafico, Rectangle area, clsSegmento segmento, clsPunto puntoObstaculo, clsResultadoProyeccion resultado)
        {
            grafico.SmoothingMode = SmoothingMode.AntiAlias;
            grafico.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            grafico.SetClip(area);

            clsPunto puntoA = segmento.PuntoInicial;
            clsPunto puntoB = segmento.PuntoFinal;
            clsPunto puntoQ = resultado.PuntoMasCercano;

            AjustarEscala(area, new[] { puntoA, puntoB, puntoObstaculo, puntoQ });
            DibujarCuadricula(grafico, area);

            PointF pixelA = APixel(puntoA);
            PointF pixelB = APixel(puntoB);
            PointF pixelP = APixel(puntoObstaculo);
            PointF pixelQ = APixel(puntoQ);

            if (!segmento.EsDegenerado)
            {
                DibujarProlongacion(grafico, pixelA, pixelB);
                using (Pen lapizSegmento = new Pen(colorSegmento, 4F) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                {
                    grafico.DrawLine(lapizSegmento, pixelA, pixelB);
                }
            }

            using (Pen lapizDistancia = new Pen(colorObstaculo, 2F) { DashStyle = DashStyle.Dash })
            {
                grafico.DrawLine(lapizDistancia, pixelP, pixelQ);
            }

            if (resultado.Tipo == TipoProyeccion.Interior && resultado.DistanciaMinima > 0.0)
            {
                DibujarAnguloRecto(grafico, pixelQ, pixelB, pixelP);
            }

            DibujarEtiquetaDistancia(grafico, pixelP, pixelQ, resultado.DistanciaMinima);
            DibujarPunto(grafico, pixelA, colorPuntoA, "A " + puntoA.ObtenerCoordenadas(), new PointF(10F, -24F));
            DibujarPunto(grafico, pixelB, colorPuntoB, "B " + puntoB.ObtenerCoordenadas(), new PointF(10F, -24F));
            DibujarPunto(grafico, pixelP, colorObstaculo, "P " + puntoObstaculo.ObtenerCoordenadas(), new PointF(10F, -24F));
            DibujarPunto(grafico, pixelQ, colorPuntoQ, "Q " + puntoQ.ObtenerCoordenadas(), new PointF(10F, 6F));

            grafico.ResetClip();
            DibujarLeyenda(grafico, area);
        }

        // Escala uniforme
        private void AjustarEscala(Rectangle area, clsPunto[] puntos)
        {
            rectArea = area;
            double minimoX = puntos[0].X, maximoX = puntos[0].X;
            double minimoY = puntos[0].Y, maximoY = puntos[0].Y;
            foreach (clsPunto punto in puntos)
            {
                minimoX = Math.Min(minimoX, punto.X);
                maximoX = Math.Max(maximoX, punto.X);
                minimoY = Math.Min(minimoY, punto.Y);
                maximoY = Math.Max(maximoY, punto.Y);
            }

            double rangoX = Math.Max(maximoX - minimoX, 1e-9);
            double rangoY = Math.Max(maximoY - minimoY, 1e-9);
            double rangoMayor = Math.Max(rangoX, rangoY);
            if (rangoMayor <= 1e-9)
            {
                rangoX = rangoY = 2.0;
            }

            double anchoUtil = Math.Max(area.Width - 2 * intMargen, 40);
            double altoUtil = Math.Max(area.Height - 2 * intMargen, 40);
            doubleEscala = Math.Min(anchoUtil / Math.Max(rangoX, rangoMayor * 0.05),
                                    altoUtil / Math.Max(rangoY, rangoMayor * 0.05));
            doubleCentroX = (minimoX + maximoX) / 2.0;
            doubleCentroY = (minimoY + maximoY) / 2.0;
        }

        private PointF APixel(clsPunto punto)
        {
            return new PointF(
                (float)(rectArea.Left + rectArea.Width / 2.0 + (punto.X - doubleCentroX) * doubleEscala),
                (float)(rectArea.Top + rectArea.Height / 2.0 - (punto.Y - doubleCentroY) * doubleEscala));
        }

        private void DibujarCuadricula(Graphics grafico, Rectangle area)
        {
            double mitadAncho = area.Width / 2.0 / doubleEscala;
            double mitadAlto = area.Height / 2.0 / doubleEscala;
            double minimoX = doubleCentroX - mitadAncho, maximoX = doubleCentroX + mitadAncho;
            double minimoY = doubleCentroY - mitadAlto, maximoY = doubleCentroY + mitadAlto;
            double paso = CalcularPasoCuadricula(Math.Max(maximoX - minimoX, maximoY - minimoY) / 10.0);

            using (Pen lapizCuadricula = new Pen(colorCuadricula, 1F))
            using (Pen lapizEjes = new Pen(colorEjes, 1.5F))
            using (Brush brochaTexto = new SolidBrush(colorTextoSecundario))
            {
                double inicioX = Math.Ceiling(minimoX / paso) * paso;
                for (int i = 0; i <= intMaximoLineasCuadricula && inicioX + i * paso <= maximoX; i++)
                {
                    double valorX = Math.Round((inicioX + i * paso) / paso) * paso;
                    float pixelX = APixel(new clsPunto(valorX, 0)).X;
                    grafico.DrawLine(Math.Abs(valorX) < paso / 2 ? lapizEjes : lapizCuadricula, pixelX, area.Top, pixelX, area.Bottom);
                    grafico.DrawString(clsConversorNumerico.Formatear(valorX), fntPequena, brochaTexto, pixelX + 2, area.Bottom - 16);
                }

                double inicioY = Math.Ceiling(minimoY / paso) * paso;
                for (int i = 0; i <= intMaximoLineasCuadricula && inicioY + i * paso <= maximoY; i++)
                {
                    double valorY = Math.Round((inicioY + i * paso) / paso) * paso;
                    float pixelY = APixel(new clsPunto(0, valorY)).Y;
                    grafico.DrawLine(Math.Abs(valorY) < paso / 2 ? lapizEjes : lapizCuadricula, area.Left, pixelY, area.Right, pixelY);
                    grafico.DrawString(clsConversorNumerico.Formatear(valorY), fntPequena, brochaTexto, area.Left + 2, pixelY - 14);
                }
            }
        }

        private static double CalcularPasoCuadricula(double pasoAproximado)
        {
            if (pasoAproximado <= 0.0) return 1.0;
            double potencia = Math.Pow(10, Math.Floor(Math.Log10(pasoAproximado)));
            double fraccion = pasoAproximado / potencia;
            double fraccionRedonda = fraccion < 1.5 ? 1 : fraccion < 3 ? 2 : fraccion < 7 ? 5 : 10;
            return fraccionRedonda * potencia;
        }

        private static void DibujarProlongacion(Graphics grafico, PointF pixelA, PointF pixelB)
        {
            float direccionX = pixelB.X - pixelA.X;
            float direccionY = pixelB.Y - pixelA.Y;
            float longitud = (float)Math.Sqrt(direccionX * direccionX + direccionY * direccionY);
            if (longitud < 0.5F) return;

            float extension = 5000F / longitud;
            PointF inicio = new PointF(pixelA.X - direccionX * extension, pixelA.Y - direccionY * extension);
            PointF fin = new PointF(pixelB.X + direccionX * extension, pixelB.Y + direccionY * extension);
            using (Pen lapizProlongacion = new Pen(Color.FromArgb(120, colorSegmento), 1F) { DashStyle = DashStyle.Dot })
            {
                grafico.DrawLine(lapizProlongacion, inicio, fin);
            }
        }

        private static void DibujarAnguloRecto(Graphics grafico, PointF pixelQ, PointF pixelB, PointF pixelP)
        {
            PointF direccionSegmento = Normalizar(pixelB.X - pixelQ.X, pixelB.Y - pixelQ.Y);
            PointF direccionObstaculo = Normalizar(pixelP.X - pixelQ.X, pixelP.Y - pixelQ.Y);
            if (direccionSegmento.IsEmpty || direccionObstaculo.IsEmpty) return;

            const float tamano = 12F;
            PointF[] esquina =
            {
                new PointF(pixelQ.X + direccionSegmento.X * tamano, pixelQ.Y + direccionSegmento.Y * tamano),
                new PointF(pixelQ.X + (direccionSegmento.X + direccionObstaculo.X) * tamano, pixelQ.Y + (direccionSegmento.Y + direccionObstaculo.Y) * tamano),
                new PointF(pixelQ.X + direccionObstaculo.X * tamano, pixelQ.Y + direccionObstaculo.Y * tamano)
            };
            using (Pen lapizAngulo = new Pen(colorTextoSecundario, 1.2F))
            {
                grafico.DrawLines(lapizAngulo, esquina);
            }
        }

        private static PointF Normalizar(float componenteX, float componenteY)
        {
            float longitud = (float)Math.Sqrt(componenteX * componenteX + componenteY * componenteY);
            return longitud < 0.5F ? PointF.Empty : new PointF(componenteX / longitud, componenteY / longitud);
        }

        private void DibujarEtiquetaDistancia(Graphics grafico, PointF pixelP, PointF pixelQ, double distanciaMinima)
        {
            PointF puntoMedio = new PointF((pixelP.X + pixelQ.X) / 2F, (pixelP.Y + pixelQ.Y) / 2F);
            DibujarTextoConFondo(grafico, "d = " + clsConversorNumerico.Formatear(distanciaMinima), colorObstaculo,
                                 new PointF(puntoMedio.X + 8F, puntoMedio.Y - 10F));
        }

        private void DibujarPunto(Graphics grafico, PointF centro, Color color, string etiqueta, PointF desplazamiento)
        {
            RectangleF circulo = new RectangleF(centro.X - intRadioPunto, centro.Y - intRadioPunto, intRadioPunto * 2, intRadioPunto * 2);
            using (Brush brochaPunto = new SolidBrush(color))
            using (Pen lapizBorde = new Pen(Color.White, 2F))
            {
                grafico.FillEllipse(brochaPunto, circulo);
                grafico.DrawEllipse(lapizBorde, circulo);
            }
            DibujarTextoConFondo(grafico, etiqueta, color, new PointF(centro.X + desplazamiento.X, centro.Y + desplazamiento.Y));
        }

        private void DibujarTextoConFondo(Graphics grafico, string texto, Color color, PointF posicion)
        {
            SizeF tamanoTexto = grafico.MeasureString(texto, fntEtiqueta);
            RectangleF fondo = new RectangleF(posicion.X - 3, posicion.Y - 1, tamanoTexto.Width + 4, tamanoTexto.Height + 1);
            using (Brush brochaFondo = new SolidBrush(Color.FromArgb(220, Color.White)))
            using (Brush brochaTexto = new SolidBrush(color))
            {
                grafico.FillRectangle(brochaFondo, fondo);
                grafico.DrawString(texto, fntEtiqueta, brochaTexto, posicion);
            }
        }

        private void DibujarLeyenda(Graphics grafico, Rectangle area)
        {
            string[] textos = { "A  Punto inicial", "B  Punto final", "P  Obstaculo", "Q  Punto mas cercano", "AB Trayectoria", "PQ Distancia minima" };
            Color[] colores = { colorPuntoA, colorPuntoB, colorObstaculo, colorPuntoQ, colorSegmento, colorObstaculo };
            const int altoFila = 20;
            Rectangle caja = new Rectangle(area.Right - 190, area.Top + 10, 180, textos.Length * altoFila + 12);

            using (Brush brochaFondo = new SolidBrush(Color.FromArgb(235, Color.White)))
            using (Pen lapizBorde = new Pen(colorCuadricula, 1F))
            using (Brush brochaTexto = new SolidBrush(Color.FromArgb(30, 41, 59)))
            {
                grafico.FillRectangle(brochaFondo, caja);
                grafico.DrawRectangle(lapizBorde, caja);

                for (int i = 0; i < textos.Length; i++)
                {
                    int filaY = caja.Top + 8 + i * altoFila;
                    using (Brush brochaColor = new SolidBrush(colores[i]))
                    using (Pen lapizColor = new Pen(colores[i], 3F))
                    {
                        if (i < 4)
                        {
                            grafico.FillEllipse(brochaColor, caja.Left + 12, filaY + 3, 10, 10);
                        }
                        else
                        {
                            lapizColor.DashStyle = i == 5 ? DashStyle.Dash : DashStyle.Solid;
                            grafico.DrawLine(lapizColor, caja.Left + 8, filaY + 8, caja.Left + 26, filaY + 8);
                        }
                    }
                    grafico.DrawString(textos[i], fntPequena, brochaTexto, caja.Left + 34, filaY);
                }
            }
        }
    }
}
