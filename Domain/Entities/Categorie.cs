using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Categorie
    {
        public Categorie(int id, int nbEmpruntsMax, double cotisation, double coefTarif, double coefDuree, bool codeReductionActif, IList<Client> clients)
        {
            Id = id;
            NbEmpruntsMax = nbEmpruntsMax;
            Cotisation = cotisation;
            CoefTarif = coefTarif;
            CoefDuree = coefDuree;
            CodeReductionActif = codeReductionActif;
            Clients = clients;
        }

        public Categorie()
        {

        }

        public int Id { get; set; }
        public int NbEmpruntsMax { get; set; }
        public double Cotisation { get; set; }
        public double CoefTarif { get; set; }
        public double CoefDuree { get; set; }
        public bool CodeReductionActif { get; set; }

        public virtual IList<Client> Clients { get; set; }
    }
}
