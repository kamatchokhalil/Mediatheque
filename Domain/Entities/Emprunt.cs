using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Emprunt
    {
        [Key]
        public int key { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateEmprunt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateLimite { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DateRappel { get; set; }
        public DateTime? DateRetour { get; set; }
        public double Tarif { get; set; }

        [ForeignKey("Client")]
        public int ClientFk { get; set; }

        [ForeignKey("Document")]
        public int DocumentFk { get; set; }

        public virtual Document Document { get; set; }
        public virtual Client Client { get; set; }
    }   
}
