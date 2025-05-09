using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using WebApi.Entity;


namespace WebApi.Data
{

    public class ContextSQL<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {

        public ContextSQL(string ConnectionString)
        {
            _SettingConexion = ConnectionString;
        }

        public class ContextSQLException : Exception 
        {
            public ContextSQLException() { }
            
            public ContextSQLException(string message) 
            { 
                _Message = message;
            }

            private string _Message = string.Empty;

            public override string Message 
            {
                get {
                    _Message = base.Message;
                    return _Message;
                }
            }
        }


        #region Declaration

        private readonly string _SettingConexion;

        #endregion

        #region Properties

        public string EntityName
        {
            get
            {
                Type type = typeof(TEntity);
                return type.Name;
            }
        }

        public string MessageError
        {
            get; private set;
        }

        #endregion

        #region Catch Sql Errors

        void cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageError = e.Message;
        }

        #endregion

        #region Interface Method

        public virtual List<TEntity> List()
        {
            DataTable dt;
            try
            {
                dt = Fill("List").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return EntityBase.ToList<TEntity>(dt);
        }

        public virtual TEntity Get(int Id)
        {
            Dictionary<string, string> lDictionary = [];
            DataTable dt;
            lDictionary.Add("Id", Id.ToString());
            try
            {
                dt = Fill("Get", lDictionary).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return EntityBase.ToList<TEntity>(dt).SingleOrDefault();
        }

        public virtual List<dynamic> Find(Dictionary<string, string> lParam)
        {
            List<dynamic> lDynamic = [];
            DataTable dt;
            try
            {
                dt = Fill("Find", lParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lDynamic = EntityBase.ToDynamic(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lDynamic;
        }

        public virtual void Delete(int Id)
        {
            Dictionary<string, string> lDictionary = new()
            {
                { "Id", Id.ToString() }
            };
            try
            {
                ExecuteNonQuery("Delete", lDictionary);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Insert(TEntity oEntity)
        {
            Dictionary<string, string> lParam = [];
            PropertyInfo[] propiedades;
            try
            {
                propiedades = typeof(TEntity).GetProperties();
                foreach (PropertyInfo propiedad in propiedades)
                {
                    if (propiedad.IsDefined(typeof(KeyAttribute), inherit: false)) { continue; } //evita enviar el Id como parametro
                    lParam.Add(propiedad.Name, propiedad.GetValue(oEntity).ToString());
                }
                ExecuteNonQuery("Insert", lParam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Update(TEntity oEntity)
        {
            Dictionary<string, string> lParam = [];
            PropertyInfo[] propiedades;
            try
            {
                propiedades = typeof(TEntity).GetProperties();
                foreach (PropertyInfo propiedad in propiedades)
                {
                    lParam.Add(propiedad.Name, propiedad.GetValue(oEntity).ToString());
                }
                ExecuteNonQuery("Update", lParam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Store Procedures Common Function

        public DataSet Fill(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            DataSet ds = new();
            SqlCommand cmd = new();
            SqlDataAdapter da;
            StringBuilder sbKey = new();
            List<dynamic> lDynamic = [];
            StringBuilder sb = new();
            sb.Append(EntityName);
            sb.Append('_');
            sb.Append(FunctionName);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sb.ToString();
            try
            {
                Parameters = Parameters ?? [];

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append('@');
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = new())
                {
                    cn.ConnectionString = _SettingConexion;
                    cmd.Connection = cn;
                    MessageError = string.Empty;
                    da = new SqlDataAdapter(cmd);
                    cn.InfoMessage += cn_InfoMessage;
                    cn.Open();
                    da.Fill(ds);
                    cn.Close();
                }

                if (MessageError.Length > 0)
                {
                    throw new ContextSQLException(MessageError);
                }
            }
            catch (ContextSQLException ex) 
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }
            return ds;
        }


        public void ExecuteNonQuery(string FunctionName, Dictionary<string, string> Parameters = null)
        {
            StringBuilder sb = new();
            sb.Append(EntityName);
            sb.Append('_');
            sb.Append(FunctionName);
            SqlCommand cmd = new ();
            MessageError = string.Empty;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sb.ToString();
            StringBuilder sbKey = new ();
            cmd.CommandTimeout = 60;
            try
            {
                Parameters = Parameters == null ? [] : Parameters;

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append('@');
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = new())
                {
                    cn.ConnectionString = _SettingConexion;
                    cn.InfoMessage += cn_InfoMessage;
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                if (MessageError.Length > 0)
                {
                    throw new ContextSQLException(MessageError);
                }

            }
            catch (ContextSQLException ex)
            {
                throw new ContextSQLException(ex.Message);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
