using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IDocumentService: IService<Document>
    {
        Boolean Empruntable(Document d);

        IList<Document> GetEmpruntables(Mediatheque mediatheque);

        List<Document> ChercherDocument(string titre);



    }

}
