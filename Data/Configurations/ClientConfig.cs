using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasOne(c => c.Categorie).WithMany(cat => cat.Clients).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Documents).WithMany(doc => doc.Clients).UsingEntity<Emprunt>(
                    emp=> emp.HasOne(emp => emp.Document).WithMany(doc => doc.Emprunts).HasForeignKey(em => em.DocumentFk),
                    emp => emp.HasOne(emp=> emp.Client).WithMany(clts=>clts.Emprunts).HasForeignKey(em => em.ClientFk)
                );
        }
    }
}
