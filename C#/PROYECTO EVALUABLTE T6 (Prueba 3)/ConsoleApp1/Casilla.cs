using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Antons Berzins - 1º DAW
Practica Evaluable Tema 6
CASILLA:
Apartado 1 SI
Apartado 2 SI
*/
namespace JuegosDeGuerra
{
    internal class Casilla { 
         
        const string separacion = "  ";
        public static int separacionLenght = separacion.Length;
        int X;
        int Y;
        string estado;
        //Constructores
        public Casilla() { 
        }
        public Casilla(int x = 0, int y = 0, string estado = ".")
        {
            this.X = x; this.Y = y; this.estado = estado;
        }
        //Setters
        public void SetPosicion(int x, int y) {
            this.X = x; this.Y = y;
        }
        public void SetX(int x)
        {
            this.X = x;
        }
        public void SetY(int y)
        {
            this.Y = y;
        }
        public void SetEstado(string nuevoestado)
        {
            this.estado = nuevoestado;
        }
        //Getters
        public int GetX()
        {
            return this.X;
        }
        public int GetY()
        {
            return this.Y;
        }
        public string GetEstado()
        {
            return this.estado;
        }
        public int GetSeparacionLenght()
        {
            return separacionLenght;
        }
        //Metodos
        public void ImprimirCasilla() {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(String.Concat(this.estado, separacion));
        
        }

    }
}
