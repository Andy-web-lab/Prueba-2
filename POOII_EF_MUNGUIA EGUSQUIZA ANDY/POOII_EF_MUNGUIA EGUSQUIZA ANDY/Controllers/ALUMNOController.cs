using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidad;
using Negocio;

namespace POOII_EF_MUNGUIA_EGUSQUIZA_ANDY.Controllers
{
    public class ALUMNOController : Controller
    {
        ALUMNO_NEG ng1 = new ALUMNO_NEG();
        ESPECIALIDAD_NEG ng2 = new ESPECIALIDAD_NEG();

        // GET: ALUMNO
        public ActionResult IndexALUMNO()
        {
            return View(ng1.ListarAlumnos());
        }

       
    
        // GET: ALUMNO/Create
        public ActionResult CreateALUMNO()
        {
            ViewBag.Especialidad = new SelectList(
               ng2.ListarEspecialidad(), "CodEsp", "NomEsp");
            //
            return View(new ALUMNO());
        }

        // POST: ALUMNO/Create
        [HttpPost]
        public ActionResult CreateALUMNO(ALUMNO obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] = ng1.GrabarALUMNO(obj);
                    //
                    return RedirectToAction("IndexALUMNO");
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            //
            ViewBag.Especialidad = new SelectList(
               ng2.ListarEspecialidad(), "CodEsp", "NomEsp");
            //
            return View(obj);
        }

        // GET: ALUMNO/Edit/5
        public ActionResult EditALUMNO(string id)
        {
            ALUMNO buscado = ng1.ListarAlumnos()
                                 .Find(c => c.CodAlumno.Equals(id));

            ViewBag.Especialidad = new SelectList(
                ng2.ListarEspecialidad(), "CodEsp", "NomEsp");

            return View(buscado);
        }

        // POST: ALUMNO/Edit/5
        [HttpPost]
        public ActionResult EditALUMNO(string id, ALUMNO obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] = ng1.ActualizarALUMNO(obj);
                    //
                    return RedirectToAction("IndexALUMNO");
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            //
            ViewBag.Especialidad = new SelectList(
                ng2.ListarEspecialidad(), "CodEsp", "NomEsp");
            //
            return View(obj);
        }

    }
}
