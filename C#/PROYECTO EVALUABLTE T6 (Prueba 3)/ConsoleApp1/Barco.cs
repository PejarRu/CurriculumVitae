using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Antons Berzins - 1º DAW
Practica Evaluable Tema 6
BARCO:
Apartado 1.1 SI
Apartado 1.2 NO - NO TENGO NINGUN ARGUMENTO BOLEANO PARA INDICAR SI ES DE SUPERFICIE O NO

Apartado 2.1 SI 
Apartado 2.2 SI

BARCO SUBCLASES - SI. PERO NO SE USAN 
*/
namespace JuegosDeGuerra
{
    internal class Barco
    {
        Casilla[] casillas;
        string orientacion;
        int longitud;
        public Barco()
        {
        }
        public Barco(int col, int fil, int longitud, string orientacion)
        {
            //Editamos los atriburtos generales
            this.orientacion= orientacion;
            this.longitud = longitud;
            this.casillas = new Casilla[longitud];
            //A partir de la casila madre y la orientacion y longitud, asignamos las demas casillas
            GenerarBarco(col, fil);

        }
        //Setter
        public void SetOrientacion(string orientacion)
        {
            this.orientacion = orientacion;
        }
        public void SetLongitud(int longitud)
        {
            this.longitud = longitud;
        }
        //Getters
        public string GetOrientacion()
        {
            return this.orientacion;
        }
        public int GetLongitud()
        {
            return this.casillas.Length;
        }
        //Generamos y alamcenamos las demas casillas
        public void GenerarBarco(int col, int fil) {
            for (int j = 0; j < longitud; j++)
            {
                if (this.orientacion == "vertical")
                {
                    //Creamos y almacenamos casillas del barco
                    //Editamos las casillas correspondientes (en direccion DERECHA)
                    this.casillas[j] = new Casilla(col + j, fil, "B");
                }
                else if (this.orientacion == "horizontal")
                {
                    //Creamos y almacenamos casillas del barco
                    //Editamos las casillas correspondientes (en direccion DERECHA)
                    this.casillas[j] = new Casilla(col + j, fil, "B");
                }
                else
                {
                    Console.WriteLine("Error al crear Barco en clase barco");
                    Console.ReadLine();
                }
            }
        }
        public bool EditarCasillaBarco(int col, int fil) {
            bool existe = false;
            bool dañada = false;
            foreach (Casilla casilla in casillas)
            {
                //Se busca la casilla que hemos disparado (si esta pertenece a algun barco)
                if (casilla.GetX() == col && casilla.GetY() == fil)
                {
                    existe = true;
                    //Vemos si la casilla estaba "B"
                    if (casilla.GetEstado() == "B")
                    {
                        casilla.SetEstado("X");
                        dañada = true;
                        //Comprobamos si ese barco esta hundido del todo
                        if (EstaHundido())
                        {
                            Console.WriteLine("Barco undido");
                        }
                    }
                }
            }

            return existe && dañada;
        }

        public bool EstaHundido()
        {
            foreach (Casilla casilla in casillas)
            {
                if (casilla.GetEstado() == "B")
                {
                    //Aun queda alguna casilla, barco no esta undido
                    return false;
                }
            }
            //No queda ninguna casilla,  barco esta undido
            return true;
        }

    }
    internal class Portaaviones : Barco {
        int longitud = 5;
        public Portaaviones() {
            Barco p =  new Barco();
            p.SetLongitud(longitud);
        }
    }
    internal class Acorazado : Barco
    {
        int longitud = 4;
        public Acorazado()
        {
            Barco p = new Barco();
            p.SetLongitud(longitud);
        }
    }
    internal class Destructor : Barco
    {
        int longitud = 3;
        public Destructor()
        {
            Barco p = new Barco();
            p.SetLongitud(longitud);
        }
    }
    internal class Fragata : Barco
    {
        int longitud = 3;
        public Fragata()
        {
            Barco p = new Barco();
            p.SetLongitud(longitud);
        }
    }
    internal class Submarino : Barco
    {
        int longitud = 2;
        public Submarino()
        {
            Barco p = new Barco();
            p.SetLongitud(longitud);
        }
    }
}
