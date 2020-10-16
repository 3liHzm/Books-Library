using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLp.Models
{
    public class BookDbContext:DbContext //the dbcotext allow as to chose wich clases that we want to make it as table  than we will ad it to dataBase
    {
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)//this opration is static 
        {


        }
        public DbSet<Auther> Authers { get; set; }//Dbset make the class as Table
        public DbSet<Books> Books { get; set; } 

    }
}
