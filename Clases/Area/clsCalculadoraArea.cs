using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp2
{
    /// <summary>
    /// Calcula el area con la formula de Gauss (determinantes 2x2).
    /// </summary>
    public class clsCalculadoraArea
    {
        // Determinante | x1 x2 |
        //              | y1 y2 |  = x1*y2 - x2*y1
        public double Determinante(clsPunto objP1, clsPunto objP2)
        {
            return objP1.X * objP2.Y - objP2.X * objP1.Y;
        }

        // Suma de todos los determinantes (el ultimo vertice se une con el primero)
        public double CalcularSuma(List<clsPunto> lstVertices)
        {
            double dblSuma = 0;
            int intN = lstVertices.Count;

            for (int intI = 0; intI < intN; intI++)
            {
                // El operador % hace que despues del ultimo vuelva al indice 0
                int intSiguiente = (intI + 1) % intN;
                dblSuma += Determinante(lstVertices[intI], lstVertices[intSiguiente]);
            }
            return dblSuma;
        }

        // Area = |suma| / 2 (el valor absoluto elimina el efecto del sentido)
        public double CalcularArea(List<clsPunto> lstVertices)
        {
            return Math.Abs(CalcularSuma(lstVertices)) / 2.0;
        }

        // Suma > 0 -> antihorario, suma < 0 -> horario
        public string ObtenerSentido(List<clsPunto> lstVertices)
        {
            double dblSuma = CalcularSuma(lstVertices);
            if (dblSuma > 0) return "antihorario";
            if (dblSuma < 0) return "horario";
            return "indefinido (area cero)";
        }

        // Texto didactico con cada determinante
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

                objTexto.AppendLine("V" + (intI + 1) + " -> V" + (intSiguiente + 1) + ":  (" +
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

