using Core.Entidades;
using Modelo;
using Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysAdmin.Controllers
{
    public class EstudianteController : Controller
    {
        private IEstudianteService _ServiceEst;
        public EstudianteController(IEstudianteService servest)
        {
            _ServiceEst = servest;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var estudianes = _ServiceEst.GetAllEstudiantes();
            return View(estudianes);
        }

        [HttpGet]
        public ActionResult AddEditEstudiante(int? id)
        {
            EstudianteModel model = new EstudianteModel();
            if (id.HasValue)
            {
                model = _ServiceEst.GetByIdEstudiante(id.Value);
            }
            return PartialView("~/Views/Estudiante/_AddEditEstudiante.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddEditEstudiante(int? id, EstudianteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    _ServiceEst.AddEdditEstudiante(isNew, model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult DeleteEstudiante(int id)
        {
            EstudianteModel model = new EstudianteModel();  
            model = _ServiceEst.GetByIdEstudiante(id);
            model.NombreCompleto = $"{model.PrimerNombre} {model.PrimerApellido}";
            return PartialView("~/Views/Estudiante/_DeleteEstudiante.cshtml", model);
        }
        [HttpPost]
        public ActionResult DeleteEstudiante(int id, FormCollection form)
        {
            _ServiceEst.DeleteEstudiante(id);
            return RedirectToAction("Index");
        }
    }
}
