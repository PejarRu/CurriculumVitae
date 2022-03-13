using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Partida
    {
        public void Lanzar() {

           Tabla tabla;
           tabla = new Tabla();
           tabla.inciarTabla();
            int turno = 1;
            do
            {
                Console.Clear();
                tabla.mostrarTablero();
                Console.SetCursorPosition(0, 6);

                if (turno%2 != 0)
                {
                    Console.WriteLine("Turno de X");

                    tabla.dibujarTipo("X");
                }
                else
                {
                    Console.WriteLine("Turno de O");

                    tabla.dibujarTipo("O");
                }
                tabla.mostrarTablero();
                turno++;

            } while (tabla.Ganador());
        }
    }
}
