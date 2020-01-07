using System;
using System.Data.Common;
using AccesoDatos;
using System.Text;
using System.Data;

namespace MyPrimeraAplicacionWeb.Models
{
    public class Alumno
    {
        public int IIDALUMNO { get; set; }
        public string NOMBRE { get; set; }
        public string APPATERNO { get; set; }
        public string APMATERNO { get; set; }
        public string TELEFONOPADRE { get; set; }

        public static Boolean consultaAlumnos(ref DataTable dataTableAlumnos, ref string msg)
        {
            BaseDatos Db = new BaseDatos();
            StringBuilder Sql = new StringBuilder();
            DataAdapter Da;
            DataSet Ds = new DataSet();
            bool Exito;
            try
            {
                Db.Conectar(true);

                Sql.AppendLine("SELECT   IIDALUMNO, NOMBRE, APPATERNO, APMATERNO, TELEFONOPADRE ");
                Sql.AppendLine("FROM  SistemaMatricula.dbo.Alumno ");
                Sql.AppendLine("WHERE BHABILITADO = 1 ");
                Sql.AppendLine("; ");

                Db.CrearComando(Sql.ToString());

                Da = Db.CrearAdapter();
                Da.Fill(Ds);
                dataTableAlumnos = Ds.Tables[0];
                Exito = true;
                msg = "OK";

            }
            catch (Exception Ex)
            {
                Exito = false;
                msg = Ex.ToString();
            }

            return Exito;
        }

    }
}