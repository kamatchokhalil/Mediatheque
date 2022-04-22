using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Video:Document
    {
        public Video(int dureeFilm, string mentionLegale, int duree, double tarif)
        {
            DureeFilm = dureeFilm;
            MentionLegale = mentionLegale;
            Duree = duree;
            Tarif = tarif;
        }

        public Video()
        {

        }

        public int DureeFilm { get; set; }
        public string MentionLegale { get; set; }
        public int Duree { get; set; }
        public double Tarif { get; set; }
    }
}
