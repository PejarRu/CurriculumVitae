using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Juego
    {
        public void Lanzar() {

            Bienvenida b = new Bienvenida();
            Partida partida = new Partida();

            do
            {
                if (!b.GetSalir())
                {
                    b.Lanzar();
                    partida.Lanzar();

                }

            } while (b.GetSalir());


        }
       
    }
}
