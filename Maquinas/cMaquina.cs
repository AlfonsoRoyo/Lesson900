using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1_Motor
{

    //EJERCICIO 2 , Crear una clase maquina con los siguientes atributos y propiedas
    public class cMaquina
    {
           // AQUI SE CREAN LOS ATRIBUTOS.................................................
        Double PotenciaTotal; 
        Double AmpersTotal;
        public enum model // Modelo tipo enumerado , se crea de esta forma
        {
            Agitador,
            Diluidor,
            Hidrosolver
        }
        private model Modelo; // aqui creamos el atributo del tipo de variable , no se usa
       
        //Matriz de la clase motores      
        public cMotor[] Motores = null;

        // AQUI SE CREAN LAS PROPIEDADES.....................................................
        public double potenciaTotal { get => PotenciaTotal; set => PotenciaTotal = value; } // las propiedades , se crea para poder tener acceso desde otra clase
        public double ampersTotal { get => AmpersTotal; set => AmpersTotal = value; }
        public cMotor[] motores { get => Motores; set => Motores = value; }  
        public model modelo { get => Modelo; set => Modelo = value; }
        public static cMaquina Hidrosolver { get; internal set; }
        //EJERCICIO 3 // Añadir un constructor a la clase maquina para introducir el modelo de la maquina,
        // segun el modelo se delimitara el numero de elementos de la matriz de motores
        public cMaquina() { } //llamada al contructor de la clase cMaquina    

         public cMaquina(model v)  
            {
            Console.WriteLine("has entrado en la clase maquina"); Console.ReadLine();
            if (model.Agitador == v ) // compara con la lista de enumerados si es Agitador pondrá un 2 en la variable nom (numero de motores)
            {
                Console.WriteLine("has selecionado Agitador"); Console.ReadLine();
                Motores = new cMotor[2];
            }
            if (model.Diluidor == v)
            {
                Console.WriteLine("has selecionado Diluidor"); Console.ReadLine();
                Motores = new cMotor[3];
            }
            if (model.Hidrosolver == v)
            {
                Console.WriteLine("has selecionado HIdrosolver"); Console.ReadLine();
                Motores = new cMotor[4];
            }
            for (int i = 0; i < Motores.Length; i++)
            {
                Console.WriteLine("En cMaquina, iterando el numero de motores " + Motores ); Console.ReadLine();
                Motores[i] = new cMotor();

            }
        
        }

        // añadir un metodo llamado PRINT para mostrar los datos de los atributos  en la consola 
        public void PrintMaquina()
        {

            Console.WriteLine("Potencia total " + PotenciaTotal);
            Console.WriteLine("Amperios Total " + AmpersTotal);
            Console.WriteLine("Modelo" + this.Modelo);
            Console.ReadLine();        

            for (int i = 0; i < Motores.Length; i++) // Accedemos a la variable Nom a traves de su propiedad (get,set) ,
            {
                Console.WriteLine("PrintMotor ");
                Motores[i].PrintMotor();
            }
            Console.WriteLine("En cMaquina vas a llamar al metodo calTotales"); Console.ReadLine();
            this.CalTotales();
        }
        //añadir un metodo para calcular la potencia total en base a la cantidad de motores que tenga el modelo ,
        // el resultado debe actualizar los atributos potenciaTotal y amperiosTotal
        // el metodo debe llamarse dentro de la propia clase cada vez que se modifique el modelo
        public void CalTotales()
        {
            Console.WriteLine("En cMaquina,has entrado en el metodo CalTotales"); Console.ReadLine();
            for (int i = 0; i < Motores.Length; i++)
            {               
                PotenciaTotal = PotenciaTotal + Motores[i].potencia;
                AmpersTotal = AmpersTotal + Motores[i].ampers;
                Console.WriteLine("calculando potencia " + (PotenciaTotal ));
                Console.WriteLine("calculando Amperios " + (AmpersTotal));
            }
        }



    }     
}
