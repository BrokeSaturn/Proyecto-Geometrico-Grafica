using System.Collections.Generic;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Modelos
{
    public class clsPoligono
    {
        // tolerancia para detectar vertices repetidos
        private const double dblToleranciaRepetido = 1e-9;

        private readonly List<clsPunto2D> lstVertices = new List<clsPunto2D>();
        private bool blnCerrado;

        public IReadOnlyList<clsPunto2D> LstVertices
        {
            get { return lstVertices; }
        }

        public int IntCantidadVertices
        {
            get { return lstVertices.Count; }
        }

        public bool BlnCerrado
        {
            get { return blnCerrado; }
        }

        public bool AgregarVertice(clsPunto2D ptoVertice, out string strMensajeError)
        {
            strMensajeError = string.Empty;
            if (blnCerrado)
            {
                strMensajeError = "El poligono esta cerrado. Use Deshacer o Limpiar para editarlo.";
                return false;
            }
            if (lstVertices.Count > 0 && lstVertices[lstVertices.Count - 1].EsIgualA(ptoVertice, dblToleranciaRepetido))
            {
                strMensajeError = "Vertice repetido: coincide con V" + (lstVertices.Count - 1) + ". Haga clic en otra posicion.";
                return false;
            }
            lstVertices.Add(ptoVertice);
            return true;
        }

        public bool EliminarUltimoVertice()
        {
            if (lstVertices.Count == 0) return false;
            lstVertices.RemoveAt(lstVertices.Count - 1);
            blnCerrado = false;
            return true;
        }

        public bool Cerrar(out string strMensajeError)
        {
            strMensajeError = string.Empty;
            if (lstVertices.Count < 3)
            {
                strMensajeError = "Se necesitan al menos 3 vertices para cerrar el poligono (hay " + lstVertices.Count + ").";
                return false;
            }
            if (lstVertices[0].EsIgualA(lstVertices[lstVertices.Count - 1], dblToleranciaRepetido))
            {
                strMensajeError = "El ultimo vertice coincide con V0. Deshaga el ultimo vertice antes de cerrar.";
                return false;
            }
            blnCerrado = true;
            return true;
        }

        public void CargarVertices(IEnumerable<clsPunto2D> lstNuevosVertices)
        {
            lstVertices.Clear();
            lstVertices.AddRange(lstNuevosVertices);
            blnCerrado = false;
        }

        public void Limpiar()
        {
            lstVertices.Clear();
            blnCerrado = false;
        }
    }
}
