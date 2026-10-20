namespace WindowsFormsApp2.Distancia
{
    public class clsResultadoProyeccion
    {
        public clsPunto PuntoMasCercano { get; }
        public clsPunto VectorAB { get; }
        public clsPunto VectorAP { get; }
        public double ParametroOriginal { get; }
        public double ParametroRestringido { get; }
        public double DistanciaMinima { get; }
        public TipoProyeccion Tipo { get; }

        public clsResultadoProyeccion(clsPunto puntoMasCercano, clsPunto vectorAB, clsPunto vectorAP,
                                   double parametroOriginal, double parametroRestringido,
                                   double distanciaMinima, TipoProyeccion tipo)
        {
            PuntoMasCercano = puntoMasCercano;
            VectorAB = vectorAB;
            VectorAP = vectorAP;
            ParametroOriginal = parametroOriginal;
            ParametroRestringido = parametroRestringido;
            DistanciaMinima = distanciaMinima;
            Tipo = tipo;
        }

        // Pertenencia al segmento
        public bool PerteneceAlSegmento
        {
            get { return ParametroRestringido >= 0.0 && ParametroRestringido <= 1.0; }
        }

        public string ObtenerDescripcionTipo()
        {
            switch (Tipo)
            {
                case TipoProyeccion.Interior:
                    return "Proyeccion interior (0 <= t* <= 1)";
                case TipoProyeccion.ExtremoA:
                    return "Extremo A (t* < 0, Q = A)";
                case TipoProyeccion.ExtremoB:
                    return "Extremo B (t* > 1, Q = B)";
                default:
                    return "Segmento degenerado (A = B)";
            }
        }
    }
}
