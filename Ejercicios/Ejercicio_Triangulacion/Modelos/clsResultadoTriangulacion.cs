using System;
using System.Collections.Generic;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Modelos
{
    public class clsResultadoTriangulacion
    {
        private readonly List<clsTriangulo> lstTriangulos = new List<clsTriangulo>();
        private readonly List<int> lstIndicesPoligono = new List<int>();

        public List<clsTriangulo> LstTriangulos { get { return lstTriangulos; } }
        public List<int> LstIndicesPoligono { get { return lstIndicesPoligono; } }
        public int IntCantidadVertices { get; set; }
        public double DblAreaPoligono { get; set; }
        public double DblAreaTriangulos { get; set; }
        public bool BlnAreaConservada { get; set; }
        public bool BlnEsConvexo { get; set; }
        public bool BlnOrientacionHoraria { get; set; }
        public string StrMensajeError { get; set; }
        public string StrAdvertencia { get; set; }

        public bool BlnExito
        {
            get { return string.IsNullOrEmpty(StrMensajeError); }
        }

        // T = n - 2
        public int IntTriangulosEsperados
        {
            get { return IntCantidadVertices >= 3 ? IntCantidadVertices - 2 : 0; }
        }

        public double DblDiferencia
        {
            get { return Math.Abs(DblAreaPoligono - DblAreaTriangulos); }
        }

        // arista del poligono si los indices son consecutivos
        public bool EsAristaDelPoligono(int intIndiceA, int intIndiceB)
        {
            int intCantidad = lstIndicesPoligono.Count;
            for (int intI = 0; intI < intCantidad; intI++)
            {
                int intActual = lstIndicesPoligono[intI];
                int intSiguiente = lstIndicesPoligono[(intI + 1) % intCantidad];
                if ((intActual == intIndiceA && intSiguiente == intIndiceB) ||
                    (intActual == intIndiceB && intSiguiente == intIndiceA))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
