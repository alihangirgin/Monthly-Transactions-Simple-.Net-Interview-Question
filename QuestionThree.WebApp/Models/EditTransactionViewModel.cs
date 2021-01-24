using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionThree.WebApp.Models
{
    public class EditTransactionViewModel
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string TransactionName { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int TransactionValue { get; set; }
    }
}
