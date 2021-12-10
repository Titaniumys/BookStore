using BookStore.Data.interfaces;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class BookRepository : IAllBooks
    {
        private readonly AppDBContent appDBContent;

        public BookRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Book> Books => appDBContent.Book;
        public IEnumerable<Book> getFavBooks => appDBContent.Book.Where(p => p.isFavourite);

        public Book GetById(int id)
        {
            return appDBContent.Book.Single(book => book.id == id);
        }

        public Book getObjectBook(int bookId) => appDBContent.Book.FirstOrDefault(p => p.id == bookId);

    }
}
