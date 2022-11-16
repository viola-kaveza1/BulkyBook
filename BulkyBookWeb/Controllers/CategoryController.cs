using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public object CategoryFromDbFirst { get; private set; }

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name ==obj.DisplayOder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactlymatch the name.");
            }

            if (ModelState.IsValid) 
            {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(obj);
        }



        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            //var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var CategoryFromDSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactlymatch the name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }

}

