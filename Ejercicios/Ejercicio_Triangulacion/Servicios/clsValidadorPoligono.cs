using System.Collections.Generic;
using WindowsFormsApp2.Ejercicios.Triangulacion.Modelos;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Servicios
{
    public class clsValidadorPoligono
    {
        // devuelve los indices validos en orden antihorario
        public bool Validar(IReadOnlyList<clsPunto2D> lstVertices, out List<int> lstIndices, out string strMensajeError,
                            out string strAdvertencia, out bool blnOrientacionHoraria)
        {
            lstIndices = new List<int>();
            strMensajeError = string.Empty;
            strAdvertencia = string.Empty;
            blnOrientacionHoraria = false;

            int intCantidad = lstVertices.Count;
            if (intCantidad < 3)
            {
                strMensajeError = "Se necesitan al menos 3 vertices (hay " + intCantidad + ").";
                return false;
            }

            if (!ValidarRepetidos(lstVertices, out strMensajeError)) return false;
            if (!ValidarAutointerseccion(lstVertices, out strMensajeError)) return false;

            for (int intI = 0; intI < intCantidad; intI++) lstIndices.Add(intI);

            List<int> lstOmitidos;
            if (!EliminarColineales(lstVertices, lstIndices, out lstOmitidos, out strMensajeError)) return false;

            List<clsPunto2D> lstValidos = ObtenerPuntos(lstVertices, lstIndices);
            double dblAreaConSigno = clsGeometria.dblAreaConSigno(lstValidos);
            if (lstIndices.Count < 3 || System.Math.Abs(dblAreaConSigno) <= clsGeometria.dblTolerancia)
            {
                strMensajeError = "Todos los vertices son colineales: el poligono no tiene area.";
                return false;
            }

            // area negativa: horario, se invierte a antihorario
            if (dblAreaConSigno < 0)
            {
                lstIndices.Reverse();
                blnOrientacionHoraria = true;
            }

            if (lstOmitidos.Count > 0)
            {
                strAdvertencia = "Se omitieron vertices colineales: V" + string.Join(", V", lstOmitidos) + ".";
            }
            return true;
        }

        public static List<clsPunto2D> ObtenerPuntos(IReadOnlyList<clsPunto2D> lstVertices, List<int> lstIndices)
        {
            List<clsPunto2D> lstPuntos = new List<clsPunto2D>();
            foreach (int intIndice in lstIndices) lstPuntos.Add(lstVertices[intIndice]);
            return lstPuntos;
        }

        private static bool ValidarRepetidos(IReadOnlyList<clsPunto2D> lstVertices, out string strMensajeError)
        {
            strMensajeError = string.Empty;
            int intCantidad = lstVertices.Count;
            for (int intI = 0; intI < intCantidad; intI++)
            {
                int intSiguiente = (intI + 1) % intCantidad;
                if (lstVertices[intI].EsIgualA(lstVertices[intSiguiente], clsGeometria.dblTolerancia))
                {
                    strMensajeError = "V" + intI + " y V" + intSiguiente + " son consecutivos y estan repetidos. Deshaga uno de ellos.";
                    return false;
                }
            }
            return true;
        }

        private static bool ValidarAutointerseccion(IReadOnlyList<clsPunto2D> lstVertices, out string strMensajeError)
        {
            strMensajeError = string.Empty;
            int intCantidad = lstVertices.Count;
            for (int intI = 0; intI < intCantidad; intI++)
            {
                for (int intJ = intI + 1; intJ < intCantidad; intJ++)
                {
                    // aristas vecinas comparten vertice, se omiten
                    bool blnSonVecinas = intJ == intI + 1 || (intI == 0 && intJ == intCantidad - 1);
                    if (blnSonVecinas) continue;

                    int intFinI = (intI + 1) % intCantidad;
                    int intFinJ = (intJ + 1) % intCantidad;
                    if (clsGeometria.blnSegmentosSeIntersecan(lstVertices[intI], lstVertices[intFinI],
                                                              lstVertices[intJ], lstVertices[intFinJ]))
                    {
                        strMensajeError = "Poligono autointersecado: las aristas V" + intI + "-V" + intFinI +
                                          " y V" + intJ + "-V" + intFinJ + " se cruzan.";
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool EliminarColineales(IReadOnlyList<clsPunto2D> lstVertices, List<int> lstIndices,
                                               out List<int> lstOmitidos, out string strMensajeError)
        {
            lstOmitidos = new List<int>();
            strMensajeError = string.Empty;
            bool blnHuboCambio = true;

            while (blnHuboCambio && lstIndices.Count >= 3)
            {
                blnHuboCambio = false;
                int intCantidad = lstIndices.Count;
                for (int intPos = 0; intPos < intCantidad; intPos++)
                {
                    clsPunto2D ptoA = lstVertices[lstIndices[(intPos - 1 + intCantidad) % intCantidad]];
                    clsPunto2D ptoB = lstVertices[lstIndices[intPos]];
                    clsPunto2D ptoC = lstVertices[lstIndices[(intPos + 1) % intCantidad]];
                    if (System.Math.Abs(clsGeometria.dblOrientacion(ptoA, ptoB, ptoC)) > clsGeometria.dblTolerancia) continue;

                    // si B no queda entre A y C la arista regresa sobre si misma
                    double dblAvance = (ptoB.X - ptoA.X) * (ptoC.X - ptoB.X) + (ptoB.Y - ptoA.Y) * (ptoC.Y - ptoB.Y);
                    if (dblAvance <= 0)
                    {
                        strMensajeError = "V" + lstIndices[intPos] + " forma un pico: la arista regresa sobre si misma.";
                        return false;
                    }

                    lstOmitidos.Add(lstIndices[intPos]);
                    lstIndices.RemoveAt(intPos);
                    blnHuboCambio = true;
                    break;
                }
            }
            lstOmitidos.Sort();
            return true;
        }
    }
}
