using Domain.Entities;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class EmpruntService : Service<Emprunt>, IEmpruntService
    {
        List<Document> documents;
        public IUnitOfWork uiprop { get; set; }

        public EmpruntService(IUnitOfWork ui) : base(ui)
        {
            uiprop = ui;
        }

        public int NbEmpruntsEffectuees(Client client)
        {
            List<Emprunt> empList = (List<Emprunt>)this.GetMany(emp => emp.ClientFk == client.ClientId);
            return empList.Count;
        }

        public int NbEmpruntsEnCours(Client client)
        {

            // check Date retour
            List<Emprunt> empList = (List<Emprunt>)this.GetMany(emp => emp.ClientFk == client.ClientId && emp.DateLimite < DateTime.Now);
            return empList.Count;
        }

        public int NbEmpruntsDeposes(Client client)
        {
            List<Emprunt> empList = (List<Emprunt>)this.GetMany(emp => emp.ClientFk == client.ClientId);
            return empList.Count;
        }

        public int NbEmprunts(Document doc)
        {
            List<Emprunt> empList = (List<Emprunt>)this.GetMany(emp => emp.DocumentFk == doc.Key);
            return empList.Count;
        }

        public void Emprunter(Document doc, Client client)
        {
            List<Document> docEmpruntable = new List<Document>();

            foreach (var item in documents)
            {
                if (item.Empruntable && doc.Equals(item))
                {
                    int nbr = item.NbEmprunts;
                    Emprunt emp = new Emprunt();
                    emp.DateEmprunt = DateTime.Now;
                    emp.DateLimite = DateTime.Now.AddDays(8);
                    emp.DateRappel = DateTime.Now.AddDays(5);
                    emp.DateRetour = DateTime.Now.AddDays(7);
                    emp.Tarif = 3d;

                    emp.ClientFk = client.ClientId;
                    emp.DocumentFk = item.Key;

                    this.Add(emp);

                    item.NbEmprunts = nbr + 1;
                    item.Empruntable = false;
                    item.Emprunte = true;
                }

            }

        }

        public void Rendre(Document doc)
        {
            DocumentService documentService = new DocumentService(uiprop);
        
            if (doc != null)
            {

                //get and remove from table Emprunt
                Emprunt emp = this.Get(emp => emp.DocumentFk == doc.Key);
                this.Delete(emp);

                // update attributs of document
                // not mapped 
                // ToDo
                doc.Empruntable = true;
                doc.Emprunte = false;
                documentService.Update(doc);

            }
            else
            {
                throw new Exception("Document not found");
            }
        }
    }
}
