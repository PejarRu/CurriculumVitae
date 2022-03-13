using System;

namespace Anton_Berzins_1DAW
{
    class TiendaMuebles
    {
        /*
        Perez Gomez, Andres
        Practica Evaluable Tema 4
        Ejercicio 1
        Apartado 1.1 si / no / parcialmente
        Apartado 1.2 si / no / parcialmente
        Apartado 1.3 si / no / parcialmente
        Apartado 1.4 si / no / parcialmente
        ...
        */
        struct ubicacionProducto
        {
            public byte pasillo;
            public byte seccion;
        }

        struct producto
        {
            public string codigo;
            public string descripcion;
            public string marca;
            public float precio;
            public ubicacionProducto ubicacion;
        }
        public static void Main()
        {

            producto[] compras = new producto[50];
            
            int cantProductos = 0;

            string respuesta;
            int opcion;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Elige una de estas opciones:");
                Console.WriteLine("Opcion 1: Añadir producto");
                Console.WriteLine("Opcion 2: Borrar producto");
                Console.WriteLine("Opcion 3: Buscar producto");
                Console.WriteLine("Opcion 4: Ordenar productos");
                Console.WriteLine("Opcion 5: Calcular importe");
                //Opcion 6: No existente(Break)

                opcion = Convert.ToInt32(Console.ReadLine());
                
                switch (opcion) {
                    
                    case 1: //Añadir producto

                        if (cantProductos < 50)
                        { //Si que hay espacio para añadir productos
                            Console.WriteLine("Opcion 1: Añadir producto");

                            Console.WriteLine("Codigo del producto");
                            respuesta = Console.ReadLine();

                            //Codigo del producto
                            while (respuesta == "")
                            {
                                Console.WriteLine("Codigo del producto(9 cifras):");
                                respuesta = Console.ReadLine();
                            }
                            compras.codigo.[cantProductos] = respuesta.Insert(3, ".").Insert(7, ".");
                            


                            //Descripcion del producto
                            Console.WriteLine("Descripcion del producto:");
                            respuesta = Console.ReadLine();
                            while (respuesta == "")
                            {
                                Console.WriteLine("Descripcion del producto:");
                                respuesta = Console.ReadLine();
                            }
                            compras.descripcion[cantProductos] = respuesta;

                            //Marca del producto
                            Console.WriteLine("Marca del producto");
                            respuesta = Console.ReadLine();
                            while (respuesta == "")
                            {
                                Console.WriteLine("Marca del producto");
                                respuesta = Console.ReadLine();
                            }
                            marca[cantProductos] = respuesta;


                            //Precio del producto
                            Console.WriteLine("Precio del producto");
                            respuesta = Console.ReadLine();
                            while (respuesta == "")
                            {
                                Console.WriteLine("Marca del producto");
                                respuesta = Console.ReadLine();
                            }

                            precio[cantProductos] = float.Parse(respuesta);

                            //Resumen
                            Console.WriteLine("Resumen: {0}, {1}, {2}, {3}$", 
                                compras.codigo[cantProductos], 
                                compras.descripcion[cantProductos], 
                                compras.marca[cantProductos], 
                                compras.precio[cantProductos]);

                            break;

                            cantProductos++;
                        }
                        else
                        {
                            Console.WriteLine("No queda espacio para añadir nuevos productos. Prueba otra opcion.");
                            break;
                        }
                            
                        
                    case 2: //Borrar producto
                        Console.WriteLine("Opcion 2: Borrar producto");
                        for (int i = cantProductos; i < 50; i++)
                        {

                            Console.WriteLine(codigo[i] + " , " + descripcion[i] + ", " + marca[i] + "\n");
                            Console.WriteLine("Escribe el codigo del producto que deseas eliminar: ");
                            string eliminar = Console.ReadLine().Replace(".", "");

                            for (int j = 0; j < 50; j++)
                            {


                            }
                        }
                        break;


                    case 3: //Buscar producto
                        Console.WriteLine("Opcion 3: Buscar producto");
                        break;


                    case 4: //Ordenar productos
                        Console.WriteLine("Opcion 4: Ordenar productos");
                        break;

                    case 5: //Calcular importe
                        Console.WriteLine("Opcion 5: Calcular importe");
                        break;

                    default:
                        Console.WriteLine("Opcion desconocida");
                        break;

                }


            } while (opcion > 0);
        }
    }
}
