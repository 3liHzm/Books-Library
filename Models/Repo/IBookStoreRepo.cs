using BooksLp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLp.Models.Repo
{
   public interface IBookStoreRepo<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update( int id, TEntity entity);
        void Delete(int id);
        //void Add(BookAutherViewModel model);
        List<TEntity> Search(string term);
    }
}
