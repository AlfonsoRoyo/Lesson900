using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1_Motor
{
   public class cMotor

    {
        // EJERCICIO 1, Crear una clase motor con los siguientes atribuos y propiedades
        Double Potencia; // Atributos de las variables
        Double Ampers;

        public double potencia { get => Potencia; set => Potencia = value; } // las propiedades , se crea para poder tener acceso desde otra clase
        public double ampers { get => Ampers; set => Ampers= value; }
        
        // añadir un metodo llamado PRINT para mostrar los datos de los atributos en la consola
        public void PrintMotor ()
        {
            Console.WriteLine("Ampers " + Ampers);
            Console.WriteLine("Potencia " + Potencia);
            Console.ReadLine(); 
        }
    }

}

 
    
