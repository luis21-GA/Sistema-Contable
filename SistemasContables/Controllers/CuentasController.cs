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
    public class CuentasController : Controller
    {
        private readonly CuentasRepository _cuetasRepository = new CuentasServices();
        private ApplicationDbcontext db = new ApplicationDbcontext();
        public void ListView()
        {
            ViewBag.idCategoria = new SelectList(db.Category, "idCategoria", "nombre");
        }
       
        // GET: Cuentas
        public ActionResult Index()
        {
            var cuentas = _cuetasRepository.GetAllCuentas();
            ListView();
            return View(cuentas);
        }

        [HttpPost]
        public ActionResult Index(int buscador)
        {

       
            var registrosFiltrados = db.Cuentas.OrderBy(item => item.CodigoCuenta).Where(item => item.CodigoCuenta == buscador).ToList();

            if (registrosFiltrados!=null)
            {
                ListView();
                return View(registrosFiltrados);
            }
            else
            {
                ListView();
                registrosFiltrados = db.Cuentas.ToList();
                return null;
            }   
        }

        /// <summary>
        /// Metodo que Perimite Realizar una busqueda de las cuentas con su respectivo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Cuentas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = await _cuetasRepository.GetbyId(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        /// <summary>
        /// Metodo Get que Perimite Mostrar una vista de Crear Cuentas 
        /// </summary>
        /// <returns></returns>
        // GET: Cuentas/Create
        public ActionResult Create()
        {


            ListView();
            return View();
        }

       /// <summary>
       /// Metodo  post que permite crear Registros de cuentas a la Base de datos 
       /// </summary>
       /// <param name="cuentas"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoCuenta,nombre,Descripcion,idCategoria,Cargos,Abonos")] Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                _cuetasRepository.Create(cuentas);
                return RedirectToAction("Index");
            }

            ListView();
            return View(cuentas);
        }

     /// <summary>
     /// Metodo Get que permite dar una vista de Editar Informacion de Cueta Seleccionada
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = db.Cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            ListView();
            return View(cuentas);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoCuenta,nombre,Descripcion,idCategoria,Cargos,Abonos")] Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ListView();
            return View(cuentas);
        }

        // GET: Cuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = db.Cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuentas cuentas = db.Cuentas.Find(id);
            db.Cuentas.Remove(cuentas);
            db.SaveChanges();
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



        public ActionResult LibroMayor()
        {
            var cuentas = _cuetasRepository.GetAllCuentas();
            ListView();
            return View(cuentas);
        }

        [HttpPost]
        public ActionResult LibroMayor(float buscador)
        {
            var registrosFiltrados = db.Cuentas.OrderBy(item => item.CodigoCuenta).Where(item => item.CodigoCuenta == buscador || item.Cargos==buscador || item.Abonos== buscador ).ToList();
            if (registrosFiltrados != null)
            {
                ListView();
                return View(registrosFiltrados);
            }
            else
            {
                ListView();
                registrosFiltrados = db.Cuentas.ToList();
                return null;
            }
        }

        public ActionResult BalanceComprobacion()
        {
            var cuentas = _cuetasRepository.GetAllCuentas();
            ListView();
            return View(cuentas);
        }
        [HttpPost]
        public ActionResult BalanceComprobacion(float buscador)
        {
            var registrosFiltrados = db.Cuentas.OrderBy(item => item.CodigoCuenta).Where(item => item.CodigoCuenta == buscador || item.Cargos == buscador || item.Abonos == buscador).ToList();
            if (registrosFiltrados != null)
            {
                ListView();
                return View(registrosFiltrados);
            }
            else
            {
                ListView();
                registrosFiltrados = db.Cuentas.ToList();
                return null;
            }
        }

        public ActionResult BalanceAjustado()
        {
            var cuentas = _cuetasRepository.GetAllCuentas();
            ListView();
            return View(cuentas);
        }
        [HttpPost]
        public ActionResult BalanceAjustado(float buscador)
        {
            var registrosFiltrados = db.Cuentas.OrderBy(item => item.CodigoCuenta).Where(item => item.CodigoCuenta == buscador || item.Cargos == buscador || item.Abonos == buscador).ToList();
            if (registrosFiltrados != null)
            {
                ListView();
                return View(registrosFiltrados);
            }
            else
            {
                ListView();
                registrosFiltrados = db.Cuentas.ToList();
                return null;
            }
        }
    }
}
