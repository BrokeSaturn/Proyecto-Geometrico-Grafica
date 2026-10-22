using System;
using WindowsFormsApp2.Ejercicios.DistanciaMinima.Modelos;

namespace WindowsFormsApp2.Ejercicios.DistanciaMinima.Servicios
{
    public class clsCalculadoraGeometrica
    {
        public clsResultadoProyeccion CalcularProyeccion(clsSegmento segmento, clsPunto puntoObstaculo)
        {
            if (segmento == null) throw new ArgumentNullException(nameof(segmento));
            if (puntoObstaculo == null) throw new ArgumentNullException(nameof(puntoObstaculo));

            clsPunto puntoInicial = segmento.PuntoInicial;
            clsPunto vectorAB = segmento.ObtenerVector();

            // Vector hacia el obstaculo
            clsPunto vectorAP = new clsPunto(puntoObstaculo.X - puntoInicial.X, puntoObstaculo.Y - puntoInicial.Y);

            // Segmento degenerado
            if (segmento.EsDegenerado)
            {
                return new clsResultadoProyeccion(puntoInicial, vectorAB, vectorAP, double.NaN, 0.0,
                                               puntoInicial.DistanciaHasta(puntoObstaculo),
                                               TipoProyeccion.SegmentoDegenerado);
            }

            // Parametro de proyeccion
            double productoPunto = vectorAP.X * vectorAB.X + vectorAP.Y * vectorAB.Y;
            double parametroOriginal = productoPunto / segmento.LongitudCuadrada;

            // Restriccion al segmento
            double parametroRestringido = Math.Max(0.0, Math.Min(1.0, parametroOriginal));

            // Punto mas cercano
            clsPunto puntoMasCercano = segmento.ObtenerPunto(parametroRestringido);

            // Distancia minima
            double distanciaMinima = puntoMasCercano.DistanciaHasta(puntoObstaculo);

            return new clsResultadoProyeccion(puntoMasCercano, vectorAB, vectorAP, parametroOriginal,
                                           parametroRestringido, distanciaMinima,
                                           ClasificarProyeccion(parametroOriginal));
        }

        private static TipoProyeccion ClasificarProyeccion(double parametroOriginal)
        {
            if (parametroOriginal < 0.0) return TipoProyeccion.ExtremoA;
            if (parametroOriginal > 1.0) return TipoProyeccion.ExtremoB;
            return TipoProyeccion.Interior;
        }
    }
}
