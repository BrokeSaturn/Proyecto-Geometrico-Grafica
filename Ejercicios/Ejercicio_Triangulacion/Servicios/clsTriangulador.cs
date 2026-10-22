using System;
using System.Collections.Generic;
using WindowsFormsApp2.Ejercicios.Triangulacion.Modelos;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Servicios
{
    public class clsTriangulador
    {
        // tolerancia numerica para comparar areas
        public const double dblToleranciaArea = 1e-6;

        private readonly clsValidadorPoligono objValidador = new clsValidadorPoligono();

        public clsResultadoTriangulacion Triangular(IReadOnlyList<clsPunto2D> lstVertices)
        {
            clsResultadoTriangulacion objResultado = new clsResultadoTriangulacion();
            objResultado.IntCantidadVertices = lstVertices.Count;

            List<int> lstIndices;
            string strMensajeError;
            string strAdvertencia;
            bool blnOrientacionHoraria;
            if (!objValidador.Validar(lstVertices, out lstIndices, out strMensajeError, out strAdvertencia, out blnOrientacionHoraria))
            {
                objResultado.StrMensajeError = strMensajeError;
                return objResultado;
            }

            List<clsPunto2D> lstValidos = clsValidadorPoligono.ObtenerPuntos(lstVertices, lstIndices);
            objResultado.LstIndicesPoligono.AddRange(lstIndices);
            objResultado.IntCantidadVertices = lstIndices.Count;
            objResultado.BlnOrientacionHoraria = blnOrientacionHoraria;
            objResultado.StrAdvertencia = strAdvertencia;
            objResultado.BlnEsConvexo = clsGeometria.blnEsConvexo(lstValidos);
            objResultado.DblAreaPoligono = clsGeometria.dblAreaZapatero(lstValidos);

            List<int> lstRestantes = new List<int>(lstIndices);
            while (lstRestantes.Count > 3)
            {
                int intPosicionOreja = BuscarOreja(lstVertices, lstRestantes);

                // sin oreja: poligono invalido, salir
                if (intPosicionOreja < 0)
                {
                    objResultado.StrMensajeError = "No se encontro una oreja valida. Revise que el poligono sea simple.";
                    break;
                }

                objResultado.LstTriangulos.Add(CrearTriangulo(lstVertices, lstRestantes, intPosicionOreja));
                lstRestantes.RemoveAt(intPosicionOreja);
            }

            if (objResultado.BlnExito)
            {
                objResultado.LstTriangulos.Add(CrearTriangulo(lstVertices, lstRestantes, 1));
            }

            double dblSumaAreas = 0.0;
            foreach (clsTriangulo objTriangulo in objResultado.LstTriangulos) dblSumaAreas += objTriangulo.dblCalcularArea();
            objResultado.DblAreaTriangulos = dblSumaAreas;

            objResultado.BlnAreaConservada = objResultado.BlnExito &&
                                             objResultado.DblDiferencia < dblToleranciaArea &&
                                             objResultado.LstTriangulos.Count == objResultado.IntTriangulosEsperados;
            return objResultado;
        }

        public bool EsOrejaValida(IReadOnlyList<clsPunto2D> lstVertices, List<int> lstRestantes, int intPosicion)
        {
            int intCantidad = lstRestantes.Count;
            int intIndiceA = lstRestantes[(intPosicion - 1 + intCantidad) % intCantidad];
            int intIndiceB = lstRestantes[intPosicion];
            int intIndiceC = lstRestantes[(intPosicion + 1) % intCantidad];
            clsPunto2D ptoA = lstVertices[intIndiceA];
            clsPunto2D ptoB = lstVertices[intIndiceB];
            clsPunto2D ptoC = lstVertices[intIndiceC];

            // B debe ser convexo (giro antihorario)
            if (clsGeometria.dblOrientacion(ptoA, ptoB, ptoC) <= clsGeometria.dblTolerancia) return false;

            // ningun otro vertice dentro del triangulo ABC
            foreach (int intIndice in lstRestantes)
            {
                if (intIndice == intIndiceA || intIndice == intIndiceB || intIndice == intIndiceC) continue;
                if (clsGeometria.blnPuntoEnTriangulo(lstVertices[intIndice], ptoA, ptoB, ptoC)) return false;
            }

            return EsDiagonalInterior(lstVertices, lstRestantes, intIndiceA, intIndiceC);
        }

        private int BuscarOreja(IReadOnlyList<clsPunto2D> lstVertices, List<int> lstRestantes)
        {
            for (int intPosicion = 0; intPosicion < lstRestantes.Count; intPosicion++)
            {
                if (EsOrejaValida(lstVertices, lstRestantes, intPosicion)) return intPosicion;
            }
            return -1;
        }

        // la diagonal AC no debe cruzar otras aristas
        private static bool EsDiagonalInterior(IReadOnlyList<clsPunto2D> lstVertices, List<int> lstRestantes, int intIndiceA, int intIndiceC)
        {
            int intCantidad = lstRestantes.Count;
            for (int intI = 0; intI < intCantidad; intI++)
            {
                int intInicio = lstRestantes[intI];
                int intFin = lstRestantes[(intI + 1) % intCantidad];
                if (intInicio == intIndiceA || intInicio == intIndiceC || intFin == intIndiceA || intFin == intIndiceC) continue;
                if (clsGeometria.blnSegmentosSeIntersecan(lstVertices[intIndiceA], lstVertices[intIndiceC],
                                                          lstVertices[intInicio], lstVertices[intFin]))
                {
                    return false;
                }
            }
            return true;
        }

        private static clsTriangulo CrearTriangulo(IReadOnlyList<clsPunto2D> lstVertices, List<int> lstRestantes, int intPosicion)
        {
            int intCantidad = lstRestantes.Count;
            int intIndiceA = lstRestantes[(intPosicion - 1 + intCantidad) % intCantidad];
            int intIndiceB = lstRestantes[intPosicion];
            int intIndiceC = lstRestantes[(intPosicion + 1) % intCantidad];
            return new clsTriangulo(lstVertices[intIndiceA], lstVertices[intIndiceB], lstVertices[intIndiceC],
                                    intIndiceA, intIndiceB, intIndiceC);
        }
    }
}
