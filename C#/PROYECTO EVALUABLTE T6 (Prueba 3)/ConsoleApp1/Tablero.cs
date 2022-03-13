using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Antons Berzins - 1º DAW
Practica Evaluable Tema 6
TABLERO:
Apartado 1.1 SI
Apartado 1.2 SI

Apartado 2.1 (PonerBarco) - PARCIALMENTE. No es un bool si no void, pero siempre que se usa, se aplican anteriormente otras funciosnes auxiliares (algunas bool) para comprobar valores correctos 
Apartado 2.2 (RellenarTablero) - SI
Apartado 2.3 (GenerarTablero) - SI
Funciones auciliares -> comprobarCabe(), comprobarCaminoLibre(), GetTipoCasilla(), ComprobarDisparo(), EditarBarco(), ComprobarQuedanBarcos y otras...
*/
namespace JuegosDeGuerra
{
    internal class Tablero
    {
        //Tamaño del tablero y las casillas
        int tamaño;
        Casilla[][] casillasTablero;
        Barco[] barcosTabla;

        //El espacio que ocupara la tabla tanto en el eje X como en el Y
        int posicionTablaIni;
        int posicionTablaFin;

        //Constructores
        public Tablero(int[] longitudesBarcosTabla, int tamaño = 20, int posicionTablaIni = 0)
        {

            this.tamaño = tamaño;
            this.casillasTablero = new Casilla[tamaño][];
            this.posicionTablaIni = posicionTablaIni;
            this.barcosTabla = new Barco[longitudesBarcosTabla.Length];
            for (int i = 0; i < longitudesBarcosTabla.Length; i++)
            {
                this.barcosTabla[i] = new Barco();
                this.barcosTabla[i].SetLongitud(longitudesBarcosTabla[i]);
            }


            //Definimos la tabla por que no tiene sentido que una tabla sea "espacio vacio"
            ConstruirTablero();
        }

        //Definicion del tablero. Almacenamos la posicion y estado (".") de cada casilla
        public void ConstruirTablero()
        {
            int separacionLngt;
            //Vamos a crear un array bidimensional que representa el tablero TAMAÑO x TAMAÑO
            this.casillasTablero = new Casilla[tamaño][];
            //Filas. Definimos la primera dimension del array "casillasTablero[][]"
            for (int fil = 0; fil < tamaño; fil++)
            {
                //Definimos la primera dimension del array (Filas)
                this.casillasTablero[fil] = new Casilla[tamaño];

                //Creamos la primera columna basandonos en la separacion inicial de la pantalla. Asignamos su posicion en la pantalla (sus pixeles X e Y)
                this.casillasTablero[fil][0] = new Casilla(posicionTablaIni, fil);

                //Hallamos la separacion que ESTA casilla tendra con la SIGUIENTE. Ej: CASILLA-> ".  "; SEPARACION_CASILLA = 2
                separacionLngt = this.casillasTablero[fil][0].GetSeparacionLenght() + 1;

                //Asignamos valores al resto de casilla basandonos en la anterior
                int proximoX = posicionTablaIni + separacionLngt;


                for (int col = 1; col < tamaño; col++)
                {
                    this.casillasTablero[fil][col] = new Casilla(proximoX, fil);
                    proximoX += separacionLngt;
                }

                //Calculamos donde acabara la tabla a la hora de visualizarse
                this.posicionTablaFin = proximoX;
            }
        }
        //Visualizacion del tablero
        public void MostrarTablero()
        {
            //Filas
            for (int fil = 0; fil < tamaño; fil++)
            {
                //Columnas
                for (int col = 0; col < tamaño; col++)
                {
                    //Imprimimos la casilla en pantalla
                    this.casillasTablero[fil][col].ImprimirCasilla();

                    //Imprimimos INDICE de numero de fila
                    Console.SetCursorPosition(this.posicionTablaFin, fil);
                    Console.WriteLine((fil + 1));
                }
            }
            //Imprimimos INDICE de numero de columnas
            for (int numCol = 0; numCol < tamaño; numCol++)
            {
                //Posicionamos el cursor para el siguiente ciclo en
                Console.SetCursorPosition(casillasTablero[0][numCol].GetX(), tamaño);
                //Imprimimos el numero de la columna
                Console.Write((numCol + 1) + new string(' ', casillasTablero[0][numCol].GetSeparacionLenght()));
            }
            Console.WriteLine("");
        }
        public void RellenarTablero(int[] longitudBarco)
        {
            //Variables
            string orientacion;
            int fil, col;
            int cantidadBarcos = longitudBarco.Length;


            //Comenzamos a llamar y crear barcos
            for (int i = 0; i < cantidadBarcos; i++)
            {
                //Variables locales
                bool[] añadido = new bool[cantidadBarcos];

                //Añadimos barcos
                while (!añadido[i])
                {
                    //Imprimimos el tablero mas actualizado
                    Console.Clear();
                    MostrarTablero();

                    Console.WriteLine("Este barco ocupara " + longitudBarco[i] + " casilas ");

                    //Pedimos datos del barco
                    orientacion = PregutnarOri();
                    col = PregutnarNum("columna");
                    fil = PregutnarNum("fila");

                    //DEBUGGING
                    //Console.WriteLine("Tablero: " + tamaño +  ".F:" + casillasTablero.Length + "C:" + casillasTablero[fil].Length);
                    //Console.WriteLine("Array interpreta - [" + fil + "][" + col + "]");
                    //Console.WriteLine("Valor de tabla [" + casillasTablero[fil][col].GetY() + "][" + casillasTablero[fil][col].GetX() + "]: " + casillasTablero[fil][col].GetEstado());

                    //Comprobamos que quepa en el tablero
                    if (ComprobarCabe(col, fil, longitudBarco[i], orientacion))
                    {
                        //Comprobamos que no exista un barco en el camino(segun el tablero)
                        if (ComprobarCaminoLibre(col, fil, longitudBarco[i], orientacion))
                        {
                            //Cambiamos casillas del tablero y creamos el barco. Devolvemos valor true si fue añadido
                            PonerBarco(col, fil, longitudBarco[i], orientacion);
                            barcosTabla[i] = new Barco(col, fil, longitudBarco[i], orientacion);

                            añadido[i] = true;
                        }
                        else
                        {
                            añadido[i] = false;
                            
                        }
                    }
                    if (añadido[i])
                    {

                        Console.Write("Barco añadido. ");
                        Console.WriteLine("Intro para continuar");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("Barco no fue añadido. Comprueba que quepa en el tablero o que no interseccione con otros barcos. ");
                        Console.WriteLine("Intro para continuar");
                        Console.ReadLine();
                    }
                }
            }
        }
        public void GenerarTablero( int[] longitudBarco)
        {
            //Variables
            string orientacion;
            int fil, col;
            int cantidadBarcos = longitudBarco.Length;


            //Comenzamos a llamar y crear barcos
            for (int i = 0; i < cantidadBarcos; i++)
            {
                //Variables locales
                bool[] añadido = new bool[cantidadBarcos];
                Random rand = new Random();


                //Añadimos barcos
                while (!añadido[i])
                {
                    //Generamos aleatoriamente datos del barco
                    orientacion = rand.Next(0, 2) == 0 ? "horizontal" : "vertical";
                    col = rand.Next(0, tamaño);
                    fil = rand.Next(0, tamaño);

                    //Comprobamos que quepa en el tablero
                    if (ComprobarCabe(col, fil, longitudBarco[i], orientacion))
                    {
                        //Comprobamos que no exista un barco en el camino(segun el tablero)
                        if (ComprobarCaminoLibre(col, fil, longitudBarco[i], orientacion))
                        {
                            //Cambiamos casillas del tablero y creamos el barco. Devolvemos valor true si fue añadido
                            PonerBarco(col, fil, longitudBarco[i], orientacion);
                            barcosTabla[i] = new Barco(col, fil, longitudBarco[i], orientacion);

                            añadido[i] = true;
                        }
                        else
                        {
                            añadido[i] = false;
                        }
                    }
                }
            }
        }

        //Cambiamos casillas de las tablas y creamos Barco
        public void PonerBarco(int col, int fil, int longitudBarco, string orientacion = "vertical")
        {


            //Procedemos a editar el tablero
            for (int j = 0; j < longitudBarco; j++)
            {
                //Casilla se propaga hacia abajo
                if (orientacion == "vertical")
                {
                    casillasTablero[fil + j][col].SetEstado("B");

                }
                //Casilla se propaga hacia derecha
                else if (orientacion == "horizontal")
                {
                    casillasTablero[fil][col + j].SetEstado("B");
                }
            }
        }
        public bool ComprobarCabe(int col, int fil, int longitud, string orientacion)
        {
            longitud -= 1;
            bool siCabe = false;
            //HORIZONTAL: La ultima casilla tendra la misma fila que la primera
            if (orientacion == "horizontal" && (fil) < (tamaño) && (col + longitud) < (tamaño)) { siCabe = true; }
            //VERTICAL: La ultima casilla tendra la misma columna que la primera
            else if (orientacion == "vertical" && (fil + longitud) < (tamaño) && (col) < (tamaño)) { siCabe = true; }
            //El barco no cabe en el tablero. Devolvemos false
            else { siCabe = false; }

            return siCabe;
        }
        public bool ComprobarCaminoLibre(int col, int fil, int longitud, string orientacion)
        {
            bool caminoLibre = false;
            //Boleano que indica si las casillas son agua "."
            string[] estadosCasillas = new string[longitud];

            //Accedemos a cada casilla
            for (int j = 0; j < longitud; j++)
            {
                //Accedemos a la casilla correspondiente
                if (orientacion == "vertical")
                {
                    //Casilla se propaga hacia derecha
                    estadosCasillas[j] = GetTipoCasilla(fil + j, col);
                }
                else if (orientacion == "horizontal")
                {
                    //Casilla se propaga hacia abajo
                    estadosCasillas[j] = GetTipoCasilla(fil, col + j);
                }
            }
            caminoLibre = estadosCasillas.Contains("B") ? false: true;
            return caminoLibre;
        }
        public string GetTipoCasilla(int col, int fil)
        {
            //Console.WriteLine(casillasTablero[col][fil].GetEstado());

            //Devolvemos "." o "B"
            return casillasTablero[col][fil].GetEstado();
        }
        public bool ComprobarDisparo(int col, int fil, Tablero tablaEnemiga)
        {
            col -= 1;
            fil -= 1;
            bool acertado = false;
            //Disparo acertado
            if (tablaEnemiga.GetTipoCasilla(col, fil) == "B") {
                
                //Actualizamos tabla enemiga
                tablaEnemiga.casillasTablero[col][fil].SetEstado("X");
                //Actualizamos barco enemigo
                tablaEnemiga.EditarBarco(col, fil, tablaEnemiga);
                //Actualizamos nuestra tabla de registrto
                this.casillasTablero[col][fil].SetEstado("X");
                acertado = true;

            }
            //Disparo fallado
            else
            {
                this.casillasTablero[col][fil].SetEstado("0");
                acertado = false;
            }
            //Actualizamos nuestra tabla de registro

            return acertado;

        }
        public void EditarBarco(int col, int fil, Tablero tabla) {
            int cantidadBarcos = barcosTabla.Length;
            foreach (Barco barco in barcosTabla)
            {
                if (barco != null)
                {
                    if (barco.EditarCasillaBarco(col, fil))
                    {
                        Console.WriteLine("Exito. Casilla (" + col + "," + fil + ") dañada");

                    }
                }
                
            }
        }
        public bool ComprobarQuedanBarcos() {

            foreach (Casilla[] fila in casillasTablero)
            {
                foreach (Casilla casilla in fila)
                {
                    if (casilla.GetEstado() == "B")
                    {
                        //Aun queda algun barco, seguimos jugando
                        return true;
                    }
                }
            }
            //No queda ningun barco, fin del juego
            return false;
        }

        //Conversaciones con el usuario
        public int PregutnarNum(string texto)
        {
            int X;
            String result = "";

            while (!Int32.TryParse(result, out X))
            {
                Console.WriteLine("Escribe " + texto + " del barco");
                result = Console.ReadLine();
            }

            return Int32.Parse(result) - 1;
        }

        public string PregutnarOri()
        {
            string orientacion = " ";
            //Preguntamos sobre la orientacion del barco
            while (orientacion == " ")
            {
                Console.WriteLine("Lo quieres vertical (\"vertical\") o horizontal (\"horizontal\")");
                orientacion = Console.ReadLine().ToLower(); ;

                orientacion = orientacion == "horizontal" || orientacion == "vertical" ? orientacion : " ";

            }

            return orientacion;
        }

    }

}

