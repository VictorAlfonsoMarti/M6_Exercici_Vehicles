﻿using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    public class Driver : Human
    {
        private string nom;
        private string cognoms;
        private string dataNaixement;
        private License llicencia;

        public Driver(string nom, string cognoms, string dataNaixement, License llicencia)
        {
            this.nom = nom;
            this.cognoms = cognoms;
            this.dataNaixement = dataNaixement;
            this.llicencia = llicencia;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Cognoms { get => cognoms; set => cognoms = value; }
        public string DataNaixement { get => dataNaixement; set => dataNaixement = value; }
        public License Llicencia { get => llicencia; set => llicencia = value; }
    }
}
