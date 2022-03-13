/* ==============================ENUNCIADO=================================*/
/*
Antons Berzins
Practica Evaluable Tema 4
Ejercicio 1
Apartado 1.1 si 
Apartado 1.2 si 
Apartado 1.3 si
Apartado 1.4 si

Apartado 1.5 no - Necesito rehacer todo el programa con STRUCTS:

        ////struct ubicacionProducto
	       //// {
		      ////  public byte pasillo;
		      ////  public byte seccion;
	       //// }
	
	       //// struct producto
	       //// {
		      ////  public string codigo;
		      ////  public string descripcion;
		      ////  public string marca;
		      ////  public float precio;
		      ////  public ubicacionProducto ubicacion;
	       //// }
	

Apartado 1.6 parcialmente

Apartado 1.7 si

Apartado 1.8 parcialmente

Apartado 1.9 no

Apartado 1.10 si



*/
/*==============================ENUNCIADO=================================*/
using System;

public class EJERCICIO_1_ANTONSBERZINS {

    public static void Main(String[] args)
    {
        const int CNT = 100;

/*########### PSEUDO STRUCT ####################*/
        string[] codigoMueble = new string[CNT];
        string[] descripcionMueble = new string[CNT];
        string[] marcaMueble = new string[CNT];
        float[] precioMueble = new float[CNT];

        //int[][] ubicacionMueble = new int[50][];

/*########### PSEUDO STRUCT ####################*/

/*########### VARIABLES ####################*/

        int input, cantidadProd = 0, i = 0;
        float almacenTemporalFloat = 0.00f;
        string almacenTemporalString;
        bool encontrado = false;

/*########### VARIBLE ####################*/

        /*########### 10 DATOS PREESTABLECIDOS PARA TRABAJAR ####################*/
        for (i = 0; i < 10; i++)
        {
            codigoMueble[i] = "codigo" + i;
            descripcionMueble[i] = "descripcion" + i;
            marcaMueble[i] = "marca" + i;
            precioMueble[i] = i;
           
        }
        cantidadProd = 10;
        /*########### 10 DATOS PREESTABLECIDOS PARA TRABAJAR ####################*/

        do
        {
            Console.WriteLine("\nElige una opcion: \n" +
          "1.-Añadir un producto\n" +
          "2.-Borrar un producto\n" +
          "3.-Buscar un producto\n" +
          "4.-Ordenar productos\n" +
          "5.-Calcular importe producto\n" +
          "6.-Mostrar todos los productos\n" +
          "0.-Salir \n");
            input = Convert.ToInt32(Console.ReadLine());


            switch (input)
            {
                case 1://Añadir producto
                    for (i = 0; i < codigoMueble.Length; i++)
                    {

                        if (String.IsNullOrEmpty(codigoMueble[i]))
                        {
                            Console.WriteLine("1.-Añadir producto \n");

                            //AÑADIMOS UN NOMBRE
                            do
                            {
                                Console.WriteLine("Escribe el nombre");
                                almacenTemporalString = Convert.ToString(Console.ReadLine());

                            } while (String.IsNullOrEmpty(almacenTemporalString));
                            codigoMueble[i] = almacenTemporalString;

                            //AÑADIMOS UNA DESCRIPCION
                            do
                            {
                                Console.WriteLine("Escribe la descripcion");
                                almacenTemporalString = Convert.ToString(Console.ReadLine());

                            } while (String.IsNullOrEmpty(almacenTemporalString));
                            descripcionMueble[i] = almacenTemporalString;
                           
                            //AÑADIMOS UNA MARCA
                            do
                            {
                                Console.WriteLine("Escribe la marca");
                                almacenTemporalString = Convert.ToString(Console.ReadLine());

                            } while (String.IsNullOrEmpty(almacenTemporalString));
                            marcaMueble[i] = almacenTemporalString;

                            //AÑADIMOS UN PRECIO
                            do
                            {
                                Console.WriteLine("Escribe un percio");
                                almacenTemporalString = Convert.ToString(Console.ReadLine());

                            } while (String.IsNullOrEmpty(almacenTemporalString));
                            precioMueble[i] = float.Parse(almacenTemporalString);
                          

                            ////AÑADIMOS UNA UBICACION
                            ////La seccion esta llena
                            //if (ubicacionMueble[pasillo, seccion] >= 39)
                            //{
                            //    //Pasamos a otro pasillo
                            //    pasillo++;
                            //    seccion = 0;
                            //}
                            //else {
                            //    //La seccion tiene hueco
                            //    seccion++;
                            //}
                            ////Asignamos a ese hueco el valor "i"
                            //ubicacionMueble[pasillo, seccion] = i;
                            break;
                        }
                    }
                    cantidadProd++;
                    break;



                case 2://Borrar producto
                    Console.WriteLine("2.-Borrar producto \n");

                    for (i = 0; i < codigoMueble.Length; i++)
                    {
                        if (codigoMueble[i] == null && codigoMueble[i + 1] == null)
                        {
                            break;
                        }
                        Console.WriteLine(codigoMueble[i] + " " + descripcionMueble[i] + " " + marcaMueble[i]);
                    }
                    Console.WriteLine("Que mueble quieres borrar? ");
                    almacenTemporalString = Convert.ToString(Console.ReadLine());
                    
                    encontrado = false;
                    i = 0;
                    do
                    {
                                                //El nombre encaja. "i" es la posicion del producto
                            int indice = Array.IndexOf(codigoMueble, almacenTemporalString);
                        if (indice > -1)
                        {
                            encontrado = true;
                            Console.WriteLine("Procedo a eliminar: " + codigoMueble[indice] + " " + descripcionMueble[indice] + " " + marcaMueble[indice] + "\n");

                            // mueble[i] toma valor del siguiente elemento mueble[i+1]
                            for (int j = indice; j < codigoMueble.Length - 1; j++)
                            {
                                
                                almacenTemporalString = codigoMueble[j + 1];
                                codigoMueble[j] = almacenTemporalString;
                                
                                almacenTemporalString = descripcionMueble[j + 1];
                                descripcionMueble[j] = almacenTemporalString;
                                                                                               
                                almacenTemporalString = marcaMueble[j + 1];
                                marcaMueble[j] = almacenTemporalString;
                                                                
                                almacenTemporalFloat = precioMueble[j + 1];
                                precioMueble[j] = almacenTemporalFloat;



                                ////Buscamos la ubicacion del producto
                                //int a, b;
                                ////Pasillos
                                //for (a = 0; a < 50; a++)
                                //{   //Secciones
                                //    for (b = 0; b <= 40; b++)
                                //    {
                                //        Console.WriteLine("CheckPoint 3 ");

                                //        //Ubicacion encontrada en pasillo "A", seccion "B"
                                //        if (ubicacionMueble[a, b] == j)
                                //        {
                                //            Console.WriteLine("Ubicacion encontrada");

                                //            ubicacionMueble[a, b] = ubicacionMueble[a, (b + 1)];
                                //            break;
                                //        }
                                //        else
                                //        {
                                //            Console.WriteLine("Ubicacion no encontrada");
                                //        }
                                //    }
                                //}
                            }
                        }
                        i++;
                    } while (codigoMueble.Equals(almacenTemporalString) && i < 20); 

                    i = 0;
                    if (encontrado)
                    {
                        Console.WriteLine("Borrado :)");
                        cantidadProd--;
                    }
                    else { 
                        Console.WriteLine("No encontrado :(");
                    }
                    
                    break;
                   
                case 3://Buscar producto
                    i = 0;

                    Console.WriteLine("Escribe parte de la descripcion del producto: ");
                    almacenTemporalString =Convert.ToString(Console.ReadLine());

                    //Si contiene algo parecido
                        for (int j = 0; j < codigoMueble.Length - 1; j++)
                        {
                            if (descripcionMueble[j] != null)
                            {
                                if(descripcionMueble[j].IndexOf(almacenTemporalString) > -1)
                                {
                                    Console.WriteLine("Lo mas parecido: " + codigoMueble[j] + " " + descripcionMueble[j] + " " + marcaMueble[j]);
                                    i++;
                                }
                            }
                        }

                    //if (i > 0)
                    //{
                    //    Console.WriteLine("Hay " + i + " productos parecidos");
                    //}
                    //else {
                    //    Console.WriteLine("No se ha encontrado nada :(");
                    //}

                    break;
                ////case 4://Ordenar productos
                ////    Console.WriteLine("4.-Mostrar productos \n");

                ////    //MOSTRAR ARRAY ANTES DE ORDENAR
                ////    Console.WriteLine("Antes de ordenar: \n");
                ////    for (i = 0; i < codigoMueble.Length; i++)
                ////    {
                ////        if (codigoMueble[i] == null && codigoMueble[i + 1] == null)
                ////        {
                ////            break;
                ////        }
                ////        Console.WriteLine(codigoMueble[i] + " " + descripcionMueble[i] + " " + marcaMueble[i] +);
                ////    }


                ////    //ORDENAR ARRAY 
                ////    Console.WriteLine("\t Ordenando...\n");
                ////    for (i = 0; i < codigoMueble.Length; i++)
                ////    {
                ////        if (codigoMueble[i] == null && codigoMueble[i + 1] == null)
                ////        {
                ////            break;
                ////        }
                ////        Console.WriteLine(codigoMueble[i] + " " + descripcionMueble[i] + " " + marcaMueble[i]);
                ////    }

                ////    //MOSTRAR ARRAY DESPUES DE ORDENAR
                ////    Console.WriteLine("Proceso terminado :) \n");
                ////    for (i = 0; i < codigoMueble.Length; i++)
                ////    {
                ////        if (codigoMueble[i] == null && codigoMueble[i + 1] == null)
                ////        {
                ////            break;
                ////        }
                ////        Console.WriteLine(codigoMueble[i] + " " + descripcionMueble[i] + " " + marcaMueble[i]);
                ////    }

                ////    break;

                case 5://Calcular importe
                    Console.WriteLine("5.-Calcular importe productos \n");
                            float precioFinal = 0;
                            
                            i = 1;
                    encontrado = false;
                        do
                        {
                            Console.WriteLine("Elige los productos a la cesta(escribe su codigo): ");
                            almacenTemporalString = Convert.ToString(Console.ReadLine());
                        
                        //for (int a = 0; a < codigoMueble.Length - 1; a++) 
                        //{ 
                                    
                        //    if (descripcionMueble[a] != null)
                        //    {
                        //        //Procusto encontrado
                        //        if (descripcionMueble[a].IndexOf(almacenTemporalString) > -1)
                        //        {
                        //            //Indice/posicion encontrado
                        //            Console.WriteLine("Añadido: " + codigoMueble[a] + " " + descripcionMueble[a] + " " + marcaMueble[a]);
                        //            encontrado = true;
                        //            precioFinal += precioMueble[a];
                        //        }
                        //        //Produsto NO encontrado
                        //        else
                        //        {
                        //            encontrado = false;

                        //        }
                        //    }

                        //}
                        if (encontrado)
                        {
                            Console.WriteLine("De momento llevas: " + precioFinal + "$");
                        }
                        else {
                            Console.WriteLine("No encontrado nada parecido ");
                        }



                        Console.WriteLine("Añadimos algo? (0.-salir; 1.-continuar) \n");
                            i = Convert.ToInt32(Console.ReadLine());

                          

                            if (i <= 0){ goto salida1; }
                            
                        } while (i >= 0);
                    
                    Console.WriteLine("El importe es : {0} euros", precioFinal.ToString("0.00"));

                salida1:
                    break;
                case 6://Mostrar productos
                    Console.WriteLine("3.-Mostrar productos \n");
                    for (i = 0; i < codigoMueble.Length; i++)
                    {
                        if (codigoMueble[i] == null && codigoMueble[i + 1] == null)
                        {
                            break;
                        }
                        Console.WriteLine(codigoMueble[i] + " " + descripcionMueble[i] + " " + marcaMueble[i]);
                    }

                    break;
                default:
                    Console.WriteLine("0.-Finalizar programa \n");
                    Console.WriteLine("Adios.  \n");

                    break;
            }

        } while (input > 0);
      


    }


}


/*########################################### SOLUCION ###########################################*/

/*

*/

/*########################################### SOLUCION ###########################################*/