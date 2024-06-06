using BulkyWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_Razor.Pages.Relatives
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        MyDBContext _dbcontext;
        public Relative relative { get; set; }
        public CreateModel(MyDBContext dbcontext)
        {
            _dbcontext=dbcontext;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost() 
        {
            _dbcontext.RelativesTable.Add(relative);
            TempData["success"] = relative.RelativeName + " is created successfully! ";
            _dbcontext.SaveChanges();
            return RedirectToPage("Relatives");
        }
    }
}
