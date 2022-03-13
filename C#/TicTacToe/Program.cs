using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 El juegop esta casi acabado. Solo hacer funcionar a las funciones que compruban si se ha completado una fila, columna o diagonal 
 y que devuelva el nombre del jugador que ha ganado.

Pd:(Ahora mismo no lo he hecho por que es una rallada oreitnarte entre 
pixeles, identidifacodres del array Tabla[][], y el metodo de comparacion.
La dificultad no es el codigo, el cual si que es sabido implementar, si 
no la dificultad mental de orientarte en las cordenasa X,Y relativas a 
ada cosa)

 */
namespace TicTacToe
{
    static internal class Program
    {
        public static void Main(String[] args) { 
            
            Juego j = new Juego();

            j.Lanzar();
        
        }
    }
}
