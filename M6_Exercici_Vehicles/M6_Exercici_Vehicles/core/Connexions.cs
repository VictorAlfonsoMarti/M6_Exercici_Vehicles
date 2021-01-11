using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace M6_Exercici_Vehicles
{
    abstract class Connexion
    {
        /*
         *  clase abstracta donde guardamos todos los métodos que interaccionan con los ficheros de la carpeta data.
         *  utilizamos estos métodos en la clase principal SoftTaller para cargar y guardar los datos cada vez que
         *  hacemos algun cambio y al inicio y final del programa.
         * 
         * 
         */
        

        public static string getPathVehicle()
        {
            /* devuelve la ruta del archivo vehicle.xml, donde se encuentran los objetos empleados guardados
             * 
             * metodo para llamar a la ruta absoluta del archivo cogiendo la ruta actual, la que sea, y buscando el archivo en el directorio
             * 
             */
            string path = Directory.GetCurrentDirectory(); // cogemos la ruta actual del archivo
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\data\vehicle.xml")); //volvemos atras 3 veces y entramos en la carpeta data

            return newPath; //devolvemos un string con la ruta exacta
        }
        public static string getPathHuman()
        {
            /* devuelve la ruta del archivo human.xml, donde se encuentran el objeto salary guardados
             * 
             * metodo para llamar a la ruta absoluta del archivo cogiendo la ruta actual, la que sea, y buscando el archivo en el directorio
             * 
             */
            string path = Directory.GetCurrentDirectory(); // cogemos la ruta actual del archivo
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\data\human.xml")); //volvemos atras 3 veces y entramos en la carpeta data

            return newPath; //devolvemos un string con la ruta exacta
        }

        public static void WriteVehicleToXmlFile(string filePath, List<object> objectToWrite, bool append = false)
        {
            /*
             * metode per guardar el contingut de una llista de objectes pasada per parametre en un fitxer .xml
             * aquest métode es l'ultim que s'executa del programa, per guardar tots els salaris que tenim
             * en aquell moment al objecte principal List<object> que guarda elsvehicles .
             * 
             *
             * codi per trucar aquest parametre:
             * // Connexion.WriteVehicleToXmlFile(Connexion.getPath(), vehicles);
             */

            Type[] tipos = new Type[] { typeof(Car), typeof(Wheel), typeof(Truck), typeof(Bike), typeof(Driver), typeof(VehicleHolder) }; // tipos de clases para llamar al serializador

            TextWriter writer = null; //inicialitzem el metode TextWriter per escriure al fitxer
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<object>), tipos); // inicialitzem el serialitzador de XML
                //asignem el fitxer que es troba a filePath i l'hi diem append=false(sobrescriu tot el contingut), si fos true, ajuntaria al final del arxiu.
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite); //serialitzem la llista i la escribim al fitxer
            }
            finally
            {
                if (writer != null)
                    writer.Close(); //per acabar tanquem el fitxer
            }
        }
        public static List<object> ReadVehicleFromXmlFile(string filePath)
        {
            /*
             * metode per llegir el contingut d'un fitxer xml i guardar el contingut en un objecte
             * aquest métode es  el primer que s'execute al iniciar el programa, despres del metode que inicialitza SoftTaller 
             * 
             *
             * codi per trucar aquest parametre:
             * // Connexion.ReadVehicleFromXmlFile(Connexion.getPath());
             */
            Type[] tipos = new Type[] { typeof(Car), typeof(Wheel), typeof(Truck), typeof(Bike), typeof(Driver), typeof(VehicleHolder) }; // tipos de clases para llamar al serializador

            TextReader reader = null; // inicialitzem el objecte TextReader
            try
            {
                //Inicialitzem el objecte XmlSerializer de tipus list<Employee> per convertir la llista en info xml
                XmlSerializer serializer = new XmlSerializer(typeof(List<object>), tipos);
                // iniciem la lectura del archiu pasat per parametre
                reader = new StreamReader(filePath);
                // asignem el contingut del archiu "desserialitzantlo" en una llista  de Employee
                List<object> vehiculos = (List<object>)serializer.Deserialize(reader);
                return vehiculos; //retornem la llista
            }
            finally
            {
                if (reader != null)
                    reader.Close(); // tanquem el archiu
            }
        }
        public static void WriteHumanToXmlFile(string filePath, List<object> objectToWrite, bool append = false)
        {
            /*
             * metode per guardar el contingut de una llista objectes pasada per parametre en un fitxer .xml
             * aquest métode es l'ultim que s'executa del programa, per guardar tots els empleats que tenim
             * en aquell moment a la llista principal de humans.
             * 
             *
             * codi per trucar aquest parametre:
             * // Connexion.WriteHumanToXmlFile(Connexion.getPath(), List<object>);
             */

            Type[] tipos = new Type[] { typeof(Car), typeof(Wheel), typeof(Truck), typeof(Bike), typeof(Driver), typeof(VehicleHolder) }; // tipos de clases para llamar al serializador

            TextWriter writer = null; //inicialitzem el metode TextWriter per escriure al fitxer
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<object>), tipos); // inicialitzem el serialitzador de XML
                //asignem el fitxer que es troba a filePath i l'hi diem append=false(sobrescriu tot el contingut), si fos true, ajuntaria al final del arxiu.
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite); //serialitzem la llista i la escribim al fitxer
            }
            finally
            {
                if (writer != null)
                    writer.Close(); //per acabar tanquem el fitxer
            }
        }
        public static List<object> ReadHumanFromXmlFile(string filePath)
        {
            /*
             * metode per llegir el contingut d'un fitxer xml i guardar el contingut en una llista de objectes
             * aquest métode es  el primer que s'execute al iniciar el programa, despres del metode que inicialitza SoftTaller 
             * 
             *
             * codi per trucar aquest parametre:
             * // Connexion.ReadHumanFromXmlFile(Connexion.getPath());
             */

            Type[] tipos = new Type[] { typeof(Car), typeof(Wheel), typeof(Truck), typeof(Bike), typeof(Driver), typeof(VehicleHolder) }; // tipos de clases para llamar al serializador

            TextReader reader = null; // inicialitzem el objecte TextReader
            try
            {
                //Inicialitzem el objecte XmlSerializer de tipus list<object> per convertir la llista en info xml
                XmlSerializer serializer = new XmlSerializer(typeof(List<object>), tipos);
                // iniciem la lectura del archiu pasat per parametre
                reader = new StreamReader(filePath);
                // asignem el contingut del archiu "desserialitzantlo" en una llista  de Employee
                List<object> humans = (List<object>)serializer.Deserialize(reader);
                return humans; //retornem la llista
            }
            finally
            {
                if (reader != null)
                    reader.Close(); // tanquem el archiu
            }
        }
    }
}
