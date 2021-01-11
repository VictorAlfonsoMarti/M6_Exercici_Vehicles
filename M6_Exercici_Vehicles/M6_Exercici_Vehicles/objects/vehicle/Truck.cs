using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    public class Truck
    {
        /*
         * clase camion 
         * 
         * contiene un constructor completo y otro constructor sin ruedas, crea las ruedas por defecto.
         * 
         */

        //ATRIBUTOS 
        private string matricula;
        private string marca;
        private string color;
        private string MarcaDelanteraDerecha;
        private double DiametroDelanteraDerecha;
        private string MarcaDelanteraIzquierda;
        private double DiametroDelanteraIzquierda;
        private string MarcaTraseraDerecha;
        private double DiametroTraseraDerecha;
        private string MarcaTraseraIzquierda;
        private double DiametroTraseraIzquierda;

        Driver conductor;

        private const string marcaDefault = "Marca de la Casa";
        private const double diametroDefault = 2;

        //GETTERS Y SETTERS
        public string _Matricula { get => matricula; set => matricula = value; }
        public string _Marca { get => marca; set => marca = value; }
        public string _Color { get => color; set => color = value; }
        public string _MarcaDelanteraDerecha { get => MarcaDelanteraDerecha; set => MarcaDelanteraDerecha = value; }
        public double _DiametroDelanteraDerecha { get => DiametroDelanteraDerecha; set => DiametroDelanteraDerecha = value; }
        public string _MarcaDelanteraIzquierda { get => MarcaDelanteraIzquierda; set => MarcaDelanteraIzquierda = value; }
        public double _DiametroDelanteraIzquierda { get => DiametroDelanteraIzquierda; set => DiametroDelanteraIzquierda = value; }
        public string _MarcaTraseraDerecha { get => MarcaTraseraDerecha; set => MarcaTraseraDerecha = value; }
        public double _DiametroTraseraDerecha { get => DiametroTraseraDerecha; set => DiametroTraseraDerecha = value; }
        public string _MarcaTraseraIzquierda { get => MarcaTraseraIzquierda; set => MarcaTraseraIzquierda = value; }
        public double _DiametroTraseraIzquierda { get => DiametroTraseraIzquierda; set => DiametroTraseraIzquierda = value; }
        public Driver _Conductor { get => conductor; set => conductor = value; }

        //CONSTRUCTOR
        public Truck()
        {
            // constructor vacio para la conexion con el archivo xml
        }
        public Truck(string matricula, string marca, string color)
        {
            // constructor por defecto
            _Matricula = matricula;
            _Marca = marca;
            _Color = color;
            // usamos el construcotr por defecto de ruedas
            _MarcaDelanteraDerecha = marcaDefault;
            _DiametroDelanteraDerecha = diametroDefault;
            _MarcaDelanteraIzquierda = marcaDefault;
            _DiametroDelanteraIzquierda = diametroDefault;
            _MarcaTraseraDerecha = marcaDefault;
            _DiametroTraseraDerecha = diametroDefault;
            _MarcaTraseraIzquierda = marcaDefault;
            _DiametroTraseraIzquierda = diametroDefault;
            _Conductor = null;
        }
        public Truck(string matricula, string marca, string color, string marcaDelantera, double diametroDelantera, string marcaTrasera, double diametroTrasera)
        {
            // constructor con todas las ruedas
            _Matricula = matricula;
            _Marca = marca;
            _Color = color;
            _MarcaDelanteraDerecha = marcaDelantera;
            _DiametroDelanteraDerecha = diametroDelantera;
            _MarcaDelanteraIzquierda = marcaDelantera;
            _DiametroDelanteraIzquierda = diametroDelantera;
            _MarcaTraseraDerecha = marcaTrasera;
            _DiametroTraseraDerecha = diametroTrasera;
            _MarcaTraseraIzquierda = marcaTrasera;
            _DiametroTraseraIzquierda = diametroTrasera;
            _Conductor = null;
        }
        public Truck(string matricula, string marca, string color, string marcaRueda, double diametroRueda, string posicionRuedas)
        {
            /*
             * constructor donde se le pasa la lista de ruedas y la posición. 
             * 
             * Al crear un nuevo objeto Car en NewVehicles.NewCar() nos pregunta si queremos añadir ruedas
             * personalizadas. llamaremos este constructor dependiendo de las llamadas
             * del usuario. puede poner ruedas delanteras pero no traseras, o traseras pero no delanteras.
             * 
             */

            _Matricula = matricula;
            _Marca = marca;
            _Color = color;
            _Conductor = null;
            if (posicionRuedas.Equals("delanteras"))
            {
                _MarcaDelanteraDerecha = marcaRueda;
                _DiametroDelanteraDerecha = diametroRueda;
                _MarcaDelanteraIzquierda = marcaRueda;
                _DiametroDelanteraIzquierda = diametroRueda;
            }
            else
            {
                _MarcaDelanteraDerecha = marcaDefault;
                _DiametroDelanteraDerecha = diametroDefault;
                _MarcaDelanteraIzquierda = marcaDefault;
                _DiametroDelanteraIzquierda = diametroDefault;
            }
            if (posicionRuedas.Equals("traseras"))
            {
                _MarcaTraseraDerecha = marcaRueda;
                _DiametroTraseraDerecha = diametroRueda;
                _MarcaTraseraIzquierda = marcaRueda;
                _DiametroTraseraIzquierda = diametroRueda;
            }
            else
            {
                _MarcaDelanteraDerecha = marcaDefault;
                _DiametroDelanteraDerecha = diametroDefault;
                _MarcaDelanteraIzquierda = marcaDefault;
                _DiametroDelanteraIzquierda = diametroDefault;
            }
        }


        // METODOS
        public override string ToString()
        {
            // metodo sobreescribe ToString() para printar los objetos de clase Car
            Console.WriteLine("Camión: ");
            Console.WriteLine("    Matrícula: {0}", _Matricula);
            Console.WriteLine("    Marca: {0}", _Marca);
            Console.WriteLine("    Color: {0}", _Color);
            Console.WriteLine("    Ruedas Delanteras:");
            Console.WriteLine("      Marca {0}", _MarcaDelanteraDerecha);
            Console.WriteLine("      Diámetro {0}", _DiametroDelanteraDerecha);
            Console.WriteLine("    Ruedas Traseras:");
            Console.WriteLine("      Marca {0}", _MarcaTraseraDerecha);
            Console.WriteLine("      Diametro {0}", _DiametroDelanteraDerecha);
            Console.WriteLine("    Conductor:");
            if (_Conductor != null)
            {
                Console.WriteLine("    Conductor:");
                _Conductor.ToString();
            }

            return "";
        }
    }
}
