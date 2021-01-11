using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    public class Wheel
    {
        /*
         *  Objeto ruedas, todos los vehiculos tienen ruedas,
         *  se llamarán en la construcción de los objetos vehiculos
         *  y en los métodos de comprobación de diámetro. 
         * 
         */

        //ATRIBUTOS
        private string marca;
        private double diametro;
        private const string marcaDefault = "Marca de la Casa";
        private const double diametroDefault = 2;


        // GETTERS Y SETTERS
        public string _Marca { get => marca; set => marca = value; }
        public double _Diametro { get => diametro; set => diametro = value; }

        //CONSTRUCTORES
        public Wheel(string marca, double diametro)
        {
            _Marca = marca;
            _Diametro = diametro;
        }
        public Wheel()
        {
            _Marca = marcaDefault;
            _Diametro = diametroDefault;
        }

        //METODOS
        public override string ToString()
        {
            // metodo sobrescrito ToString() para printar el objeto Wheel
            Console.WriteLine("          Rueda - Marca: {0} || Diámetro: {1}", _Marca, _Diametro);
            return "";
        }

    }
}
