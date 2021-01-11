using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    class Check
    {
        /*
         *  clase que conté mètodes per comprovar les entrades del usuari en 
         *  la creació de objectes.
         * 
         *  
         */

        public static string CheckMatricula(string matriculaEntrada)
        {
            // metode que comprova la matricula entrada per paràmetre
            // Una matrícula ha de tenir 4 números i dues o tres lletres.
            // formato 0000XX o 0000XXX

            string numeros = "0123456789"; // variables de comprovació
            string lletres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Boolean matriculaOk = false;

            string matriculaCorrecta = matriculaEntrada; // guardamos la matricula para retornarla
            char[] matricula = matriculaEntrada.ToCharArray(); // convertimos el string en un array de char para hacer comprobaciones
            if ((matriculaCorrecta.Length == 6) || (matriculaCorrecta.Length == 7)) // si la mida de matricula es 6 o 7 (correcta)
            {
                matriculaOk = true; // la damos por vuena a no ser que encuentre alguna excepcion de las de abajo
            }
            for (int x = 0; x <= 3; x++) // recorremos las 4 primeras posiciones del string
            {
                // si alguna de las posiciones donde tendria que haber numeros, no hay
                if (numeros.IndexOf(matricula[x]) < 0) // buscamos la x en la cadena numeros
                {
                    matriculaOk = false; // matricula no correcta
                }
            }
            // si la posicion 4 y 5 del array no son letras mayusculas
            if ((lletres.IndexOf(matricula[4]) < 0) || (lletres.IndexOf(matricula[5]) < 0))
            {
                matriculaOk = false; // matricula no correcta
            }
            if (matriculaCorrecta.Length == 7) // si la matricula tiene 3 letras
            {
                if ((lletres.IndexOf(matricula[6]) < 0))
                {
                    matriculaOk = false;
                }
            }
            if (matriculaOk == true) // si la matricula esta bien
            {
                goto TodoOK; // salimos
            }
            else // si ha encontrado algun error, imprimimos y volvemos a llamar al metodo.
            {
                error: 
                Console.WriteLine("ERROR: La matricula introducida es incorrecta.");
                Console.WriteLine("FORMATO CORRECTO: 0000XX o 0000XXX");
                Console.WriteLine("Por favor, vuelva a introducir la matricula:");
                matriculaCorrecta = CheckMatricula(Console.ReadLine()); // ejecutamos recursivamente el comprobador. 
            }
            TodoOK: // punt d'accés si está tot correcte
            return matriculaCorrecta; // devolvemos la matricula si es correcta
        }

        public static double CheckDiametro(double diametro)
        {
            /*
             * método que checkea el double introducido por parámetro 
             * para que sea superior a 0.4 e inferior a 4.
             *  
             */
            double diametroCorrecto = diametro;

            if (diametroCorrecto < 0.4 || diametroCorrecto > 4)
            {
                Console.WriteLine("ERROR: El diámetro tiene que estar entre 0,4 y 4");
                diametroIncorrecto: // punto de retorno por si pasan un diametro incorrecto
                Console.WriteLine("Por favor, introduzca un diámetro nuevo: ");
                try //intentamos convertir la entrada en un double
                {
                    diametroCorrecto = Check.CheckDiametro(Convert.ToDouble(Console.ReadLine())); // comprobamos el diametro recursivamente
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("ERROR: Diametro no reconocido.");
                    goto diametroIncorrecto;
                }
            }

            return diametroCorrecto;

        }


    }
}
