using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WebApi.Entity
{
    [Serializable]
    public abstract class EntityBase
    {
        
        [Key]
        public int Id { get; set; }

        #region ToList

        public static List<T> ToList<T>(DataTable dt)
        {
            var properties = typeof(T).GetProperties();
            List<string> columnNames;
            try
            {
                if (dt == null)
                {
                    return []; //new List<T>();
                }

                columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
                return dt.AsEnumerable().Select(dr =>
                {
                    var objT = Activator.CreateInstance<T>();

                    foreach (var p in properties)
                    {
                        if (columnNames.Contains(p.Name) && (dr[p.Name] != DBNull.Value && p.PropertyType.Name != "Nullable"))
                        {

                            switch (p.PropertyType.Name)
                            {
                                case "Decimal":
                                    p.SetValue(objT, decimal.Parse(dr[p.Name].ToString()), null);
                                    break;
                                case "String":
                                    p.SetValue(objT, dr[p.Name].ToString(), null);
                                    break;
                                case "Int64":
                                    p.SetValue(objT, long.Parse(dr[p.Name].ToString()), null);
                                    break;
                                case "Int16":
                                    p.SetValue(objT, short.Parse(dr[p.Name].ToString()), null);
                                    break;
                                case "Int32":
                                    p.SetValue(objT, int.Parse(dr[p.Name].ToString()), null);
                                    break;
                                case "Byte":
                                    p.SetValue(objT, byte.Parse(dr[p.Name].ToString()), null);
                                    break;
                                case "Short":
                                    p.SetValue(objT, short.Parse(dr[p.Name].ToString()), null);
                                    break;
                                case "Boolean":
                                    p.SetValue(objT, bool.Parse(dr[p.Name].ToString()), null);
                                    break;
                                case "Single":
                                    p.SetValue(objT, Single.Parse(dr[p.Name].ToString()), null);
                                    break;
                                case "DateTime":
                                    p.SetValue(objT, DateTime.Parse(dr[p.Name].ToString()), null);
                                    break;
                                default:
                                    p.SetValue(objT, dr[p.Name], null);
                                    break;
                            }
                            if (dr[p.Name] == DBNull.Value)
                            {
                                switch (p.PropertyType.Name)
                                {
                                    case "String":
                                        p.SetValue(objT, string.Empty, null);
                                        break;
                                    case "Int64":
                                    case "Int32":
                                    case "Int16":
                                    case "Byte":
                                    case "Short":
                                    case "Single":
                                    case "Decimal":
                                        p.SetValue(objT, 0, null);
                                        break;
                                    case "Boolean":
                                        p.SetValue(objT, false, null);
                                        break;
                                    case "DateTime":
                                        p.SetValue(objT, DateTime.MinValue, null);
                                        break;
                                    default:
                                        break;
                                }
                            }

                        }
                    }
                    return objT;
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<T> ToList<T>(List<dynamic> odynamic)
        {
            List<T> lReturn = new List<T>();
            PropertyInfo[] TipoConcretoProperties = typeof(T).GetProperties();
            string sTempValue;
            try
            {
                foreach (dynamic item in odynamic)
                {
                    var oEntity = Activator.CreateInstance<T>();

                    foreach (PropertyInfo p in TipoConcretoProperties)
                    {
                        if (p.PropertyType.Name != "Nullable" && p.PropertyType.Name.Contains("List") == false)
                        {
                            try
                            {
                                sTempValue = ((IDictionary<string, object>)item)[p.Name].ToString();
                            }
                            catch (KeyNotFoundException)
                            {
                                continue; // no existe la propiedad en la clase concreta, asi que no puede pasar el valor de la dynamic a la propiedad concreta.
                            }

                            switch (p.PropertyType.Name)
                            {
                                case "Decimal":
                                    p.SetValue(oEntity, decimal.Parse(sTempValue), null);
                                    break;
                                case "String":
                                    p.SetValue(oEntity, sTempValue, null); ;
                                    break;
                                case "Int64":
                                    p.SetValue(oEntity, long.Parse(sTempValue), null);
                                    break;
                                case "Int16":
                                    p.SetValue(oEntity, short.Parse(sTempValue), null);
                                    break;
                                case "Int32":
                                    p.SetValue(oEntity, int.Parse(sTempValue), null);
                                    break;
                                case "Byte":
                                    p.SetValue(oEntity, byte.Parse(sTempValue), null);
                                    break;
                                case "Short":
                                    p.SetValue(oEntity, short.Parse(sTempValue), null);
                                    break;
                                case "Boolean":
                                    p.SetValue(oEntity, bool.Parse(sTempValue), null);
                                    break;
                                case "Single":
                                    p.SetValue(oEntity, Single.Parse(sTempValue), null);
                                    break;
                                case "DateTime":
                                    p.SetValue(oEntity, DateTime.Parse(sTempValue), null);
                                    break;
                                default:
                                    p.SetValue(oEntity, sTempValue, null);
                                    break;
                            }
                        }
                    }
                    lReturn.Add(oEntity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lReturn;
        }

        public static T ToList<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            try
            {
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                ms.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }

        /// <summary>
        ///  Devuelve una lista completa de string basado en una columna de un datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="column"></param>
        /// <param name="Condicion"></param>
        /// <returns></returns>
        public static List<string> ToList(DataTable dt, string column, string Condicion = "")
        {
            List<string> lReturn = [];
            DataTable dtFiltrada = new DataTable();
            try
            {
                if (!dt.Columns.Contains(column))
                {
                    return lReturn;
                }

                if (dt.Rows.Count > 0 && dt.Select(Condicion).Length > 0)
                {
                    dtFiltrada = dt.Select(Condicion).CopyToDataTable();
                }

                foreach (DataRow dr in dtFiltrada.Rows)
                {
                    lReturn.Add(dr[column].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lReturn;
        }

        #endregion

        #region ToString

        public static string ToString(DataTable dt, string Condicion, string Campo, string ValorDefault = "")
        {
            string s = ValorDefault;
            DataRow[] ldr;
            try
            {
                if (dt.Rows.Count > 0 && Condicion.Length > 0 && dt.Select(Condicion).Length == 1)
                {
                    ldr = dt.Select(Condicion);
                    s = ldr.CopyToDataTable().Rows[0][Campo].ToString();
                }
                if (dt.Rows.Count == 1 && Condicion.Length == 0)
                {
                    s = dt.Rows[0][Campo].ToString();

                    if (s.Length == 0)
                    {
                        s = ValorDefault;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return s;
        }

        public static string ToString(DataTable dt, string Campo, string ValorDefault = "")
        {
            string s = ValorDefault;
            try
            {
                if (dt.Rows.Count == 1 && Campo != string.Empty)
                {
                    if (dt.Columns.Contains(Campo))
                    {
                        s = dt.Rows[0][Campo].ToString();
                    }
                    if (s.Length == 0)
                    {
                        s = ValorDefault;
                    }
                }
                if (dt.Rows.Count > 1)
                {
                    s = dt.Rows[0][Campo].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return s;
        }

        public static string ToString(DataRow dr, string Campo, string ValorDefault = "")
        {
            string s = ValorDefault;
            try
            {
                if (dr[Campo] != null)
                {
                    if (dr[Campo].ToString().Length != 0)
                    {
                        s = dr[Campo].ToString();

                        if (s.Length == 0)
                        {
                            s = ValorDefault;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return s;
        }

        #endregion

        #region ToDatable

        public static DataSet ToDatatable(string Json)
        {
            DataSet ds = new DataSet("ds");
            List<string> childTokens = new List<string>();
            JObject jsonObject;
            jsonObject = JObject.Parse(Json);
            try
            {
                foreach (JProperty jTable in jsonObject.Children<JProperty>())
                {
                    childTokens.Add(jTable.Name);
                    var jChilds = jTable.Descendants().First();
                    DataTable dt;
                    JArray jArrayResult = new JArray();

                    foreach (JObject row in jChilds.Children<JObject>())
                    {
                        JObject jTableRowResult = new JObject();
                        foreach (JProperty column in row.Properties())
                        {
                            if (column.Value is JValue)
                            {
                                jTableRowResult.Add(column.Name, column.Value);
                            }
                        }

                        jArrayResult.Add(jTableRowResult);
                    }

                    dt = JsonConvert.DeserializeObject<DataTable>(jArrayResult.ToString());
                    dt.TableName = jTable.Name;
                    ds.Tables.Add(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }

        public static DataTable ToDatatable<T>(List<T> lista)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Obtener las propiedades del tipo T
                PropertyInfo[] propiedades = typeof(T).GetProperties();

                // Crear columnas en el DataTable
                foreach (var propiedad in propiedades)
                {
                    dataTable.Columns.Add(propiedad.Name, propiedad.PropertyType);
                }

                // Llenar el DataTable con los valores de las propiedades
                foreach (var item in lista)
                {
                    var fila = dataTable.NewRow();
                    foreach (var propiedad in propiedades)
                    {
                        fila[propiedad.Name] = propiedad.GetValue(item) ?? DBNull.Value; // Manejo de valores nulos
                    }
                    dataTable.Rows.Add(fila);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dataTable;
        }

        public static DataTable ToDatatable(DataTable dt, string Condicion)
        {
            DataTable dtReturn = new DataTable();
            try
            {
                if (dt.Rows.Count > 0 && dt.Select(Condicion).Length > 0)
                {
                    dtReturn = dt.Select(Condicion).CopyToDataTable();
                }
                else
                {
                    dtReturn = dt.Copy();
                    dtReturn.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dtReturn;
        }

        #endregion

        #region ToDate

        public static DateTime? ToDate(DataTable dt, string Campo, bool NoSoportaNull = false)
        {
            DateTime? d = null;
            DateTime dd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); //Manda el valor del mes actual.
            try
            {
                if (dt.Rows.Count >= 1)
                {
                    if (dt.Rows[0][Campo].ToString().Trim().Length != 0)
                    {
                        d = DateTime.Parse(dt.Rows[0][Campo].ToString());
                    }
                }
                if (dt.Rows.Count == 0 && NoSoportaNull == true)
                {
                    d = dd;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return d;
        }

        public static DateTime? ToDate(DataRow dr, string Campo)
        {
            DateTime? d = null;
            try
            {
                if (dr[Campo] != null)
                {
                    if (dr[Campo].ToString().Trim().Length != 0)
                    {
                        d = DateTime.Parse(dr[Campo].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return d;
        }

        #endregion

        #region To Dictionary

        /// <summary>
        /// ToDictionary : funcion que convierte los valores de una entidad aun no instanciada a un dictionary.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo de dato original de la entidad a convertir
        /// </typeparam>
        /// <param name="entidad"></param>
        /// <param name="MergeKeyValue"></param>
        /// <returns>
        /// un dictionary con la lista de propiedades y valores 
        /// </returns>
        public static Dictionary<string, string> ToDictionary<T>(T entidad, bool MergeKeyValue = false)
        {
            Dictionary<string, string> lDictionary = new Dictionary<string, string>();
            PropertyInfo[] propiedades = entidad.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] Subpropiedades = [];
            string sPrimitive = string.Empty;
            
            foreach (PropertyInfo prop in propiedades)
            {
                object valor = null;
                try
                {
                    valor = prop.GetValue(entidad);
                }
                catch 
                {
                    continue;
                }

                sPrimitive = prop.PropertyType.Namespace; // obviamente tiene namespace

                if (prop.IsDefined(typeof(KeyAttribute), inherit: false) && MergeKeyValue == false)
                { continue; } //evita enviar el Key Id

                if (prop.IsDefined(typeof(NotMappedAttribute), inherit: false))
                { 
                    continue; 
                } //evita enviar atributos con notmapper

                if (valor != null && sPrimitive == "System")
                {
                    var vprop = valor != null ? valor.ToString() : null;
                    lDictionary.Add(prop.Name, vprop);
                    continue;
                }

                if (valor == null && sPrimitive == "System")
                {
                    lDictionary.Add(prop.Name, "");
                    continue;
                }

                if (sPrimitive != "System") 
                {
                    Type targetType = Type.GetType(p.PropertyType.FullName);
                    object convertedValue = Convert.ChangeType(prop, targetType);
                    PropertyInfo[] subproperties = targetType.GetProperties();
                    foreach (PropertyInfo sp in subproperties)
                    {
                        bool isSubPropertyNotMapped = Attribute.IsDefined(sp, typeof(NotMappedAttribute));
                        if (isSubPropertyNotMapped)
                        {
                            continue;
                        }
                        object subvalue = sp.GetValue(convertedValue);
                        lDictionary.Add(sp.Name, subvalue.ToString());
                    }
                    continue;
                }
            }

            return lDictionary;
        }

        /// <summary>
        /// ToDiccionary funcion que pasa todos los valores de una clase INSTANCIADA a un dictionary
        /// </summary>
        /// <param name="IncludeBlankSpace">
        /// Este parametro agrega valores vacios como valor, si hago una busqueda y en mi propiedad tengo valores vacios los incluira en la busqueda, 
        /// en cambio si tengo un insert seria bueno que los incluya.
        /// si existe un campo que tiene que puede estar vacio o no, debemos poner la propiedad en true para que lo agregue como parametro
        /// </param>
        /// <param name="IncludeZero">
        /// este parametro agrega valores zero como valor, si hago una busqueda y en mi propiedad tengo valores con cero los incluira en la busqueda, 
        /// en cambio si tengo un insert seria bueno que los incluya.
        /// si existe un campo que tiene que puede estar vacio o no, debemos poner la propiedad en true para que lo agregue como parametro
        /// </param>
        /// <returns>
        /// Devuelve un array de propiedades con sus valores
        /// </returns>
        public Dictionary<string, string> ToDictionary(bool IncludeBlankSpace = false, bool IncludeZero = false)
        {
            Dictionary<string, string> lProperty = new Dictionary<string, string>();
            Type t = this.GetType();
            PropertyInfo[] properties = t.GetProperties();
            try
            {
                foreach (PropertyInfo p in properties)
                {
                    StringBuilder sb = new StringBuilder();
                    object PropertyValue = p.GetValue(this, null);
                    string typeName = p.PropertyType.Name;
                    bool isPropertyNotMapped = Attribute.IsDefined(p, typeof(NotMappedAttribute));

                    if (isPropertyNotMapped || PropertyValue == null) 
                    {
                        continue;
                    }

                    if (PropertyValue.ToString() == "" && IncludeBlankSpace == false)
                    {
                        continue;
                    }

                    switch (typeName)
                    {
                        case "String":
                            sb.Append(PropertyValue);
                            break;
                        case "Double":
                            if (PropertyValue.ToString() == "0" && IncludeZero == false)
                            {
                                continue;
                            }
                            sb.Append(((double)PropertyValue).ToString("C0"));
                            break;
                        case "Short":
                            if (PropertyValue.ToString() == "0" && IncludeZero == false)
                            {
                                continue;
                            }
                            sb.Append(((short)PropertyValue).ToString());
                            break;
                        case "Int16":
                        case "Int32":
                        case "Int64":
                            if (PropertyValue.ToString() == "0" && IncludeZero == false)
                            {
                                continue;
                            }
                            sb.Append(((int)PropertyValue).ToString());
                            break;
                        case "Byte":
                            sb.Append(((byte)PropertyValue).ToString());
                            break;
                        case "Boolean":
                            sb.Append(((bool)PropertyValue) ? "true" : "false");
                            break;
                        case "Single":
                            if (PropertyValue.ToString() == "0" && IncludeZero == false)
                            {
                                continue;
                            }
                            sb.Append(((Single)PropertyValue).ToString());
                            break;
                        case "DateTime":
                            sb.Append(((DateTime)PropertyValue).ToString("yyyy-MM-ddTHH:mm:ss"));
                            break;
                        case "DateOnly":
                            sb.Append(((DateOnly)PropertyValue).Year.ToString());
                            sb.Append(((DateOnly)PropertyValue).Month.ToString());
                            sb.Append(((DateOnly)PropertyValue).Day.ToString());
                            break;
                        case "Decimal":
                            if (PropertyValue.ToString() == "0" && IncludeZero == false)
                            {
                                continue;
                            }
                            sb.Append(((Decimal)PropertyValue).ToString());
                            break;
                        default:
                            Type targetType = Type.GetType(p.PropertyType.FullName);
                            object convertedValue = Convert.ChangeType(PropertyValue, targetType);
                            PropertyInfo[] subproperties = targetType.GetProperties();
                            foreach (PropertyInfo sp in subproperties)
                            {
                                bool isSubPropertyNotMapped = Attribute.IsDefined(sp, typeof(NotMappedAttribute));
                                if (isSubPropertyNotMapped) {
                                    continue;
                                }
                                object subvalue = sp.GetValue(convertedValue);
                                lProperty.Add(sp.Name, subvalue.ToString());
                            }
                            continue;
                    }
                    lProperty.Add(p.Name, sb.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lProperty;
        }

        public static string ToJson(DataSet ds)
        {
            const string COMILLADOBLE = "\"";
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.AppendLine();
            try
            {

                for (int iTable = 0; iTable < ds.Tables.Count; iTable++)
                {
                    sb.Append(COMILLADOBLE);
                    sb.Append(ds.Tables[iTable].TableName);
                    sb.Append(COMILLADOBLE);
                    sb.Append(":");
                    sb.Append("[");
                    sb.AppendLine();

                    for (int i = 0; i < ds.Tables[ds.Tables[iTable].TableName].Rows.Count; i++)
                    {
                        decimal Numero = 0;
                        bool bNumero;

                        sb.Append("{");

                        for (int j = 0; j < ds.Tables[ds.Tables[iTable].TableName].Columns.Count; j++)
                        {

                            if (j < ds.Tables[ds.Tables[iTable].TableName].Columns.Count - 1)
                            {
                                sb.Append(COMILLADOBLE);
                                sb.Append(ds.Tables[0].Columns[j].ColumnName.ToString());
                                sb.Append(COMILLADOBLE);
                                sb.Append(":");
                                sb.Append(COMILLADOBLE);
                                sb.Append(ds.Tables[0].Rows[i][j].ToString());
                                sb.Append(COMILLADOBLE);
                                sb.Append(",");
                            }

                            if (j == ds.Tables[ds.Tables[iTable].TableName].Columns.Count - 1)
                            {
                                sb.Append(COMILLADOBLE);
                                sb.Append(ds.Tables[ds.Tables[iTable].TableName].Columns[j].ColumnName.ToString());
                                sb.Append(COMILLADOBLE);
                                sb.Append(":");

                                bNumero = decimal.TryParse(ds.Tables[ds.Tables[iTable].TableName].Rows[i][j].ToString(), out Numero);

                                if (bNumero)
                                {
                                    sb.Append(ds.Tables[ds.Tables[iTable].TableName].Rows[i][j].ToString());
                                }
                                else
                                {
                                    sb.Append(COMILLADOBLE);
                                    sb.Append(ds.Tables[ds.Tables[iTable].TableName].Rows[i][j].ToString());
                                    sb.Append(COMILLADOBLE);
                                }
                            }
                        }
                        if (i == ds.Tables[0].Rows.Count - 1)
                        {
                            sb.Append("}");
                        }
                        else
                        {
                            sb.Append("},");
                        }
                        sb.AppendLine();
                    }

                    sb.Append("]");
                    sb.AppendLine();
                }

                sb.Append("}");
                sb.AppendLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return sb.ToString();
        }

        public static List<dynamic> ToDynamic(DataTable dt)
        {
            List<dynamic> dynamicDt = new List<dynamic>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    dynamic dyn = new ExpandoObject();
                    dynamicDt.Add(dyn);
                    foreach (DataColumn column in dt.Columns)
                    {
                        var dic = (IDictionary<string, object>)dyn;
                        dic[column.ColumnName] = row[column];
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dynamicDt;
        }

        public static DataSet ToDataset(string xml)
        {
            StringReader r;
            DataSet ds = new DataSet();
            try
            {
                r = new StringReader(xml);
                ds.ReadXml(r);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }

        #endregion

        #region Sort


        /// <summary>
        /// Ordena una lista de tipo Dinamic Property ej var result = Sort<Person>(MiDinamicProperty, "MiColumna");
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">
        /// la dinamic property
        /// </param>
        /// <param name="property">
        /// la columna a ordenar
        /// </param>
        /// <returns>
        /// Retorna la misma lista ordenada
        /// </returns>
        public static List<dynamic> Sort<T>(List<dynamic> input, string property)
        {
            var type = typeof(T);
            var sortProperty = type.GetProperty(property);
            List<dynamic> lReturn = new List<dynamic>();
            try
            {
                lReturn = input.OrderBy(p => sortProperty.GetValue(p, null)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lReturn;
        }

        public static List<dynamic> Sort(List<dynamic> input, string property)
        {
            List<dynamic> lReturn = new List<dynamic>();
            try
            {
                // Se necesita quitar el ordenamiento porque no es compatible.
                property = property.Replace(" ASC", string.Empty);
                property = property.Replace(" DESC", string.Empty);
                lReturn = input.OrderBy(p => p.GetType().GetProperty(property).GetValue(p, null)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lReturn;
        }

        /// <summary>
        /// Recibe un datatable y el orden representa a la columna y el tipo de ordenamiento ej Nombre ASC
        /// Si la columna esta vacia la devuelve vacia.
        /// </summary>
        /// <param name="dt">
        /// Datatable
        /// </param>
        /// <param name="Orden">
        /// Ej Nombre Asc
        /// </param>
        /// <returns></returns>
        public static DataTable Sort(DataTable dt, string Orden)
        {
            DataView dv = new DataView();
            try
            {
                if (dt.Rows.Count == 0)
                {
                    return dt;
                }
                dv = dt.AsDataView();
                dv.Sort = Orden;

                //Despues del sort, tengo que reacomodar los numeros de filas para el paginado
                if (dt.Columns["rownum"] != null)
                {
                    for (int row = 0; row < dv.Count; row++)
                    {
                        dv[row]["rownum"] = row + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dv.ToTable();
        }

        #endregion

        #region Util 

        /// <summary>
        /// EntityPropertyToList
        /// </summary>
        /// <typeparam name="T">
        /// Tipo de dato de la clase
        /// </typeparam>
        /// <param name="TEntity">
        /// la clase propiamente declarada
        /// </param>
        /// <returns>
        /// Devuelve todas las propiedades de una clase en una lista de string
        /// </returns>
        public static List<string> EntityPropertyToList<T>(T TEntity) 
        {
            PropertyInfo[] initProperties = typeof(T).GetProperties();
            List<string> lPropertyName = new List<string>();

            foreach (PropertyInfo p in initProperties) {
                lPropertyName.Add(p.Name);
            }

            return lPropertyName;
        }

        /// <summary>
        /// Merge
        /// </summary>
        /// <typeparam name="TInit">
        /// Tipo de dato de la clase origen
        /// </typeparam>
        /// <typeparam name="TFinal">
        /// Tipo de dato de la clase destino
        /// </typeparam>
        /// <param name="obj1">
        /// clase origen
        /// </param>
        /// <returns>
        /// devuelve la clase destino, llena con los valores de la clase origen
        /// </returns>
        /// <exception cref="Exception">
        /// si ocurre un error, devuelve un exception
        /// </exception>
        public static TFinal Merge<TInit, TFinal>(TInit obj1) where TFinal : new()
        {
            TFinal result = new TFinal();

            // Obtener las propiedades de la clase inicial
            PropertyInfo[] initProperties = typeof(TInit).GetProperties();
            // Obtener las propiedades de la clase final
            PropertyInfo[] finalProperties = typeof(TFinal).GetProperties();
            try
            {
                foreach (PropertyInfo initProperty in initProperties)
                {
                    if (initProperty.CanRead)
                    {
                        var value = initProperty.GetValue(obj1);

                        // Buscar una propiedad correspondiente en la clase final
                        foreach (PropertyInfo finalProperty in finalProperties)
                        {

                            if (finalProperty.GetCustomAttribute<NotMappedAttribute>() != null)
                            {
                                continue; // Omitir esta propiedad
                            }

                            if (finalProperty.Name == initProperty.Name && finalProperty.CanWrite)
                            {
                                // Asignar el valor si no es null
                                if (value != null && initProperty.PropertyType.Name == finalProperty.PropertyType.Name)
                                {
                                    finalProperty.SetValue(result, value);
                                }
                                if (initProperty.PropertyType.Name == "DateTime" && finalProperty.PropertyType.Name == "String")
                                {
                                    finalProperty.SetValue(result, ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ss"));
                                }
                                if (initProperty.PropertyType.Name == "DateOnly" && finalProperty.PropertyType.Name == "String")
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append((((DateOnly)value)).Year.ToString());
                                    sb.Append((((DateOnly)value)).Month.ToString());
                                    sb.Append((((DateOnly)value).Day.ToString()));
                                    finalProperty.SetValue(result, sb.ToString());
                                }
                                if (value != null && initProperty.PropertyType.Name == "Nullable`1" && finalProperty.PropertyType.Name == "String") 
                                {
                                    finalProperty.SetValue(result, ((DateTime)value).ToString("yyyy-MM-dd"));
                                }

                                break; // Salimos del bucle interno una vez que encontramos la propiedad correspondiente
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public static string NombreDelMes(int iMes, string sCultura = "es-AR")
        {
            string sRta = string.Empty;
            try
            {
                sRta = CultureInfo.GetCultureInfo(sCultura).DateTimeFormat.GetMonthName(iMes);
                return sRta.First().ToString().ToUpper() + sRta.Substring(1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Devuelve cantidad de dias entre dos fechas, enviandole como parametro el dia que queremos que cuente de la semanas.
        /// </summary>
        /// <param name="dInicio">
        /// Fecha inicio
        /// </param>
        /// <param name="dFinal">
        /// Fecha Fin
        /// </param>
        /// <param name="DayofWeek"></param>
        /// <returns>
        /// Dias de diferencia
        /// </returns>
        public static int DayOfWeekBetweenDates(DateTime dInicio, DateTime dFinal, DayOfWeek DayofWeek)
        {
            int iCantidad = 0;
            try
            {
                while (dInicio != dFinal)
                {
                    if (dInicio.DayOfWeek == DayofWeek)
                    {
                        iCantidad++;
                    }

                    dInicio = dInicio.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return iCantidad;
        }




        /// <summary>
        /// devuelve el nombre del dia de la semana de una fecha determinada.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string DayNameOfWeek(DateTime fecha)
        {
            string s = string.Empty;
            try
            {
                s = fecha.ToString("dddd", new CultureInfo("es-ES"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return s;
        }

        #endregion

    }
}
