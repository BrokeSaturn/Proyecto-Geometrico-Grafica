using System;
using WindowsFormsApp2.Comun;

namespace WindowsFormsApp2.Ejercicios.DistanciaMinima.Modelos
{
    public class clsPunto
    {
        public double X { get; }
        public double Y { get; }

        public clsPunto(double coordenadaX, double coordenadaY)
        {
            X = coordenadaX;  
            Y = coordenadaY;
        }

        // Distancia euclidiana
        public double DistanciaHasta(clsPunto puntoDestino)
        {
            double diferenciaX = puntoDestino.X - X;
            double diferenciaY = puntoDestino.Y - Y;
            return Math.Sqrt(diferenciaX * diferenciaX + diferenciaY * diferenciaY);
        }

        public string ObtenerCoordenadas()
        {
            return "(" + clsConversorNumerico.Formatear(X) + ", " + clsConversorNumerico.Formatear(Y) + ")";
        }

        public override string ToString()
        {
            return ObtenerCoordenadas();
        }
    }
}
