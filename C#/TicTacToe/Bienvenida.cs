using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Bienvenida
    {
        bool salir;
        public void Lanzar(){
            Console.WriteLine(new String('\n', 10));
            Console.WriteLine(new String('*', 50));
            Console.WriteLine("Bienvenidos a TicTacToe.");
            Console.WriteLine("Persiona intro para continuar o cualquier otra tecla para salir.");
            Console.WriteLine(new String('*', 50));
            Console.WriteLine(new String('\n', 10));
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {
                salir = false;
            }
            else { 
                salir = true;
            }
            Console.Clear();
        }
        public bool GetSalir()
        {
            return salir;
        }
        public void SetSalir(bool salir)
        {
            this.salir = salir;
        }

}
}
