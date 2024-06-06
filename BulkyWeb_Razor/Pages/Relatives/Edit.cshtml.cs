using BulkyWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_Razor.Pages.Relatives
{
    [BindProperties]
    public class EditModel : PageModel
    {
        MyDBContext _dbcontext;
        public Relative relative { get; set; }
        public EditModel(MyDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                relative = _dbcontext.RelativesTable.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbcontext.RelativesTable.Update(relative);
                _dbcontext.SaveChanges();
                TempData["success"] = "Details for ID "+ relative.RelativeId +" is Updated!";
                return RedirectToPage("Relatives");
            }
            return Page();
        }
    }
}
