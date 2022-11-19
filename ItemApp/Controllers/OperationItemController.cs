
using ItemApp.Data;
using ItemApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ItemApp.Controllers
{
    public class OperationItemController : Controller
    {
        private readonly ItemDbContext _context;

        public OperationItemController(ItemDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var show = _context.Items.Include(s=>s.Category).ToList();

            return View(show);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item model)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        public IActionResult Delete(int ?id)
        {
           
            var show=_context.Items.Find(id);
            
            if (show != null)
            {
                _context.Items.Remove(show);
               
                
                _context.SaveChanges(true);
                
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
           

            var show = _context.Items.Include(s=>s.Category).FirstOrDefault(x=>x.Id==id);
            
            return View(show);
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {

            var show = _context.Items.Include(s=>s.Category).FirstOrDefault(s=>s.Id==id);
            return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item model)
        {
          if(ModelState.IsValid)
            {
                _context.Items.Update(model);
                _context.SaveChanges(true);
                return RedirectToAction("Index");
            }
        
            return View();
        }


    }
}
