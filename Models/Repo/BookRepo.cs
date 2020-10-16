using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLp.Models.Repo
{
    public class BookRepo : IBookStoreRepo<Books>
    {
        List<Books> books;

        public BookRepo()
        {
            books = new List<Books>()
            {
                new Books
                {
                    Id =1, Tital="C# tuto", Auther = new Auther{Id=2}, ImageUrl="Screenshot (10).png"
                },
                new Books
                {
                    Id =2, Tital="C++ tuto", Auther = new Auther{Id =3}, ImageUrl="Screenshot (17).png"
                },
                new Books
                {
                    Id =3, Tital="C tuto", Auther = new Auther{Id=1}, ImageUrl="Screenshot (6).png"
                }

            };
        }
        public void Add(Books entity)
        {
            entity.Id = books.Max(s => s.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            //var book = books.Single(s => s.Id == id);
            var book = Find(id);
            books.Remove(book);
        }

        public Books Find(int id)
        {
            var book = books.SingleOrDefault(s => s.Id == id);
            return book;
        }

        public IList<Books> List()
        {
            return books;
        }

        public List<Books> Search(string term)
        {
            return books.Where(a => a.Tital.Contains(term)).ToList();


        }

        public void Update(int id, Books entity)
        {
            //var book = books.SingleOrDefault(s => s.Id == id);//لا تكرر

            var book = Find(id);
            book.Tital = entity.Tital;
            book.Auther = entity.Auther;
            book.ImageUrl = entity.ImageUrl;
        }


    }
}
