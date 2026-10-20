using System;

namespace WindowsFormsApp2.Distancia
{
    public class clsSegmento
    {
        public clsPunto PuntoInicial { get; }
        public clsPunto PuntoFinal { get; }

        public clsSegmento(clsPunto puntoInicial, clsPunto puntoFinal)
        {
            PuntoInicial = puntoInicial ?? throw new ArgumentNullException(nameof(puntoInicial));
            PuntoFinal = puntoFinal ?? throw new ArgumentNullException(nameof(puntoFinal));
        }

        // Vector del segmento
        public clsPunto ObtenerVector()
        {
            return new clsPunto(PuntoFinal.X - PuntoInicial.X, PuntoFinal.Y - PuntoInicial.Y);
        }

        // Norma al cuadrado
        public double LongitudCuadrada
        {
            get
            {
                clsPunto vectorSegmento = ObtenerVector();
                return vectorSegmento.X * vectorSegmento.X + vectorSegmento.Y * vectorSegmento.Y;
            }
        }

        // Segmento degenerado
        public bool EsDegenerado
        {
            get { return LongitudCuadrada <= 0.0; }
        }

        // Punto en el segmento
        public clsPunto ObtenerPunto(double parametro)
        {
            clsPunto vectorSegmento = ObtenerVector();
            return new clsPunto(PuntoInicial.X + parametro * vectorSegmento.X,
                             PuntoInicial.Y + parametro * vectorSegmento.Y);
        }
    }
}
