using BooksLp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLp.ViewModels
{
    public class BookAutherViewModel
    {
        public int BookId { get; set; }


        [Required]
        [StringLength(20, MinimumLength =2)] //[MaxLength(20)]   //[MinLength(2)]
        public string Titel { get; set; }

        public int AutherId { get; set; }
        public List<Auther> Authers { get; set; }
        public IFormFile File { get; set; } //IFormFill is interface allow us to deal with files that come from Http req
        public  string ImageUrl { get; set; }


    }
}
