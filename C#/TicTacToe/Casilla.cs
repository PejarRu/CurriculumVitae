using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Casilla
    {
        int x, y;
        string tipo, separacionX = "|";
        string separacionY;
        public Casilla(int x, int y, string tipo, string separacion = "") {
            this.x = x;
            this.y = y; 
            this.tipo = tipo;   
            this.separacionX = separacion;
            this.separacionY = new String('-', String.Concat(" ", separacion).Length);
        }

        public void SetTipo(string tipo) {
            this.tipo=tipo;
        }
        public string GetTipo()
        {
            return this.tipo;
        }
        public string GetSeparacion()
        {
            return this.separacionX;
        }
        public int GetSeparacionXINT()
        {
            return this.separacionX.Length;
        }
        public string GetSeparacionY()
        {
            return separacionY;
        }
        public void ImprimirCasilla() { 
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(tipo + separacionX);
        }
    }
}
