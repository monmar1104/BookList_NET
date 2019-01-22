﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookList.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext db;

        public BooksController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Books.ToList());
        }

        //Get: /Book/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if(ModelState.IsValid)
            {
                db.Add(book);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        //Details : Books/Details/{Id}
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var book = await db.Books.SingleOrDefaultAsync(m => m.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }




        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
        }
    }
}
