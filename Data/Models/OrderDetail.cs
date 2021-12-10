using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class OrderDetail
    {
        public int id { set; get; }
        public int orderID { get; set; }

        public int BookID { get; set; }
        public double price { get; set; }
        public virtual Book book { get; set; }
        public virtual Order order { get; set; }

    }
}
