using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPrimeraAplicacionWeb.Models;


namespace MyPrimeraAplicacionWeb.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarAlumnos()
        {
            List<Alumno> listaAlumno = new List<Alumno>();
            DataTable respT = new DataTable();
            string msg = "";
            Boolean resp = false;
            resp = Alumno.consultaAlumnos(ref respT, ref msg);

            if (resp)
            {


                for (int i = 0; i < respT.Rows.Count; i++)
                {
                    Alumno alumnoClase = new Alumno();
                    alumnoClase.IIDALUMNO = Convert.ToInt32(respT.Rows[i]["IIDALUMNO"]);
                    alumnoClase.NOMBRE = respT.Rows[i]["NOMBRE"].ToString();
                    alumnoClase.APMATERNO = respT.Rows[i]["APMATERNO"].ToString();
                    alumnoClase.APMATERNO = respT.Rows[i]["APMATERNO"].ToString();
                    alumnoClase.TELEFONOPADRE = respT.Rows[i]["TELEFONOPADRE"].ToString();
                    listaAlumno.Add(alumnoClase);
                }
            }
            else
            {
                listaAlumno = null;
            }

            return Json(listaAlumno, JsonRequestBehavior.AllowGet);           
        }
    }
}