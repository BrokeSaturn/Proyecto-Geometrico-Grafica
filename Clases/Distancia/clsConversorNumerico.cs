using System;
using System.Globalization;

namespace WindowsFormsApp2.Distancia
{
    public static class clsConversorNumerico
    {
        private const string strFormatoSalida = "0.###";
        private const NumberStyles estiloNumero = NumberStyles.AllowLeadingSign |
                                                  NumberStyles.AllowDecimalPoint |
                                                  NumberStyles.AllowLeadingWhite |
                                                  NumberStyles.AllowTrailingWhite;

        // Conversion numerica
        public static bool IntentarConvertir(string texto, out double valor)
        {
            valor = 0.0;
            if (string.IsNullOrWhiteSpace(texto)) return false;

            string textoNormalizado = texto.Trim().Replace(',', '.');
            if (!double.TryParse(textoNormalizado, estiloNumero, CultureInfo.InvariantCulture, out valor))
            {
                return false;
            }
            return !double.IsNaN(valor) && !double.IsInfinity(valor);
        }

        public static string Formatear(double valor)
        {
            double valorRedondeado = Math.Round(valor, 3) + 0.0;
            return valorRedondeado.ToString(strFormatoSalida, CultureInfo.InvariantCulture);
        }
    }
}
