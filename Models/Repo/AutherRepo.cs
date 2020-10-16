using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLp.Models.Repo
{
    public class AutherRepo : IBookStoreRepo<Auther>
    {
        IList<Auther> authers;

        public AutherRepo()
        {
            authers = new List<Auther>()
            {
                new Auther {Id =1, Name="ali" },
                new Auther{ Id =2, Name="ahmed" },
                new Auther{Id =3, Name="wowowo" }
            };

        }
        public void Add(Auther entity)
        {
            entity.Id = authers.Max(s => s.Id) + 1;
            authers.Add(entity);
        }

        public void Delete(int id)
        {
            var auther = Find(id);
            authers.Remove(auther);//هنا راح يروح لليست ويدور على الوثر ويحذف من الليست
        }

        public Auther Find(int id)
        {
            var auther = authers.SingleOrDefault(s => s.Id == id);
            return auther;
        }

        public IList<Auther> List()
        {
            return authers;
        }

        public List<Auther> Search(string term)
        {
            return authers.Where(a => a.Name.Contains(term)).ToList();
        }

        public void Update(int id, Auther entity)
        {
            var auther = Find(id);
            auther.Id = entity.Id;// the new id
            auther.Name = entity.Name;//the new name 
        }

        //public void Update(Auther entity, int id)
        //{
        //    var auther = Find(id);
        //    auther.Id = entity.Id;// the new id
        //    auther.Name = entity.Name;//the new na
        //}

    }
}
