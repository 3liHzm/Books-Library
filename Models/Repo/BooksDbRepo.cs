using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLp.Models.Repo
{
    public class BooksDbRepo : IBookStoreRepo<Books>
    {

        BookDbContext db;
        public BooksDbRepo( BookDbContext _db)
        {
            db = _db;
        }
        public void Add(Books entity)
        {
            db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            //var book = books.Single(s => s.Id == id);
            var book = Find(id);
            db.Books.Remove(book);
            db.SaveChanges();

        }

        public Books Find(int id)
        {
            var book = db.Books.Include(s => s.Auther).SingleOrDefault(s => s.Id == id);
            return book;
        }

        public IList<Books> List()
        {
            return db.Books.Include(s=>s.Auther).ToList();
        }

        public void Update(int id, Books entity)
        {
            //var book = books.SingleOrDefault(s => s.Id == id);//لا تكرر

            db.Update(entity);
            db.SaveChanges();

        }

        public List<Books> Search(string term)
        {
            var result = db.Books.Include(s => s.Auther)
                .Where(b => b.Tital.ToLower().Contains(term.ToLower())
                         || b.Auther.Name.ToLower().Contains(term.ToLower())).ToList();

            return result;
        }
       
    }
}
