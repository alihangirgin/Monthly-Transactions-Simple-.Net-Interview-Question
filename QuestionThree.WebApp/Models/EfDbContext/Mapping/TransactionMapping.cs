using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionThree.WebApp.Models.EfDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionThree.WebApp.Models.EfDbContext.Mapping
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TransactionName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.TransactionValue)
                .IsRequired();
            builder.Property(x => x.CreateDate)
                .IsRequired();
            builder.Property(x => x.UpdateDate);
            builder.Property(x => x.DeleteDate);

        }
    }
}
