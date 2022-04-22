using System;
using System.Collections.Generic;
using System.Text;
using ServicePattern;
using Domain.Entities;
using PS.Data.Infrastructure;

namespace Service
{
    public class DocumentService : Service<Document>, IDocumentService
    {
        List<Document> documents;
        List<Emprunt> empruntsList;


        public DocumentService(IUnitOfWork ui):base(ui)
        {


        }


        public Boolean Empruntable(Document d)
        {
            Document doc = this.GetById(d.Key);
            if (doc != null)
            {
                if (doc.Emprunte) {
                    return true;
                }
                else {
                    return false; 
                }
            }
            else {
                throw new Exception("erreur");
            }
           
        }

        public IList<Document> GetEmpruntables(Mediatheque mediatheque)
        {
            List<Document> docMed = (List<Document>)mediatheque.Documents;
            List<Document> resDoc = new List<Document>();

            foreach (var item in docMed)
            {
                if (item.Empruntable)
                {
                    resDoc.Add(item);
                }
            }

            return resDoc;
        }

        public List<Document> ChercherDocument(string titre)
        {
            List<Document> docFinded = new List<Document>();

            foreach (var item in documents)
            {
                if (item.Titre.StartsWith(titre))
                {
                    docFinded.Add(item);
                }
            }

            return docFinded;
        }
    }
}
