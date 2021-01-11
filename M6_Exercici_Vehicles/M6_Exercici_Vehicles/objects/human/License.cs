using System;
using System.Collections.Generic;
using System.Text;

namespace M6_Exercici_Vehicles
{
    public class License
    {
        private string ID;
        private string tipus;
        private string nomComplet;
        private string caducitat;

        public License(string iD, string tipus, string nomComplet, string caducitat)
        {
            ID = iD;
            this.tipus = tipus;
            this.nomComplet = nomComplet;
            this.caducitat = caducitat;
        }
        public License ()
        {
        }

        public string ID1 { get => ID; set => ID = value; }
        public string Tipus { get => tipus; set => tipus = value; }
        public string NomComplet { get => nomComplet; set => nomComplet = value; }
        public string Caducitat { get => caducitat; set => caducitat = value; }
    

    }
}
