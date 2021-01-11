using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    class SoftTaller
    {
        /*
         * clase principal del programa 
         * 
         */

        public static void SoftTallerStart()
        {

            /*
             * métode principal del programa, es el que s'executa al iniciar.
             * 

             */

            // EJECUTAR SIEMPRE PRIMERO cargamos la lista de objetos vehiculos y los humanos que tenemos guardada en el archivo vehicle.xml
            List<object> vehiculos = new List<object>(); // creamos la lista vehiculos
            vehiculos = Connexion.ReadVehicleFromXmlFile(Connexion.getPathVehicle()); // asignamos el contenido de vehicle.xml a la lista creada
            Console.OutputEncoding = Encoding.UTF8; // declaramos el utf8 en los Console.Write para los simbolos
            List<object> personas = new List<object>(); // creamos nueva lista personas
            personas = Connexion.ReadHumanFromXmlFile(Connexion.getPathHuman()); // le asignamos de contenido el objeto guardado en el archivo salary.xml
            // EJECUTAR HASTA AQUÍ SIEMPRE PRIMERO

            // FRONTLINE
            Inicio:
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("---- BIENVENIDO A SOFTTALLER ----");
            Console.WriteLine();
            Console.WriteLine("Qué quieres hacer?");
            Console.WriteLine();
            Console.WriteLine("   Opción 1: ver los vehiculos guardados");
            Console.WriteLine("   Opción 2: ver las personas guardadas");
            Console.WriteLine("   Opción 3: agregar un nuevo vehiculo o una nueva persona");
            Console.WriteLine("   Opción 4: cerrar el programa");
            Console.WriteLine();
            IntroducirOpcion:
            Console.WriteLine("Indica el número de la opción que quieres: ");
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                /*
                 * Según las opciones printadas por pantalla y la opción indicada por el usuario,
                 * ejecutamos diferentes metodos. tras los casos en que es posible que se haya 
                 * modificado la información de los vehiculos o personas, guardamos los datos a 
                 * los archivos xml y volvemos a cargarlos, por si el programa se cierra de forma inesperada.
                 */
                case "1":
                    Console.Clear();
                    Console.WriteLine("--- LISTA DE VEHICULOS ---");
                    Console.WriteLine();
                    Console.WriteLine();
                    // metodo para mostrar el contenido de la lista vehiculos
                    SoftTallerNavigator.ShowList(vehiculos, "Vehículo");
                    Console.WriteLine();
                    Console.WriteLine("Pulse ENTER para volver al menú principal...");
                    Console.ReadLine();
                    goto Inicio;
                case "2":
                    Console.Clear();
                    Console.WriteLine("--- LISTA DE PERSONAS ---");
                    Console.WriteLine();
                    Console.WriteLine();
                    // metodo para mostrar el contenido de la lista personas
                    SoftTallerNavigator.ShowList(personas, "Persona");
                    Console.WriteLine("Pulse ENTER para volver al menú principal...");
                    Console.ReadLine();
                    goto Inicio;
                case "3":
                    Console.Clear();
                    Console.WriteLine("--- AGREGAR NUEVO VEHICULO O PERSONA---");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("   Opción 1: agregar un nuevo vehiculo");
                    Console.WriteLine("   Opción 2: agregar una nueva persona");
                    Console.WriteLine("   Opción 3: volver al menú principal");
                    error123:
                    string opcion2 = Console.ReadLine();
                    switch (opcion2)
                    {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--- AGREGAR NUEVO VEHICULO ---");
                        Console.WriteLine();
                        Console.WriteLine();
                        vehiculos = SoftTallerNavigator.CrearVehicle(vehiculos, personas);
                        Console.WriteLine();
                        // guardamos la lista al archivo xml
                        Connexion.WriteVehicleToXmlFile(Connexion.getPathVehicle(), vehiculos);
                        // cargamos la lista personas tras haberla guardado en los metodos de NewVehicle
                        personas = Connexion.ReadHumanFromXmlFile(Connexion.getPathHuman());
                        goto Inicio;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("--- AGREGAR NUEVA PERSONA ---");
                        Console.WriteLine();
                        Console.WriteLine();
                        // llamamos ala funcion crear nuevo driver y la adjuntamos a la lista
                        personas.Add(NewHuman.AddDriver());
                        Console.WriteLine();
                        // guardamos la lista al archivo xml
                        Connexion.WriteHumanToXmlFile(Connexion.getPathHuman(), personas);
                        goto Inicio;
                        case "3":
                            goto Inicio;
                        default:
                            Console.WriteLine("ERROR: NÚMERO NO RECONOCIDO");
                            Console.WriteLine("Por favor, introduzca una opción válida");
                            goto error123;
                    }
                    break;
                case "4":
                    Console.WriteLine("GRACIAS POR UTILIZAR SOFTTALLER");
                    break;
                default:
                    Console.WriteLine("ERROR: NÚMERO NO RECONOCIDO");
                    Console.WriteLine("Por favor, introduzca una opción válida");
                    goto IntroducirOpcion;
            }

            // EJECUTAR SIEMPRE ÚLTIMO guardamos la lista de Employee y el Salary en un archivo xml
            Connexion.WriteVehicleToXmlFile(Connexion.getPathVehicle(), vehiculos);
            Connexion.WriteHumanToXmlFile(Connexion.getPathHuman(), personas);
            // EJECUTAR HASTA AQUÍ SIEMPRE ÚLTIMO
        }
    }
}
