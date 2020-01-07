using MyPrimeraAplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPrimeraAplicacionWeb.Controllers
{
    public class PeriodoController : Controller
    {
        // GET: Periodo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarPeriodo()
        {
            List<Models.Periodo> listaPeriodo = new List<Periodo>();
            DataTable respT = new DataTable();
            string msg = "";
            Boolean resp = false;
            resp = Periodo.consultaPeriodos(ref respT, ref msg);

            if (resp)
            {


                for (int i = 0; i < respT.Rows.Count; i++)
                {
                    Periodo periodoClase = new Periodo();
                    periodoClase.IIDPERIODO = Convert.ToInt32(respT.Rows[i]["IIDPERIODO"]);
                    periodoClase.NOMBRE = respT.Rows[i]["NOMBRE"].ToString();
                    periodoClase.FECHAINICIO = (Convert.ToDateTime(respT.Rows[i]["FECHAINICIO"])).ToShortDateString();
                    periodoClase.FECHAFIN = (Convert.ToDateTime(respT.Rows[i]["FECHAFIN"])).ToShortDateString();
                    listaPeriodo.Add(periodoClase);
                }
            }
            else
            {
                listaPeriodo = null;
            }

            return Json(listaPeriodo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscarPeriodoxNombre(string nombrePeriodo)
        {
            List<Models.Periodo> listaPeriodo = new List<Periodo>();
            DataTable respT = new DataTable();
            string msg = "";
            Boolean resp = false;
            resp = Periodo.consultaPeriodosxNombre(ref nombrePeriodo, ref respT, ref msg);

            if (resp)
            {


                for (int i = 0; i < respT.Rows.Count; i++)
                {
                    Periodo periodoClase = new Periodo();
                    periodoClase.IIDPERIODO = Convert.ToInt32(respT.Rows[i]["IIDPERIODO"]);
                    periodoClase.NOMBRE = respT.Rows[i]["NOMBRE"].ToString();
                    periodoClase.FECHAINICIO = (Convert.ToDateTime(respT.Rows[i]["FECHAINICIO"])).ToShortDateString();
                    periodoClase.FECHAFIN = (Convert.ToDateTime(respT.Rows[i]["FECHAFIN"])).ToShortDateString();
                    listaPeriodo.Add(periodoClase);
                }
            }
            else
            {
                listaPeriodo = null;
            }

            return Json(listaPeriodo, JsonRequestBehavior.AllowGet);
        }
    }
}