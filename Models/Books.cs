using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLp.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Tital { get; set; }
        public string ImageUrl { get; set; }
        public Auther Auther { get; set; }
    }
}
