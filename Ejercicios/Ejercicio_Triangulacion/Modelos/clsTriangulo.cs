using System;
using WindowsFormsApp2.Ejercicios.Triangulacion.Servicios;

namespace WindowsFormsApp2.Ejercicios.Triangulacion.Modelos
{
    public class clsTriangulo
    {
        private readonly clsPunto2D ptoA;
        private readonly clsPunto2D ptoB;
        private readonly clsPunto2D ptoC;
        private readonly int intIndiceA;
        private readonly int intIndiceB;
        private readonly int intIndiceC;

        public clsTriangulo(clsPunto2D ptoVerticeA, clsPunto2D ptoVerticeB, clsPunto2D ptoVerticeC,
                            int intIndiceVerticeA, int intIndiceVerticeB, int intIndiceVerticeC)
        {
            ptoA = ptoVerticeA;
            ptoB = ptoVerticeB;
            ptoC = ptoVerticeC;
            intIndiceA = intIndiceVerticeA;
            intIndiceB = intIndiceVerticeB;
            intIndiceC = intIndiceVerticeC;
        }

        public clsPunto2D PtoA { get { return ptoA; } }
        public clsPunto2D PtoB { get { return ptoB; } }
        public clsPunto2D PtoC { get { return ptoC; } }
        public int IntIndiceA { get { return intIndiceA; } }
        public int IntIndiceB { get { return intIndiceB; } }
        public int IntIndiceC { get { return intIndiceC; } }

        // area del triangulo: mitad del determinante
        public double dblCalcularArea()
        {
            return Math.Abs(clsGeometria.dblOrientacion(ptoA, ptoB, ptoC)) / 2.0;
        }

        public string ObtenerNombre()
        {
            return "V" + intIndiceA + " - V" + intIndiceB + " - V" + intIndiceC;
        }
    }
}
