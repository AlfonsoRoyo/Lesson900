using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace p1_Motor
{
    public class cProyecto

    {         
        // AQUI SE CREAN LOS ATRIBUTOS.................................................
        string Nombre; 
        string Cliente;
        DateTime FechaEntrada = new DateTime(2042, 12, 24);
        DateTime FechaSalida = new DateTime(2042, 12, 24);
        public cMaquina maq = null;

        public enum estado // Modelo tipo enumerado , se crea de esta forma
        {
            Pendiente,
            EnCurso,
            Finalizado
        }       
        estado Estado; // aqui creamos el atributo del tipo de variable
 
       public cMaquina Nom1 = null; // aqui creamos el atributo del tipo de variable
        
        // AQUI SE CREAN LAS PROPIEDADES.....................................................
        public string nombre { get => Nombre; set => Nombre = value; }
        public string cliente { get => Cliente; set => Cliente = value; }
        public DateTime fechaEntrada { get => FechaEntrada; set => FechaEntrada = value; }
        public DateTime fechaSalida { get => FechaSalida; set => FechaSalida = value; }
        public cMaquina nom1 { get => Nom1; set => Nom1 = value; } // se genera las propiedades de la matriz nom1 para poder acceder a ella.
        
        public cProyecto() { }       
        public cProyecto( string nombre,string cliente,DateTime fechaInput, DateTime fechaOutput, cMaquina mq, estado st)
        {         
            this.Nombre = nombre;
            this.Cliente = cliente;
            this.FechaEntrada = fechaInput;
            this.FechaSalida = fechaOutput;
            this.maq = mq;
            this.Estado = st;
            Console.WriteLine(fechaInput.ToString("Y-M-d H:m:ss"));
        }
        public cProyecto(string nombre, string cliente, cMaquina mq, estado st)
        {
            this.Nombre = nombre;
            this.Cliente = cliente;
            this.maq = mq;
            this.Estado = st;
        }
        public estado status
        {
            get
            {
                if (FechaEntrada == default || DateTime.Now < FechaEntrada)
                { Estado = estado.Pendiente; }
                else if (FechaSalida < DateTime.Now)
                { Estado = estado.Finalizado; }
                else if (DateTime.Now > FechaEntrada)
                { this.Estado = estado.EnCurso; }
                return status;
            }
        }
        public void PrintProyecto()
        {
            Console.WriteLine("Nombre " + nombre);
            Console.WriteLine("Cliente " + cliente);
            Console.WriteLine("Fecha Entrada " + FechaEntrada.ToString());
            Console.WriteLine("Fecha Salida " + FechaSalida.ToString());
            Console.WriteLine("Estado " + Estado.ToString());
            maq.PrintMaquina();
        }     
        public void ReadXML()
        {
            Console.WriteLine("vas a llamar al metod ReadXML"); Console.ReadLine();
            
            XmlSerializer reader = new XmlSerializer(this.GetType());
            string fitxer = "";
            fitxer = Environment.CurrentDirectory + "//cProyecto.xml";
            var path = Environment.CurrentDirectory + "//cProyecto.xml";
            System.IO.StreamReader file = new System.IO.StreamReader(fitxer);
            cProyecto proyecto = (cProyecto)reader.Deserialize(file);
            this.Nombre = proyecto.Nombre;
            this.Cliente = proyecto.Cliente;
            this.FechaEntrada = proyecto.FechaEntrada;
            this.FechaSalida = proyecto.FechaSalida;
            file.Close();
            Console.WriteLine(Nombre);
            Console.WriteLine(cliente);
            Console.WriteLine(FechaEntrada);
            Console.WriteLine(FechaSalida);
            Console.ReadKey();            
        }       
        public void WriteXML()
        {

            Console.WriteLine("Desde Proyecto,vas a llamar al metod WriteXML"); Console.ReadLine();
            XmlSerializer writer = new XmlSerializer(this.GetType());               
            var path = "";
            path = Environment.CurrentDirectory + "//cProyecto.xml";
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file,this);
            file.Close();
           
        }
    }
}




