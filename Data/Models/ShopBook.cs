using BookStore.Data.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class ShopBook : IShopBook
    {
        private readonly AppDBContent appDBContent;

        public ShopBook(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopBookId { get; set; }

        public List<ShopBookItem> listShopItem { get; set; }

        public static ShopBook GetShop(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopBookId = session.GetString("ShopId") ?? Guid.NewGuid().ToString();

            session.SetString("ShopId", shopBookId);
            return new ShopBook(context) { ShopBookId = shopBookId };
        }

        public void AddToShop(Book book)
        {
            appDBContent.ShopBookItems.Add(new ShopBookItem {
                ShopBookId = ShopBookId,
                book = book,
                price = (int)book.price
            });

            appDBContent.SaveChanges();
        }

        public void Delete(string id)
        {
            var cart = appDBContent.ShopBookItems.FirstOrDefault(cart => cart.ShopBookId == id);
            appDBContent.ShopBookItems.Remove(cart);
            appDBContent.SaveChanges();
        }
        public List<ShopBookItem> getShopItems() {
            return appDBContent.ShopBookItems.Where(c => c.ShopBookId == ShopBookId).Include(s => s.book).ToList();
        }
    }
}
