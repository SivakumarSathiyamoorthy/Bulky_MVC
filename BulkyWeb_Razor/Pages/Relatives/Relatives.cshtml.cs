
using BulkyWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_Razor.Pages.Relatives
{
    public class RelativesModel : PageModel
    {
        private MyDBContext _dbcontext;
        public List<Relative> RelativesList { get; set; }
        public RelativesModel(MyDBContext dbcontext)
        {
            _dbcontext=dbcontext;
        }
        public void OnGet()
        {
            RelativesList=_dbcontext.RelativesTable.ToList();
        }
    }
}
