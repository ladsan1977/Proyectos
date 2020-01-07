using MyPrimeraAplicacionWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPrimeraAplicacionWeb.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        public string mensaje()
        {
            return "Hola, bienvenidos a este curso";
        }

        public string saludo(string nombre)
        {
            return "Hola como estas : " + nombre;
        }

        public string saludoCompleto(string nombre, string apellido)
        {
            return "Hola como estas : " + nombre+ " " + apellido;
            //  localhost:44328/Curso/saludoCompleto/?nombre=Luz&apellido=Sanchez
        }

        public ActionResult ListarCurso()
        {
            return View();
        }

        public JsonResult listar()
        {
           
            List<Curso> listaCurso = new List<Curso>();
            DataTable respT = new DataTable();
            string msg = "";
            Boolean resp = false;
            resp = Curso.consultaCursos(ref respT, ref msg);

            if (resp)
            {
               

                for (int i = 0; i < respT.Rows.Count; i++)
                {
                    Curso cursoClase = new Curso();
                    cursoClase.IIDCURSO = Convert.ToInt32(respT.Rows[i]["IIDCURSO"]);
                    cursoClase.NOMBRE = respT.Rows[i]["NOMBRE"].ToString();
                    cursoClase.DESCRIPCION = respT.Rows[i]["DESCRIPCION"].ToString();
                    listaCurso.Add(cursoClase);
                }
            }
            else
            {
                listaCurso = null;
            }

            return Json(listaCurso, JsonRequestBehavior.AllowGet);

            // string JSONresult = "";
            //JSONresult = JsonConvert.SerializeObject(respT);
            //List<Curso> listCursos = JsonConvert.DeserializeObject<List<Curso>>(content);
            //return Json(JSONresult, JsonRequestBehavior.AllowGet);
            //return Ok(JSONresult);

            //{
            //new Curso {IIDCURSO=1,NOMBRE="MATH",DESCRIPCION="PRUEBA" },
            //new Curso {IIDCURSO=2,NOMBRE="ESPAÑOL",DESCRIPCION="PRUEBA 1" },
            //};

        }

        public JsonResult buscarCursoxNombre(string nombre)
        {
            List<Curso> listaCursoFiltro = new List<Curso>();
            DataTable respT = new DataTable();
            string msg = "";
            Boolean resp = false;
            resp = Curso.filtrarCurso(ref nombre,ref respT, ref msg);

            if (resp)
            {
                for (int i = 0; i < respT.Rows.Count; i++)
                {
                    Curso cursoClase = new Curso();
                    cursoClase.IIDCURSO = Convert.ToInt32(respT.Rows[i]["IIDCURSO"]);
                    cursoClase.NOMBRE = respT.Rows[i]["NOMBRE"].ToString();
                    cursoClase.DESCRIPCION = respT.Rows[i]["DESCRIPCION"].ToString();
                    listaCursoFiltro.Add(cursoClase);
                }
            }
            else
            {
                listaCursoFiltro = null;
            }
            return Json(listaCursoFiltro, JsonRequestBehavior.AllowGet);          
        }
    }

   
}