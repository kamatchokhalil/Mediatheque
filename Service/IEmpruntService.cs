using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IEmpruntService:IService<Emprunt>
    {
        int NbEmpruntsEffectuees(Client client);
        int NbEmpruntsEnCours(Client client);
        int NbEmpruntsDeposes(Client client);
        int NbEmprunts(Document doc);
        void Rendre(Document doc);
        void Emprunter(Document doc, Client client);
    }
}
