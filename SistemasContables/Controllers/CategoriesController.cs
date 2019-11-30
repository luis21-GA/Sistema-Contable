using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SistemasContables.Models;
using SistemasContables.Repository.Implementation;
using SistemasContables.Repository.Interfaces;

namespace SistemasContables.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository = new CategoryService();
        private ApplicationDbcontext db = new ApplicationDbcontext();


        // GET: Categories
        public ActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
           
            return View(categories.ToList());
        }

        [HttpPost]
        public ActionResult Index(int buscador)
        {
            var registrosFiltrados = db.Category.OrderBy(item => item.idCategoria).Where(item => item.idCategoria == buscador).ToList();

            if (registrosFiltrados != null)
            {
            
                return View(registrosFiltrados);
            }
            else
            {
                registrosFiltrados = db.Category.ToList();
                return null;
            }
        }
        // GET: Categories/Details/5
        public  async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await _categoryRepository.GetbyId(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            TempData["codigo"] = category.idCategoria;
            return View(category);
        
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCategoria,nombre,descripcion")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Create(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task< ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category =  await _categoryRepository.GetbyId(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            TempData["codigo"] = category.idCategoria;
            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task< ActionResult> Edit([Bind(Include = "idCategoria,nombre,descripcion")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.Edit(category);

                return RedirectToAction("Index");
            }
                TempData["codigo"] = category.idCategoria;
                return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await _categoryRepository.GetbyId(id);     
            if (category == null)
            {
                return HttpNotFound();
            }
            TempData["codigo"] = category.idCategoria;
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Category.Find(id);
            _categoryRepository.Delete(id);
            TempData["codigo"] = category.idCategoria;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
