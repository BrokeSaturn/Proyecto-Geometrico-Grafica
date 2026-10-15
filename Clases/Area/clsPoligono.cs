using System;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    // Administrador de vertices y validaciones geometricas
    public class clsPoligono
    {
        private List<clsPunto> lstVertices = new List<clsPunto>();
        private bool blnCerrado = false;
        private string strUltimoError = "";

        public List<clsPunto> Vertices
        {
            get { return lstVertices; }
        }

        public int Cantidad
        {
            get { return lstVertices.Count; }
        }

        public bool Cerrado
        {
            get { return blnCerrado; }
        }

        public string UltimoError
        {
            get { return strUltimoError; }
        }

        public void AgregarVertice(double dblX, double dblY)
        {
            blnCerrado = false;
            lstVertices.Add(new clsPunto(dblX, dblY));
        }

        public void EliminarUltimoVertice()
        {
            if (lstVertices.Count > 0)
            {
                lstVertices.RemoveAt(lstVertices.Count - 1);
            }
            blnCerrado = false;
        }

        public void Limpiar()
        {
            lstVertices.Clear();
            blnCerrado = false;
            strUltimoError = "";
        }

        public bool Cerrar()
        {
            if (!TieneMinimoVertices())
            {
                return false;
            }
            blnCerrado = true;
            if (TieneAutointersecciones())
            {
                blnCerrado = false;
                return false;
            }
            return true;
        }

        public bool TieneMinimoVertices()
        {
            if (lstVertices.Count < 3)
            {
                strUltimoError = "Se necesitan al menos 3 vertices (hay " + lstVertices.Count + ").";
                return false;
            }
            return true;
        }

        // Valida minimo de vertices, cierre y ausencia de cruces
        public bool EsValido()
        {
            if (!TieneMinimoVertices())
            {
                return false;
            }
            if (!blnCerrado)
            {
                strUltimoError = "El poligono no esta cerrado. Presione 'Cerrar poligono'.";
                return false;
            }
            if (TieneAutointersecciones())
            {
                return false;
            }
            return true;
        }

        // Comprueba cruces entre aristas no consecutivas
        public bool TieneAutointersecciones()
        {
            int intN = lstVertices.Count;
            int intAristas = blnCerrado ? intN : intN - 1;

            for (int intI = 0; intI < intAristas; intI++)
            {
                for (int intJ = intI + 1; intJ < intAristas; intJ++)
                {
                    if (SonConsecutivas(intI, intJ, intAristas))
                    {
                        continue;
                    }

                    clsPunto objA = lstVertices[intI];
                    clsPunto objB = lstVertices[(intI + 1) % intN];
                    clsPunto objC = lstVertices[intJ];
                    clsPunto objD = lstVertices[(intJ + 1) % intN];

                    if (SeCruzan(objA, objB, objC, objD))
                    {
                        strUltimoError = "El poligono se autointersecta: arista V" + (intI + 1) +
                                         "-V" + (((intI + 1) % intN) + 1) + " cruza con V" + (intJ + 1) +
                                         "-V" + (((intJ + 1) % intN) + 1) + ".";
                        return true;
                    }
                }
            }
            return false;
        }

        // Dos aristas consecutivas comparten vertice por definicion
        private bool SonConsecutivas(int intI, int intJ, int intAristas)
        {
            if (intJ == intI + 1)
            {
                return true;
            }
            if (blnCerrado && intI == 0 && intJ == intAristas - 1)
            {
                return true;
            }
            return false;
        }

        // Producto cruz para orientacion: >0 izquierda, <0 derecha, 0 colineal
        private double Orientacion(clsPunto objA, clsPunto objB, clsPunto objC)
        {
            return (objB.X - objA.X) * (objC.Y - objA.Y) - (objB.Y - objA.Y) * (objC.X - objA.X);
        }

        private int Signo(double dblValor)
        {
            if (dblValor > 1e-9) return 1;
            if (dblValor < -1e-9) return -1;
            return 0;
        }

        // Comprueba si un punto colineal se encuentra sobre el segmento
        private bool EstaEnSegmento(clsPunto objA, clsPunto objB, clsPunto objC)
        {
            return Math.Min(objA.X, objB.X) <= objC.X && objC.X <= Math.Max(objA.X, objB.X) &&
                   Math.Min(objA.Y, objB.Y) <= objC.Y && objC.Y <= Math.Max(objA.Y, objB.Y);
        }

        // Verifica si los segmentos AB y CD se cruzan
        private bool SeCruzan(clsPunto objA, clsPunto objB, clsPunto objC, clsPunto objD)
        {
            int intO1 = Signo(Orientacion(objA, objB, objC));
            int intO2 = Signo(Orientacion(objA, objB, objD));
            int intO3 = Signo(Orientacion(objC, objD, objA));
            int intO4 = Signo(Orientacion(objC, objD, objB));

            // Caso general: orientaciones opuestas
            if (intO1 != intO2 && intO3 != intO4)
            {
                return true;
            }

            // Casos limite: extremos o puntos sobre la arista
            if (intO1 == 0 && EstaEnSegmento(objA, objB, objC)) return true;
            if (intO2 == 0 && EstaEnSegmento(objA, objB, objD)) return true;
            if (intO3 == 0 && EstaEnSegmento(objC, objD, objA)) return true;
            if (intO4 == 0 && EstaEnSegmento(objC, objD, objB)) return true;

            return false;
        }
    }
}
