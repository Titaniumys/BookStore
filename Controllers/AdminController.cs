using BookStore.Data;
using BookStore.Data.interfaces;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AdminController : Controller
    {

        private readonly IShopBook ishopBook;

        private readonly AppDBContent appDbContent;

        public AdminController(AppDBContent appDbContent, IShopBook ishopBook)
        {
            this.ishopBook = ishopBook;
            this.appDbContent = appDbContent;
        }

        public IActionResult Add()
        {
            return View();
        }
        //4
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                DBObjects.Delete(appDbContent, id);

                return View();
            }

            return View();
        }

        public IActionResult AddSuccess(Book book)
        {
            DBObjects.Add(appDbContent, book);

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult ErrorMessage()
        {
            return View();
        }

        public IActionResult ErrorMessageCart()
        {
            return View();
        }*/
    }
}
