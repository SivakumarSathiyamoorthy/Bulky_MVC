using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _dbContex;

        public CategoryController(ApplicationDbContext dbContex )
        {
            _dbContex = dbContex;
        }
        public IActionResult Index()
        {
            var categories=_dbContex.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category name and display order should not be same");
            }

            if (ModelState.IsValid)
                {
                _dbContex.Categories.Add(obj);
                _dbContex.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
                }
           return View();
        }

        public IActionResult Edit(int? id)
        {
            if( id == null || id <= 0) { return NotFound(); }
            var obj = _dbContex.Categories.Find(id);
            if (obj==null) { return NotFound(); }
            return View(obj);

        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category name and display order should not be same");
            }

            if (ModelState.IsValid)
            {
                _dbContex.Categories.Update(obj);
                _dbContex.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0) { return NotFound(); }
            var obj = _dbContex.Categories.Find(id);
            if (obj == null) { return NotFound(); }
            return View(obj);

        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id <= 0) { return NotFound(); }
            var obj = _dbContex.Categories.Find(id);
            if (obj == null) { return NotFound(); }
            _dbContex.Categories.Remove(obj);
            TempData["success"] = "Category deleted successfully";
            _dbContex.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
