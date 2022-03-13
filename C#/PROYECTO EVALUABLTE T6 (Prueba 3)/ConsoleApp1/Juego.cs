using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Antons Berzins - 1º DAW
Practica Evaluable Tema 6
JUEGO:
Dentro de esta clase se crearan "partidas" cada vez que 1 juego termine. Un juego puede llegar a crear varias partidas
La logistica pricipal esta dentro de "Partida".
*/
namespace JuegosDeGuerra
{
    
    internal class Juego
    {
        public void Lanzar(){
            Bienvenida  b = new Bienvenida();
            b.Lanzar();
            do
            {
                if (!b.GetSalir())
                {

                    Console.Clear();

                    Partida p = new Partida();
                    p.Lanzar();

                    Console.Clear();

                    //Punto de fin de partida.
                    Console.WriteLine("Si deseas volver a jugar (\"si\") o cualquier otra tecla para salir");

                    if (Console.ReadLine().ToLower() == "si")
                    {
                        //Inicializamos de nuevo
                        b.Lanzar();
                        p = null;
                        p = new Partida();

                    }
                    else
                    {
                        //Terminamos programa
                        Console.WriteLine("Saliendo del programa. Intro para salir");
                        Console.ReadLine();
                        b.SetSalir(true);
                    }
                }
            } while (!b.GetSalir());

        }

    }
}
