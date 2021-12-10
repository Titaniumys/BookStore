using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class Book
    {
        public int id { set; get; }

        public string name { set; get; }

        public string FIO { set; get; }

        public int DATA { set; get; }

        public string img { set; get; }

        public double price { set; get; }

        public bool isFavourite { set; get; }

        public bool availabe { set; get; }

        public string CategoryName { set; get; }
    }
}
