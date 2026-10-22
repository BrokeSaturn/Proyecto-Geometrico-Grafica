using System;
using System.Globalization;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Modelos
{
    public class clsPunto2D
    {
        private readonly double dblX;
        private readonly double dblY;

        public clsPunto2D(double dblXInicial, double dblYInicial)
        {
            dblX = dblXInicial;
            dblY = dblYInicial;
        }

        public double X
        {
            get { return dblX; }
        }

        public double Y
        {
            get { return dblY; }
        }

        public bool EsIgualA(clsPunto2D ptoOtro, double dblTolerancia)
        {
            return Math.Abs(dblX - ptoOtro.X) <= dblTolerancia && Math.Abs(dblY - ptoOtro.Y) <= dblTolerancia;
        }

        public override string ToString()
        {
            return "(" + dblX.ToString("0.##", CultureInfo.InvariantCulture) + ", " +
                   dblY.ToString("0.##", CultureInfo.InvariantCulture) + ")";
        }
    }
}
