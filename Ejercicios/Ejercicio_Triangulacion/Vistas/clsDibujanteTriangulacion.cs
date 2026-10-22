using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using WindowsFormsApp2.Ejercicios.Triangulacion.Modelos;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Vistas
{
    public class clsDibujanteTriangulacion
    {
        // pixeles por unidad del plano
        private const float sngEscala = 40F;
        private const float sngMargen = 30F;
        private const float sngRadioVertice = 5F;

        private static readonly Color[] arrColoresTriangulo =
        {
            Color.FromArgb(37, 99, 235), Color.FromArgb(22, 163, 74), Color.FromArgb(234, 88, 12),
            Color.FromArgb(124, 58, 237), Color.FromArgb(219, 39, 119), Color.FromArgb(13, 148, 136),
            Color.FromArgb(202, 138, 4), Color.FromArgb(220, 38, 38), Color.FromArgb(79, 70, 229),
            Color.FromArgb(101, 163, 13)
        };

        private static readonly Color clrCuadricula = Color.FromArgb(232, 236, 241);
        private static readonly Color clrEjes = Color.FromArgb(148, 163, 184);
        private static readonly Color clrBorde = Color.FromArgb(30, 41, 59);
        private static readonly Color clrDiagonal = Color.FromArgb(71, 85, 105);
        private static readonly Color clrVertice = Color.FromArgb(220, 38, 38);
        private static readonly Color clrTexto = Color.FromArgb(100, 116, 139);

        private readonly Font fntEtiqueta = new Font("Segoe UI", 9F, FontStyle.Bold);
        private readonly Font fntPequena = new Font("Segoe UI", 7.5F);

        // eje Y de pantalla crece hacia abajo: se invierte
        public PointF ConvertirAPantalla(clsPunto2D ptoMundo, Rectangle rectArea)
        {
            return new PointF(rectArea.Left + sngMargen + (float)ptoMundo.X * sngEscala,
                              rectArea.Bottom - sngMargen - (float)ptoMundo.Y * sngEscala);
        }

        public clsPunto2D ConvertirAMundo(Point ptoPantalla, Rectangle rectArea, bool blnAjustarCuadricula)
        {
            double dblX = (ptoPantalla.X - rectArea.Left - sngMargen) / sngEscala;
            double dblY = (rectArea.Bottom - sngMargen - ptoPantalla.Y) / sngEscala;

            // ajuste a la cuadricula de media unidad
            if (blnAjustarCuadricula) return new clsPunto2D(Math.Round(dblX * 2) / 2, Math.Round(dblY * 2) / 2);
            return new clsPunto2D(Math.Round(dblX, 2), Math.Round(dblY, 2));
        }

        public void Dibujar(Graphics grfLienzo, Rectangle rectArea, clsPoligono objPoligono,
                            clsResultadoTriangulacion objResultado, int intTriangulosVisibles)
        {
            grfLienzo.SmoothingMode = SmoothingMode.AntiAlias;
            grfLienzo.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            DibujarCuadricula(grfLienzo, rectArea);
            if (objResultado != null && objResultado.BlnExito)
            {
                DibujarTriangulos(grfLienzo, rectArea, objResultado, intTriangulosVisibles);
            }
            DibujarAristas(grfLienzo, rectArea, objPoligono);
            DibujarVertices(grfLienzo, rectArea, objPoligono);

            if (objPoligono.IntCantidadVertices == 0)
            {
                using (StringFormat objFormato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (Brush brhTexto = new SolidBrush(clrTexto))
                {
                    grfLienzo.DrawString("Haga clic para agregar vertices o use Cargar ejemplo", fntEtiqueta, brhTexto, rectArea, objFormato);
                }
            }
        }

        private void DibujarCuadricula(Graphics grfLienzo, Rectangle rectArea)
        {
            using (Pen penCuadricula = new Pen(clrCuadricula, 1F))
            using (Pen penEjes = new Pen(clrEjes, 1.5F))
            using (Brush brhTexto = new SolidBrush(clrTexto))
            {
                int intUnidadesX = (int)((rectArea.Width - sngMargen) / sngEscala);
                int intUnidadesY = (int)((rectArea.Height - sngMargen) / sngEscala);

                for (int intX = 0; intX <= intUnidadesX; intX++)
                {
                    PointF ptoBase = ConvertirAPantalla(new clsPunto2D(intX, 0), rectArea);
                    grfLienzo.DrawLine(intX == 0 ? penEjes : penCuadricula, ptoBase.X, rectArea.Top, ptoBase.X, rectArea.Bottom);
                    grfLienzo.DrawString(intX.ToString(), fntPequena, brhTexto, ptoBase.X + 2, ptoBase.Y + 2);
                }
                for (int intY = 0; intY <= intUnidadesY; intY++)
                {
                    PointF ptoBase = ConvertirAPantalla(new clsPunto2D(0, intY), rectArea);
                    grfLienzo.DrawLine(intY == 0 ? penEjes : penCuadricula, rectArea.Left, ptoBase.Y, rectArea.Right, ptoBase.Y);
                    if (intY > 0) grfLienzo.DrawString(intY.ToString(), fntPequena, brhTexto, ptoBase.X - 18, ptoBase.Y - 7);
                }
            }
        }

        private void DibujarTriangulos(Graphics grfLienzo, Rectangle rectArea, clsResultadoTriangulacion objResultado, int intTriangulosVisibles)
        {
            int intLimite = Math.Min(intTriangulosVisibles, objResultado.LstTriangulos.Count);
            using (Pen penDiagonal = new Pen(clrDiagonal, 1.5F) { DashStyle = DashStyle.Dash })
            using (Brush brhTexto = new SolidBrush(clrBorde))
            {
                for (int intI = 0; intI < intLimite; intI++)
                {
                    clsTriangulo objTriangulo = objResultado.LstTriangulos[intI];
                    PointF[] arrPuntos =
                    {
                        ConvertirAPantalla(objTriangulo.PtoA, rectArea),
                        ConvertirAPantalla(objTriangulo.PtoB, rectArea),
                        ConvertirAPantalla(objTriangulo.PtoC, rectArea)
                    };

                    Color clrBase = arrColoresTriangulo[intI % arrColoresTriangulo.Length];
                    using (Brush brhRelleno = new SolidBrush(Color.FromArgb(90, clrBase)))
                    {
                        grfLienzo.FillPolygon(brhRelleno, arrPuntos);
                    }

                    // diagonales: lados del triangulo que no son aristas
                    DibujarDiagonalSiCorresponde(grfLienzo, penDiagonal, objResultado, objTriangulo.IntIndiceA, objTriangulo.IntIndiceB, arrPuntos[0], arrPuntos[1]);
                    DibujarDiagonalSiCorresponde(grfLienzo, penDiagonal, objResultado, objTriangulo.IntIndiceB, objTriangulo.IntIndiceC, arrPuntos[1], arrPuntos[2]);
                    DibujarDiagonalSiCorresponde(grfLienzo, penDiagonal, objResultado, objTriangulo.IntIndiceC, objTriangulo.IntIndiceA, arrPuntos[2], arrPuntos[0]);

                    PointF ptoCentro = new PointF((arrPuntos[0].X + arrPuntos[1].X + arrPuntos[2].X) / 3F,
                                                  (arrPuntos[0].Y + arrPuntos[1].Y + arrPuntos[2].Y) / 3F);
                    string strNombre = "T" + (intI + 1);
                    SizeF objTamano = grfLienzo.MeasureString(strNombre, fntEtiqueta);
                    grfLienzo.DrawString(strNombre, fntEtiqueta, brhTexto, ptoCentro.X - objTamano.Width / 2, ptoCentro.Y - objTamano.Height / 2);
                }
            }
        }

        private static void DibujarDiagonalSiCorresponde(Graphics grfLienzo, Pen penDiagonal, clsResultadoTriangulacion objResultado,
                                                         int intIndiceA, int intIndiceB, PointF ptoA, PointF ptoB)
        {
            if (!objResultado.EsAristaDelPoligono(intIndiceA, intIndiceB)) grfLienzo.DrawLine(penDiagonal, ptoA, ptoB);
        }

        private void DibujarAristas(Graphics grfLienzo, Rectangle rectArea, clsPoligono objPoligono)
        {
            IReadOnlyList<clsPunto2D> lstVertices = objPoligono.LstVertices;
            if (lstVertices.Count < 2) return;

            using (Pen penBorde = new Pen(clrBorde, 2.5F))
            using (Pen penCierre = new Pen(clrEjes, 1.5F) { DashStyle = DashStyle.Dot })
            {
                for (int intI = 0; intI < lstVertices.Count - 1; intI++)
                {
                    grfLienzo.DrawLine(penBorde, ConvertirAPantalla(lstVertices[intI], rectArea), ConvertirAPantalla(lstVertices[intI + 1], rectArea));
                }

                // arista de cierre: solida si esta cerrado, punteada si no
                PointF ptoUltimo = ConvertirAPantalla(lstVertices[lstVertices.Count - 1], rectArea);
                PointF ptoPrimero = ConvertirAPantalla(lstVertices[0], rectArea);
                grfLienzo.DrawLine(objPoligono.BlnCerrado ? penBorde : penCierre, ptoUltimo, ptoPrimero);
            }
        }

        private void DibujarVertices(Graphics grfLienzo, Rectangle rectArea, clsPoligono objPoligono)
        {
            using (Brush brhVertice = new SolidBrush(clrVertice))
            using (Brush brhTexto = new SolidBrush(clrBorde))
            using (Brush brhFondo = new SolidBrush(Color.FromArgb(210, Color.White)))
            using (Pen penContorno = new Pen(Color.White, 1.5F))
            {
                for (int intI = 0; intI < objPoligono.IntCantidadVertices; intI++)
                {
                    PointF ptoVertice = ConvertirAPantalla(objPoligono.LstVertices[intI], rectArea);
                    RectangleF rectCirculo = new RectangleF(ptoVertice.X - sngRadioVertice, ptoVertice.Y - sngRadioVertice,
                                                            sngRadioVertice * 2, sngRadioVertice * 2);
                    grfLienzo.FillEllipse(brhVertice, rectCirculo);
                    grfLienzo.DrawEllipse(penContorno, rectCirculo);

                    string strEtiqueta = "V" + intI + " " + objPoligono.LstVertices[intI];
                    SizeF objTamano = grfLienzo.MeasureString(strEtiqueta, fntPequena);
                    RectangleF rectFondo = new RectangleF(ptoVertice.X + 7, ptoVertice.Y - 18, objTamano.Width, objTamano.Height);
                    grfLienzo.FillRectangle(brhFondo, rectFondo);
                    grfLienzo.DrawString(strEtiqueta, fntPequena, brhTexto, rectFondo.Location);
                }
            }
        }
    }
}
