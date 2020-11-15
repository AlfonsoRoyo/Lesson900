using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1_Motor
{
    class Program
    {
        static void Main(string[] args)
        {
            // inicializacion de la clase cMotor 
            cMotor cm = new cMotor();
            cm.ampers = 4;
            cm.potencia = 3;

            Console.WriteLine("Desde Program,vas a llamar al metodo PrintMotor"); Console.ReadLine();          
            cm.PrintMotor();
            //llamada al constructor de la clase maquina 
            Console.WriteLine("Desde Program, vas a llamar al constructor de la clase maquina"); Console.ReadLine();

            cMaquina mq = new cMaquina(cMaquina.model.Hidrosolver);
            
            for (int i = 0; i < mq.motores.Length; i++)
            {
                Console.WriteLine("iterando  los datos en la matriz " + mq.motores[i].ampers); Console.ReadLine();

                mq.motores[i].ampers = cm.ampers;
                mq.motores[i].potencia = cm.potencia;
            }
            Console.WriteLine("Desde Program,vas a llamar al metodo PrintMaquina"); Console.ReadLine();

            mq.PrintMaquina();

            DateTime dtinput1 = new DateTime(2042, 12, 24);
            DateTime dtoutput1 = new DateTime(2042, 12, 24);
            DateTime dtinput2 = new DateTime(2020, 09, 02);
            DateTime dtoutput2 = new DateTime(2021,08, 03);

            Console.WriteLine("Desde Program,vas a llamar al constructor de cProyecto"); Console.ReadLine();
            cProyecto cp1 = new cProyecto("Ateca", "Josep", dtinput1, dtoutput1, cMaquina.Hidrosolver, cProyecto.estado.EnCurso);
            cProyecto cp2 = new cProyecto("Ateca", "Josep", dtinput2, dtoutput2, cMaquina.Hidrosolver, cProyecto.estado.EnCurso);

            cp2.WriteXML();                             
            cp1.ReadXML();
            Console.ReadKey();
        }
          

    }









}
