using BookStore.Data.interfaces;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopBook shopBook;

        public OrderController(IAllOrders allOrders, ShopBook shopBook)
        {
            this.allOrders = allOrders;
            this.shopBook = shopBook;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        //1
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopBook.listShopItem = shopBook.getShopItems();

            if(shopBook.listShopItem.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }

            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно оформлен";
            return View();
        }
    }
}
