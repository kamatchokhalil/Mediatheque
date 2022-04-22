using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Livre:Document
    {
        public Livre(string resume, int nbPage, int duree, double tarif)
        {
            Resume = resume;
            NbPage = nbPage;
            Duree = duree;
            Tarif = tarif;
        }

        public Livre()
        {

        }

        [DataType(DataType.MultilineText)]
        public string Resume { get; set; }
        public int NbPage { get; set; }
        public int Duree { get; set; }
        public double Tarif { get; set; }
    }
}
