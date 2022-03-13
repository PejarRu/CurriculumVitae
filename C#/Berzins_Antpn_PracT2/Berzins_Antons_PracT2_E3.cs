/*
Berzins, Antons
Practica Evaluable Tema 2
Ejercicio 3 TOTALMENTE
*/
/*

Realiza un programa que le pida al usuario el tamaño del lado de un hexágono regular, y
luego lo dibuje en pantalla con asteriscos. Por ejemplo, si el usuario elige un hexágono de
lado 3, se dibujará esto:

3->5h
   ** *
  *** **
 **** *** anchura max:7
  *** ** 
   ** * 5
4l->7h
   ** **
  *** ***
 **** ****
***** ***** anchura max:10
 **** ****
  *** ***
   ** **

5l-> 9h
    *** **
   **** ***
  ***** ****
 ****** *****
******* ****** anchura max:13
 ****** *****
  ***** ****
   **** ***
	*** **

6l-> 11h
     *** ***
    **** ****
   ***** *****
  ****** ******
 ******* *******
******** ******** anchura max:16
 ******* *******
  ****** ******
   ***** *****
    **** ****
 	 *** ***

	  Conclusion:
	  altura = (lado * 2) - 1;
	  anchura max = (lado * 3) - 2;
*/

using System;

class PractT2_E3_Berzins_Anton{

	static void Main(){

		int lado;
		
			Console.WriteLine("\nEscibre el lado del hexagono: ");
			lado = Convert.ToInt32(Console.ReadLine());
			
//--------------------------------------------------------


        




		do
		{
			int copia_lado = lado;
			int altura = ((lado * 2) - 1);
			int lado_max = (lado * 3) - 2;
			int espacio1 = lado-2;

			for (int i = 1; i <= altura; i++)
			{	
				if (i < lado )//PARTE SUPERIOR SUPERIOR SUPERIOR SUPERIOR SUPERIOR SUPERIOR SUPERIOR SUPERIOR
				{
					
					for (int x = espacio1; x >= 0; x--)//espacios de la iaquierda de 1 en 1
					{
						Console.Write(" ");
						
					}
					
					for (int y = copia_lado; y > 0; y-=1)//asteriscos de 1 en 1(Realmente de 2 en dos)
					{
						Console.Write("*");
						
						
					}
					espacio1--;//DECRECIENDO DEL ESPACIO
					copia_lado+=2; //CRECIENDO DEL ASTERISCO PARA QUE SEA DE 2 EN 2
					
					Console.Write("\n");


				}else{//PARTE INFERIOR INFERIOR INFERIOR INFERIOR INFERIOR INFERIOR INFERIOR INFERIOR INFERIOR
					
					for (int x = 0; x <= espacio1; x++){//Espacios de la izquierda de 1 en 1
					
						Console.Write(" ");
					}
					for (int y = 0; y < copia_lado; y+=1){//Ateriscos 
					
						Console.Write("*");
						
					}
					espacio1++;
					copia_lado-=2;
					Console.Write("\n");
				}			
			}
				Console.WriteLine("\nEscibre el lado del hexagono: ");
				lado = Convert.ToInt32(Console.ReadLine());
		
		} while (lado > 0);

//----------------------------------------------------

	}	


}
