using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_CRUD_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_CRUD_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db.tEmpCRUD.ToList();
            return View(data);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Add(emp);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var details = await _db.tEmpCRUD.FindAsync(id);
            return View(details);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Update(emp);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var details = await _db.tEmpCRUD.FindAsync(id);
            return View(details);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var details = await _db.tEmpCRUD.FindAsync(id);
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var details = await _db.tEmpCRUD.FindAsync(id);
            _db.tEmpCRUD.Remove(details);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
