using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Antons Berzins - 1º DAW
Practica Evaluable Tema 6
PARTIDA:
Apartado 1.1 (Crear ambos tablero) - SI 
Apartado 1.2 (Elegir entre rellenar o generar tablero) - SI
Apartado 1.3 (Generar barcos) - PARCIAL. Uso un int[] con longitudes de los barcos

Apartado 2.1 (Bucle de juego) - SI
Apartado 2.2 (Alternacion de turnos) - SI. Se muestran los tableros necesarios para cada turno. El turno de la IA se ve parecida a la de un humano.
Apartado 2.3 (Disparos hacia el tablero enemigo) - SI
Apartado 2.4 (Tabla que reguistra todos nuestros diparos anteriores) - SI
Apartado 2.5 (Turno del ordenador) - SI

Errores: Al hundir un barco por completo el mensaje de "Barco hundido" no se ve explicitamente en la pantalla. Seguramente sea por Console.Clear(). Sin embarco la comprobacion de que el barco tiene todas las casillas hundidas si se realiza
*/
namespace JuegosDeGuerra
{
    internal class Partida
    {
        //AJUSTES DEL JUEGO GENERALES
        //Ajustes : tablero
        const int tamaño = 20;
        const int posicion = 0;
        //Ajustes : barcs
        int[] longitudesBarcos = { 5, 4, 3, 3, 2 };

        //JUEGO
        public void Lanzar() {
            string satisfecho = " ";
            Tablero tableroJugador = null;
            while (tableroJugador == null)
            {
                tableroJugador = new Tablero(longitudesBarcos, tamaño, posicion);

                string rellenar = " ";
                //Inicializaamos el tablero del jugador
                while (rellenar == " ")
                {
                    Console.WriteLine("Quieres rellenar el tablero manualmente? \"(si\\no)\"");
                    rellenar = Console.ReadLine().ToLower();
                    rellenar = rellenar == "no" || rellenar == "si" ? rellenar : " ";
                }

                //Iniclializamos el tablero del jugador y le damos visibilidad
                //Rellenamos el tablero del jugador MANUALMENTE
                if (rellenar == "si")
                {
                    Console.Clear();
                    tableroJugador.RellenarTablero(longitudesBarcos);
                }
                //Rellenamos el tablero del jugador ALEATORIAMENTE
                else if (rellenar == "no")
                {
                    Console.Clear();
                    tableroJugador.GenerarTablero(longitudesBarcos);

                }
                //Tablero de jugador creado
                Console.Clear();
                tableroJugador.MostrarTablero();

                Console.WriteLine("Todos los barcos añadidos. Barcos totales: " + longitudesBarcos.Length + "\nEste es el tablero con el que vas a jugar");
                while (satisfecho == " ")
                {
                    Console.WriteLine("Estas satisfecho con el tablero? Comenzamos \"(si\\no)\"");
                    satisfecho = Console.ReadLine().ToLower(); ;
                    satisfecho = satisfecho == "no" || satisfecho == "si" ? satisfecho : " ";

                }
                if (satisfecho == "no")
                {
                    satisfecho = " ";
                    tableroJugador = null;

                }
            }

            //Creamos el tablero ia
            Tablero tableroIA = new Tablero(longitudesBarcos, tamaño, (posicion));
            tableroIA.GenerarTablero(longitudesBarcos);

            Turnos(tableroJugador, tableroIA, longitudesBarcos);

        }
        public void Turnos(Tablero tabla1, Tablero tabla2, int[] longitudesBarcos) {
            Tablero tableroIntermedio1 = new Tablero(longitudesBarcos, tamaño, (posicion + 80));
            Tablero tableroIntermedio2 = new Tablero(longitudesBarcos, tamaño, (posicion + 80));
            Random rand = new Random();
            int numTurno = 0;
            bool hayGanador = false;
            while (!hayGanador) 
            {
                //Console.Write("Te quedan casillas por eliminar:" + puntos1 + "\nAl enemigo le quedan casillas por eliminar::" + puntos2);
                //Console.ReadLine();
                int col = 0, fil = 0;  
                if (numTurno % 2 == 0) 
                {
                    //TURNO JUGADOR 2
                    //Datos sobre el disparo para jugador 1
                    while (fil <= 0 || col <= 0)
                    {
                        TablasMostrar(tabla1, tableroIntermedio1, "TU TABLA", "TUS DISPAROS");
                        try
                        {
                            Console.WriteLine("Elige una casilla para disparar. Escribe la columna y fila correspondiente.");    
                        
                            Console.Write("Columna:");
                            col = Convert.ToInt32(Console.ReadLine());
                            col = col > tamaño ? 0 : col;

                            Console.Write("Fila:");
                            fil = Convert.ToInt32(Console.ReadLine());
                            fil = fil > tamaño ? 0 : fil;

                        }
                        catch (Exception)
                        {
                            col = 0;
                            fil = 0;
                        }

                        
                    }

                    //Disparamos. Comprobamos si el disaporo dió algo
                    bool acertado = tableroIntermedio1.ComprobarDisparo(fil, col, tabla2);

                    //Resumen del disparo
                    TablasMostrar(tabla1, tableroIntermedio1, "TU TABLA", "TUS DISPAROS");


                    Console.WriteLine("Has a disparado a C:" + col + " F:" + fil);
                    if (acertado)
                    {
                        Console.WriteLine("Has dañado un barco enemigo.");
                    }
                    else
                    {
                        Console.WriteLine("Has fallado.");
                    }
                    Console.WriteLine("Intro para siguiente turno");
                    Console.ReadLine();
                    
                }
                else
                {
                    //TURNO JUGADOR 2
                    //Datos sobre el disparo para jugador 2

                    //Generamos aleatoriamente el disparo
                    col = rand.Next(1, tamaño);
                    fil = rand.Next(1, tamaño);
                    
                    //Resumen del disparo
                    TablasMostrar(tabla2, tableroIntermedio2, "TABLA ENEMIGA", "DISPAROS ENEMIGOS");
                    //TablasMostrar(tabla1, tableroIntermedio2, "TU TABLA", "DISPAROS ENEMIGOS");
                    Console.WriteLine("El enemigo ha disparado a " + "C:" + col + " F: " + fil);


                    //Disparamos. Comprobamos si el disaporo dió algo
                    if (tableroIntermedio2.ComprobarDisparo(Convert.ToInt32(fil), Convert.ToInt32(col), tabla1))
                    {
                        //La IA dio a alguna casilla
                        Console.WriteLine("Por desgracia teniamos un barco ahi. Nos ha dañado. Intro para continuar");
                    }
                    else
                    {
                        //La IA fallo
                        Console.WriteLine("Por suerte ha fallado su disparo. Intro para continuar");

                    }
                    Console.ReadLine();
                }
                //Comprobamos si la partida a finalizdo
                if (!tabla2.ComprobarQuedanBarcos())
                {
                    hayGanador = true;
                    Console.Clear();
                    Console.WriteLine("Felicidades, has ganado");
                }
                else if (!tabla1.ComprobarQuedanBarcos())
                {
                    hayGanador = true;
                    Console.Clear();
                    Console.WriteLine("Has perdido!");
                }
                numTurno++;
            }
            Console.WriteLine("La partida finalizo con "  + numTurno + " turnos");
            Console.ReadLine();



        }
        public void TablasMostrar(Tablero tabla, Tablero tableroIntermedio, string texto1, string texto2)
        {
            Console.Clear();
            tableroIntermedio.MostrarTablero();
            Console.SetCursorPosition(posicion + 80, tamaño + 1);
            Console.WriteLine(texto2);

            tabla.MostrarTablero();
            Console.WriteLine(texto1);

        }
    }
}
