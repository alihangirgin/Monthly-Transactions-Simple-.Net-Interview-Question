using Microsoft.EntityFrameworkCore;
using QuestionThree.WebApp.Models.EfDbContext.Entities;
using QuestionThree.WebApp.Models.EfDbContext.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionThree.WebApp.Models.EfDbContext
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base()
        {
        }

        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.; Database=TransactionDb; Trusted_Connection=True;Integrated Security=true;")
                //.UseLazyLoadingProxies()
                ;
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TransactionMapping());

            modelBuilder.Entity<Transaction>().HasData(new List<Transaction>()
            {
                new Transaction(){ Id=1, TransactionName="Salary", TransactionValue=1670 },
                new Transaction(){ Id=2, TransactionName="Car", TransactionValue=-60 },
                new Transaction(){ Id=3, TransactionName="Clothing", TransactionValue=-320 },
                new Transaction(){ Id=4, TransactionName="Food", TransactionValue=-85 },
                new Transaction(){ Id=5, TransactionName="Leisure", TransactionValue=-35 },
                new Transaction(){ Id=6, TransactionName="Living", TransactionValue=-560 }
            });

        }
    }
}
