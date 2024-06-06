using BulkyWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace BulkyWeb_Razor.Pages.Relatives
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        MyDBContext _dbcontext;
        public Relative relative { get; set; }
        public DeleteModel(MyDBContext dbcontext)
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
            var obj = _dbcontext.RelativesTable.Find(relative.RelativeId);

            if (obj == null) 
                {
                return NotFound();
                }
            _dbcontext.RelativesTable.Remove(obj);
            _dbcontext.SaveChanges();
            TempData["success"] =relative.RelativeName +  " Deleted Successfully";
            return RedirectToPage("Relatives");
        }

    }
}
