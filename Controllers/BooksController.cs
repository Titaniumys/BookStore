using BookStore.Data.interfaces;
using BookStore.Data.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{ 
    public class BooksController : Controller
    {

        private readonly IAllBooks _allBooks;


        public BooksController(IAllBooks iAllBooks)
        {
            _allBooks = iAllBooks;
        }
        
        public ViewResult Index()
        {
            IEnumerable<Book> books = null;
            books = _allBooks.Books;
            var book = new BooksListViewModel
            {
                allBooks = books
            };
            return View(book);
        }
        public ViewResult List(string category)
        {
        
            ViewBag.Tittle = "Страница с книгами";
            BooksListViewModel obj = new BooksListViewModel();
            obj.allBooks = _allBooks.Books;
            obj.currCategory = "Книги";

            return View(obj);
        }

        public IActionResult Show(int id)
        {
            var books = _allBooks.GetById(id);
            return View(books);
        }

        public IActionResult GetByCategoryName(string categoryName)
        {
            IEnumerable<Book> books = null;

            books = _allBooks.Books.Where(i => i.CategoryName.Equals(categoryName)).OrderBy(i => i.id);

            var book = new BooksListViewModel
            {
                allBooks = books
            };
            return View("ShowCategory", book);
        }

        public IActionResult AllBooks()
        {
            IEnumerable<Book> books = null;

            books = _allBooks.Books.OrderBy(i => i.id);

            var book = new BooksListViewModel
            {
                allBooks = books
            };
            return View("ShowMyBooks", book);
        }

    }

}
