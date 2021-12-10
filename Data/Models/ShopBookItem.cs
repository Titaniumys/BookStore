using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class ShopBookItem
    {
        public int id { get; set; }

        public Book book { get; set; }

        public int price { get; set; }

        public string ShopBookId { get; set; }
    }
}
