using BookStore.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class DBObjects
    {
        public static void Add(AppDBContent context, Book book)
        {
            context.AddAsync(new Book
            {
                name = book?.name,
                img = book?.img,
                price = book.price,
                FIO = book?.FIO,
                DATA = book.DATA,
                isFavourite = book.isFavourite,
                availabe = book.availabe,
                CategoryName = book.CategoryName  
            });

            context.SaveChanges();
        }

        public static void Delete(AppDBContent context, int Id)
        {
            var book = context.Book.Where(c => c.id == Id).FirstOrDefault();

            context.Book.Remove(book!);

            context.SaveChanges();
        }      
    }
}
