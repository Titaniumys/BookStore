using BookStore.Data.interfaces;
using BookStore.Data.Models;
using BookStore.Data.Repository;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class ShopBookController : Controller
    {
        private readonly IAllBooks _bookRep;
        private readonly ShopBook _shopBook;

        public ShopBookController(IAllBooks bookRep, ShopBook shopBook)
        {
            _bookRep = bookRep;
            _shopBook = shopBook;
        }

        public ViewResult Index()
        {
            var items = _shopBook.getShopItems();
            _shopBook.listShopItem = items;

            var obj = new ShopBookViewModel
            {
                shopBook = _shopBook
            };

            return View(obj);
        }
        //2
        public RedirectToActionResult addToBook(int id)
        {
            var item = _bookRep.Books.FirstOrDefault(i => i.id == id);

            if(item != null)
            {
                _shopBook.AddToShop(item);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(string id)
        {
            _shopBook.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
