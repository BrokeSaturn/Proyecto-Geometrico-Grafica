namespace WindowsFormsApp2
{
    // Coordenada bidimensional
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

        public override string ToString()
        {
            return "(" + dblX.ToString("0.##") + ", " + dblY.ToString("0.##") + ")";
        }
    }
}
