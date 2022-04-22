using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Audio:Document
    {
        public Audio(string classification, int duree, double tarif)
        {
            Classification = classification;
            Duree = duree;
            Tarif = tarif;
        }

        public Audio()
        {

        }
        public string Classification { get; set; }
        public int Duree { get; set; }
        public double Tarif { get; set; }
    }
}
