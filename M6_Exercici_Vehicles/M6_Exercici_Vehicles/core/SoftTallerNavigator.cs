using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    class SoftTallerNavigator : SoftTaller
    {
        /*
         * clase que conté els métodes per navegar a través dels menús i executar métodes segons les interaccions.
         * 
         */

        public static List<object> CrearVehicle(List<object> llista, List<object> personas)
        {
            /*
             * métode que es crida per saber quin tipus de vehicle s'ha de crear.
             * - 1. Recull el tipus de vehicle que es vol crear
             * - 2. Segons el tipus vehicle, crida al mètode corresponent per crear-lo.
             * - 3. cada mètode que es crida retorna un vehicle, aquest metode els guarda
             *      en la llsita i retorna la llista sensera.
             */
            string entrada;
            object nouVehicle = null; // variable para guardar los objetos que retornan los metodos

            entradaErronea: // punto de retorno si el usuario entra un vehiculo incorrecto
            Console.WriteLine("¿Qué tipo de vehículo quieres crear? coche || moto || camion ");
            entrada = Console.ReadLine();

            // comprobamos la entrada
            switch (entrada)
            {
                case "coche":
                    nouVehicle = NewVehicle.NewCar(personas); // asignamos el objeto retornado a la variable antes creada
                    break;
                case "moto":
                    nouVehicle = NewVehicle.NewBike(personas);
                    break;
                case "camion":
                    nouVehicle = NewVehicle.NewTruck(personas);
                    break;
                default:
                    Console.WriteLine("ERROR: {0} no se encuentra entre los vehiculos disponibles.", entrada);
                    goto entradaErronea;
            }

            // añadimos el objeto a la lista
            llista.Add(nouVehicle);
            // devolvemos la llista
            return llista;
        }

        public static void ShowList(List<object> llista, string objeto)
        {
            // metode que recorre una llista de objectes i les printe mostrant també el tipus de objecte

            for (int x = 0; x < llista.Count; x++)
            {
                Console.WriteLine("{0} {1}:",objeto, x+1);
                Console.WriteLine();
                llista[x].ToString();
                Console.WriteLine();
            }
        }



    }
}
