
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksLp.Models;
using BooksLp.Models.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksLp.Controllers
{
    public class AutherController : Controller

    {
        private readonly IBookStoreRepo<Auther> autherRepo;

        public AutherController(IBookStoreRepo<Auther> AutherRepo)
        {
            autherRepo = AutherRepo;
        }
        // GET: Default
        public ActionResult Index()
        {
            var authers = autherRepo.List();
            return View(authers);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            var auther = autherRepo.Find(id);
            return View(auther);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            //var auther = new Auther { Id = i, Name = " " };
            //autherRepo.Add(auther);
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auther auther)
        {
            try
            {
                // TODO: Add insert logic here
                autherRepo.Add(auther);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            var auther = autherRepo.Find(id);

            return View(auther);
        }

        // POST: Default/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Auther auther)
        {
            try
            {
                // TODO: Add update logic here
                autherRepo.Update(id, auther);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            var auther = autherRepo.Find(id);
            return View(auther);
        }

        // POST: Default/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Auther auther)
        {
            try
            {
                // TODO: Add delete logic here
                autherRepo.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}