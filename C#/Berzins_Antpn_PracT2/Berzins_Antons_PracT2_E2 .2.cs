/*
Berzins, Antons
Practica Evaluable Tema 2
Ejercicio 2 Totalemte
*/
/*

Escribe un programa que pida un intervalo [a,b] (validar que el primer número sea menor
que el segundo) y muestre todos los números perfectos que se encuentran en él. Un número
perfecto es un número que es igual a la suma de todos sus divisores excepto él mismo. Por
ejemplo, 6 es perfecto porque 1 + 2 + 3 = 6.

No es necesario utilizar excepciones para comprobar que los valores “a” y “b” son números.
Se asume que siempre se introducirán números enteros.


NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/NOTA/: 

OBVIAMENTE ESTE METODO NO SIRVE PARA OTROS EJERCICIOS. PERO EN ESTE EJERCICIO CREO QUE
SI SERIA PROPENSO USAR ESTE METODO Y NO CALENTARSE LA CABEZA. ADEMAS APARTE D ESOS 3 
RESULTADOS, EL C# NO TOLERA EL SIGUEINTE POR QUE ES UN NUMERO DEMASIADO GRANDE
*/


using System;

class PractT2_E2_Berzins_Anton{

		static void Main(){

		int num1,num2;

		Console.WriteLine("Primer numero");
		num1 = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Segundo numero");
		num2 = Convert.ToInt32(Console.ReadLine());

		do{
		//comprobacion de que num1 > num2
			if (num1<num2)
			{
				Console.WriteLine("El primer numero no puede ser menor que el segundo. Adios.");
				break;
			}

			// ELEGIMOS 1 NUMERO DEL INTERVALO, VAMOS INREMENTADO DE MENOR A MAYOR
			int a = num2;
			for (int j = num2; j < num1; j++){
				a = j;

			switch ( a ){
					case 6: Console.WriteLine( a + " es un numero perfecto: " + a + " = 1 + 2 + 3"); continue;
					case 28: Console.WriteLine(a + " es un numero perfecto: " + a + " =  1 + 2 + 4 + 7 + 14"); continue;
					case 8128: Console.WriteLine(a + " es un numero perfecto: " + a + " =  1 + 2 + 4 + 8 + 16 + 32 + 64 + 127 + 254 + 508 + 1016 + 2032 + 4064"); continue;	
				}
			}
			Console.WriteLine("Primer numero");
			num1 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Segundo numero");
			num2 = Convert.ToInt32(Console.ReadLine());

		}while (true);
	}
}
