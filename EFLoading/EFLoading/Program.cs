using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            //var author = new Author
            //{
            //    Name = "Пушкин А.С."
            //};
            //var book = new Book
            //{
            //    Name = "Сказки",
            //    Price = 1000,
            //    Author_Id = author.Id
            //};
            //using(var context = new LibraryContext())
            //{
            //    context.Authors.Add(author);
            //    context.Books.Add(book);
            //    context.SaveChanges();
            //}


            //Lazy Loading Ленивая загрузка - указание навигационному свойству virtual. Работает только внутри using
            using (var context = new LibraryContext())
            {
                var book = context.Books.SingleOrDefault();
                var author = book.Author;
            }
            //EagerLoading Жадная загрузка - используем при загрузке сущности Include("навиг.св-во")
            using (var context = new LibraryContext())
            {
                var book = context.Books.Include("Author").SingleOrDefault();
                var author = book.Author;
            }
            //ExplicitLoading Явная загрузка - context.Entry(загр.сущн.)[.Reference("нав.св-во")]/[.Collection("Нав.св-во")].Load(); Работает только внутри using
            using (var context = new LibraryContext())
            {
                var book = context.Books.SingleOrDefault();
                context.Entry(book).Reference("Author").Load();
                var author = book.Author;
            }
        }
    }
}
