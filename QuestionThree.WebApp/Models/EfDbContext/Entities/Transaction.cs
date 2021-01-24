using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionThree.WebApp.Models.EfDbContext.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionName { get; set; }
        public int TransactionValue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
