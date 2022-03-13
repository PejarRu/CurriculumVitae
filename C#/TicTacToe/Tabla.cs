using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Tabla
    {
        Casilla[][] tablero;
        int cantCasillas;
        public Tabla(int cantCasillas = 3){
            this.cantCasillas = cantCasillas;
            tablero = inciarTabla();

        }
        public Casilla[][] inciarTabla() {
            Casilla[][] tableroNuevo = new Casilla[cantCasillas][];

            int sepY = 0;
            for (int fila = 0; fila < cantCasillas; fila++)
            {
                int sepX = 0;
                tableroNuevo[fila] = new Casilla[cantCasillas];
                for(int col = 0; col < cantCasillas; col++)
                {
                    if (col == cantCasillas)
                    {
                        tableroNuevo[fila][col] = new Casilla(col + sepX, fila + sepY, " ");
                    }
                    else
                    {
                        tableroNuevo[fila][col] = new Casilla(col + sepX, fila + sepY, " ", "|");
                    }
                    sepX += tableroNuevo[fila][col].GetSeparacionXINT();
                }
                sepY += 1;
            }
            return tableroNuevo;
        }
        public void mostrarTablero()
        {
            foreach (Casilla[] fila in this.tablero)
            {
                int sep = 0;
                foreach (Casilla casilla in fila)
                {
                    if (casilla != null)
                    {
                        casilla.ImprimirCasilla();
                    } 
                    sep += tablero[0][0].GetSeparacionXINT();
                }
                Console.WriteLine();
                Console.WriteLine(string.Concat(Enumerable.Repeat(tablero[0][0].GetSeparacionY(), cantCasillas)));
            }

        }

        public void dibujarTipo(string tipo) {
            int col, fil;
            do
            {
                try
                {
                    Console.WriteLine("Escribe la columna (1,2 o 3)");
                    col = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Escribe la fila (1,2 o 3)");
                    fil = Convert.ToInt32(Console.ReadLine());

                    if (casillaVacia(col - 1, fil - 1) && ((col >= 1 && col <= 3) && (fil >= 1 && fil <= 3)))
                    {
                        tablero[col - 1][fil - 1].SetTipo(tipo);
                    }
                    else
                    {
                        Console.WriteLine("Casilla ocupada, elige otra");
                        col = 0;
                        fil = 0;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Escribe solo lo numero que te dicen");
                    col = 0;
                    fil = 0;
                }
            } while ( (col == 0 || fil == 0) || ((col < 1 && col > 3) && (fil < 1 && fil > 3)));

            
        }

        public bool casillaVacia(int col, int fil)
        {
            bool vacio = false;
            if (tablero[col][fil].GetTipo() == "" || tablero[col][fil].GetTipo() == " ")
            {
                vacio = true;
            }
            return vacio;


        }
        public bool Ganador() { 
        
            bool ganador = false;
            // || diagonalLlena()
            if (verticalLlena()  || horizontalLlena())
                {
                    ganador = true;
                }

            return ganador;
        
        }
        public bool horizontalLlena()
        {
            bool[] casillaEjeXCoincide = new bool[cantCasillas];
            bool filaCompleta = false;
            for (int fila = 0; fila < cantCasillas; fila++)
            {
                for (int col = 0; col < cantCasillas - 1; col++)
                {
                    if (tablero[fila][col].GetTipo() == tablero[fila][col+1].GetTipo())
                    {
                        if (tablero[fila][col].GetTipo() != "" || tablero[fila][col].GetTipo() != " ")
                        {
                            casillaEjeXCoincide[fila] = true;
                        }
                    }
                    else
                    {
                        casillaEjeXCoincide[fila] = false;

                    }
                }

                //Si la columna tiene las 3 casillas iguales. Devolvemos true
                filaCompleta = !(Array.IndexOf(casillaEjeXCoincide, false) > -1);
                if (filaCompleta)
                {
                    return filaCompleta;
                }

            }
            //Tras el ciclo obtenemos un array del cual podemos dedusicr si hay alguna casilla que no coincide.
            //Si hay alguna casilla que no coincide, (false). Devolvemos false
            return filaCompleta;

        }
        public bool verticalLlena() {

            bool[] casillaEjeYCoincide = new bool[cantCasillas];
            bool colunaCompleta = false;
            for (int fila = 0; fila < cantCasillas - 1; fila++)
            {
                for (int col = 0; col < cantCasillas; col++)
                {
                    if (tablero[fila][col].GetTipo() == tablero[fila+1][col].GetTipo())
                        {
                            if (tablero[fila][col].GetTipo() != "" && tablero[fila][col].GetTipo() != " ")
                            {
                                casillaEjeYCoincide[fila] = true;
                            }
                    }
                    else
                    {
                        casillaEjeYCoincide[fila] = false;
                    }
                }

                //Si la fila tiene las 3 casillas iguales. Devolvemos true
                colunaCompleta = !(Array.IndexOf(casillaEjeYCoincide, false) > -1);
                if (colunaCompleta)
                {
                    return colunaCompleta;
                }

            }
            //Tras el ciclo obtenemos un array del cual podemos dedusicr si hay alguna casilla que no coincide.
            //Si hay alguna casilla que no coincide, (false). Devolvemos false
            return colunaCompleta;
        }

       
        //public bool diagonalLlena()
        //{
        //    bool diagonalCoincide1 = false;
        //    bool diagonalCoincide2 = false;
        //    for (int fila = 0; fila < cantCasillas - 1; fila++)
        //    {
        //        diagonalCoincide1 = true;
        //        for (int col = 0; col < cantCasillas - 1; col++)
        //        {
        //            if ((tablero[fila][col].GetTipo() != "" || tablero[fila][col].GetTipo() != " ")
        //                && tablero[fila][col].GetTipo() != tablero[fila+1][col + 1].GetTipo())
        //            {
        //                diagonalCoincide1 = false;
        //            }


        //        }
        //        if (diagonalCoincide1)
        //        {
        //            return diagonalCoincide1;
        //        }
        //    }

        //    for (int fila = 0; fila < cantCasillas - 1; fila++)
        //    {
        //        diagonalCoincide2 = true;
        //        for (int col = 0; col < cantCasillas - 1; col++)
        //        {
        //            if ((tablero[fila][col].GetTipo() != "" || tablero[fila][col].GetTipo() != " ")
        //                && tablero[fila][col].GetTipo() != tablero[fila + 1][col + 1].GetTipo())
        //            {
        //                diagonalCoincide2 = false;
        //            }


        //        }
        //        if (diagonalCoincide2)
        //        {
        //            return diagonalCoincide2;
        //        }
        //    }
        //    return diagonalCoincide1 || diagonalCoincide2;

        //}

        
    }
}
