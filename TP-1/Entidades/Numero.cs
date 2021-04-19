using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region "Atributos"
        private double numero;
        #endregion

        #region "Propiedades"
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion

        #region "Constructores"

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero; // valido que sea numero
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Comprobrueba que el valor recibido sea numérico
        /// </summary>
        /// <param name="strNumero"> Numero a comprobar </param>
        /// <returns> Si el valor es numerico, lo retorna en formato double. En el caso contrario, retorna 0 </returns>
        private double ValidarNumero(string strNumero)
        {
            double numDouble = 0;
            strNumero = strNumero.Replace(".", ","); // reemplazo los . por , si hubiera
            double.TryParse(strNumero, out numDouble); // intento parsear
            return numDouble;
        }

        /// <summary>
        /// Valida que la cadena de caracteres esté compuesta SOLAMENTE por caracteres '0' o '1'
        /// </summary>
        /// <param name="binario"> String a comprobar </param>
        /// <returns> True si es binario, false si no lo es </returns>
        private bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convierte un numero de tipo string de binario a decimal
        /// </summary>
        /// <param name="numBinario"> string numero a convertir </param>
        /// <returns> Retorna el calor decimal en string si pudo convertirlo, o "Valor invalido", si no pudo. </returns>
        public string BinarioDecimal(string numBinario)
        {
            int numDecimal = 0;
            Numero num = new Numero();
            if (num.EsBinario(numBinario))
            {
                for (int i = 0; i < numBinario.Length; i++)
                {
                    char posicion = numBinario[numBinario.Length - (i + 1)]; // +1 porque el ultimo char es \0
                    if (posicion.Equals('1')) // de atras hacia adelante
                    {
                        numDecimal += (int)Math.Pow(2, i);
                    }
                }
                return numDecimal.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Convierte un double decimal en binario
        /// </summary>
        /// <param name="numDecimal"> Double numero decimal a convertir </param>
        /// <returns> Retorna el string del numero binario. </returns>
        public string DecimalBinario(double numDecimal)
        {
            string numBinario = string.Empty;
            char[] charNumBinario = "0".ToCharArray();
            numDecimal = Math.Abs(numDecimal); // si ingresan negativo, toma el absoluto 
            int.TryParse(numDecimal.ToString(), out int absNumDecimal);

            while (absNumDecimal > 0)
            {
                numBinario += absNumDecimal % 2; // 0 o 1
                absNumDecimal = absNumDecimal / 2;
            }

            if (numBinario != string.Empty)
            {
                charNumBinario = numBinario.ToCharArray(); // a array de chars
                Array.Reverse(charNumBinario); // invertir cadena
            }
            return new string(charNumBinario); // a string
        }

        /// <summary>
        /// Convierte un double decimal en binario
        /// </summary>
        /// <param name="strNumDecimal"> String numero decimal a convertir </param>
        /// <returns> Retorna el numero binario si pudo convertirlo, o 0, si no pudo </returns>
        public string DecimalBinario(string strNumDecimal)
        {
            if (double.TryParse(strNumDecimal, out double numDecimal))
            {
                return DecimalBinario(numDecimal);
            }
            else
            {
                return "Valor inválido";
            }
        }
        #endregion

        #region "Sobrecarga de operadores"

        /// <summary>
        /// Resta dos atributos numero de la clase Numero
        /// </summary>
        /// <param name="n1"> Numero 1 a ser restado </param>
        /// <param name="n2"> Numero 2 a restar </param>
        /// <returns> Retorna el resultado de la resta </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Suma dos atributos numero de la clase Numero
        /// </summary>
        /// <param name="n1"> Numero 1 a sumar </param>
        /// <param name="n2"> Numero 2 a sumar </param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Divide dos atributos numero de la clase Numero
        /// </summary>
        /// <param name="n1"> Numero 1 a ser dividido </param>
        /// <param name="n2"> Numero 2 a dividir </param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// Multiplica dos atributos numero de la clase Numero
        /// </summary>
        /// <param name="n1"> Numero 1 a multiplicar </param>
        /// <param name="n2"> Numero 2 a multiplicar </param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        #endregion

    }
}
