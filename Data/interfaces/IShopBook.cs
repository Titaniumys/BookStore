using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.interfaces
{
    public interface IShopBook
    {
        public void AddToShop(Book book);

        public List<ShopBookItem> getShopItems();

        public List<ShopBookItem> listShopItem { get; set; }

        public void Delete(string id);
    }
}
