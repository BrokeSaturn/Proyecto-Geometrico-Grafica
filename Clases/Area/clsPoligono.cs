using System;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    /// <summary>
    /// Guarda los vertices del contorno y valida que sea un poligono simple.
    /// </summary>
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

        // ---------- Edicion de vertices ----------

        public void AgregarVertice(double dblX, double dblY)
        {
            // Si ya estaba cerrado y se agrega otro punto, se vuelve a abrir
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

        // ---------- Validaciones ----------

        // Cierra el poligono (el ultimo vertice se une con el primero)
        public bool Cerrar()
        {
            if (!TieneMinimoVertices())
            {
                return false;
            }
            blnCerrado = true;
            if (TieneAutointersecciones())
            {
                blnCerrado = false;   // no se permite cerrar un contorno invalido
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

        // Validacion completa: minimo, cierre y sin cruces
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

        // Compara cada arista con las demas NO consecutivas.
        public bool TieneAutointersecciones()
        {
            int intN = lstVertices.Count;
            // Si esta abierto hay n-1 aristas; si esta cerrado hay n
            int intAristas = blnCerrado ? intN : intN - 1;

            for (int intI = 0; intI < intAristas; intI++)
            {
                for (int intJ = intI + 1; intJ < intAristas; intJ++)
                {
                    if (SonConsecutivas(intI, intJ, intAristas))
                    {
                        continue;   // las aristas vecinas comparten un vertice: es normal
                    }

                    clsPunto objA = lstVertices[intI];
                    clsPunto objB = lstVertices[(intI + 1) % intN];
                    clsPunto objC = lstVertices[intJ];
                    clsPunto objD = lstVertices[(intJ + 1) % intN];

                    if (SeCruzan(objA, objB, objC, objD))
                    {
                        strUltimoError = "El poligono se autointersecta: la arista V" + (intI + 1) +
                                         "-V" + (((intI + 1) % intN) + 1) + " cruza la arista V" + (intJ + 1) +
                                         "-V" + (((intJ + 1) % intN) + 1) + ".";
                        return true;
                    }
                }
            }
            return false;
        }

        // Dos aristas son consecutivas si estan una al lado de la otra.
        // Si esta cerrado, la ultima arista tambien es vecina de la primera.
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

        // ---------- Geometria: orientacion con producto cruz ----------

        // Producto cruz de (B-A) x (C-A):
        //  > 0 giro a la izquierda, < 0 giro a la derecha, 0 colineales.
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

        // Si C esta alineado con A-B, revisa si cae dentro del segmento
        private bool EstaEnSegmento(clsPunto objA, clsPunto objB, clsPunto objC)
        {
            return Math.Min(objA.X, objB.X) <= objC.X && objC.X <= Math.Max(objA.X, objB.X) &&
                   Math.Min(objA.Y, objB.Y) <= objC.Y && objC.Y <= Math.Max(objA.Y, objB.Y);
        }

        // Segmento AB cruza segmento CD?
        private bool SeCruzan(clsPunto objA, clsPunto objB, clsPunto objC, clsPunto objD)
        {
            int intO1 = Signo(Orientacion(objA, objB, objC));
            int intO2 = Signo(Orientacion(objA, objB, objD));
            int intO3 = Signo(Orientacion(objC, objD, objA));
            int intO4 = Signo(Orientacion(objC, objD, objB));

            // Caso general: C y D en lados opuestos de AB, y A y B en lados opuestos de CD
            if (intO1 != intO2 && intO3 != intO4)
            {
                return true;
            }

            // Casos especiales: un punto cae justo sobre la otra arista
            if (intO1 == 0 && EstaEnSegmento(objA, objB, objC)) return true;
            if (intO2 == 0 && EstaEnSegmento(objA, objB, objD)) return true;
            if (intO3 == 0 && EstaEnSegmento(objC, objD, objA)) return true;
            if (intO4 == 0 && EstaEnSegmento(objC, objD, objB)) return true;

            return false;
        }
    }
}

