using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTP.Models;

namespace WebApplicationTP.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            List<AlumnosCLS> listaAlumnos = null;

            using (var bd = new DBAlumnosEntities())
            {
                listaAlumnos = (from alumno in bd.Alumnos
                                select new AlumnosCLS
                                {
                                    alumnoid = alumno.CodigoAlumno,
                                    apellidos = alumno.Apellido,
                                    nombres = alumno.Nombre,
                                    escuela = alumno.Escuela
                                }).ToList();

            }

            return View(listaAlumnos);
        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(AlumnosCLS oAlumnosCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oAlumnosCLS);
            }
            else
            {
                using (var bd = new DBAlumnosEntities())
                {
                    Alumnos oAlumnos = new Alumnos();
                    oAlumnos.CodigoAlumno = oAlumnosCLS.alumnoid;
                    oAlumnos.Nombre = oAlumnosCLS.nombres;
                    oAlumnos.Apellido = oAlumnosCLS.apellidos;
                    oAlumnos.Escuela = oAlumnosCLS.escuela;
                    bd.Alumnos.Add(oAlumnos);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
   