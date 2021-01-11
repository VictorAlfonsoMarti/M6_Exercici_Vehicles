using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    public class VehicleHolder : Human
    {
        private string nom;
        private string cognoms;
        private string dataNaixement;
        private License llicencia;
        private bool asegurança;
        private bool garage;

        public string Nom { get => nom; set => nom = value; }
        public string Cognoms { get => cognoms; set => cognoms = value; }
        public string DataNaixement { get => dataNaixement; set => dataNaixement = value; }
        public License Llicencia { get => llicencia; set => llicencia = value; }
        public bool Asegurança { get => asegurança; set => asegurança = value; }
        public bool Garage { get => garage; set => garage = value; }

        public VehicleHolder(string nom, string cognoms, string dataNaixement, License llicencia, bool asegurança, bool garage)
        {
            this.nom = nom;
            this.cognoms = cognoms;
            this.dataNaixement = dataNaixement;
            this.llicencia = llicencia;
            this.asegurança = asegurança;
            this.garage = garage;
        }
        public VehicleHolder () { }



    }
}
