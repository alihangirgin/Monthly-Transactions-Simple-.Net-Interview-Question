using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionThree.WebApp.Models
{
    public class TransactionRow
    {
        public int Id { get; set; }
        public string TransactionName { get; set; }
        public int TransactionValue { get; set; }
    }
}
