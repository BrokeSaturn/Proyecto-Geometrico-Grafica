namespace WindowsFormsApp2
{
    /// <summary>
    /// Representa un punto (vertice) en el plano cartesiano.
    /// </summary>
    public class clsPunto
    {
        private double dblX;
        private double dblY;

        public clsPunto(double dblXInicial, double dblYInicial)
        {
            dblX = dblXInicial;
            dblY = dblYInicial;
        }

        public double X
        {
            get { return dblX; }
            set { dblX = value; }
        }

        public double Y
        {
            get { return dblY; }
            set { dblY = value; }
        }

        // Texto amigable para mostrar en el ListBox, ej: "(2.5, 3)"
        public override string ToString()
        {
            return "(" + dblX.ToString("0.##") + ", " + dblY.ToString("0.##") + ")";
        }
    }
}

