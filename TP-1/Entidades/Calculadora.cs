using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Decide que operacion realizar entre dos atributos numero de la clase Numero
        /// </summary>
        /// <param name="num1"> Numero 1 </param>
        /// <param name="num2"> Numero 2 </param>
        /// <param name="operador"> Operador </param>
        /// <returns> Retorna el resultado de la operacion indicada por parametros. Si el operador no es '+' '-' '/' o '*', retorna el resultado de la operacion '+' </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            char.TryParse(operador, out char operadorChar);
            //string operadorValidado = ValidarOperador(operadorChar);
            switch (ValidarOperador(operadorChar))
            {
                case "-":
                    return num1 - num2;
                case "/":
                    return num1 / num2;
                case "*":
                    return num1 * num2;
                default:
                    return num1 + num2;
            }
        }

        /// <summary>
        /// Valida que el operador sea '+' '-' '/' o '*', retorna el resultado de la operacion '+'
        /// </summary>
        /// <param name="operador"> Char operador a validar </param>
        /// <returns> Retorna el operador indicado. Si es invalido, retorna '+' </returns>
        private static string ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '-':
                    return "-";
                case '/':
                    return "/";
                case '*':
                    return "*";
                default:
                    return "+";
            }
        }
    }
}
