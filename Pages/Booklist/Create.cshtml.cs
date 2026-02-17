using Book_list.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_list.Pages.Booklist
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db; 
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet() 
        {

        } 
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
