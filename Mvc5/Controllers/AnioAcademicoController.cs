using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;
using System.Net;

namespace Mvc5.Controllers
{
    public class AnioAcademicoController : Controller
    {
        private IAnioAcademicoService _anioAcademicoService;
        public AnioAcademicoController()
        {
            _anioAcademicoService = new AnioAcademicoService();
        }   
        // GET: AnioAcademico
        public ActionResult Index(string criterio)
        {
            var lista = _anioAcademicoService.GetAnioAcademicos(criterio);
            return View(lista);
        }

        // GET: AnioAcademico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var al = _anioAcademicoService.GetAnioAcademico(id);
            if (al == null)
            {
                return HttpNotFound();
            }
            return View(al);
        }

        // GET: AnioAcademico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnioAcademico/Create
        [HttpPost]
        public ActionResult Create(AnioAcademico anioAcademico, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    _anioAcademicoService.AddAnioAcademico(anioAcademico);
                    


                    return RedirectToAction("Index");
                }
                return View(anioAcademico);
            }
            catch
            {
                return View();
            }
        }

        // GET: AnioAcademico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var al = _anioAcademicoService.GetAnioAcademico(id);
            if (al == null)
            {
                return HttpNotFound();
            }
            return View(al);
         
        }

        // POST: AnioAcademico/Edit/5
        [HttpPost]
        public ActionResult Edit(AnioAcademico anio, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    _anioAcademicoService.UpdateAnioAcademico(anio);
                

                    return RedirectToAction("Index");
                }
                return View(anio);
            }
            catch
            {
                return View();
            }
        }

        // GET: AnioAcademico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var al = _anioAcademicoService.GetAnioAcademico(id);
            if (al == null)
            {
                return HttpNotFound();
            }
            return View(al);
        }

        // POST: AnioAcademico/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                if (ModelState.IsValid)
                {
                    _anioAcademicoService.DeleteAnioAcademico(id);
                  


                    return RedirectToAction("Index");
                }
                return View(id);
            }
            catch
            {
                return View();
            }
        }
    }
}
