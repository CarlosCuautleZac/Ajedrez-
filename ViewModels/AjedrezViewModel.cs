using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ajedrez.ViewModels
{
    public class AjedrezViewModel : INotifyPropertyChanged
    {
        /* Console.WriteLine("Tu Peon esta en B1");
            Console.WriteLine("Escribe la serie de movimientos del peon separados por espcios");
         */

        public ICommand ValidarCommand { get; set; }

        //Es para saber si se cumple el regex
        private bool movimientosvalidos;

        public bool MovimientosValidos
        {
            get { return movimientosvalidos; }
            set { movimientosvalidos = value; Actualizar("MovimientosValidos"); }
        }

        //Esta es la cadena completa que se enlazara a la view
        private string palabra;

        public string Palabra
        {
            get { return palabra; }
            set { palabra = value; Actualizar("Palabra"); }
        }

        private string[] movimientos;

        public string[] Movimientos
        {
            get { return movimientos; }
            set { movimientos = value; Actualizar("Movimientos"); }
        }


        //Aqui veremos el resultado
        private string piezaconvertida;

        public string PiezaConvertida
        {
            get { return piezaconvertida; }
            set { piezaconvertida = value; Actualizar("PiezaConvertida"); }
        }

        private string piezaactual = "";

        public string PiezaActual
        {
            get { return piezaactual; }
            set { piezaactual = value; Actualizar("PiezaActual"); }
        }


        public AjedrezViewModel()
        {
            ValidarCommand = new RelayCommand(GetPiezaConvertida);
        }

        //Este metodo verifica el largo adecuado 
        public bool LargoAdecuado()
        {
            //Aqui vamos a seperar la cadena por espacios, la hacemos mayusculas y lo convertimos en un arreglo
            Movimientos = Palabra.Split(' ').Where(x => x != "").Select(x => x.ToUpper()).ToArray();


            foreach (var item in Movimientos)
            {
                if (item.Length != 2)
                    return false;
            }

            return true;
        }

        //Este metodo verifica si es valida la palabra con el regex
        public bool EsPalabraValida()
        {

            if (LargoAdecuado())
            {
                foreach (var item in Movimientos)
                {
                    //Aqui con expresiones regulares validamos las palabras
                    if (!Regex.IsMatch(item, "^[A-F]{1}[1-6]{1}"))
                        return false;

                }

                return true;
            }
            else
                return false;
        }

        //Validamos los movimientos
        public bool ValidarMovimiento()
        {
            if (EsPalabraValida())
            {
                for (int i = 0; i < Movimientos.Length - 1; i++)
                {
                    var actual = Movimientos[i];


                    if (i == 0)
                    {
                        if (actual == "B2" || actual == "B3")
                            MovimientosValidos = true;
                        else
                            return MovimientosValidos = false;
                    }


                    if (Movimientos[0] == "B1")
                    {
                        return false;
                    }



                    if (actual == "B2")
                    {
                        if (Movimientos[i + 1] == "B3")
                            MovimientosValidos = true;
                        else
                            return MovimientosValidos = false;
                    }


                    if (actual == "B3")
                    {
                        if (Movimientos[i + 1] == "B4" || Movimientos[i + 1] == "A4")
                            MovimientosValidos = true;
                        else
                            return MovimientosValidos = false;
                    }

                    if (actual == "B4" || actual == "A4")
                    {
                        if (Movimientos[i + 1] == "B5" || Movimientos[i + 1] == "A5")
                            MovimientosValidos = true;
                        else
                            return MovimientosValidos = false;
                    }

                    if (actual == "B5" || actual == "A5")
                    {
                        if (Movimientos[i + 1] == "B6" || Movimientos[i + 1] == "A6")
                            MovimientosValidos = true;
                        else
                            return MovimientosValidos = false;
                    }

                    if (actual == "B6" || actual == "A6")
                    {
                        return MovimientosValidos = false;
                    }


                }

                return MovimientosValidos = true;
            }
            else
                return MovimientosValidos = false;
        }


        public void GetPiezaConvertida()
        {
            ValidarMovimiento();

            if (MovimientosValidos)
            {
                if (Movimientos[movimientos.Length - 1] == "A6" || movimientos[movimientos.Length - 1] == "B6")
                    PiezaConvertida = "Tu peon se ha convertido en una reina!";
                //si termina en otro lugar
                else
                    PiezaConvertida = "Movimientos validos";
            }
            //si no fueron validos sus movimientos
            else
                PiezaConvertida = "Movimientos invalidos!";

            Actualizar();
            GetPiezaActual();

        }

        public async void GetPiezaActual()
        {
            for (int i = 0; i < Movimientos.Length; i++)
            {
                PiezaActual = Movimientos[i];
                Actualizar("PiezaActual");
                await Task.Delay(1000);
            }
        }

        public void Actualizar(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
