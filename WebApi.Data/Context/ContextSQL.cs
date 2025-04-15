using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebApi.Entity;

namespace WebApi.Data
{
    public sealed class ContextSQL<TEntity> : IRepository<TEntity> where TEntity : class, new()
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

        private string _SettingConexion;

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

        public List<TEntity> List()
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

        public TEntity Get(int Id)
        {
            Dictionary<string, string> lDictionary = new Dictionary<string, string>();
            List<dynamic> lDynamic = new List<dynamic>();
            DataTable dt = new DataTable();
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

        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            List<dynamic> lDynamic = new List<dynamic>();
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

        public void Delete(int Id)
        {
            Dictionary<string, string> lDictionary = new Dictionary<string, string>();
            lDictionary.Add("Id", Id.ToString());
            try
            {
                ExecuteNonQuery("Delete", lDictionary);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insert(Dictionary<string, string> lParam)
        {
            try
            {
                ExecuteNonQuery("Insert", lParam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Dictionary<string, string> lParam)
        {
            try
            {
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
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da;
            StringBuilder sbKey = new StringBuilder();
            List<dynamic> lDynamic = new List<dynamic>();
            StringBuilder sb = new StringBuilder();
            sb.Append(EntityName);
            sb.Append("_");
            sb.Append(FunctionName);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sb.ToString();
            try
            {
                Parameters = Parameters == null ? new Dictionary<string, string>() : Parameters;

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append("@");
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = new SqlConnection())
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
            StringBuilder sb = new StringBuilder();
            sb.Append(EntityName);
            sb.Append("_");
            sb.Append(FunctionName);
            SqlCommand cmd = new SqlCommand();
            MessageError = string.Empty;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sb.ToString();
            StringBuilder sbKey = new StringBuilder();
            cmd.CommandTimeout = 60;
            try
            {
                Parameters = Parameters == null ? new Dictionary<string, string>() : Parameters;

                foreach (var d in Parameters)
                {
                    sbKey.Clear();
                    sbKey.Append("@");
                    sbKey.Append(d.Key);
                    cmd.Parameters.Add(new SqlParameter(sbKey.ToString(), d.Value));
                }

                using (SqlConnection cn = new SqlConnection())
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
