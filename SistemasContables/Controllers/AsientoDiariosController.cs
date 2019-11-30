using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemasContables.Models;

namespace SistemasContables.Controllers
{
    public class AsientoDiariosController : Controller
    {
        private ApplicationDbcontext db = new ApplicationDbcontext();


        public void ListView()
        {
            ViewBag.idCategoria = new SelectList(db.Category, "idCategoria", "nombre");
            ViewBag.CodigoCuenta = new SelectList(db.Cuentas, "CodigoCuenta", "nombre");
            ViewBag.CodigoCuenta1 = new SelectList(db.Cuentas, "CodigoCuenta", "nombre");
        }
        // GET: AsientoDiarios
        public ActionResult Index()
        {
            ListView();
            var asientoDiario = db.AsientoDiario.Include(a => a.Cuentas).Include(a => a.Cuentas1);
            return View(asientoDiario.ToList());
        }

        // GET: AsientoDiarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoDiario asientoDiario = db.AsientoDiario.Find(id);
            if (asientoDiario == null)
            {
                return HttpNotFound();
            }
            return View(asientoDiario);
        }

        // GET: AsientoDiarios/Create
        public ActionResult Create()
        {
           
            ListView();
            return View();
        }

        // POST: AsientoDiarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsiento,CodigoCuenta,CodigoCuenta1,Debe1,Haber1,Debe2,Haber2,Fecha,DEscripcion")] AsientoDiario asientoDiario)
        {
            if (ModelState.IsValid && asientoDiario.Debe1==asientoDiario.Haber2)
            {


                Cuentas CuentaSelecciona1 = db.Cuentas.Single(item => item.CodigoCuenta == asientoDiario.CodigoCuenta);
                Cuentas CuentaSeleccionada2 = db.Cuentas.Single(item => item.CodigoCuenta == asientoDiario.CodigoCuenta1);

                if (CuentaSelecciona1!=null )
                {
                    if (asientoDiario.Debe1>0)
                    {
                        var resultado = CuentaSeleccionada2.Cargos;
                        if (resultado==null)
                        {
                            CuentaSeleccionada2.Cargos = asientoDiario.Debe1;
                        }
                        else
                        {
                            CuentaSeleccionada2.Cargos = resultado + asientoDiario.Debe1;
                        }
                       
                        db.Entry(CuentaSelecciona1).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                   

                }
                if (CuentaSeleccionada2 != null)
                {
                    if (asientoDiario.Haber2 > 0)
                    {
                        var resultado = CuentaSelecciona1.Abonos;

                        if (resultado == null)
                        {
                            CuentaSelecciona1.Abonos =  asientoDiario.Haber2;
                        }
                        else
                        {
                            CuentaSelecciona1.Abonos = resultado + asientoDiario.Haber2;
                        }
                       
                        db.Entry(CuentaSelecciona1).State = EntityState.Modified;
                        db.SaveChanges();
                    }


                }

                db.AsientoDiario.Add(asientoDiario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ListView();
                return RedirectToAction("Index");
            }
           
         
        }

        // GET: AsientoDiarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoDiario asientoDiario = db.AsientoDiario.Find(id);
            if (asientoDiario == null)
            {
                return HttpNotFound();
            }
            ListView();
           
            return View(asientoDiario);
        }

        // POST: AsientoDiarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsiento,CodigoCuenta,CodigoCuenta1,Debe1,Haber1,Debe2,Haber2,Fecha,DEscripcion")] AsientoDiario asientoDiario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asientoDiario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ListView();
            return View(asientoDiario);
        }

        // GET: AsientoDiarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoDiario asientoDiario = db.AsientoDiario.Find(id);
            if (asientoDiario == null)
            {
                return HttpNotFound();
            }
            return View(asientoDiario);
        }

        // POST: AsientoDiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsientoDiario asientoDiario = db.AsientoDiario.Find(id);
            db.AsientoDiario.Remove(asientoDiario);
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



      
    }
}
