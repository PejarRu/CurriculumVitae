using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Antons Berzins - 1º DAW
Practica Evaluable Tema 6
OBSERVACIONES GENERALES:
Apartado 1 (Usabilidad) - SI. Prevencion de errores y excepciones

OBSERVACIONES ESPECIFICAS:
DATOS:
Apartado 2.1 (Prevencion de texto vacio) - SI 
Apartado 2.1 (Datos numericos validados) - SI 
SUBCALSES:
Apartado 3.1 (Constructor por clase) - SI 
Apartado 3.2 (Visibilidad) - PARCIAL. Puede haber alguna clase sin visibilidad explicita
Apartado 3.3 (Propiedades get/set) - PARCIAL. He usado muy poco los atributros privados.
Apartado 3.4 (Override de toString()) - NO. Como no lo he usado en el progrma no lo he implementado en ningun sitio

Apartado 5 (Texto vacio) - SI 
Apartado 6 (Texto vacio) - SI 
*/
namespace JuegosDeGuerra
{
    class JuegosDeGuerra 
    {
        public static void Main(String[] args) { 
        
            Juego j = new Juego();
            j.Lanzar();


        }

    }
}
