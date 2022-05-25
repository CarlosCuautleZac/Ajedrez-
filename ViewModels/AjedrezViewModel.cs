using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ajedrez.ViewModels
{
    class AjedrezViewModel
    {
        /* Console.WriteLine("Tu Peon esta en B1");
            Console.WriteLine("Escribe la serie de movimientos del peon separados por espcios");
         */

        //Es para saber si se cumple el regex
        private bool palabravalida;

        public bool PalabraValida
        {
            get { return palabravalida; }
            set { palabravalida = value; }
        }

        //Esta es la cadena completa 
        private string palabra;

        public string Palabra
        {
            get { return palabra; }
            set { palabra = value; }
        }

        private string[] movimientos;

        public string[] Movimientos
        {
            get { return movimientos; }
            set { movimientos = value; }
        }



        public bool PalabraValida(string cadena)
        {
            Movimientos = cadena.Split(' ').Where(x => x != "").ToArray();

            foreach (var item in Movimientos)
            {
                //En caso de que el largo de cada palabra sea mayor a 2, el programa se rompe y no seria valido
                if (item.Length != 2)
                {
                   return PalabraValida = false;
                    break;
                }

                //Aqui con expresiones regulares validamos las palabras
                if (Regex.IsMatch(item, "^[A-F]{1}[1-6]{1}"))
                    PalabraValida = true;
                else
                    PalabraValida = false;
            }

        }

        private bool ValidarMovimiento(string movimientos)
        {

            return true;
        }

    }
}
