using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    public class Bike
    {
        /*
         * clase moto
         * 
         * contiene un constructor completo y otro constructor sin ruedas, crea las ruedas por defecto.
         * 
         */

        //ATRIBUTOS 
        private string matricula;
        private string marca;
        private string color;
        private string MarcaDelantera;
        private double DiametroDelantera;
        private string MarcaTrasera;
        private double DiametroTrasera;

        private const string marcaDefault = "Marca de la Casa";
        private const double diametroDefault = 2;



        //GETTERS Y SETTERS
        public string _Matricula { get => matricula; set => matricula = value; }
        public string _Marca { get => marca; set => marca = value; }
        public string _Color { get => color; set => color = value; }
        public string _MarcaDelantera { get => MarcaDelantera; set => MarcaDelantera = value; }
        public double _DiametroDelantera { get => DiametroDelantera; set => DiametroDelantera = value; }
        public string _MarcaTrasera { get => MarcaTrasera; set => MarcaTrasera = value; }
        public double _DiametroTrasera { get => DiametroTrasera; set => DiametroTrasera = value; }

        //CONSTRUCTOR
        public Bike()
        {
            // constructor vacio para la conexion con el archivo xml
        }
        public Bike(string matricula, string marca, string color)
        {
            // constructor por defecto
            _Matricula = matricula;
            _Marca = marca;
            _Color = color;
            // usamos el construcotr por defecto de Wheel para generar ruedas base.
            _MarcaDelantera = marcaDefault;
            _DiametroDelantera = diametroDefault;
            _MarcaTrasera = marcaDefault;
            _DiametroTrasera = diametroDefault;
        }
        public Bike(string matricula, string marca, string color, string marcaDelantera, double diametroDelantero, string marcaTrasera, double diametroTrasero)
        {
            // constructor con todas las ruedas
            _Matricula = matricula;
            _Marca = marca;
            _Color = color;
            _MarcaDelantera = marcaDelantera;
            _DiametroDelantera = diametroDelantero;
            _MarcaTrasera = marcaDelantera;
            _DiametroTrasera = diametroDelantero;

        }
        public Bike(string matricula, string marca, string color, string marcaRueda, double diametroRueda, string posicionRueda)
        {
            /*
             * constructor donde se le pasa la lista de ruedas y la posición. 
             * 
             * Al crear un nuevo objeto Bike en NewVehicles.NewBike() nos pregunta si queremos añadir ruedas
             * personalizadas. llamaremos este constructor dependiendo de las llamadas
             * del usuario. puede poner ruedas delanteras pero no traseras, o traseras pero no delanteras.
             * 
             */

            _Matricula = matricula;
            _Marca = marca;
            _Color = color;
            if (posicionRueda.Equals("delanteras"))
            {
                _MarcaDelantera = marcaRueda;
                _DiametroDelantera = diametroRueda;
            }
            else
            {
                _MarcaDelantera = marcaDefault;
                _DiametroDelantera = diametroDefault;
            }
            if (posicionRueda.Equals("traseras"))
            {
                _MarcaTrasera = marcaRueda;
                _DiametroTrasera = diametroRueda;
            }
            else
            {
                _MarcaDelantera = marcaDefault;
                _DiametroDelantera = diametroDefault;
            }
        }


        // METODOS
        public override string ToString()
        {
            // metodo sobreescribe ToString() para printar los objetos de clase Car
            Console.WriteLine("Moto: ");
            Console.WriteLine("    Matrícula: {0}", _Matricula);
            Console.WriteLine("    Marca: {0}", _Marca);
            Console.WriteLine("    Color: {0}", _Color);
            Console.WriteLine("    Rueda Delantera:");
            Console.WriteLine("      Marca {0}", _MarcaDelantera);
            Console.WriteLine("      Diámetro {0}", _DiametroDelantera);
            Console.WriteLine("    Rueda Trasera:");
            Console.WriteLine("      Marca {0}", _MarcaTrasera);
            Console.WriteLine("      Diametro {0}", _DiametroDelantera);


            return "";
        }
    }
}
