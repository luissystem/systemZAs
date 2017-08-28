using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace Mvc5.Controllers
{
    public class MatriculaController : Controller
    {
        private IMatriculaService _matriculaService;
        private IAlumnoService _alumnoService;
        private IApoderadoService _apoderadoService;
        private IAnioAcademicoService _anioAcademicoService;
        private IUbigeoService _ubigeoService;
        private IDocumentoService _documentoService;
        private INivelService _nivelService;
        private IGradoService _gradoService;
        private ISeccionService _seccionService;
        public MatriculaController()
        {
            if (_matriculaService ==null)
            {
                _matriculaService = new MatriculaService();
            }
            if (_alumnoService==null)
            {
                _alumnoService = new AlumnoService();

            }
            if (_apoderadoService ==null)
            {
                _apoderadoService = new ApoderadosService();
            }
            if (_anioAcademicoService==null)
            {
                _anioAcademicoService = new AnioAcademicoService();
            }
            if (_ubigeoService==null)
            {
                _ubigeoService = new UbigeoService();
            }
            if (_documentoService== null)
            {
                _documentoService = new DocumentoService();
            }
            if (_nivelService==null)
            {
                _nivelService = new NivelService();
            }
            if (_gradoService==null)
            {
                _gradoService = new GradoService();
            }
            if (_seccionService==null)
            {
                _seccionService = new SeccionService();
            }
        }

        // GET: Matricula
        public ActionResult Index()
        {
            ViewBag.alumno = new SelectList(new List<SelectListItem>
            {
                new SelectListItem() {Text= "seleccione", Value = "0" }
            }, "Value", "Text");
            var grados = new List<SelectListItem>() {
                new SelectListItem() { Text = "Grado", Value = "0" }
            };
            var seccion = new List<SelectListItem>() {
                new SelectListItem() { Text = "Seccion", Value = "0" }
            };
            ViewBag.anios = new SelectList(_anioAcademicoService.GetAnioAcademicos(""), "AnioAcademicoId", "Anio");

            ViewBag.grado = new SelectList(grados, "Value", "Text");
            ViewBag.seccion = new SelectList(seccion, "Value", "Text");
            ViewBag.nivel = new SelectList(_nivelService.GetNiveles(), " NivelId ", "Nombre");
            var fecha = DateTime.Now.Year.ToString();
            var lista = _matriculaService.GetMatriculas("").Where(d => d.AnioAcademico.Anio.Equals(fecha));
            return View(lista);
        }

        // GET: Matricula/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Matricula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Matricula/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Matricula/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Matricula/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Matricula/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Matricula/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
