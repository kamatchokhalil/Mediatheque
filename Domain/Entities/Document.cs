using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Document
    {
        public Document(int key, string titre, string auteur, string annee, bool empruntable, bool emprunte, int nbEmprunts, Mediatheque mediatheque, IList<Client> clients)
        {
            Key = key;
            Titre = titre;
            Auteur = auteur;
            Annee = annee;
            Empruntable = empruntable;
            Emprunte = emprunte;
            NbEmprunts = nbEmprunts;
            Mediatheque = mediatheque;
            Clients = clients;
        }

        public Document()
        {

        }

        [Key]
        public int Key { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Annee { get; set; }
        [NotMapped]
        public bool Empruntable { get; set; }
        [NotMapped]
        public bool Emprunte { get; set; }
        [NotMapped]
        public int NbEmprunts { get; set; }

        public virtual Mediatheque Mediatheque { get; set; }
        public virtual IList<Client> Clients { get; set; }

        public virtual IList<Emprunt> Emprunts { get; set; }
    }
}
