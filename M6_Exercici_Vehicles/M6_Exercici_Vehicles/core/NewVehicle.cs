using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    class NewVehicle
    {
        /*
         * clase que contiene todos los métodos para crear nuevos vehiculos 
         * los metodos son iguales, sólo cambian las llamadas a los objetos y algunas
         * variables. hacen lo mismo y devuelven lo mismo
         */

        public static Car NewCar()
        {
            /* metodo que retorna un nuevo objeto Car a partir de las entradas indicadas por el usuario
             * 
             * posibles returns: 
             * Car {matricula, marca, color} - ruedas por defecto
             * Car {matricula, marca, color, ruedas delanteras} - ruedas traseras por defecto
             * Car {matricula, marca, color, ruedas traseras} - ruedas delanteras por defecto
             * Car {matricula, marca, color, ruedas delanteras, ruedas traseras} - ningún valor por defecto
             * 
             */
            
            
            // ATRIBUTOS
            string matricula;
            string marca;
            string color;
            string ruedasDelanterasMarca = null; //inicializamos las listas en null
            string ruedasTraserasMarca = null; //inicializamos las listas en null
            double ruedasDelanterasDiametro = 0; //inicializamos las listas en null
            double ruedasTraserasDiametro = 0; //inicializamos las listas en null
            string respuesta; // entrada del usuario
            double respuesta2; // entrada del usuario para el diametro de las ruedas


            // BLOQUE 1: CREAMOS COCHE NUEVO
                Console.WriteLine();
                Console.WriteLine("--- CREAR NUEVO COCHE ---");
                Console.WriteLine();
                Console.WriteLine("Indica la matrícula del vechiculo:");
                matricula = Check.CheckMatricula(Console.ReadLine()); // checkea la matricula con un metodo
                Console.WriteLine("Indica la marca del vechiculo:");
                marca = Console.ReadLine();
                Console.WriteLine("Indica el color del vechiculo:");
                color = Console.ReadLine();

            // creamos el objeto con las entradas indicadas;
            Car coche = new Car(matricula, marca, color);

                // printamos el coche
                Console.Clear();
                Console.WriteLine("--- NUEVO VEHICULO CREADO ---");
                coche.ToString();

            // BLOQUE 2 CREAMOS RUEDAS PERSONALIZADAS:

                // SUBLOQUE1: CREAMOS RUEDAS DELANTERAS:
                    // preguntamos si quiere añadir ruedas delanteras personalizadas
                    Console.WriteLine();
                    respuestaIncorrecta: // goto por si entran algo diferente a 'si' o 'no'
                    Console.WriteLine("Quiere añadir ruedas DELANTERAS personalizadas? si || no");
                    respuesta = Console.ReadLine();
                    // segun respuesta hacemos:
                    switch (respuesta)
                    {
                        case "si":
                            // creamos nuevo objeto ruedas, lo añadimos a la lista ruedas delanteras y las asignamos de nuevo al objeto
                            Console.WriteLine("Indica la marca de las ruedas delanteras:");
                            respuesta = Console.ReadLine();
                    
                            diametroIncorrecto: // punto de retorno por si pasan un diametro incorrecto
                            try //intentamos convertir la entrada en un double
                            {
                                Console.WriteLine("Indica el diametro de las ruedas delanteras:");
                                respuesta2 = Check.CheckDiametro(Convert.ToDouble(Console.ReadLine())); // comprobamos el diametro con un metodo
                            }
                            catch (System.FormatException ex)
                            {
                                Console.WriteLine("ERROR: Diametro no reconocido.");
                                goto diametroIncorrecto;
                            }
                            // si las entradas son correctas, creamos las ruedas
                            ruedasDelanterasMarca = respuesta;
                            ruedasDelanterasDiametro = respuesta2;
                            break;
                        case "no": //salimos
                            break;
                        default:
                            Console.WriteLine("ERROR: Debe escribir 'si' o 'no'");
                            goto respuestaIncorrecta;
                    }

                // SUBLOQUE 2: CREAMOS RUEDAS TRASERAS
                    // preguntamos si quiere añadir ruedas traseras personalizadas
                    Console.WriteLine();
                    respuestaIncorrecta2: // goto por si entran algo diferente a 'si' o 'no'
                    Console.WriteLine("Quiere añadir ruedas TRASERAS personalizadas? si || no");
                    respuesta = Console.ReadLine();
                    // segun respuesta hacemos:
                    switch (respuesta)
                    {
                        case "si":
                            // creamos nuevo objeto ruedas, lo añadimos a la lista ruedas delanteras y las asignamos de nuevo al objeto
                            Console.WriteLine("Indica la marca de las ruedas traseras:");
                            respuesta = Console.ReadLine();

                            diametroIncorrecto2: // punto de retorno por si pasan un diametro incorrecto
                            try //intentamos convertir la entrada en un double
                            {
                                Console.WriteLine("Indica el diametro de las ruedas traseras:");
                                respuesta2 = Check.CheckDiametro(Convert.ToDouble(Console.ReadLine())); // comprobamos el diametro con un metodo
                            }
                            catch (System.FormatException ex)
                            {
                                Console.WriteLine("ERROR: Diametro no reconocido.");
                                goto diametroIncorrecto2;
                            }
                            // si las entradas son correctas, creamos las ruedas
                            ruedasTraserasMarca = respuesta;
                            ruedasTraserasDiametro = respuesta2;
                    break;
                        case "no": // salimos
                            break;
                        default:
                            Console.WriteLine("ERROR: Debe escribir 'si' o 'no'");
                            goto respuestaIncorrecta2;
                    }


            // BLOQUE 3: ASIGNAMOS LAS RUEDAS CREADAS
                // dependiendo si ha creado ruedas delanteras pero no traseras, traseras pero no delanteras o las dos. llamamos otra vez al constructor
                if (ruedasDelanterasMarca != null && ruedasTraserasMarca == null ) // si hay delanteras pero no traseras
                {
                    coche = new Car(matricula, marca, color, ruedasDelanterasMarca, ruedasDelanterasDiametro, "delanteras"); // llamamos al constructor dandole la posiciión del as ruedas
                }
                else if (ruedasDelanterasMarca == null && ruedasTraserasMarca != null) // si hay traseras pero no delanteras
                {
                    coche = new Car(matricula, marca, color, ruedasTraserasMarca, ruedasTraserasDiametro, "traseras"); // llamamos al constructor dandole la posiciión del as ruedas
                }
                else if (ruedasDelanterasMarca != null && ruedasTraserasMarca != null) // si hay delanteras y traseras
                {
                    coche = new Car(matricula, marca, color, ruedasDelanterasMarca, ruedasDelanterasDiametro, ruedasTraserasMarca, ruedasTraserasDiametro); // llamamos al constructor completo
                }

            // Devolvemos el objeto final creado
            coche.ToString();
            Console.ReadLine();
            return coche;
        }

        public static Bike NewBike()
        {
            /* metodo que retorna un nuevo objeto Bike a partir de las entradas indicadas por el usuario
             * 
             * posibles returns: 
             * Bike {matricula, marca, color} - ruedas por defecto
             * Bike {matricula, marca, color, ruedas delanteras} - ruedas traseras por defecto
             * Bike {matricula, marca, color, ruedas traseras} - ruedas delanteras por defecto
             * Bike {matricula, marca, color, ruedas delanteras, ruedas traseras} - ningún valor por defecto
             * 
             */


            // ATRIBUTOS
            string matricula;
            string marca;
            string color;
            string ruedasDelanterasMarca = null; //inicializamos las listas en null
            string ruedasTraserasMarca = null; //inicializamos las listas en null
            double ruedasDelanterasDiametro = 0; //inicializamos las listas en null
            double ruedasTraserasDiametro = 0; //inicializamos las listas en null
            string respuesta; // entrada del usuario
            double respuesta2; // entrada del usuario para el diametro de las ruedas


            // BLOQUE 1: CREAMOS MOTO NUEVA
            Console.WriteLine();
            Console.WriteLine("--- CREAR NUEVA MOTO ---");
            Console.WriteLine();
            Console.WriteLine("Indica la matrícula del vechiculo:");
            matricula = Check.CheckMatricula(Console.ReadLine()); // checkea la matricula con un metodo
            Console.WriteLine("Indica la marca del vechiculo:");
            marca = Console.ReadLine();
            Console.WriteLine("Indica el color del vechiculo:");
            color = Console.ReadLine();

            // creamos el objeto con las entradas indicadas;
            Bike moto = new Bike(matricula, marca, color);

            // printamos el coche
            Console.Clear();
            Console.WriteLine("--- NUEVO VEHICULO CREADO ---");
            moto.ToString();

            // BLOQUE 2 CREAMOS RUEDAS PERSONALIZADAS:

            // SUBLOQUE1: CREAMOS RUEDAS DELANTERAS:
            // preguntamos si quiere añadir ruedas delanteras personalizadas
            Console.WriteLine();
            respuestaIncorrecta: // goto por si entran algo diferente a 'si' o 'no'
            Console.WriteLine("Quiere añadir rueda DELANTERA personalizada? si || no");
            respuesta = Console.ReadLine();
            // segun respuesta hacemos:
            switch (respuesta)
            {
                case "si":
                    // creamos nuevo objeto ruedas, lo añadimos a la lista ruedas delanteras y las asignamos de nuevo al objeto
                    Console.WriteLine("Indica la marca de la rueda delantera:");
                    respuesta = Console.ReadLine();

                diametroIncorrecto: // punto de retorno por si pasan un diametro incorrecto
                    try //intentamos convertir la entrada en un double
                    {
                        Console.WriteLine("Indica el diametro de las rueda delantera:");
                        respuesta2 = Check.CheckDiametro(Convert.ToDouble(Console.ReadLine())); // comprobamos el diametro con un metodo
                    }
                    catch (System.FormatException ex)
                    {
                        Console.WriteLine("ERROR: Diametro no reconocido.");
                        goto diametroIncorrecto;
                    }
                    // si las entradas son correctas, creamos las ruedas
                    ruedasTraserasMarca = respuesta;
                    ruedasTraserasDiametro = respuesta2;
                    break;
                case "no": //salimos
                    break;
                default:
                    Console.WriteLine("ERROR: Debe escribir 'si' o 'no'");
                    goto respuestaIncorrecta;
            }

            // SUBLOQUE 2: CREAMOS RUEDAS TRASERAS
            // preguntamos si quiere añadir ruedas traseras personalizadas
            Console.WriteLine();
            respuestaIncorrecta2: // goto por si entran algo diferente a 'si' o 'no'
            Console.WriteLine("Quiere añadir rueda TRASERA personalizada? si || no");
            respuesta = Console.ReadLine();
            // segun respuesta hacemos:
            switch (respuesta)
            {
                case "si":
                    // creamos nuevo objeto ruedas, lo añadimos a la lista ruedas delanteras y las asignamos de nuevo al objeto
                    Console.WriteLine("Indica la marca de las rueda trasera:");
                    respuesta = Console.ReadLine();

                diametroIncorrecto2: // punto de retorno por si pasan un diametro incorrecto
                    try //intentamos convertir la entrada en un double
                    {
                        Console.WriteLine("Indica el diametro de las rueda trasera:");
                        respuesta2 = Check.CheckDiametro(Convert.ToDouble(Console.ReadLine())); // comprobamos el diametro con un metodo
                    }
                    catch (System.FormatException ex)
                    {
                        Console.WriteLine("ERROR: Diametro no reconocido.");
                        goto diametroIncorrecto2;
                    }
                    // si las entradas son correctas, creamos las ruedas
                    ruedasTraserasMarca = respuesta;
                    ruedasTraserasDiametro = respuesta2;
                    break;
                case "no": // salimos
                    break;
                default:
                    Console.WriteLine("ERROR: Debe escribir 'si' o 'no'");
                    goto respuestaIncorrecta2;
            }


            // BLOQUE 3: ASIGNAMOS LAS RUEDAS CREADAS
            // dependiendo si ha creado ruedas delanteras pero no traseras, traseras pero no delanteras o las dos. llamamos otra vez al constructor
            if (ruedasDelanterasMarca != null && ruedasTraserasMarca == null) // si hay delanteras pero no traseras
            {
                moto = new Bike(matricula, marca, color, ruedasDelanterasMarca, ruedasDelanterasDiametro, "delanteras"); // llamamos al constructor dandole la posiciión del as ruedas
            }
            else if (ruedasDelanterasMarca == null && ruedasTraserasMarca != null) // si hay traseras pero no delanteras
            {
                moto = new Bike(matricula, marca, color, ruedasTraserasMarca, ruedasTraserasDiametro, "traseras"); // llamamos al constructor dandole la posiciión del as ruedas
            }
            else if (ruedasDelanterasMarca != null && ruedasTraserasMarca != null) // si hay delanteras y traseras
            {
                moto = new Bike(matricula, marca, color, ruedasDelanterasMarca, ruedasDelanterasDiametro, ruedasTraserasMarca, ruedasTraserasDiametro); // llamamos al constructor completo
            }


            // Devolvemos el objeto final creado
            return moto;
        }

        public static Truck NewTruck()
        {
            /* metodo que retorna un nuevo objeto Truck a partir de las entradas indicadas por el usuario
              * 
              * posibles returns: 
              * Truck {matricula, marca, color} - ruedas por defecto
              * Truck {matricula, marca, color, ruedas delanteras} - ruedas traseras por defecto
              * Truck {matricula, marca, color, ruedas traseras} - ruedas delanteras por defecto
              * Truck {matricula, marca, color, ruedas delanteras, ruedas traseras} - ningún valor por defecto
              * 
              */


            // ATRIBUTOS
            string matricula;
            string marca;
            string color;
            string ruedasDelanterasMarca = null; //inicializamos las listas en null
            string ruedasTraserasMarca = null; //inicializamos las listas en null
            double ruedasDelanterasDiametro = 0; //inicializamos las listas en null
            double ruedasTraserasDiametro = 0; //inicializamos las listas en null
            string respuesta; // entrada del usuario
            double respuesta2; // entrada del usuario para el diametro de las ruedas


            // BLOQUE 1: CREAMOS COCHE NUEVO
            Console.WriteLine();
            Console.WriteLine("--- CREAR NUEVO CAMIÓN ---");
            Console.WriteLine();
            Console.WriteLine("Indica la matrícula del vechiculo:");
            matricula = Check.CheckMatricula(Console.ReadLine()); // checkea la matricula con un metodo
            Console.WriteLine("Indica la marca del vechiculo:");
            marca = Console.ReadLine();
            Console.WriteLine("Indica el color del vechiculo:");
            color = Console.ReadLine();

            // creamos el objeto con las entradas indicadas;
            Truck camion = new Truck(matricula, marca, color);

            // printamos el coche
            Console.Clear();
            Console.WriteLine("--- NUEVO VEHICULO CREADO ---");
            camion.ToString();

            // BLOQUE 2 CREAMOS RUEDAS PERSONALIZADAS:

            // SUBLOQUE1: CREAMOS RUEDAS DELANTERAS:
            // preguntamos si quiere añadir ruedas delanteras personalizadas
            Console.WriteLine();
            respuestaIncorrecta: // goto por si entran algo diferente a 'si' o 'no'
            Console.WriteLine("Quiere añadir ruedas DELANTERAS personalizadas? si || no");
            respuesta = Console.ReadLine();
            // segun respuesta hacemos:
            switch (respuesta)
            {
                case "si":
                    // creamos nuevo objeto ruedas, lo añadimos a la lista ruedas delanteras y las asignamos de nuevo al objeto
                    Console.WriteLine("Indica la marca de las ruedas delanteras:");
                    respuesta = Console.ReadLine();

                diametroIncorrecto: // punto de retorno por si pasan un diametro incorrecto
                    try //intentamos convertir la entrada en un double
                    {
                        Console.WriteLine("Indica el diametro de las ruedas delanteras:");
                        respuesta2 = Check.CheckDiametro(Convert.ToDouble(Console.ReadLine())); // comprobamos el diametro con un metodo
                    }
                    catch (System.FormatException ex)
                    {
                        Console.WriteLine("ERROR: Diametro no reconocido.");
                        goto diametroIncorrecto;
                    }
                    // si las entradas son correctas, creamos las ruedas
                    ruedasTraserasMarca = respuesta;
                    ruedasTraserasDiametro = respuesta2;
                    break;
                case "no": //salimos
                    break;
                default:
                    Console.WriteLine("ERROR: Debe escribir 'si' o 'no'");
                    goto respuestaIncorrecta;
            }

            // SUBLOQUE 2: CREAMOS RUEDAS TRASERAS
            // preguntamos si quiere añadir ruedas traseras personalizadas
            Console.WriteLine();
            respuestaIncorrecta2: // goto por si entran algo diferente a 'si' o 'no'
            Console.WriteLine("Quiere añadir ruedas TRASERAS personalizadas? si || no");
            respuesta = Console.ReadLine();
            // segun respuesta hacemos:
            switch (respuesta)
            {
                case "si":
                    // creamos nuevo objeto ruedas, lo añadimos a la lista ruedas delanteras y las asignamos de nuevo al objeto
                    Console.WriteLine("Indica la marca de las ruedas traseras:");
                    respuesta = Console.ReadLine();

                    diametroIncorrecto2: // punto de retorno por si pasan un diametro incorrecto
                    try //intentamos convertir la entrada en un double
                    {
                        Console.WriteLine("Indica el diametro de las ruedas traseras:");
                        respuesta2 = Check.CheckDiametro(Convert.ToDouble(Console.ReadLine())); // comprobamos el diametro con un metodo
                    }
                    catch (System.FormatException ex)
                    {
                        Console.WriteLine("ERROR: Diametro no reconocido.");
                        goto diametroIncorrecto2;
                    }
                    // si las entradas son correctas, creamos las ruedas
                    ruedasTraserasMarca = respuesta;
                    ruedasTraserasDiametro = respuesta2;
                    break;
                case "no": // salimos
                    break;
                default:
                    Console.WriteLine("ERROR: Debe escribir 'si' o 'no'");
                    goto respuestaIncorrecta2;
            }


            // BLOQUE 3: ASIGNAMOS LAS RUEDAS CREADAS
            // dependiendo si ha creado ruedas delanteras pero no traseras, traseras pero no delanteras o las dos. llamamos otra vez al constructor
            if (ruedasDelanterasMarca != null && ruedasTraserasMarca == null) // si hay delanteras pero no traseras
            {
                camion = new Truck(matricula, marca, color, ruedasDelanterasMarca, ruedasDelanterasDiametro, "delanteras"); // llamamos al constructor dandole la posiciión del as ruedas
            }
            else if (ruedasDelanterasMarca == null && ruedasTraserasMarca != null) // si hay traseras pero no delanteras
            {
                camion = new Truck(matricula, marca, color, ruedasTraserasMarca, ruedasTraserasDiametro, "traseras"); // llamamos al constructor dandole la posiciión del as ruedas
            }
            else if (ruedasDelanterasMarca != null && ruedasTraserasMarca != null) // si hay delanteras y traseras
            {
                camion = new Truck(matricula, marca, color, ruedasDelanterasMarca, ruedasDelanterasDiametro, ruedasTraserasMarca, ruedasTraserasDiametro); // llamamos al constructor completo
            }

            // Devolvemos el objeto final creado
            return camion;
        }
    }
}
