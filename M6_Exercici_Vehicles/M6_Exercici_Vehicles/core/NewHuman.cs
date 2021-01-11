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
            /* metodo que retorna un nuevo objeto Car a partir de las entradas indicadas por el usuario
             * 
             * posibles returns: 
             *  {matricula, marca, color} - ruedas por defecto
             * Car {matricula, marca, color, ruedas delanteras} - ruedas traseras por defecto
             * Car {matricula, marca, color, ruedas traseras} - ruedas delanteras por defecto
             * Car {matricula, marca, color, ruedas delanteras, ruedas traseras} - ningún valor por defecto
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
                Console.WriteLine("ERROR: FORMAT NO RECONEGUT: DD/MM/YYYY"); // <-- Control flow goes here
                goto fechaIncorrecta;
            }
            dataNaixement = Console.ReadLine();
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
                    if (tipusLlicencia != "moto" || tipusLlicencia != "coche" || tipusLlicencia != "camion")
                    {
                        Console.Write("ERROR: licencia no reconocida");
                        goto licenciaIncorrecta;
                    }
                    Console.WriteLine("Indica la fecha de caducidad de la licencia:");
                    caducitatLlicencia = Console.ReadLine();
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

            // printamos el coche
            Console.Clear();
            Console.WriteLine("--- NUEVO CONDUCTOR CREADO ---");
            conductor.ToString();


            // Devolvemos el objeto final creado
            return conductor;
        }
    }
}
