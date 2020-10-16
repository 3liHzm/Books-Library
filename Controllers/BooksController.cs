using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BooksLp.Models;
using BooksLp.Models.Repo;
using BooksLp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksLp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookStoreRepo<Books> bookRepo;
        private readonly IBookStoreRepo<Auther> autherRepo;
        private readonly IHostingEnvironment hosting;

        public BooksController(IBookStoreRepo<Books> BookRepo, IBookStoreRepo<Auther> autherRepo, IHostingEnvironment hosting) 
        {
            bookRepo = BookRepo;
            this.autherRepo = autherRepo;
            this.hosting = hosting;
        }
        // GET: Books
        public ActionResult Index()
        {
            var books = bookRepo.List();
            
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepo.Find(id);
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
          //  var model = new BookAutherViewModel { Authers = FillSelectList() }; we make amethod for that
            return View(GetAllAuther());
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAutherViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = UploadFile(model.File) ?? string.Empty;


                    if (model.AutherId == -1)
                    {
                        ViewBag.Message = "please select auther";

                       // var vmodel = new BookAutherViewModel { Authers = FillSelectList() };
                        return View(GetAllAuther());
                    }
                    // TODO: Add insert logic here
                    var auther = autherRepo.Find(model.AutherId);
                    Books book = new Books { Id = model.BookId, Tital = model.Titel, Auther = auther, ImageUrl = fileName };
                    bookRepo.Add(book);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
           // var vvmodel = new BookAutherViewModel { Authers = FillSelectList() };
            ModelState.AddModelError("", "You have to fill all required fields !!");
            return View(GetAllAuther());
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepo.Find(id);
             var autherId = book.Auther == null? book.Auther.Id = 0 : book.Auther.Id;
            //var autherId = book.Auther.Id;
            var ViewModel = new BookAutherViewModel { BookId = book.Id, Titel = book.Tital, AutherId = autherId, Authers = autherRepo.List().ToList(), ImageUrl=book.ImageUrl };
            return View(ViewModel);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookAutherViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = UploadFile(model.File, model.ImageUrl) ?? string.Empty;



                    // TODO: Add update logic here
                    var auther = autherRepo.Find(model.AutherId);
                    Books book = new Books { Tital = model.Titel, Auther = auther, ImageUrl = fileName, Id=model.BookId };
                    bookRepo.Update(model.BookId, book);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "You have to fill all required fields !!");
            return View(GetAllAuther());
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepo.Find(id);
            
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                bookRepo.Delete(id);
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<Auther> FillSelectList()
        {
            var authers = autherRepo.List().ToList();
            authers.Insert(0, new Auther { Id = -1, Name = " select an auther " });
            return authers;
        }

        BookAutherViewModel GetAllAuther()
        {
            var model = new BookAutherViewModel { Authers = FillSelectList() };
            return (model);
        }
        string UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string Uploads = Path.Combine(hosting.WebRootPath, "Uploads");
               
                string fullPath = Path.Combine(Uploads, file.FileName);
                file.CopyTo(new FileStream(fullPath, FileMode.Create));
                return (file.FileName);
            }
            return null;
        }
        string UploadFile(IFormFile file, string ImageUrl)
        {
            if (file != null)
            {


                string Uploads = Path.Combine(hosting.WebRootPath, "Uploads");
                
                string NewfullPath = Path.Combine(Uploads, file.FileName);

                // string oldFileName = bookRepo.Find(model.BookId).ImageUrl;
                string oldFileName = ImageUrl;

                string fullOldPath = Path.Combine(Uploads, ImageUrl);
                if (NewfullPath != fullOldPath)
                {
                    //delet the file

                    System.IO.File.Delete(fullOldPath);

                    //save the new fill
                    file.CopyTo(new FileStream(NewfullPath, FileMode.Create));
                }
                return file.FileName;
            }
            return ImageUrl;
        }

        public ActionResult Search(string term)
        {
            if(term != null) { 
            var result = bookRepo.Search(term);


            return View("Index", result);
            }
            var Aresult = bookRepo.List();
            return View("Index", Aresult);
        }

    }
}