using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestionThree.WebApp.Models;
using QuestionThree.WebApp.Models.EfDbContext;
using QuestionThree.WebApp.Models.EfDbContext.Entities;

namespace QuestionThree.WebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly EfDbContext _context;

        public HomeController(EfDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var transactionList = new List<TransactionRow>();
            using (var context = new EfDbContext())
            {
                var checkTransactions = context.Transactions.Where(x => x.DeleteDate == null).ToList();
                if (checkTransactions != null)
                {
                    foreach (var item in checkTransactions)
                    {
                        var transaction = new TransactionRow();
                        transaction.Id = item.Id;
                        transaction.TransactionName = item.TransactionName;
                        transaction.TransactionValue = item.TransactionValue;
                        transactionList.Add(transaction);
                    }
                }

            }
            return View(transactionList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTransactionViewModel model)
        {
            using (var context = new EfDbContext())
            {
                var newTransaction = new Transaction();
                newTransaction.TransactionName = model.TransactionName;
                newTransaction.TransactionValue = model.TransactionValue;
                newTransaction.CreateDate = DateTime.Now;
                context.Transactions.Add(newTransaction);
                context.SaveChanges();
            }
            return Redirect(Url.Action("Index", "Home"));
        }

        public IActionResult Edit(int id)
        {
            var transaction = new EditTransactionViewModel();
            using (var context = new EfDbContext())
            {
                var checkTransaction = context.Transactions.Where(x => x.Id == id && x.DeleteDate == null).First();
                if (checkTransaction != null)
                {
                    transaction.TransactionName = checkTransaction.TransactionName;
                    transaction.TransactionValue = checkTransaction.TransactionValue;
                }
            }
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Edit(EditTransactionViewModel model)
        {
            using (var context = new EfDbContext())
            {
                var transaction = context.Transactions.Where(x => x.Id == model.Id && x.DeleteDate == null).First();
                if (transaction != null)
                {
                    transaction.TransactionName = model.TransactionName;
                    transaction.TransactionValue = model.TransactionValue;
                    transaction.UpdateDate = DateTime.Now;
                    context.SaveChanges();
                }

            }
            return Redirect(Url.Action("Index", "Home"));
        }


        public IActionResult Delete(int id)
        {
            using (var context = new EfDbContext())
            {
                var transaction = context.Transactions.Where(x => x.Id == id && x.DeleteDate == null).First();
                if (transaction != null)
                {
                    transaction.DeleteDate = DateTime.Now;
                    context.SaveChanges();
                }
            }
            return Redirect(Url.Action("Index", "Home"));
        }



    }
}
