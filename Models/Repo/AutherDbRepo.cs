using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLp.Models.Repo
{
    public class AutherDbRepo : IBookStoreRepo<Auther>
    {
        BookDbContext db;

        public AutherDbRepo(BookDbContext _db)
        {

            db = _db;
        }
        public void Add(Auther entity)
        {
            db.Authers.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var auther = Find(id);
            db.Authers.Remove(auther);//هنا راح يروح  ويدور على الوثر ويحذف من 
            db.SaveChanges();

        }

        public Auther Find(int id)
        {
            var auther = db.Authers.SingleOrDefault(s => s.Id == id);
            return auther;
        }

        public IList<Auther> List()
        {
            return db.Authers.ToList();
        }



        public void Update(int id, Auther entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }

       public List<Auther> Search(string term)
        {
            return db.Authers.Where(a => a.Name.ToLower().Contains(term.ToLower())).ToList();
        }

        //public void Update(Auther entity, int id)
        //{
        //    var auther = Find(id);
        //    auther.Id = entity.Id;// the new id
        //    auther.Name = entity.Name;//the new na
        //}

    }
    
    
}
