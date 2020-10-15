﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor_2_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Razor_2_1.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext  _db;
        
        public IEnumerable<Book> Books { get; set; }
        [TempData]
        public String Message { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
           
        }
        public async Task OnGet()
        {
          Books = await _db.Books.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id) 
        {
            var book = await _db.Books.FindAsync(id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            Message = "Book deleted successufully.";

            return RedirectToPage("Index");
        }      
    }
}