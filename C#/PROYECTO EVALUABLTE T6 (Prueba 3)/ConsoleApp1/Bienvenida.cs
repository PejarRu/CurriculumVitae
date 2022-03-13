using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosDeGuerra
{
    internal class Bienvenida
    {
        bool salir;
        public void Lanzar() {
            Console.Clear();
            Console.SetCursorPosition(0, 10);
            Console.WriteLine(new String('*', 60));
            Console.WriteLine(new String(' ', 10) + "Bienvenido a \"Juegos de Guerra\"");
            Console.WriteLine(new String(' ', 6) + "Creado por Antons Berzins | 1º - DAW");
            Console.WriteLine(new String(' ', 3) + "Presiona 2 veces INTRO  para empezar a jugar o ESC para salir");
            Console.WriteLine(new String('*', 60));


            ConsoleKeyInfo tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.Write(" \n");
                    Console.WriteLine("Comenzamos juego");
                    salir = false;
                }
                else if (tecla.Key == ConsoleKey.Escape) {
                    Console.Write(" \n");
                    Console.WriteLine("Saliendo del programa");
                    salir = true;
                }
                else
                {
                    Console.Write(" \n");
                    Console.WriteLine("Tecla desconocida. Saliendo del programa");
                    salir = true;
                }

        }
        //Getters
        public bool GetSalir() { 
            return salir;
        }
        //Setters
        public void SetSalir(bool salir)
        {
            this.salir = salir;
        }

    }
}
