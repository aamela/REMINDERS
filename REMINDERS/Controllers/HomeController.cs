using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using REMINDERS.App_Start;
using THelpConnect;

namespace REMINDERS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AnadirRecordatorio()
        {
            SqlCommand cmd = new SqlCommand();
            string lastId="";
            string strSQLlastId;


            THCBSQL xTHCBSQL = new THCBSQL();
         
            var xREMINDERS = new REMINDERS.TWREMINDERS();
            var xREMINDERSDB = new REMINDERS.TWREMINDERSDB(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            var tipoDocumento = Request.Form["tdocumento"];
            var finicio = Request.Form["finicio"];
            var ffin = Request.Form["ffin"];
            var hora = Request.Form["hora"];
            var minuto = Request.Form["minuto"];
            var periodicidad = Request.Form["periodicidad"];
            var textoEmail = Request.Form["textoEmail"];
            var recordatorio = DateTime.Parse(Request.Form["recordatorio"]);

            strSQLlastId = "SELECT IDENT_CURRENT('WREMINDERS')";

            xREMINDERS.id_doctype = tipoDocumento;
            xREMINDERS.id_usuario = "1";
            xREMINDERS.start_date = DateTime.Parse(finicio);
            xREMINDERS.end_date = DateTime.Parse(ffin);
            xREMINDERS.periodicity = periodicidad;
            xREMINDERS.next_exec_date = recordatorio;
            xREMINDERS.rem_text = textoEmail;
            xREMINDERS.last_exec = "1";
            xREMINDERS.last_exec_date = DateTime.Now;
            xREMINDERS.user_cre = "1";
            xREMINDERS.date_cre = DateTime.Now;
            xREMINDERS.hour = Convert.ToInt32(hora);
            xREMINDERS.minute = Convert.ToInt32(minuto);
            xREMINDERS.busi_partner = "1";

           
            try
            {
                xTHCBSQL.ConnectionString = xREMINDERSDB.ConnectionString;

                xREMINDERSDB.DbCn = xTHCBSQL;
                xREMINDERSDB.DbCn.Conecta();

                if (xREMINDERSDB.SaveData(xREMINDERS,xREMINDERSDB.DbCn))
                {
                    SqlDataReader dr = xREMINDERSDB.DbCn.GetDataReader(strSQLlastId, 4000);

                   

                    while (dr.Read())
                    {
                        lastId = dr[0].ToString();
                    }


                    return Content(lastId);
                }
                else
                {
                    return Content("No se ha añadido el recordatorio. " + xREMINDERSDB.LastError);
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                xREMINDERSDB.DbCn.Desconecta();
            }
        }

        [HttpPost]
        public ActionResult EnviarArchivos()
        {
            
            SqlCommand cmd = new SqlCommand();
           
            THCBSQL xTHCBSQL = new THCBSQL();



            TWREMINDERDOCSDB xWREMINDERDOCSDB = new TWREMINDERDOCSDB(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            


            xTHCBSQL.ConnectionString = xWREMINDERDOCSDB.ConnectionString;

          
            xWREMINDERDOCSDB.DbCn = xTHCBSQL;

            xWREMINDERDOCSDB.DbCn.Conecta();
   

            for (int i = 0; i < Request.Files.Count; i++)
            
            {
                try
                {
                       TWREMINDERDOCS xWREMINDERDOCS = new TWREMINDERDOCS();

                       BinaryReader br = new BinaryReader(Request.Files[i].InputStream);

                       Guid NewGuid= Guid.NewGuid();

                       xWREMINDERDOCS.FileGuid = NewGuid;
                       xWREMINDERDOCS.FileName = Request.Files[i].FileName;
                       xWREMINDERDOCS.FileData = br.ReadBytes(Request.Files[i].ContentLength);
                       xWREMINDERDOCS.id_reminder = Int32.Parse(Request.Form["id_reminder"].ToString());

                       if (xWREMINDERDOCSDB.SaveData(xWREMINDERDOCS, xWREMINDERDOCSDB.DbCn))
                       {
                           return Content("Se han guardado los datos");
                       }
                   
                } 
                catch (Exception ex)
                {

                    return Content(ex.Message);

                }
                finally
                {
                    xWREMINDERDOCSDB.DbCn.Desconecta();
                }
               
            }

            return Content("");

        }

        public ActionResult CargarRecordatorios()
        {
            var xREMINDERS = new REMINDERS.TWREMINDERS();
            var xREMINDERSDB = new REMINDERS.TWREMINDERSDB(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            var strHTML = "";

            THCBSQL xTHCBSQL = new THCBSQL();

            xTHCBSQL.ConnectionString = xREMINDERSDB.ConnectionString;

            
            xREMINDERSDB.DbCn = xTHCBSQL;
            xREMINDERSDB.DbCn.Conecta();
            try
            {
                SqlDataReader dr = xREMINDERSDB.DbCn.GetDataReader("SELECT * FROM WREMINDERS", 40000);
                while (dr.Read())
                {
                    strHTML += "<option id='" + dr[0] + "' value='" + dr[0] + "'>" + dr[0] + "</option>";
                    
                }

                return Content(strHTML);
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                xREMINDERSDB.DbCn.Desconecta();
            }
        }

        public ActionResult CargarTipoDocumentos()
        {
            var xREMINDERSDOCS = new TWREMINDERDOCS();
            var xREMINDERSDOCSDB = new TWREMINDERDOCSDB(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            var strHTML = "";

            THCBSQL xTHCBSQL = new THCBSQL();

            xTHCBSQL.ConnectionString = xREMINDERSDOCSDB.ConnectionString;


            xREMINDERSDOCSDB.DbCn = xTHCBSQL;
            xREMINDERSDOCSDB.DbCn.Conecta();
            try
            {
                SqlDataReader dr = xREMINDERSDOCSDB.DbCn.GetDataReader("SELECT DISCRIMINADOR FROM TENUMERADOEX", 40000);
                while (dr.Read())
                {
                    strHTML += "<option id='" + dr[0] + "' value='" + dr[0] + "'>" + dr[0] + "</option>";

                }

                return Content(strHTML);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                xREMINDERSDOCSDB.DbCn.Desconecta();
            }
        }    
            
        [HttpPost]
        public ActionResult CargarRecordatorio(int id_recordatorio)
        {
            String strSQL;   
            var xREMINDERSDB = new REMINDERS.TWREMINDERSDB(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            

            strSQL = "SELECT * FROM WREMINDERS WHERE id_reminder = " + id_recordatorio;

            
            THCBSQL xTHCBSQL = new THCBSQL();

            xTHCBSQL.ConnectionString = xREMINDERSDB.ConnectionString;

            
            xREMINDERSDB.DbCn = xTHCBSQL;
            xREMINDERSDB.DbCn.Conecta();

            
            try
            {
                SqlDataReader dr = xREMINDERSDB.DbCn.GetDataReader(strSQL, 40000);
                
                while (dr.Read())
                {
                  
                    return Json(new { finicio = dr["start_date"].ToString(), ffin = dr["end_date"].ToString(), hora = dr["hour"].ToString(), minuto = dr["minute"].ToString(), periodicidad = dr["periodicity"].ToString(), textoemail = dr["rem_text"].ToString(), nextreminder = dr["next_exec_date"].ToString() });

                }


            }
            catch (Exception ex)
            {
                 return Content(ex.Message);
            }
            return Content("");
        }

        public ActionResult ModificarRecordatorio()
        {
            
            THCBSQL xTHCBSQL = new THCBSQL();
            
            var xREMINDERS = new REMINDERS.TWREMINDERS();
            var xREMINDERSDB = new REMINDERS.TWREMINDERSDB(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            var id_recordatorio = Request.Form["id_recordatorio"];
            var tipoDocumento = Request.Form["tdocumento"];
            var finicio = Request.Form["finicio"];
            var ffin = Request.Form["ffin"];
            var hora = Request.Form["hora"];
            var minuto = Request.Form["minuto"];
            var periodicidad = Request.Form["periodicidad"];
            var textoEmail = Request.Form["textoEmail"];
            var recordatorio = DateTime.Parse(Request.Form["recordatorio"]);
            
            xREMINDERS.SetPropData("id_reminder", id_recordatorio);

            xREMINDERS.SetPropData("id_doctype", tipoDocumento);

            xREMINDERS.SetPropData("id_usuario", "1");

            xREMINDERS.SetPropData("start_date", DateTime.Parse(finicio));

            xREMINDERS.SetPropData("end_date", DateTime.Parse(ffin));

            xREMINDERS.SetPropData("periodicity", periodicidad);

            xREMINDERS.SetPropData("next_exec_date", recordatorio);

            xREMINDERS.SetPropData("rem_text", textoEmail);

            xREMINDERS.SetPropData("user_cre", "1");

            xREMINDERS.SetPropData("date_cre", DateTime.Now);

            xREMINDERS.SetPropData("hour", Convert.ToInt32(hora));

            xREMINDERS.SetPropData("minute", Convert.ToInt32(minuto));

            xREMINDERS.SetPropData("busi_partner", "1");

            xTHCBSQL.ConnectionString = xREMINDERSDB.ConnectionString;

            xREMINDERSDB.DbCn = xTHCBSQL;
            xREMINDERSDB.DbCn.Conecta();
          
               SqlCommand cmd = new SqlCommand();

              try
              {
                
                  if (xREMINDERSDB.CreateUpdateCommandById(ref cmd, Int32.Parse(id_recordatorio), xREMINDERS))
                  {
                    xREMINDERSDB.DbCn.ExecProcedure(ref cmd);
                    
                      return Content("Se ha modificado el recordatorio");
                  }

              }
              catch (Exception ex)
              {
                  return Content(ex.Message);
              }

            return Content("");
        }


        [HttpPost]
        public ActionResult EliminarRecordatorio(int id_reminder)
        {
           
            var xREMINDERSDB = new REMINDERS.TWREMINDERSDB(ConfigurationManager.ConnectionStrings[0].ConnectionString);
      
            THCBSQL xTHCBSQL = new THCBSQL();

            xTHCBSQL.ConnectionString = xREMINDERSDB.ConnectionString;

            xREMINDERSDB.DbCn = xTHCBSQL;
            xREMINDERSDB.DbCn.Conecta();
            
            try
            {
                
                if (EliminarDocumentosRecordatorio(id_reminder))
                {
                
                    if (xREMINDERSDB.Delete(id_reminder))
                    {


                        return Content("Se ha eliminado el recordatorio");

                    }
                    
                }
                else
                {
                    return Content("No se guarda. " + xREMINDERSDB.LastError);
                }

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            finally
            {
                
            }

            return Content("");
        }
        private bool EliminarDocumentosRecordatorio(int id_reminder)
        {
            

            THCBSQL xTHCBSQL = new THCBSQL();

            TWREMINDERDOCSDB xWREMINDERDOCSDB = new TWREMINDERDOCSDB(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            TWREMINDERDOCS wREMINDERSDOCS = new TWREMINDERDOCS();
            SqlCommand cmd = new SqlCommand();

            xTHCBSQL.ConnectionString = xWREMINDERDOCSDB.ConnectionString;
            
            xWREMINDERDOCSDB.DbCn = xTHCBSQL;
            
            
            try{
               
                if(xWREMINDERDOCSDB.CreateDeleteCommandById(ref cmd,id_reminder))
                {
                    xWREMINDERDOCSDB.DbCn.ExecProcedure(ref cmd);
                  
                    return true;
                }
                
            }
            catch (Exception ex)
            {
               Response.Write("Error eliminando documentos. " + ex.Message);
               return false;
            }
          
            return false;
        }
    }
    
}