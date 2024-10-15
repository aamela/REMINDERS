using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;
using REMINDERS;
using AdvEvents;
using AdvEnums;
using THelpConnect;
using System.Web.UI.WebControls;

//****************************************************************************************************
//***** TWREMINDERS                                                                            *****
//****************************************************************************************************
namespace REMINDERS
{
    public class TWREMINDERS : INotifyPropertyChanged
    {
        #region 'Definición de delegados'
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void ExceptionHandler(object sender, LastErrorEventArgs e);
        public event ExceptionHandler OnException;
        public delegate void StatusChanged(object sender, DataStatusChange e);
        public event StatusChanged OnDataStatusChanged;
        #endregion
        #region 'Variables privadas de Objeto'
        private string is_busipartner = string.Empty;
        private DateTime id_dateame = Convert.ToDateTime("01/01/1800");
        private DateTime id_datecre = Convert.ToDateTime("01/01/1800");
        private DateTime id_enddate = Convert.ToDateTime("01/01/1800");
        private Int32 il_hour = -1;
        private string is_iddoctype = string.Empty;
        private Int32 il_idreminder = -1;
        private string is_idusuario = string.Empty;
        private string is_lastexec = string.Empty;
        private DateTime id_lastexecdate = Convert.ToDateTime("01/01/1800");
        private Int32 il_minute = -1;
        private DateTime id_nextexecdate = Convert.ToDateTime("01/01/1800");
        private string is_periodicity = string.Empty;
        private Int32 il_remevdays = -1;
        private string is_remtext = string.Empty;
        private DateTime id_startdate = Convert.ToDateTime("01/01/1800");
        private string is_transcd = string.Empty;
        private string is_userame = string.Empty;
        private string is_usercre = string.Empty;
        #endregion
        #region "Variables privadas de Clase"
        private string is_LastError = string.Empty;
        private RegStatus ii_Estado = RegStatus.Added;
        private string is_ConnectionString = string.Empty;
        private bool ib_Modified = false;
        private bool ib_DbLoading = false;
        #endregion
        #region "Public properties"
        [XmlElement("busi_partner")]
        public string busi_partner
        {
            get { return is_busipartner; }
            set
            {
                if (value != is_busipartner)
                {
                    is_busipartner = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("busi_partner");
                    }
                }
            }
        }
        [XmlElement("date_ame")]
        public DateTime date_ame
        {
            get { return id_dateame; }
            set
            {
                if (value != id_dateame)
                {
                    id_dateame = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("date_ame");
                    }
                }
            }
        }
        [XmlElement("date_cre")]
        public DateTime date_cre
        {
            get { return id_datecre; }
            set
            {
                if (value != id_datecre)
                {
                    id_datecre = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("date_cre");
                    }
                }
            }
        }
        [XmlElement("end_date")]
        public DateTime end_date
        {
            get { return id_enddate; }
            set
            {
                if (value != id_enddate)
                {
                    id_enddate = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("end_date");
                    }
                }
            }
        }
        [XmlElement("hour")]
        public Int32 hour
        {
            get { return il_hour; }
            set
            {
                if (value != il_hour)
                {
                    il_hour = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("hour");
                    }
                }
            }
        }
        [XmlElement("id_doctype")]
        public string id_doctype
        {
            get { return is_iddoctype; }
            set
            {
                if (value != is_iddoctype)
                {
                    is_iddoctype = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("id_doctype");
                    }
                }
            }
        }
        [XmlElement("id_reminder")]
        public Int32 id_reminder
        {
            get { return il_idreminder; }
            set
            {
                if (value != il_idreminder)
                {
                    il_idreminder = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("id_reminder");
                    }
                }
            }
        }
        [XmlElement("id_usuario")]
        public string id_usuario
        {
            get { return is_idusuario; }
            set
            {
                if (value != is_idusuario)
                {
                    is_idusuario = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("id_usuario");
                    }
                }
            }
        }
        [XmlElement("last_exec")]
        public string last_exec
        {
            get { return is_lastexec; }
            set
            {
                if (value != is_lastexec)
                {
                    is_lastexec = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("last_exec");
                    }
                }
            }
        }
        [XmlElement("last_exec_date")]
        public DateTime last_exec_date
        {
            get { return id_lastexecdate; }
            set
            {
                if (value != id_lastexecdate)
                {
                    id_lastexecdate = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("last_exec_date");
                    }
                }
            }
        }
        [XmlElement("minute")]
        public Int32 minute
        {
            get { return il_minute; }
            set
            {
                if (value != il_minute)
                {
                    il_minute = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("minute");
                    }
                }
            }
        }
        [XmlElement("next_exec_date")]
        public DateTime next_exec_date
        {
            get { return id_nextexecdate; }
            set
            {
                if (value != id_nextexecdate)
                {
                    id_nextexecdate = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("next_exec_date");
                    }
                }
            }
        }
        [XmlElement("periodicity")]
        public string periodicity
        {
            get { return is_periodicity; }
            set
            {
                if (value != is_periodicity)
                {
                    is_periodicity = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("periodicity");
                    }
                }
            }
        }
        [XmlElement("rem_ev_days")]
        public Int32 rem_ev_days
        {
            get { return il_remevdays; }
            set
            {
                if (value != il_remevdays)
                {
                    il_remevdays = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("rem_ev_days");
                    }
                }
            }
        }
        [XmlElement("rem_text")]
        public string rem_text
        {
            get { return is_remtext; }
            set
            {
                if (value != is_remtext)
                {
                    is_remtext = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("rem_text");
                    }
                }
            }
        }
        [XmlElement("start_date")]
        public DateTime start_date
        {
            get { return id_startdate; }
            set
            {
                if (value != id_startdate)
                {
                    id_startdate = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("start_date");
                    }
                }
            }
        }
        [XmlElement("trans_cd")]
        public string trans_cd
        {
            get { return is_transcd; }
            set
            {
                if (value != is_transcd)
                {
                    is_transcd = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("trans_cd");
                    }
                }
            }
        }
        [XmlElement("user_ame")]
        public string user_ame
        {
            get { return is_userame; }
            set
            {
                if (value != is_userame)
                {
                    is_userame = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("user_ame");
                    }
                }
            }
        }
        [XmlElement("user_cre")]
        public string user_cre
        {
            get { return is_usercre; }
            set
            {
                if (value != is_usercre)
                {
                    is_usercre = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("user_cre");
                    }
                }
            }
        }
        [XmlIgnoreAttribute]
        public string LastError
        {
            get
            {
                return is_LastError;
            }
        }

        [XmlIgnoreAttribute]
        public string ConnectionString
        {
            get { return is_ConnectionString; }
            set { is_ConnectionString = value; }
        }
        [XmlIgnoreAttribute]
        public RegStatus Estado
        {
            get { return ii_Estado; }
            set { ii_Estado = value; }
        }
        [XmlIgnoreAttribute]
        public bool Modified
        {
            get { return ib_Modified; }
        }
        [XmlIgnoreAttribute]
        public bool DbLoading
        {
            get { return ib_DbLoading; }
            set { ib_DbLoading = value; }
        }
        #endregion
        #region "Public Functions"
        public bool IsValid()
        {
            return true;
        }
        public void Initialize()
        {
            is_busipartner = string.Empty;
            id_dateame = Convert.ToDateTime("01/01/1800");
            id_datecre = Convert.ToDateTime("01/01/1800");
            id_enddate = Convert.ToDateTime("01/01/1800");
            il_hour = -1;
            is_iddoctype = string.Empty;
            il_idreminder = -1;
            is_idusuario = string.Empty;
            is_lastexec = string.Empty;
            id_lastexecdate = Convert.ToDateTime("01/01/1800");
            il_minute = -1;
            id_nextexecdate = Convert.ToDateTime("01/01/1800");
            is_periodicity = string.Empty;
            il_remevdays = -1;
            is_remtext = string.Empty;
            id_startdate = Convert.ToDateTime("01/01/1800");
            is_transcd = string.Empty;
            is_userame = string.Empty;
            is_usercre = string.Empty;
            ii_Estado = RegStatus.Added;
            ChangeStatus();
            ib_Modified = false;
        }
        public bool LoadData()
        {
            TWREMINDERSDB lo_WREMINDERS = null;
            bool lb_res = false;
            is_LastError = string.Empty;
            lo_WREMINDERS = new TWREMINDERSDB(is_ConnectionString);
            lo_WREMINDERS.OnException += new TWREMINDERSDB.ExceptionHandler(OnDataError);
            lb_res = lo_WREMINDERS.LoadData(this);
            ChangeStatus();
            lo_WREMINDERS.OnException -= OnDataError;
            lo_WREMINDERS = null;
            return lb_res;
        }
        public bool SaveData()
        {
            bool lb_res = false;
            TWREMINDERSDB lo_WREMINDERS = null;
            is_LastError = String.Empty;
            lb_res = IsValid();
            if (lb_res)
            {
                lo_WREMINDERS = new TWREMINDERSDB(is_ConnectionString);
                lo_WREMINDERS.OnException += new TWREMINDERSDB.ExceptionHandler(OnDataError);
                lb_res = lo_WREMINDERS.SaveData(this);
                ChangeStatus();
                lo_WREMINDERS.OnException -= OnDataError;
            }
            return lb_res;
        }
        public bool Delete()
        {
            bool lb_res = false;
            TWREMINDERSDB lo_WREMINDERS = null;
            ii_Estado = RegStatus.Deleted;
            lo_WREMINDERS = new TWREMINDERSDB(is_ConnectionString);
            lo_WREMINDERS.OnException += new TWREMINDERSDB.ExceptionHandler(OnDataError);
            lb_res = lo_WREMINDERS.Delete(this);
            lo_WREMINDERS.OnException -= OnDataError;
            ChangeStatus();
            lo_WREMINDERS = null;
            return lb_res;
        }
        #endregion
        #region "Component Model public functions"
        public bool SetPropData(string as_PropName, object as_Dato)
        {
            bool lb_res = false;
            PropertyInfo lo_Property = null;
            Type lo_Type = null;
            string ls_TipoNet = string.Empty;
            lo_Type = this.GetType();
            lo_Property = lo_Type.GetProperty(as_PropName);
            if (lo_Property != null)
            {
                try
                {
                    if (as_Dato != null)
                    {
                        lo_Property.SetValue(this, Convert.ChangeType(as_Dato, lo_Property.PropertyType, null), null);
                    }
                    else
                    {
                        lb_res = true;
                    }
                    lb_res = true;
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            return lb_res;
        }
        public object GetPropData(string as_PropName)
        {
            object lo_res = null;
            PropertyInfo lo_Property = null;
            Type lo_Type = null;
            string ls_TipoNet = string.Empty;
            lo_Type = this.GetType();
            lo_Property = lo_Type.GetProperty(as_PropName);
            if (lo_Property != null)
            {
                lo_Type = lo_Property.GetType();
                try
                {
                    lo_res = lo_Property.GetValue(this, null);
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            return lo_res;
        }
        public PropertyInfo[] GetPropertyInfo()
        {
            PropertyInfo[] lo_Properties = null;
            Type lo_Type = null;
            string ls_TipoNet = string.Empty;
            lo_Type = this.GetType();
            lo_Properties = lo_Type.GetProperties();
            return lo_Properties;
        }
        #endregion

        #region "Manejador de errores"
        private void HandleError(Exception ao_ex)
        {
            is_LastError = ao_ex.Message;
            if (OnException != null)
            {
                OnException(this, new LastErrorEventArgs(ao_ex));
            }
        }
        private void HandleError(string as_ErrText)
        {
            is_LastError = as_ErrText;
            if (OnException != null)
            {
                OnException(this, new LastErrorEventArgs(new Exception(as_ErrText)));
            }
        }
        private void HandleError(object sender, LastErrorEventArgs e)
        {
            is_LastError = e.LastError.Message;
            if (OnException != null)
            {
                OnException(this, e);
            }
        }
        private void OnDataError(object sender, LastErrorEventArgs e)
        {
            HandleError(sender, e);
        }
        #endregion
        #region "Cambio de estado del registro"
        private void ChangeStatus()
        {
            int ll_Status = 0;
            ib_Modified = true;
            switch (ii_Estado)
            {
                case RegStatus.Added:
                    ll_Status = 1;
                    break;
                case RegStatus.Deleted:
                    ll_Status = 3;
                    break;
                case RegStatus.Modified:
                    ll_Status = 2;
                    break;
                case RegStatus.Unchanged:
                    ib_Modified = false;
                    ll_Status = 4;
                    break;
            }
            if (OnDataStatusChanged != null)
            {
                OnDataStatusChanged(this, new DataStatusChange(ll_Status, ""));
            }
        }
        #endregion
        #region "Cambio de valor de propiedad"
        private void NotifyPropertyChanged(string as_PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(as_PropertyName));
        }
        #endregion
    }


    public class TWREMINDERSDB
    {
        #region 'Definición de delegados'
        public delegate void ExceptionHandler(object sender, LastErrorEventArgs e);
        public event ExceptionHandler OnException;
        #endregion
        #region "Constructores de la clase"
        
        #endregion
        #region 'Variables privadas de clase'
        private THCBSQL io_Cn = null;
        private string is_ConnectionString = string.Empty;
        private string is_LastError = string.Empty;
        #endregion
        #region "Propiedades publicas"
        public THCBSQL DbCn
        {
            get { return io_Cn; }
            set { io_Cn = value; }
        }
        public string ConnectionString
        {
            get { return is_ConnectionString; }
            set { is_ConnectionString = value; }
        }
        public string LastError
        {
            get { return is_LastError; }
        }
        #endregion
        #region "Private Functions"

        public TWREMINDERSDB(string as_ConnectionString)
        {
            is_ConnectionString = as_ConnectionString;
        }
        private bool LoadFromDB(string as_Consulta, TWREMINDERS ao_WREMINDERS)
        {
            bool lb_res = false;
            IDataReader lo_Reader = null;
            if (ao_WREMINDERS != null)
            {
                ao_WREMINDERS.Initialize();
                try
                {
                    lo_Reader = io_Cn.GetDataReader(as_Consulta, io_Cn.CommandTimeOut);
                    if (lo_Reader != null)
                    {
                        lb_res = GetData(lo_Reader, ao_WREMINDERS);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    if (lo_Reader != null)
                    {
                        lo_Reader.Close();
                        lo_Reader.Dispose();
                    }
                }
            }
            return lb_res;
        }

        public bool LoadFromDB(string as_Consulta, TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            IDataReader lo_Reader = null;
            if (ao_WREMINDERS != null)
            {
                ao_WREMINDERS.Initialize();
                try
                {
                    lo_Reader = ao_Cn.GetDataReader(as_Consulta, ao_Cn.CommandTimeOut);
                    if (lo_Reader != null)
                    {
                        lb_res = GetData(lo_Reader, ao_WREMINDERS);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    if (lo_Reader != null)
                    {
                        lo_Reader.Close();
                        lo_Reader.Dispose();
                    }
                }
            }
            return lb_res;
        }

        private bool LoadFromDB(string as_Consulta, TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            IDataReader lo_Reader = null;
            if (ao_WREMINDERS != null)
            {
                ao_WREMINDERS.Initialize();
                try
                {
                    lo_Reader = ao_Cn.GetDataReader(as_Consulta, ao_Cn.CommandTimeOut, al_Trans);
                    if (lo_Reader != null)
                    {
                        lb_res = GetData(lo_Reader, ao_WREMINDERS);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    if (lo_Reader != null)
                    {
                        lo_Reader.Close();
                        lo_Reader.Dispose();
                    }
                }
            }
            return lb_res;
        }

        private bool GetData(IDataReader ao_Reader, TWREMINDERS ao_WREMINDERS)
        {
            bool lb_res = false;
            List<string> lo_ColumnList = null;
            int ll_Ordinal = 0;
            lo_ColumnList = Enumerable.Range(0, ao_Reader.FieldCount).Select(ao_Reader.GetName).ToList();
            int ll_n = 0;
            if (!ao_Reader.IsClosed)
            {
                while (ao_Reader.Read())
                {
                    ll_n++;
                    ao_WREMINDERS.DbLoading = true;
                    foreach (string ls_Columna in lo_ColumnList)
                    {
                        ll_Ordinal = ao_Reader.GetOrdinal(ls_Columna);
                        try
                        {
                            if (!ao_Reader.IsDBNull(ll_Ordinal))
                            {
                                ao_WREMINDERS.SetPropData(ls_Columna, ao_Reader.GetValue(ll_Ordinal));
                            }
                        }
                        catch (Exception ex)
                        {
                            HandleError(ex);
                        }
                    }
                    ao_WREMINDERS.Estado = RegStatus.Unchanged;
                    ao_WREMINDERS.DbLoading = false;
                }
                if (ll_n > 0)
                {
                    lb_res = true;
                }
                else
                {
                    lb_res = false;
                }
            }
            lo_ColumnList.Clear();
            lo_ColumnList = null;
            return lb_res;
        }
        private bool SetData(System.Data.SqlClient.SqlCommand ao_cmd, TWREMINDERS ao_WREMINDERS)
        {
            bool lb_res = false;
            try
            {
                switch (ao_WREMINDERS.Estado)
                {
                    case RegStatus.Added:
                        if (ao_WREMINDERS.busi_partner.Length > 0) { ao_cmd.Parameters["@busi_partner"].Value = ao_WREMINDERS.busi_partner; } else { ao_cmd.Parameters["@busi_partner"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.date_ame != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@date_ame"].Value = ao_WREMINDERS.date_ame; } else { ao_cmd.Parameters["@date_ame"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.date_cre != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@date_cre"].Value = ao_WREMINDERS.date_cre; } else { ao_cmd.Parameters["@date_cre"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.end_date != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@end_date"].Value = ao_WREMINDERS.end_date; } else { ao_cmd.Parameters["@end_date"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.hour > -1) { ao_cmd.Parameters["@hour"].Value = ao_WREMINDERS.hour; } else { ao_cmd.Parameters["@hour"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.id_doctype.Length > 0) { ao_cmd.Parameters["@id_doctype"].Value = ao_WREMINDERS.id_doctype; } else { ao_cmd.Parameters["@id_doctype"].Value = string.Empty; };

                        if (ao_WREMINDERS.id_usuario.Length > 0) { ao_cmd.Parameters["@id_usuario"].Value = ao_WREMINDERS.id_usuario; } else { ao_cmd.Parameters["@id_usuario"].Value = string.Empty; };

                        if (ao_WREMINDERS.last_exec.Length > 0) { ao_cmd.Parameters["@last_exec"].Value = ao_WREMINDERS.last_exec; } else { ao_cmd.Parameters["@last_exec"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.last_exec_date != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@last_exec_date"].Value = ao_WREMINDERS.last_exec_date; } else { ao_cmd.Parameters["@last_exec_date"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.minute > -1) { ao_cmd.Parameters["@minute"].Value = ao_WREMINDERS.minute; } else { ao_cmd.Parameters["@minute"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.next_exec_date != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@next_exec_date"].Value = ao_WREMINDERS.next_exec_date; } else { ao_cmd.Parameters["@next_exec_date"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.periodicity.Length > 0) { ao_cmd.Parameters["@periodicity"].Value = ao_WREMINDERS.periodicity; } else { ao_cmd.Parameters["@periodicity"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.rem_ev_days > -1) { ao_cmd.Parameters["@rem_ev_days"].Value = ao_WREMINDERS.rem_ev_days; } else { ao_cmd.Parameters["@rem_ev_days"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.rem_text.Length > 0) { ao_cmd.Parameters["@rem_text"].Value = ao_WREMINDERS.rem_text; } else { ao_cmd.Parameters["@rem_text"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.start_date != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@start_date"].Value = ao_WREMINDERS.start_date; } else { ao_cmd.Parameters["@start_date"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.trans_cd.Length > 0) { ao_cmd.Parameters["@trans_cd"].Value = ao_WREMINDERS.trans_cd; } else { ao_cmd.Parameters["@trans_cd"].Value = string.Empty; };

                        if (ao_WREMINDERS.user_ame.Length > 0) { ao_cmd.Parameters["@user_ame"].Value = ao_WREMINDERS.user_ame; } else { ao_cmd.Parameters["@user_ame"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.user_cre.Length > 0) { ao_cmd.Parameters["@user_cre"].Value = ao_WREMINDERS.user_cre; } else { ao_cmd.Parameters["@user_cre"].Value = DBNull.Value; };

                        lb_res = true;
                        break;
                    case RegStatus.Deleted:
                        ao_cmd.Parameters["@id_reminder"].Value = ao_WREMINDERS.id_reminder;

                        lb_res = true;
                        break;
                    case RegStatus.Modified:
                        ao_cmd.Parameters["@id_reminder"].Value = ao_WREMINDERS.id_reminder;

                        if (ao_WREMINDERS.busi_partner.Length > 0) { ao_cmd.Parameters["@busi_partner"].Value = ao_WREMINDERS.busi_partner; } else { ao_cmd.Parameters["@busi_partner"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.date_ame != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@date_ame"].Value = ao_WREMINDERS.date_ame; } else { ao_cmd.Parameters["@date_ame"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.date_cre != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@date_cre"].Value = ao_WREMINDERS.date_cre; } else { ao_cmd.Parameters["@date_cre"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.end_date != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@end_date"].Value = ao_WREMINDERS.end_date; } else { ao_cmd.Parameters["@end_date"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.hour > -1) { ao_cmd.Parameters["@hour"].Value = ao_WREMINDERS.hour; } else { ao_cmd.Parameters["@hour"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.id_doctype.Length > 0) { ao_cmd.Parameters["@id_doctype"].Value = ao_WREMINDERS.id_doctype; } else { ao_cmd.Parameters["@id_doctype"].Value = string.Empty; };

                        if (ao_WREMINDERS.id_usuario.Length > 0) { ao_cmd.Parameters["@id_usuario"].Value = ao_WREMINDERS.id_usuario; } else { ao_cmd.Parameters["@id_usuario"].Value = string.Empty; };

                        if (ao_WREMINDERS.last_exec.Length > 0) { ao_cmd.Parameters["@last_exec"].Value = ao_WREMINDERS.last_exec; } else { ao_cmd.Parameters["@last_exec"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.last_exec_date != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@last_exec_date"].Value = ao_WREMINDERS.last_exec_date; } else { ao_cmd.Parameters["@last_exec_date"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.minute > -1) { ao_cmd.Parameters["@minute"].Value = ao_WREMINDERS.minute; } else { ao_cmd.Parameters["@minute"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.next_exec_date != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@next_exec_date"].Value = ao_WREMINDERS.next_exec_date; } else { ao_cmd.Parameters["@next_exec_date"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.periodicity.Length > 0) { ao_cmd.Parameters["@periodicity"].Value = ao_WREMINDERS.periodicity; } else { ao_cmd.Parameters["@periodicity"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.rem_ev_days > -1) { ao_cmd.Parameters["@rem_ev_days"].Value = ao_WREMINDERS.rem_ev_days; } else { ao_cmd.Parameters["@rem_ev_days"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.rem_text.Length > 0) { ao_cmd.Parameters["@rem_text"].Value = ao_WREMINDERS.rem_text; } else { ao_cmd.Parameters["@rem_text"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.start_date != Convert.ToDateTime("01/01/1800")) { ao_cmd.Parameters["@start_date"].Value = ao_WREMINDERS.start_date; } else { ao_cmd.Parameters["@start_date"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.trans_cd.Length > 0) { ao_cmd.Parameters["@trans_cd"].Value = ao_WREMINDERS.trans_cd; } else { ao_cmd.Parameters["@trans_cd"].Value = string.Empty; };

                        if (ao_WREMINDERS.user_ame.Length > 0) { ao_cmd.Parameters["@user_ame"].Value = ao_WREMINDERS.user_ame; } else { ao_cmd.Parameters["@user_ame"].Value = DBNull.Value; };

                        if (ao_WREMINDERS.user_cre.Length > 0) { ao_cmd.Parameters["@user_cre"].Value = ao_WREMINDERS.user_cre; } else { ao_cmd.Parameters["@user_cre"].Value = DBNull.Value; };

                        lb_res = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return lb_res;
        }
        private bool SetDataDel(System.Data.SqlClient.SqlCommand ao_cmd, Int32 al_idreminder)
        {
            bool lb_res = false;
            try
            {
                ao_cmd.Parameters["@id_reminder"].Value = al_idreminder;

                lb_res = true;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return lb_res;
        }
        public bool InsertData(TWREMINDERS ao_WREMINDERS)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateInsertCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    if (io_Cn.ActualizaDB(ref lo_cmd))
                    {
                        ao_WREMINDERS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + io_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = "No se ha actualizado el registro." + io_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        public bool InsertData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn)
        {
            
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateInsertCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    ao_Cn.ExecProcedure(ref lo_cmd);
                    //lo_cmd.Parameters['rei']
                    //      ao
                    if (ao_Cn.ActualizaDB(ref lo_cmd))
                    {
                        ao_WREMINDERS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        public bool InsertData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateInsertCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd, al_Trans))
                    {
                        ao_WREMINDERS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool UpdateData(TWREMINDERS ao_WREMINDERS)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateUpdateCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    if (io_Cn.ActualizaDB(ref lo_cmd))
                    {
                        ao_WREMINDERS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + io_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = io_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool UpdateData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateUpdateCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd))
                    {
                        ao_WREMINDERS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool UpdateData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateUpdateCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd, al_Trans))
                    {
                        ao_WREMINDERS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool DeleteData(TWREMINDERS ao_WREMINDERS)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateDeleteCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    if (io_Cn.ActualizaDB(ref lo_cmd))
                    {
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No ha sido posible borrar el registro." + io_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = io_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }

        public bool DeleteData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateDeleteCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd))
                    {
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No ha sido posible borrar el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }

        private bool DeleteData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateDeleteCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd, al_Trans))
                    {
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No ha sido posible borrar el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }

        public bool DeleteData(Int32 al_idreminder)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateDeleteCommand(ref lo_cmd))
            {
                if (SetDataDel(lo_cmd, al_idreminder))
                {
                    if (io_Cn.ActualizaDB(ref lo_cmd))
                    {
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No ha sido posible borrar el registro." + io_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = io_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }


        private bool CreateDeleteCommand(ref System.Data.SqlClient.SqlCommand ao_cmd)
        {
            bool lb_res = true;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_reminder";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            ao_cmd.CommandText = "DELETE FROM WREMINDERS WHERE id_reminder = @id_reminder";
            return lb_res;
        }

        private bool CreateInsertCommand(ref System.Data.SqlClient.SqlCommand ao_cmd)
        {
            bool lb_res = true;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@busi_partner";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 20;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@date_ame";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@date_cre";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@end_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@hour";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_doctype";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Output;
            lo_param.ParameterName = "@id_reminder";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_usuario";
            lo_param.SqlDbType = System.Data.SqlDbType.NVarChar;
            lo_param.Size = 128;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@last_exec";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@last_exec_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@minute";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@next_exec_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@periodicity";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@rem_ev_days";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@rem_text";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 2147483647;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@start_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@trans_cd";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@user_ame";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@user_cre";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);

            ao_cmd.CommandText = "INSERT INTO WREMINDERS (busi_partner,date_ame,date_cre,end_date,hour,id_doctype,id_usuario,last_exec,last_exec_date,minute,next_exec_date,periodicity,rem_ev_days,rem_text,start_date,trans_cd,user_ame,user_cre) VALUES (@busi_partner,@date_ame,@date_cre,@end_date,@hour,@id_doctype,@id_usuario,@last_exec,@last_exec_date,@minute,@next_exec_date,@periodicity,@rem_ev_days,@rem_text,@start_date,@trans_cd,@user_ame,@user_cre)";
            return lb_res;
        }

        public bool CreateInsertCommandByReminder(ref System.Data.SqlClient.SqlCommand ao_cmd, TWREMINDERS reminder)
        {
            bool lb_res = true;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
            /*lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@busi_partner";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 20;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@date_ame";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@date_cre";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@end_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@hour";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_doctype";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Output;
            lo_param.ParameterName = "@id_reminder";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_usuario";
            lo_param.SqlDbType = System.Data.SqlDbType.NVarChar;
            lo_param.Size = 128;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@last_exec";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@last_exec_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@minute";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@next_exec_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@periodicity";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@rem_ev_days";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@rem_text";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 2147483647;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@start_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@trans_cd";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@user_ame";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@user_cre";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);*/

            ao_cmd.CommandText = "INSERT INTO WREMINDERS (busi_partner,date_ame,date_cre,end_date,hour,id_doctype,id_usuario,last_exec,last_exec_date,minute,next_exec_date,periodicity,rem_ev_days,rem_text,start_date,trans_cd,user_ame,user_cre) VALUES ('" + reminder.busi_partner + "', '" + reminder.date_ame + "', '" + reminder.date_cre + "', '" + reminder.end_date + "' , " + reminder.hour + " , '" + reminder.id_doctype + "' , '" + reminder.id_usuario + "' , '" + reminder.last_exec + "' , '" + reminder.last_exec_date + "' , " + reminder.minute + " , '" + reminder.next_exec_date + "' , '" + reminder.periodicity + "' , " + reminder.rem_ev_days + " , '" + reminder.rem_text + "' ,'" + reminder.start_date + "' , '" + reminder.trans_cd + "' , '" + reminder.user_ame + "' , '" + reminder.user_cre + "')" ;
            return lb_res;
           // return ao_cmd.CommandText;
        }

        private bool CreateUpdateCommand(ref System.Data.SqlClient.SqlCommand ao_cmd)
        {
            bool lb_res = true;
            string ls_values = string.Empty;
            string ls_campos = string.Empty;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@busi_partner";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 20;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@date_ame";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@date_cre";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@end_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@hour";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_doctype";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Output;
            lo_param.ParameterName = "@id_reminder";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_usuario";
            lo_param.SqlDbType = System.Data.SqlDbType.NVarChar;
            lo_param.Size = 128;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@last_exec";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@last_exec_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@minute";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@next_exec_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@periodicity";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@rem_ev_days";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@rem_text";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 2147483647;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@start_date";
            lo_param.SqlDbType = System.Data.SqlDbType.DateTime;
            lo_param.Size = 8;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@trans_cd";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@user_ame";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@user_cre";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 50;
            ao_cmd.Parameters.Add(lo_param);
            ao_cmd.CommandText = "UPDATE WREMINDERS SET busi_partner = @busi_partner , date_ame = @date_ame , date_cre = @date_cre , end_date = @end_date , hour = @hour , id_doctype = @id_doctype , id_usuario = @id_usuario , last_exec = @last_exec , last_exec_date = @last_exec_date , minute = @minute , next_exec_date = @next_exec_date , periodicity = @periodicity , rem_ev_days = @rem_ev_days , rem_text = @rem_text , start_date = @start_date , trans_cd = @trans_cd , user_ame = @user_ame , user_cre = @user_cre WHERE id_reminder = @id_reminder";

            return lb_res;
        }

           public bool CreateUpdateCommandById(ref System.Data.SqlClient.SqlCommand ao_cmd, int id_recordatorio, TWREMINDERS reminder)
        {

            bool lb_res = true;
            string ls_values = string.Empty;
            string ls_campos = string.Empty;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;

            ao_cmd.CommandText = "UPDATE WREMINDERS SET busi_partner = '" + reminder.busi_partner + "', date_cre = '" + reminder.date_cre + "', date_ame = '" + reminder.date_ame + "', end_date = '" + reminder.end_date + "' , hour = '" + reminder.hour + "' , id_doctype = '" + reminder.id_doctype + "' , id_usuario = '" + reminder.id_usuario + "' , last_exec = '" + reminder.last_exec + "' , last_exec_date = '" + reminder.last_exec_date + "' , minute = '" + reminder.minute + "' , next_exec_date = '" + reminder.next_exec_date + "' , periodicity = '" + reminder.periodicity + "' , rem_ev_days = '" + reminder.rem_ev_days + "' , rem_text ='" + reminder.rem_text + "' , start_date = '" + reminder.start_date + "' , trans_cd = '" + reminder.trans_cd + "' , user_ame = '" + reminder.user_ame + "' , user_cre = '" + reminder.user_cre + "' WHERE id_reminder = " + id_recordatorio;
            //ao_cmd.ExecuteNonQuery();
            return lb_res;
        }
        #endregion
        #region "Public Functions"
        public bool LoadData(TWREMINDERS ao_WREMINDERS)
        {
            string ls_Consulta = string.Empty;
            bool lb_res = false;
            is_LastError = string.Empty;
            lb_res = ConnectToDb();
            if (lb_res)
            {
                ls_Consulta = "SELECT busi_partner,date_ame,date_cre,end_date,hour,id_doctype,id_reminder,id_usuario,last_exec,last_exec_date,minute,next_exec_date,periodicity,rem_ev_days,rem_text,start_date,trans_cd,user_ame,user_cre FROM WREMINDERS WHERE id_reminder = " + ao_WREMINDERS.id_reminder + "";
                lb_res = LoadFromDB(ls_Consulta, ao_WREMINDERS);
            }
            DisconnectDb();
            return lb_res;
        }
        public bool LoadData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn)
        {
            string ls_Consulta = string.Empty;
            bool lb_res = false;
            is_LastError = string.Empty;
            ls_Consulta = "SELECT busi_partner,date_ame,date_cre,end_date,hour,id_doctype,id_reminder,id_usuario,last_exec,last_exec_date,minute,next_exec_date,periodicity,rem_ev_days,rem_text,start_date,trans_cd,user_ame,user_cre FROM WREMINDERS WHERE id_reminder = " + ao_WREMINDERS.id_reminder + "";
            lb_res = LoadFromDB(ls_Consulta, ao_WREMINDERS, ao_Cn);
            return lb_res;
        }
        public bool SaveData(TWREMINDERS ao_WREMINDERS)
        {
            bool lb_res = false;
            is_LastError = String.Empty;
            lb_res = ConnectToDb();
            if (lb_res)
            {
                try
                {
                    switch (ao_WREMINDERS.Estado)
                    {
                        case RegStatus.Added:
                            lb_res = InsertData(ao_WREMINDERS);
                            break;
                        case RegStatus.Deleted:
                            lb_res = DeleteData(ao_WREMINDERS);
                            break;
                        case RegStatus.Modified:
                            lb_res = UpdateData(ao_WREMINDERS);
                            break;
                        case RegStatus.Unchanged:
                            lb_res = true;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    DisconnectDb();
                }
            }
            return lb_res;
        }
        public bool SaveData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            is_LastError = String.Empty;
            try
            {
                
                switch (ao_WREMINDERS.Estado)
                {
                    case RegStatus.Added:
                        lb_res = InsertData(ao_WREMINDERS, ao_Cn);
                        break;
                    case RegStatus.Deleted:
                        lb_res = DeleteData(ao_WREMINDERS, ao_Cn);
                        break;
                    case RegStatus.Modified:
                        lb_res = UpdateData(ao_WREMINDERS, ao_Cn);
                        break;
                    case RegStatus.Unchanged:
                        lb_res = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return lb_res;
        }
        public bool SaveData(TWREMINDERS ao_WREMINDERS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            is_LastError = String.Empty;
            try
            {
                switch (ao_WREMINDERS.Estado)
                {
                    case RegStatus.Added:
                        lb_res = InsertData(ao_WREMINDERS, ao_Cn, al_Trans);
                        break;
                    case RegStatus.Deleted:
                        lb_res = DeleteData(ao_WREMINDERS, ao_Cn, al_Trans);
                        break;
                    case RegStatus.Modified:
                        lb_res = UpdateData(ao_WREMINDERS, ao_Cn, al_Trans);
                        break;
                    case RegStatus.Unchanged:
                        lb_res = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return lb_res;
        }
        public bool Delete(TWREMINDERS ao_WREMINDERS)
        {
            ao_WREMINDERS.Estado = RegStatus.Deleted;
            return SaveData(ao_WREMINDERS);
        }
        public bool Delete(Int32 al_idreminder)
        {
            return DeleteData(al_idreminder);
        }
        #endregion
        #region "Extended public functions"
        public bool ConnectToDb()
        {
            bool lb_res = false;
            if (is_ConnectionString.Length > 0)
            {
                try
                {
                    if (io_Cn != null)
                    {
                        io_Cn.OnException -= ConnectionException;
                        io_Cn.Desconecta();
                        io_Cn = null;
                    }
                    io_Cn = new THCBSQL();
                    io_Cn.ConnectionTimeOut = 60;
                    io_Cn.ConnectionString = is_ConnectionString;
                    io_Cn.OnException += new THCB.ExceptionHandler(ConnectionException);
                    if (io_Cn.Conecta())
                    {
                        lb_res = true;
                    }
                    else
                    {
                        HandleError(io_Cn.LastError);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                    if (io_Cn != null)
                    {
                        io_Cn.Desconecta();
                        io_Cn.OnException -= ConnectionException;
                        io_Cn = null;
                    }
                }
            }
            else
            {
                HandleError("No se ha establecido la cadena de conexión.");
            }
            return lb_res;
        }
        public bool DisconnectDb()
        {
            bool lb_res = false;
            if (io_Cn != null)
            {
                try
                {
                    io_Cn.Desconecta();
                    io_Cn.OnException -= ConnectionException;
                    io_Cn = null;
                    lb_res = true;
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            return lb_res;
        }
        #endregion
        #region "Manejador de errores"
        private void HandleError(Exception ao_ex)
        {
            is_LastError = ao_ex.Message;
            if (OnException != null)
            {
                OnException(this, new LastErrorEventArgs(ao_ex));
            }
        }
        private void HandleError(string as_ErrText)
        {
            is_LastError = as_ErrText;
            if (OnException != null)
            {
                OnException(this, new LastErrorEventArgs(new Exception(as_ErrText)));
            }
        }
        private void ConnectionException(object sender, LastErrorEventArgs e)
        {
            HandleError(e.LastError);
        }
        #endregion
    }

    //****************************************************************************************************
    //***** TWREMINDERDOCS                                                                      *****
    //****************************************************************************************************
    public class TWREMINDERDOCS : INotifyPropertyChanged
    {
        #region 'Definición de delegados'
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void ExceptionHandler(object sender, LastErrorEventArgs e);
        public event ExceptionHandler OnException;
        public delegate void StatusChanged(object sender, DataStatusChange e);
        public event StatusChanged OnDataStatusChanged;
        #endregion
        #region 'Variables privadas de Objeto'
        private Byte[] ia_FileData = null;
        private Guid ig_FileGuid = Guid.Empty;
        private string is_FileName = string.Empty;
        private Int32 il_idreminder = -1;
        #endregion
        #region "Variables privadas de Clase"
        private string is_LastError = string.Empty;
        private RegStatus ii_Estado = RegStatus.Added;
        private string is_ConnectionString = string.Empty;
        private bool ib_Modified = false;
        private bool ib_DbLoading = false;
        #endregion
        #region "Public properties"
        [XmlElement("FileData")]
        public Byte[] FileData
        {
            get { return ia_FileData; }
            set
            {
                if (value != ia_FileData)
                {
                    ia_FileData = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("FileData");
                    }
                }
            }
        }
        [XmlElement("FileGuid")]
        public Guid FileGuid
        {
            get { return ig_FileGuid; }
            set
            {
                if (value != ig_FileGuid)
                {
                    ig_FileGuid = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("FileGuid");
                    }
                }
            }
        }
        [XmlElement("FileName")]
        public string FileName
        {
            get { return is_FileName; }
            set
            {
                if (value != is_FileName)
                {
                    is_FileName = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("FileName");
                    }
                }
            }
        }
        [XmlElement("id_reminder")]
        public Int32 id_reminder
        {
            get { return il_idreminder; }
            set
            {
                if (value != il_idreminder)
                {
                    il_idreminder = value;
                    if (ii_Estado == RegStatus.Unchanged)
                    {
                        ii_Estado = RegStatus.Modified;
                    }
                    if (!ib_DbLoading)
                    {
                        ChangeStatus();
                        NotifyPropertyChanged("id_reminder");
                    }
                }
            }
        }
        [XmlIgnoreAttribute]
        public string LastError
        {
            get
            {
                return is_LastError;
            }
        }

        [XmlIgnoreAttribute]
        public string ConnectionString
        {
            get { return is_ConnectionString; }
            set { is_ConnectionString = value; }
        }
        [XmlIgnoreAttribute]
        public RegStatus Estado
        {
            get { return ii_Estado; }
            set { ii_Estado = value; }
        }
        [XmlIgnoreAttribute]
        public bool Modified
        {
            get { return ib_Modified; }
        }
        [XmlIgnoreAttribute]
        public bool DbLoading
        {
            get { return ib_DbLoading; }
            set { ib_DbLoading = value; }
        }
        #endregion
        #region "Public Functions"
        public bool IsValid()
        {
            return true;
        }
        public void Initialize()
        {
            ia_FileData = null;
            ig_FileGuid = Guid.Empty;
            is_FileName = string.Empty;
            il_idreminder = -1;
            ii_Estado = RegStatus.Added;
            ChangeStatus();
            ib_Modified = false;
        }
        public bool LoadData()
        {
            TWREMINDERDOCSDB lo_WREMINDERDOCS = null;
            bool lb_res = false;
            is_LastError = string.Empty;
            lo_WREMINDERDOCS = new TWREMINDERDOCSDB(is_ConnectionString);
            lo_WREMINDERDOCS.OnException += new TWREMINDERDOCSDB.ExceptionHandler(OnDataError);
            lb_res = lo_WREMINDERDOCS.LoadData(this);
            ChangeStatus();
            lo_WREMINDERDOCS.OnException -= OnDataError;
            lo_WREMINDERDOCS = null;
            return lb_res;
        }
        public bool SaveData()
        {
            bool lb_res = false;
            TWREMINDERDOCSDB lo_WREMINDERDOCS = null;
            is_LastError = String.Empty;
            lb_res = IsValid();
            if (lb_res)
            {
                lo_WREMINDERDOCS = new TWREMINDERDOCSDB(is_ConnectionString);
                lo_WREMINDERDOCS.OnException += new TWREMINDERDOCSDB.ExceptionHandler(OnDataError);
                lb_res = lo_WREMINDERDOCS.SaveData(this);
                ChangeStatus();
                lo_WREMINDERDOCS.OnException -= OnDataError;
            }
            return lb_res;
        }
        public bool Delete()
        {
            bool lb_res = false;
            TWREMINDERDOCSDB lo_WREMINDERDOCS = null;
            ii_Estado = RegStatus.Deleted;
            lo_WREMINDERDOCS = new TWREMINDERDOCSDB(is_ConnectionString);
            lo_WREMINDERDOCS.OnException += new TWREMINDERDOCSDB.ExceptionHandler(OnDataError);
            lb_res = lo_WREMINDERDOCS.Delete(this);
            lo_WREMINDERDOCS.OnException -= OnDataError;
            ChangeStatus();
            lo_WREMINDERDOCS = null;
            return lb_res;
        }
        #endregion
        #region "Component Model public functions"
        public bool SetPropData(string as_PropName, object as_Dato)
        {
            bool lb_res = false;
            PropertyInfo lo_Property = null;
            Type lo_Type = null;
            string ls_TipoNet = string.Empty;
            lo_Type = this.GetType();
            lo_Property = lo_Type.GetProperty(as_PropName);
            if (lo_Property != null)
            {
                try
                {
                    if (as_Dato != null)
                    {
                        lo_Property.SetValue(this, Convert.ChangeType(as_Dato, lo_Property.PropertyType, null), null);
                    }
                    else
                    {
                        lb_res = true;
                    }
                    lb_res = true;
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            return lb_res;
        }
        public object GetPropData(string as_PropName)
        {
            object lo_res = null;
            PropertyInfo lo_Property = null;
            Type lo_Type = null;
            string ls_TipoNet = string.Empty;
            lo_Type = this.GetType();
            lo_Property = lo_Type.GetProperty(as_PropName);
            if (lo_Property != null)
            {
                lo_Type = lo_Property.GetType();
                try
                {
                    lo_res = lo_Property.GetValue(this, null);
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            return lo_res;
        }
        public PropertyInfo[] GetPropertyInfo()
        {
            PropertyInfo[] lo_Properties = null;
            Type lo_Type = null;
            string ls_TipoNet = string.Empty;
            lo_Type = this.GetType();
            lo_Properties = lo_Type.GetProperties();
            return lo_Properties;
        }
        #endregion

        #region "Manejador de errores"
        private void HandleError(Exception ao_ex)
        {
            is_LastError = ao_ex.Message;
            if (OnException != null)
            {
                OnException(this, new LastErrorEventArgs(ao_ex));
            }
        }
        private void HandleError(string as_ErrText)
        {
            is_LastError = as_ErrText;
            if (OnException != null)
            {
                OnException(this, new LastErrorEventArgs(new Exception(as_ErrText)));
            }
        }
        private void HandleError(object sender, LastErrorEventArgs e)
        {
            is_LastError = e.LastError.Message;
            if (OnException != null)
            {
                OnException(this, e);
            }
        }
        private void OnDataError(object sender, LastErrorEventArgs e)
        {
            HandleError(sender, e);
        }
        #endregion
        #region "Cambio de estado del registro"
        private void ChangeStatus()
        {
            int ll_Status = 0;
            ib_Modified = true;
            switch (ii_Estado)
            {
                case RegStatus.Added:
                    ll_Status = 1;
                    break;
                case RegStatus.Deleted:
                    ll_Status = 3;
                    break;
                case RegStatus.Modified:
                    ll_Status = 2;
                    break;
                case RegStatus.Unchanged:
                    ib_Modified = false;
                    ll_Status = 4;
                    break;
            }
            if (OnDataStatusChanged != null)
            {
                OnDataStatusChanged(this, new DataStatusChange(ll_Status, ""));
            }
        }
        #endregion
        #region "Cambio de valor de propiedad"
        private void NotifyPropertyChanged(string as_PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(as_PropertyName));
        }
        #endregion
    }


    public class TWREMINDERDOCSDB
    {
        #region 'Definición de delegados'
        public delegate void ExceptionHandler(object sender, LastErrorEventArgs e);
        public event ExceptionHandler OnException;
        #endregion
        #region "Constructores de la clase"
        public TWREMINDERDOCSDB(string as_ConnectionString)
        {
            is_ConnectionString = as_ConnectionString;
        }
        #endregion
        #region 'Variables privadas de clase'
        private THCBSQL io_Cn = null;
        private string is_ConnectionString = string.Empty;
        private string is_LastError = string.Empty;
        #endregion
        #region "Propiedades publicas"
        public THCBSQL DbCn
        {
            get { return io_Cn; }
            set { io_Cn = value; }
        }
        public string ConnectionString
        {
            get { return is_ConnectionString; }
            set { is_ConnectionString = value; }
        }
        public string LastError
        {
            get { return is_LastError; }
        }
        #endregion
        #region "Private Functions"
        private bool LoadFromDB(string as_Consulta, TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            bool lb_res = false;
            IDataReader lo_Reader = null;
            if (ao_WREMINDERDOCS != null)
            {
                ao_WREMINDERDOCS.Initialize();
                try
                {
                    lo_Reader = io_Cn.GetDataReader(as_Consulta, io_Cn.CommandTimeOut);
                    if (lo_Reader != null)
                    {
                        lb_res = GetData(lo_Reader, ao_WREMINDERDOCS);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    if (lo_Reader != null)
                    {
                        lo_Reader.Close();
                        lo_Reader.Dispose();
                    }
                }
            }
            return lb_res;
        }

        private bool LoadFromDB(string as_Consulta, TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            IDataReader lo_Reader = null;
            if (ao_WREMINDERDOCS != null)
            {
                ao_WREMINDERDOCS.Initialize();
                try
                {
                    lo_Reader = ao_Cn.GetDataReader(as_Consulta, ao_Cn.CommandTimeOut);
                    if (lo_Reader != null)
                    {
                        lb_res = GetData(lo_Reader, ao_WREMINDERDOCS);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    if (lo_Reader != null)
                    {
                        lo_Reader.Close();
                        lo_Reader.Dispose();
                    }
                }
            }
            return lb_res;
        }

        private bool LoadFromDB(string as_Consulta, TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            IDataReader lo_Reader = null;
            if (ao_WREMINDERDOCS != null)
            {
                ao_WREMINDERDOCS.Initialize();
                try
                {
                    lo_Reader = ao_Cn.GetDataReader(as_Consulta, ao_Cn.CommandTimeOut, al_Trans);
                    if (lo_Reader != null)
                    {
                        lb_res = GetData(lo_Reader, ao_WREMINDERDOCS);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    if (lo_Reader != null)
                    {
                        lo_Reader.Close();
                        lo_Reader.Dispose();
                    }
                }
            }
            return lb_res;
        }

        private bool GetData(IDataReader ao_Reader, TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            bool lb_res = false;
            List<string> lo_ColumnList = null;
            int ll_Ordinal = 0;
            lo_ColumnList = Enumerable.Range(0, ao_Reader.FieldCount).Select(ao_Reader.GetName).ToList();
            int ll_n = 0;
            if (!ao_Reader.IsClosed)
            {
                while (ao_Reader.Read())
                {
                    ll_n++;
                    ao_WREMINDERDOCS.DbLoading = true;
                    foreach (string ls_Columna in lo_ColumnList)
                    {
                        ll_Ordinal = ao_Reader.GetOrdinal(ls_Columna);
                        try
                        {
                            if (!ao_Reader.IsDBNull(ll_Ordinal))
                            {
                                ao_WREMINDERDOCS.SetPropData(ls_Columna, ao_Reader.GetValue(ll_Ordinal));
                            }
                        }
                        catch (Exception ex)
                        {
                            HandleError(ex);
                        }
                    }
                    ao_WREMINDERDOCS.Estado = RegStatus.Unchanged;
                    ao_WREMINDERDOCS.DbLoading = false;
                }
                if (ll_n > 0)
                {
                    lb_res = true;
                }
                else
                {
                    lb_res = false;
                }
            }
            lo_ColumnList.Clear();
            lo_ColumnList = null;
            return lb_res;
        }
        private bool SetData(System.Data.SqlClient.SqlCommand ao_cmd, TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            bool lb_res = false;
            try
            {
                switch (ao_WREMINDERDOCS.Estado)
                {
                    case RegStatus.Added:
                        if (ao_WREMINDERDOCS.FileData.Length > 0) { ao_cmd.Parameters["@FileData"].Value = ao_WREMINDERDOCS.FileData; } else { ao_cmd.Parameters["@FileData"].Value = DBNull.Value; };

                        ao_cmd.Parameters["@FileGuid"].Value = ao_WREMINDERDOCS.FileGuid; ;

                        if (ao_WREMINDERDOCS.FileName.Length > 0) { ao_cmd.Parameters["@FileName"].Value = ao_WREMINDERDOCS.FileName; } else { ao_cmd.Parameters["@FileName"].Value = string.Empty; };

                        if (ao_WREMINDERDOCS.id_reminder > -1) { ao_cmd.Parameters["@id_reminder"].Value = ao_WREMINDERDOCS.id_reminder; } else { ao_cmd.Parameters["@id_reminder"].Value = DBNull.Value; };

                        lb_res = true;
                        break;
                    case RegStatus.Deleted:
                        ao_cmd.Parameters["@FileGuid"].Value = ao_WREMINDERDOCS.FileGuid;

                        lb_res = true;
                        break;
                    case RegStatus.Modified:
                        ao_cmd.Parameters["@FileGuid"].Value = ao_WREMINDERDOCS.FileGuid;

                        if (ao_WREMINDERDOCS.FileData.Length > 0) { ao_cmd.Parameters["@FileData"].Value = ao_WREMINDERDOCS.FileData; } else { ao_cmd.Parameters["@FileData"].Value = DBNull.Value; };

                        ao_cmd.Parameters["@FileGuid"].Value = ao_WREMINDERDOCS.FileGuid; ;

                        if (ao_WREMINDERDOCS.FileName.Length > 0) { ao_cmd.Parameters["@FileName"].Value = ao_WREMINDERDOCS.FileName; } else { ao_cmd.Parameters["@FileName"].Value = string.Empty; };

                        if (ao_WREMINDERDOCS.id_reminder > -1) { ao_cmd.Parameters["@id_reminder"].Value = ao_WREMINDERDOCS.id_reminder; } else { ao_cmd.Parameters["@id_reminder"].Value = DBNull.Value; };

                        lb_res = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return lb_res;
        }
        private bool SetDataDel(System.Data.SqlClient.SqlCommand ao_cmd, Guid ig_FileGuid)
        {
            bool lb_res = false;
            try
            {
                ao_cmd.Parameters["@FileGuid"].Value = ig_FileGuid;

                lb_res = true;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return lb_res;
        }
        private bool InsertData(TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateInsertCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (io_Cn.ActualizaDB(ref lo_cmd))
                    {
                        ao_WREMINDERDOCS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + io_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = "No se ha insertado el registro. Metodo1" + io_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool InsertData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateInsertCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd))
                    {
                        ao_WREMINDERDOCS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha insertado el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = "No se ha insertado el registro. Metodo 2" + ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool InsertData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateInsertCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd, al_Trans))
                    {
                        ao_WREMINDERDOCS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha insertado el registro. Metodo 3" + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool UpdateData(TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateUpdateCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (io_Cn.ActualizaDB(ref lo_cmd))
                    {
                        ao_WREMINDERDOCS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + io_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = io_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool UpdateData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateUpdateCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd))
                    {
                        ao_WREMINDERDOCS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool UpdateData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateUpdateCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd, al_Trans))
                    {
                        ao_WREMINDERDOCS.Estado = RegStatus.Unchanged;
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No se ha actualizado el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }
        private bool DeleteData(TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateDeleteCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (io_Cn.ActualizaDB(ref lo_cmd))
                    {
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No ha sido posible borrar el registro." + io_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = io_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }

        private bool DeleteData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateDeleteCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd))
                    {
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No ha sido posible borrar el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }

        private bool DeleteData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateDeleteCommand(ref lo_cmd))
            {
                if (SetData(lo_cmd, ao_WREMINDERDOCS))
                {
                    if (ao_Cn.ActualizaDB(ref lo_cmd, al_Trans))
                    {
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No ha sido posible borrar el registro." + ao_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = ao_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }

        private bool DeleteData(Guid ig_FileGuid)
        {
            bool lb_res = false;
            System.Data.SqlClient.SqlCommand lo_cmd = null;
            if (CreateDeleteCommand(ref lo_cmd))
            {
                if (SetDataDel(lo_cmd, ig_FileGuid))
                {
                    if (io_Cn.ActualizaDB(ref lo_cmd))
                    {
                        lb_res = true;
                    }
                    else
                    {
                        is_LastError = "No ha sido posible borrar el registro." + io_Cn.LastError;
                        HandleError(is_LastError);
                    }
                }
            }
            else
            {
                is_LastError = io_Cn.LastError;
                HandleError(is_LastError);
            }
            return lb_res;
        }

        public bool CreateDeleteCommandById(ref System.Data.SqlClient.SqlCommand ao_cmd, int id_reminder)
        {
            bool lb_res = true;
          //  System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
          /*  lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_reminder";
            lo_param.SqlDbType = System.Data.SqlDbType.UniqueIdentifier;
            lo_param.Size = 16;
            ao_cmd.Parameters.Add(lo_param);*/

            ao_cmd.CommandText = "DELETE FROM WREMINDERDOCS WHERE id_reminder = " + id_reminder;
            return lb_res;
        }

        private bool CreateDeleteCommand(ref System.Data.SqlClient.SqlCommand ao_cmd)
        {
            bool lb_res = true;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileGuid";
            lo_param.SqlDbType = System.Data.SqlDbType.UniqueIdentifier;
            lo_param.Size = 16;
            ao_cmd.Parameters.Add(lo_param);

            ao_cmd.CommandText = "DELETE FROM WREMINDERDOCS WHERE FileGuid = @FileGuid";
            return lb_res;
        }

        private bool CreateInsertCommand(ref System.Data.SqlClient.SqlCommand ao_cmd)
        {
            bool lb_res = true;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileData";
            lo_param.SqlDbType = System.Data.SqlDbType.VarBinary;
            lo_param.Size = 2147483647;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileGuid";
            lo_param.SqlDbType = System.Data.SqlDbType.UniqueIdentifier;
            lo_param.Size = 16;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileName";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 300;
            ao_cmd.Parameters.Add(lo_param);

            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_reminder";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);

            ao_cmd.CommandText = "INSERT INTO WREMINDERDOCS (FileData,FileGuid,FileName,id_reminder) VALUES (@FileData,@FileGuid,@FileName,@id_reminder)";
            return lb_res;
        }

        private bool CreateUpdateCommand(ref System.Data.SqlClient.SqlCommand ao_cmd)
        {
            bool lb_res = true;
            string ls_values = string.Empty;
            string ls_campos = string.Empty;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileData";
            lo_param.SqlDbType = System.Data.SqlDbType.VarBinary;
            lo_param.Size = 2147483647;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileGuid";
            lo_param.SqlDbType = System.Data.SqlDbType.UniqueIdentifier;
            lo_param.Size = 16;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileName";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 300;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_reminder";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            ao_cmd.CommandText = "UPDATE WREMINDERDOCS SET FileData = @FileData , FileName = @FileName , id_reminder = @id_reminder WHERE FileGuid = @FileGuid";

            return lb_res;
        }

        private bool CreateUpdateCommandById(ref System.Data.SqlClient.SqlCommand ao_cmd, int id_recordatorio)
        {
            bool lb_res = true;
            string ls_values = string.Empty;
            string ls_campos = string.Empty;
            System.Data.SqlClient.SqlParameter lo_param = null;
            if (ao_cmd == null)
            {
                ao_cmd = new System.Data.SqlClient.SqlCommand();
            }
            ao_cmd.CommandType = System.Data.CommandType.Text;
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileData";
            lo_param.SqlDbType = System.Data.SqlDbType.VarBinary;
            lo_param.Size = 2147483647;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileGuid";
            lo_param.SqlDbType = System.Data.SqlDbType.UniqueIdentifier;
            lo_param.Size = 16;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@FileName";
            lo_param.SqlDbType = System.Data.SqlDbType.VarChar;
            lo_param.Size = 300;
            ao_cmd.Parameters.Add(lo_param);
            lo_param = new System.Data.SqlClient.SqlParameter();
            lo_param.Direction = System.Data.ParameterDirection.Input;
            lo_param.ParameterName = "@id_reminder";
            lo_param.SqlDbType = System.Data.SqlDbType.Int;
            lo_param.Size = 4;
            ao_cmd.Parameters.Add(lo_param);
            ao_cmd.CommandText = "UPDATE WREMINDERDOCS SET FileData = @FileData , FileName = @FileName WHERE id_rem = @FileGuid";

            return lb_res;
        }
        #endregion
        #region "Public Functions"
        public bool LoadData(TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            string ls_Consulta = string.Empty;
            bool lb_res = false;
            is_LastError = string.Empty;
            lb_res = ConnectToDb();
            if (lb_res)
            {
                ls_Consulta = "SELECT FileData,FileGuid,FileName,id_reminder FROM WREMINDERDOCS WHERE FileGuid = '" + ao_WREMINDERDOCS.FileGuid + "'";
                lb_res = LoadFromDB(ls_Consulta, ao_WREMINDERDOCS);
            }
            DisconnectDb();
            return lb_res;
        }
        public bool LoadData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn)
        {
            string ls_Consulta = string.Empty;
            bool lb_res = false;
            is_LastError = string.Empty;
            ls_Consulta = "SELECT FileData,FileGuid,FileName,id_reminder FROM WREMINDERDOCS WHERE FileGuid = '" + ao_WREMINDERDOCS.FileGuid + "'";
            lb_res = LoadFromDB(ls_Consulta, ao_WREMINDERDOCS, ao_Cn);
            return lb_res;
        }
        public bool SaveData(TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            bool lb_res = false;
            is_LastError = String.Empty;
            lb_res = ConnectToDb();
            if (lb_res)
            {
                try
                {
                    switch (ao_WREMINDERDOCS.Estado)
                    {
                        case RegStatus.Added:
                            lb_res = InsertData(ao_WREMINDERDOCS);
                            break;
                        case RegStatus.Deleted:
                            lb_res = DeleteData(ao_WREMINDERDOCS);
                            break;
                        case RegStatus.Modified:
                            lb_res = UpdateData(ao_WREMINDERDOCS);
                            break;
                        case RegStatus.Unchanged:
                            lb_res = true;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                finally
                {
                    DisconnectDb();
                }
            }
            return lb_res;
        }
        public bool SaveData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn)
        {
            bool lb_res = false;
            is_LastError = String.Empty;
            try
            {
                switch (ao_WREMINDERDOCS.Estado)
                {
                    case RegStatus.Added:
                        lb_res = InsertData(ao_WREMINDERDOCS, ao_Cn);
                        break;
                    case RegStatus.Deleted:
                        lb_res = DeleteData(ao_WREMINDERDOCS, ao_Cn);
                        break;
                    case RegStatus.Modified:
                        lb_res = UpdateData(ao_WREMINDERDOCS, ao_Cn);
                        break;
                    case RegStatus.Unchanged:
                        lb_res = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return lb_res;
        }
        public bool SaveData(TWREMINDERDOCS ao_WREMINDERDOCS, THCBSQL ao_Cn, int al_Trans)
        {
            bool lb_res = false;
            is_LastError = String.Empty;
            try
            {
                switch (ao_WREMINDERDOCS.Estado)
                {
                    case RegStatus.Added:
                        lb_res = InsertData(ao_WREMINDERDOCS, ao_Cn, al_Trans);
                        break;
                    case RegStatus.Deleted:
                        lb_res = DeleteData(ao_WREMINDERDOCS, ao_Cn, al_Trans);
                        break;
                    case RegStatus.Modified:
                        lb_res = UpdateData(ao_WREMINDERDOCS, ao_Cn, al_Trans);
                        break;
                    case RegStatus.Unchanged:
                        lb_res = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return lb_res;
        }
        public bool Delete(TWREMINDERDOCS ao_WREMINDERDOCS)
        {
            ao_WREMINDERDOCS.Estado = RegStatus.Deleted;
            return SaveData(ao_WREMINDERDOCS);
        }
        public bool Delete(Guid ig_FileGuid)
        {
            return DeleteData(ig_FileGuid);
        }
        #endregion
        #region "Extended public functions"
        public bool ConnectToDb()
        {
            bool lb_res = false;
            if (is_ConnectionString.Length > 0)
            {
                try
                {
                    if (io_Cn != null)
                    {
                        io_Cn.OnException -= ConnectionException;
                        io_Cn.Desconecta();
                        io_Cn = null;
                    }
                    io_Cn = new THCBSQL();
                    io_Cn.ConnectionTimeOut = 60;
                    io_Cn.ConnectionString = is_ConnectionString;
                    io_Cn.OnException += new THCB.ExceptionHandler(ConnectionException);
                    if (io_Cn.Conecta())
                    {
                        lb_res = true;
                    }
                    else
                    {
                        HandleError(io_Cn.LastError);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                    if (io_Cn != null)
                    {
                        io_Cn.Desconecta();
                        io_Cn.OnException -= ConnectionException;
                        io_Cn = null;
                    }
                }
            }
            else
            {
                HandleError("No se ha establecido la cadena de conexión.");
            }
            return lb_res;
        }
        public bool DisconnectDb()
        {
            bool lb_res = false;
            if (io_Cn != null)
            {
                try
                {
                    io_Cn.Desconecta();
                    io_Cn.OnException -= ConnectionException;
                    io_Cn = null;
                    lb_res = true;
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            return lb_res;
        }
        #endregion
        #region "Manejador de errores"
        private void HandleError(Exception ao_ex)
        {
            is_LastError = ao_ex.Message;
            if (OnException != null)
            {
                OnException(this, new LastErrorEventArgs(ao_ex));
            }
        }
        private void HandleError(string as_ErrText)
        {
            is_LastError = as_ErrText;
            if (OnException != null)
            {
                OnException(this, new LastErrorEventArgs(new Exception(as_ErrText)));
            }
        }
        private void ConnectionException(object sender, LastErrorEventArgs e)
        {
            HandleError(e.LastError);
        }
        #endregion
    }

}