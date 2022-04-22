using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Mediatheque
    {
        public Mediatheque(int key, string nom, IList<Document> documents, IList<Client> clients)
        {
            Key = key;
            Nom = nom;
            Documents = documents;
            Clients = clients;
        }

        public Mediatheque()
        {
                
        }

        [Key]
        public int Key { get; set; }
        public string Nom { get; set; }
        public virtual IList<Document> Documents { get; set; }
        public virtual IList<Client> Clients { get; set; }
    }
}
