using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    class NewHuman
    {
        /*
         * clase que contiene todos los métodos para crear nuevos vehiculos 
         * los metodos son iguales, sólo cambian las llamadas a los objetos y algunas
         * variables. hacen lo mismo y devuelven lo mismo
         */

        public static Driver AddDriver()
        {
            /* metodo que retorna un nuevo objeto Driver a partir de las entradas indicadas por el usuario
             * 
             * 
             */

            // ATRIBUTOS
            string nom;
            string cognoms;
            string dataNaixement;
            string IDLlicencia;
            string tipusLlicencia;
            string nomComplet;
            string caducitatLlicencia;

            string respuesta;
            string respuesta2;

            Inicio:
            // BLOQUE 1: CREAMOS CONDUCTOR NUEVO
            Console.WriteLine();
            Console.WriteLine("--- CREAR NUEVO CONDUCTOR ---");
            Console.WriteLine();
            Console.WriteLine("Indica el nombre del conductor:");
            nom = Check.checkName(Console.ReadLine()); // checkea la matricula con un metodo
            Console.WriteLine("Indica los apellidos del conductor:");
            cognoms = Check.checkName(Console.ReadLine());
            nomComplet = nom + " " + cognoms;
            fechaIncorrecta:
            Console.WriteLine("Indica la fecha de nacimiento del conductor: DD/MM/YYYY");
            dataNaixement = Console.ReadLine();
            // comprobamos el formato de la fecha de nacimiento
            DateTime dDate;
            if (DateTime.TryParse(dataNaixement, out dDate))
            { 
                String.Format("{0:d/MM/yyyy}", dDate);
            }
            else
            {
                Console.WriteLine("ERROR: DATA NO RECONEGUDA: DD/MM/YYYY"); // <-- Control flow goes here
                goto fechaIncorrecta;
            }
            ErrorSiNo:
            Console.WriteLine("Este conductor tendrá licencia? si || no");
            respuesta = Console.ReadLine();
            Driver conductor;
            if ((respuesta == "si") || (respuesta == "no"))
            {
                if (respuesta == "si")
                {
                    Console.WriteLine("Indica la ID de la licencia:");
                    IDLlicencia = Console.ReadLine();
                    licenciaIncorrecta:
                    Console.WriteLine("Indica el tipo de la licencia: moto || coche || camion");
                    tipusLlicencia = Console.ReadLine();
                    if (tipusLlicencia != "moto" && tipusLlicencia != "coche" && tipusLlicencia != "camion")
                    {
                        Console.Write("ERROR: licencia no reconocida");
                        goto licenciaIncorrecta;
                    }
                    fechaIncorrecta2:
                    Console.WriteLine("Indica la fecha de caducidad de la licencia: DD/MM/YYYY");
                    caducitatLlicencia = Console.ReadLine();
                    if (DateTime.TryParse(caducitatLlicencia, out dDate))
                    {
                        String.Format("{0:d/MM/yyyy}", dDate);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: DATA NO RECONEGUDA: DD/MM/YYYY"); // <-- Control flow goes here
                        goto fechaIncorrecta2;
                    }

                    conductor = new Driver(nom, cognoms, dataNaixement, new License(IDLlicencia, tipusLlicencia, nomComplet, caducitatLlicencia));
                }
                else
                {
                    conductor = new Driver(nom, cognoms, dataNaixement, null);
                }
            }
            else
            {
                Console.WriteLine("Introduce si o no...");
                goto ErrorSiNo;
            }

            // printamos el 
            Console.Clear();
            Console.WriteLine("--- NUEVO CONDUCTOR CREADO ---");
            conductor.ToString();
            respuesta2Error:
            Console.WriteLine();
            Console.WriteLine("Conductor correcto? si = salir al menu || no = borrar nuevo conductor");
            respuesta2 = Console.ReadLine();
            switch (respuesta2)
            {
                case "si":
                    break;
                case "no":
                    Console.WriteLine("Borrando nuevo conductor creado...");
                    conductor = null;
                respuestaError:
                    Console.WriteLine("Quiere salir o crear otro conductor? salir || crear");
                    respuesta = Console.ReadLine();
                    switch (respuesta)
                    {
                        case "salir":
                            break;
                        case "crear":
                            goto Inicio;
                        default:
                            Console.WriteLine("ERROR: Escriba 'salir' o 'crear'.");
                            goto respuestaError;
                    }
                    break;
                default:
                    Console.WriteLine("ERROR: Escriba 'si' o 'no'.");
                    goto respuesta2Error;
            }

            // Devolvemos el objeto final creado
            return conductor;
        }
    }
}