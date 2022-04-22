using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Client
    {
        public Client(int clientId, string nom, string prenom, string adresse, string login, string password, DateTime dateInscription, int codeRedusction, Mediatheque mediatheque, Categorie categorie, IList<Document> documents)
        {
            ClientId = clientId;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Login = login;
            Password = password;
            DateInscription = dateInscription;
            CodeRedusction = codeRedusction;
            Mediatheque = mediatheque;
            Categorie = categorie;
            Documents = documents;
        }

        public Client()
        {

        }

        public int ClientId { get; set; }
        [Required(ErrorMessage ="Name field required")]
        public string Nom { get; set; }
        [Required(ErrorMessage = " lastname field required")]
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        [Required(ErrorMessage = " login field required")]
        public string Login { get; set; }
        [Required(ErrorMessage = " password field required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateInscription { get; set; }
        public int CodeRedusction { get; set; }

        [ForeignKey("Categorie")]
        public int? CategoryId { get; set; }

        public virtual Mediatheque Mediatheque { get; set; }
        public virtual Categorie Categorie { get; set; }
        public virtual IList<Document> Documents { get; set; }

        public virtual IList<Emprunt> Emprunts { get; set; }
    }
}
