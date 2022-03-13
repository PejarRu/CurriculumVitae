/*
Berzins, Antons
Practica Evaluable Tema 2
Ejercicio 1 TOTALMENTE
*/

/*ENUNCIADO:
Implementa un programa que solicite al usuario dos números enteros que representen el día
y el mes de una fecha y, muestre por pantalla la estación del año correspondiente. El
programa pedirá de forma recurrente más parejas de números hasta que se introduzca un
“0” como día o mes.
Suponemos que el mes de Febrero siempre tendrá 28 días, y la siguiente distribución de las
estaciones del año:
• Primavera : del 21 de Marzo al 20 de Junio
• Verano : del 21 de Junio al 21 de Septiembre
• Otoño: del 22 de Septiembre al 21 de Diciembre
• Invierno: del 22 de Diciembre al 20 de Marzo
En caso de que la entrada introducida no se corresponda con ninguna estación, se debe
mostrar el mensaje "Fecha incorrecta" y continuar la ejecución del programa.
Utilizando excepciones (bloques try..catch) se deberá controlar si los datos introducidos no
son números, mostrar un mensaje de error y continuar la ejecución del programa.
*/

/*MENSAJE : 
No sabia si al intorducir 0 en cualquier de las variables, se permite mostrar un mensaje de TEMPORADA
en el caso de que no se pueda, se deberia de añadir un "if" en cada "case" para validar que (dia != 0)
y solo si este fuese verdadero, se escribiria el mensaje.
*/

using System;

	class PractT2_E1_Berzins_Anton{

		static void Main(){

		int dia = 1, mes = 1;	

		do{
				
			try{

				Console.WriteLine("\nEscribe un dia: ");
	 			dia = Convert.ToInt32(Console.ReadLine());
	 
	 			Console.WriteLine("\nEscribe un mes del año: ");
	 			mes = Convert.ToInt32(Console.ReadLine());

			if (dia == 0 || mes == 0)
				{
					Console.WriteLine("Adeu");
					break;
				}else if( dia > 31)
				{
					Console.WriteLine("Fecha introducida incorrectamente");
					continue;
				}
				else{	
					switch ( mes ) {

						case 1: Console.WriteLine("Estamos en INVIERNO");
						continue;
							
						case 2: 
							if (dia > 28)
							{
								Console.WriteLine("Fecha introducida incorrectamente");
								continue;

							}else
							{	
								Console.WriteLine("Estamos en INVIERNO");
								continue;
							}


						case 3:
							if (dia <= 20)
							{
								Console.WriteLine("Estamos en INVIERNO");
								continue;

							}else
							{	Console.WriteLine("Estamos en PRIMAVERA");
							continue;
							}

						case 4: Console.WriteLine("Estamos en PRIMAVERA");
						continue;


						case 5: Console.WriteLine("Estamos en PRIMAVERA");
						continue;


						case 6:
							if (dia <= 20)
							{
								Console.WriteLine("Estamos en PRIMAVERA");
								continue;

							}else
							{	Console.WriteLine("Estamos en VERANO");
								continue;
								
							}

						case 7: Console.WriteLine("Estamos en VERANO");
						continue;

						case 8: Console.WriteLine("Estamos en VERANO");
						continue;

						case 9: 
							if (dia <= 21)
							{
								Console.WriteLine("Estamos en VERANO");
								continue;
							}else
							{	Console.WriteLine("Estamos en OTOÑO");
								continue;
								
							}

						case 10: Console.WriteLine("Estamos en OTOÑO");
						continue;

						case 11: Console.WriteLine("Estamos en OTOÑO");
						continue;

						case 12: 
							if (dia <= 21)
							{
								Console.WriteLine("Estamos en OTOÑO");
								continue;
							}else
							{	Console.WriteLine("Estamos en INVIERNO");
								continue;
								
							}
			
						default: 
						
							Console.WriteLine("Fecha introducida incorrectamente");
							continue;	
				
					}	
		}
			}
			catch (FormatException){
				
				Console.WriteLine("No es un número válido");
				continue;
			}

		} while (dia > 0 && mes > 0);

	}		

}





	/*cases mal planteados

				case (mes == 12 && dia <= 21): Console.WriteLine("Estamos en INVIERNO");
				case (mes >= 1 || mes <= 3): Console.WriteLine("Estamos en INVIERNO");
				case (mes == 3 && dia >= 20): Console.WriteLine("Estamos en INVIERNO");

				case (mes == 3 && dia <= 21): Console.WriteLine("Estamos en PRIMAVERA");
				case (mes >= 3 || mes <= 6): Console.WriteLine("Estamos en PRIMAVERA");
				case (mes == 6 && dia >= 21): Console.WriteLine("Estamos en PRIMAVERA");

				case (mes == 6 && dia <= 22): Console.WriteLine("Estamos en VERANO");
				case (mes >= 6 || mes <= 9): Console.WriteLine("Estamos en VERANO");
				case (mes == 9 && dia >= 21): Console.WriteLine("Estamos en VERANO");

				case (mes == 9 && dia <= 22): Console.WriteLine("Estamos en OTOÑO");
				case (mes >= 9 || mes <= 12): Console.WriteLine("Estamos en OTOÑO");
				case (mes == 12 && dia >= 20): Console.WriteLine("Estamos en OTOÑO");
	
	

	*/

			/*
			
			while (dia != 0 || mes != 0){

			bool primavera = false, verano = false, otoño = false, invierno = false;
			//Tenemos ambas variables alamcenadas

				if ( dia <= 31 && mes <= 12) //Para seguir en el programa, mes < 12 y dia<31 (Caracteristicas generales de las fechas)
				//Si no se cumple se muestra un mensaje de error y repite el programa
				{
					
					if (mes == 2 && dia >= 28)//Segunda validacion. En el caso de que el mes sea 2(Febrero) y el dia > 28; Lanzamos error
					{
						Console.WriteLine("Fecha incorrecta");//mensaje de error
						break;


					}else if(mes == 2 && dia >= 28){// En el caso de que el mes sea 2(Febrero), el dia debe ser menor de 28. Si es asi, proseguimos
						

						
					}//Primavera : del 21 de Marzo al 20 de Junio
					else if(mes >= 3 && mes <=6) //Posiblemente Primavera
					{
						if (mes == 3 && dia >= 21)//Esta dentro del rango
						{
							primavera = true;
					Console.Write("La estacion del año es PRIMAVERA");

						}else if(mes == 6 && dia >=20)//Esta dentro del rango
						{
							primavera = true;
					Console.Write("La estacion del año es PRIMAVERA");

						}else {//Esta fuera del rango
							primavera = false;
						}
						
					}//Verano : del 21 de Junio al 21 de Septiembre
					else if(mes >= 6 && mes <= 9)//Posiblemente Verano
					{
						if (mes == 6 && dia >= 21)//Esta dentro del rango
						{
							verano = true;
					Console.Write("La estacion del año es VERANO");

						}else if(mes == 9 && dia <=21)//Esta dentro del rango
						{
							verano = true;
					Console.Write("La estacion del año es VERANO");

						}else {//Esta fuera del rango
							verano = false;
						}
						
					}//Otoño: del 22 de Septiembre al 21 de Diciembre
					else if(mes >= 9 && mes <= 12)//Posiblemente Otoño
					{
						if (mes == 9 && dia >= 22)//Esta dentro del rango
						{
							otoño = true;
					Console.Write("La estacion del año es OTOÑO");

						}else if(mes == 12 && dia <=21)//Esta dentro del rango
						{
							otoño = true;
					Console.Write("La estacion del año es OTOÑO");

						}else {//Esta fuera del rango
							otoño = false;
						}
						
					}//Invierno: del 22 de Diciembre al 20 de Marzo
					else if((mes == 12 || mes >= 1) && mes <= 3)//Posiblemente Invierno
					{
						if (mes == 12 && dia >= 22)//Esta dentro del rango
						{
							invierno = true;
					Console.Write("La estacion del año es INVIERNO");

						}else if(mes <= 3 && dia >=20)//Esta dentro del rango
						{
							invierno = true;
					Console.Write("La estacion del año es INVIERNO");
							
						}else {//Esta fuera del rango
							invierno = false;
						}
					}
					
				}else if(mes == 0 || dia == 0)
				{
					break;
				}else{

				Console.WriteLine("Fecha incorrecta"); //mensaje de error
				break;

				}

			}

			*/


			
			
			/*switch (VALOR)
			{
				case primavera: Console.Write("La estacion del año es PRIMAVERA");
				case verano: Console.Write("La estacion del año es VERANO");
				case otoño: Console.Write("La estacion del año es OTOÑO");
				case invierno: Console.Write("La estacion del año es INVIERNO");

				default: continue;
			}
			*/


