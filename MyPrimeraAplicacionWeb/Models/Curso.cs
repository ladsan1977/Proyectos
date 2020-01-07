using System;
using System.Data.Common;
using AccesoDatos;
using System.Text;
using System.Data;

namespace MyPrimeraAplicacionWeb.Models
{
    public class Curso
    {
        public int IIDCURSO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }

        public int BHABILITADO { get; set; }


        public static Boolean consultaCursos(ref DataTable dataTableCursos, ref string msg)
        {
            BaseDatos Db = new BaseDatos();
            StringBuilder Sql = new StringBuilder();
            DataAdapter Da;
            DataSet Ds = new DataSet();
            bool Exito;
            try
            {
                Db.Conectar(true);

                Sql.AppendLine("SELECT IIDCURSO, NOMBRE, DESCRIPCION ");
                Sql.AppendLine("FROM  SistemaMatricula.dbo.Curso ");
                Sql.AppendLine("WHERE BHABILITADO = 1 ");
                Sql.AppendLine("; ");

                Db.CrearComando(Sql.ToString());

                Da = Db.CrearAdapter();
                Da.Fill(Ds);
                dataTableCursos = Ds.Tables[0];
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

        public static Boolean filtrarCurso(ref string filtro,ref DataTable dataTableCursosFiltro, ref string msg)
        {
            BaseDatos Db = new BaseDatos();
            StringBuilder Sql = new StringBuilder();
            DataAdapter Da;
            DataSet Ds = new DataSet();
            bool Exito;
            try
            {
                Db.Conectar(true);

                Sql.AppendLine("SELECT IIDCURSO, NOMBRE, DESCRIPCION ");
                Sql.AppendLine("FROM  SistemaMatricula.dbo.Curso ");
                Sql.AppendLine("WHERE BHABILITADO = 1 ");

                if (!string.IsNullOrEmpty(filtro)) 
                {
                    Sql.AppendLine("AND NOMBRE LIKE @Filtro");
                };

                Sql.AppendLine("; ");

                DbParameter[] arrayParms = new DbParameter[1];
                arrayParms[0] = (DbParameter)Db.CrearParametro();
                arrayParms[0].DbType = DbType.String;
                arrayParms[0].ParameterName = "@Filtro";
                arrayParms[0].Value = '%'+filtro.Trim()+'%';

                Db.CrearComando(Sql.ToString());

                foreach (DbParameter parametro in arrayParms)
                {
                    Db.AsignarParametro(parametro);
                }

                Da = Db.CrearAdapter();
                Da.Fill(Ds);
                dataTableCursosFiltro = Ds.Tables[0];
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