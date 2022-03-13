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

*/


using System;

class PractT2_E2_Berzins_Anton{

static void Main(){

		int num1,num2, resto, SUMA = 0;
		string divisores = ""; 

		Console.WriteLine("Primer numero");
		num1 = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Segundo numero");
		num2 = Convert.ToInt32(Console.ReadLine());

		


		//comprobacion de que num1 > num2
		do{
			if (num1<num2)
			{
				Console.WriteLine("El primer numero no puede ser menor que el segundo. Adios.");
				break;
			}


			for (int i = num2; i < num1; i++){// ELEGIMOS 1 NUMERO DEL INTERVALO, VAMOS INREMENTADO DE MENOR A MAYOR
				for (int j = 1; j < i; j++){//PARA CADA NUMERO DE ARRIBA, COGEMOR OTROS NUMEROS Y DIVIDIMOS ENTRE CADA UNO

					resto = i%j;
					
					if (resto == 0){//ME INTERESA SABER LAS DIVISIONES EXACTAS( ASÍ SABEMOS LOS DIVISORES)
				
						divisores += " + " + j;//LOS ALMACENAMOS EN "DIVISORES"
						SUMA += j;// Y LAS VAMOS SUMANDO TODAS ENTRE SÍ

						//Console.WriteLine(j + " SI es divisor de " + i);
					}

					//Console.WriteLine(divisores);	
					
				}
				if (SUMA == i){//SI LA SUMA DE LOS DIVISORES CUADRA AL COCIENTE. ES UN NUMERO PERFECTO. LO ANUNCIAMOS.
						Console.WriteLine(i + " SI es un numero perfecto: "+ i + " = " + divisores);
					}else{
						//Console.WriteLine(i + " NO es un numero perfecto: "+ i + " != " + divisores);
						
					}
				SUMA = 0;//PREPARAMOS LA VARIABLE PARA EL SIGUIENTE CICLO
				divisores = "";//PREPARAMOS LA VARIABLE PARA EL SIGUIENTE CICLO
				
			}





			Console.WriteLine("Primer numero");
			num1 = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Segundo numero");
			num2 = Convert.ToInt32(Console.ReadLine());

		}while (true);


}



}