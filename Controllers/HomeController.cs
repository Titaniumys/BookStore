using BookStore.Data.interfaces;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private IAllBooks _bookRep;


        public HomeController(IAllBooks bookRep)
        {
            _bookRep = bookRep;

        }

        public ViewResult Index()
        {
            var homeBooks = new HomeViewModel
            {
                favBooks = _bookRep.getFavBooks
            };
            return View(homeBooks);
        }

    }
}
