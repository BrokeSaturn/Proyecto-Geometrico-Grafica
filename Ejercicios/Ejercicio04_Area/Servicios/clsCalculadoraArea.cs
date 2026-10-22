using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp2.Ejercicios.Area.Modelos;

namespace WindowsFormsApp2.Ejercicios.Area.Servicios
{
    // Calculo del area usando determinantes 2x2 (Gauss)
    public class clsCalculadoraArea
    {
        // Determinante 2x2: x1*y2 - x2*y1
        public double Determinante(clsPunto objP1, clsPunto objP2)
        {
            return objP1.X * objP2.Y - objP2.X * objP1.Y;
        }

        // Suma ciclica de determinantes conectando el ultimo vertice al primero
        public double CalcularSuma(List<clsPunto> lstVertices)
        {
            double dblSuma = 0;
            int intN = lstVertices.Count;

            for (int intI = 0; intI < intN; intI++)
            {
                int intSiguiente = (intI + 1) % intN;
                dblSuma += Determinante(lstVertices[intI], lstVertices[intSiguiente]);
            }
            return dblSuma;
        }

        // Area = |suma| / 2
        public double CalcularArea(List<clsPunto> lstVertices)
        {
            return Math.Abs(CalcularSuma(lstVertices)) / 2.0;
        }

        // Sentido de giro segun el signo de la suma
        public string ObtenerSentido(List<clsPunto> lstVertices)
        {
            double dblSuma = CalcularSuma(lstVertices);
            if (dblSuma > 0) return "antihorario";
            if (dblSuma < 0) return "horario";
            return "indefinido (area cero)";
        }

        // Desglose de cada determinante para visualizacion
        public string ObtenerPasoAPaso(List<clsPunto> lstVertices)
        {
            StringBuilder objTexto = new StringBuilder();
            double dblSuma = 0;
            int intN = lstVertices.Count;

            objTexto.AppendLine("Formula: det = xi*yi+1 - xi+1*yi");
            objTexto.AppendLine("------------------------------------");

            for (int intI = 0; intI < intN; intI++)
            {
                int intSiguiente = (intI + 1) % intN;
                clsPunto objA = lstVertices[intI];
                clsPunto objB = lstVertices[intSiguiente];
                double dblDet = Determinante(objA, objB);
                dblSuma += dblDet;

                objTexto.AppendLine("V" + (intI + 1) + " -> V" + (intSiguiente + 1) + ": (" +
                    objA.X.ToString("0.###") + ")*(" + objB.Y.ToString("0.###") + ") - (" +
                    objB.X.ToString("0.###") + ")*(" + objA.Y.ToString("0.###") + ") = " +
                    dblDet.ToString("0.###"));
            }

            objTexto.AppendLine("------------------------------------");
            objTexto.AppendLine("Suma de determinantes = " + dblSuma.ToString("0.###"));
            objTexto.AppendLine("Area = |" + dblSuma.ToString("0.###") + "| / 2 = " +
                (Math.Abs(dblSuma) / 2.0).ToString("0.###"));
            objTexto.AppendLine("Sentido: " + ObtenerSentido(lstVertices));
            return objTexto.ToString();
        }
    }
}
