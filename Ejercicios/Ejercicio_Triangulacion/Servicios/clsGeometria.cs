using System;
using System.Collections.Generic;
using WindowsFormsApp2.Ejercicios.Triangulacion.Modelos;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Servicios
{
    public static class clsGeometria
    {
        // tolerancia para considerar un valor como cero
        public const double dblTolerancia = 1e-9;

        // orientacion: >0 antihorario, <0 horario, 0 colineales
        public static double dblOrientacion(clsPunto2D ptoA, clsPunto2D ptoB, clsPunto2D ptoC)
        {
            return (ptoB.X - ptoA.X) * (ptoC.Y - ptoA.Y) - (ptoB.Y - ptoA.Y) * (ptoC.X - ptoA.X);
        }

        // area con signo por formula del zapatero
        public static double dblAreaConSigno(IReadOnlyList<clsPunto2D> lstVertices)
        {
            double dblSuma = 0.0;
            int intCantidad = lstVertices.Count;
            for (int intI = 0; intI < intCantidad; intI++)
            {
                clsPunto2D ptoActual = lstVertices[intI];
                clsPunto2D ptoSiguiente = lstVertices[(intI + 1) % intCantidad];
                dblSuma += ptoActual.X * ptoSiguiente.Y - ptoSiguiente.X * ptoActual.Y;
            }
            return dblSuma / 2.0;
        }

        public static double dblAreaZapatero(IReadOnlyList<clsPunto2D> lstVertices)
        {
            return Math.Abs(dblAreaConSigno(lstVertices));
        }

        // dentro si los tres productos cruzados tienen igual signo
        public static bool blnPuntoEnTriangulo(clsPunto2D ptoP, clsPunto2D ptoA, clsPunto2D ptoB, clsPunto2D ptoC)
        {
            double dblD1 = dblOrientacion(ptoA, ptoB, ptoP);
            double dblD2 = dblOrientacion(ptoB, ptoC, ptoP);
            double dblD3 = dblOrientacion(ptoC, ptoA, ptoP);

            bool blnHayNegativo = dblD1 < -dblTolerancia || dblD2 < -dblTolerancia || dblD3 < -dblTolerancia;
            bool blnHayPositivo = dblD1 > dblTolerancia || dblD2 > dblTolerancia || dblD3 > dblTolerancia;

            // el borde cuenta como dentro
            return !(blnHayNegativo && blnHayPositivo);
        }

        public static bool blnSegmentosSeIntersecan(clsPunto2D ptoP1, clsPunto2D ptoP2, clsPunto2D ptoQ1, clsPunto2D ptoQ2)
        {
            int intO1 = intSigno(dblOrientacion(ptoP1, ptoP2, ptoQ1));
            int intO2 = intSigno(dblOrientacion(ptoP1, ptoP2, ptoQ2));
            int intO3 = intSigno(dblOrientacion(ptoQ1, ptoQ2, ptoP1));
            int intO4 = intSigno(dblOrientacion(ptoQ1, ptoQ2, ptoP2));

            if (intO1 != intO2 && intO3 != intO4) return true;

            // casos colineales: punto sobre el otro segmento
            if (intO1 == 0 && blnEstaEnSegmento(ptoQ1, ptoP1, ptoP2)) return true;
            if (intO2 == 0 && blnEstaEnSegmento(ptoQ2, ptoP1, ptoP2)) return true;
            if (intO3 == 0 && blnEstaEnSegmento(ptoP1, ptoQ1, ptoQ2)) return true;
            if (intO4 == 0 && blnEstaEnSegmento(ptoP2, ptoQ1, ptoQ2)) return true;
            return false;
        }

        // convexo si todos los giros tienen el mismo signo
        public static bool blnEsConvexo(IReadOnlyList<clsPunto2D> lstVertices)
        {
            int intCantidad = lstVertices.Count;
            bool blnHayPositivo = false;
            bool blnHayNegativo = false;
            for (int intI = 0; intI < intCantidad; intI++)
            {
                double dblGiro = dblOrientacion(lstVertices[intI], lstVertices[(intI + 1) % intCantidad],
                                                lstVertices[(intI + 2) % intCantidad]);
                if (dblGiro > dblTolerancia) blnHayPositivo = true;
                if (dblGiro < -dblTolerancia) blnHayNegativo = true;
            }
            return !(blnHayPositivo && blnHayNegativo);
        }

        private static int intSigno(double dblValor)
        {
            if (dblValor > dblTolerancia) return 1;
            if (dblValor < -dblTolerancia) return -1;
            return 0;
        }

        private static bool blnEstaEnSegmento(clsPunto2D ptoP, clsPunto2D ptoA, clsPunto2D ptoB)
        {
            return ptoP.X <= Math.Max(ptoA.X, ptoB.X) + dblTolerancia && ptoP.X >= Math.Min(ptoA.X, ptoB.X) - dblTolerancia &&
                   ptoP.Y <= Math.Max(ptoA.Y, ptoB.Y) + dblTolerancia && ptoP.Y >= Math.Min(ptoA.Y, ptoB.Y) - dblTolerancia;
        }
    }
}
