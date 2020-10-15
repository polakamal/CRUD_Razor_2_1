using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor_2_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Razor_2_1.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public String Message { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Book Book { get; set; }

        public void OnGet()

        {

        }
        public async Task<IActionResult> OnPost(Book Book)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            Message = "Book has been successfully!";
            return RedirectToPage("Index");

        }
    }
}