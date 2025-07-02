using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApi.Model
{
    public abstract class ModelBase
    {

   
        public string NombreToFecha(string MonthName, int Year, int Day = 1, string DateFormat = "dd/MM/yyyy")
        {
            DateTime d;
            string sFecha;
            int iMes;
            Dictionary<int, string> ListaMes = new Dictionary<int, string>();
            try
            {
                ListaMes.Add(01, "Enero");
                ListaMes.Add(02, "Febrero");
                ListaMes.Add(03, "Marzo");
                ListaMes.Add(04, "Abril");
                ListaMes.Add(05, "Mayo");
                ListaMes.Add(06, "Junio");
                ListaMes.Add(07, "Julio");
                ListaMes.Add(08, "Agosto");
                ListaMes.Add(09, "Septiembre");
                ListaMes.Add(10, "Octubre");
                ListaMes.Add(11, "Noviembre");
                ListaMes.Add(12, "Diciembre");
                iMes = ListaMes.Where(x => x.Value.ToLower() == MonthName.ToLower()).SingleOrDefault().Key;
                d = new DateTime(Year, iMes, Day);
                sFecha = d.ToString(DateFormat);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return sFecha;
        }


        /// <summary>
        /// Busca en un array de palabras si existe una linea que contenga algunas de las palabras del array.
        /// </summary>
        /// <param name="lLines">
        /// lineas donde busca
        /// </param>
        /// <param name="lSearchText">
        /// lista de palabras o texto a buscar
        /// </param>
        /// <param name="DeleteText">
        /// Elimina el texto buscado 
        /// </param>
        /// <param name="IsNullDefaultValue">
        /// Valor por default en caso de que no encuentre nada.
        /// </param>        
        /// <returns>
        /// devuelve la linea buscada, la que encuentre primero
        /// </returns>
        public string BuscarLinea(List<string> lLines, List<string> lSearchText, bool DeleteText = false, string IsNullDefaultValue = "")
        {
            int NoExistResult = 0;
            int index = 0;
            string sLine = string.Empty;
            try
            {
                foreach (string SearchText in lSearchText)
                {
                    NoExistResult = lLines.Select((linea, indice) => new { Linea = linea, Indice = indice })
                    .Where(x => x.Linea.ToLower().Contains(SearchText.ToLower()))
                    .Select(x => x.Indice)
                    .Count();

                    if (NoExistResult == 0)
                    {
                        continue;
                    }

                    if (NoExistResult > 0) 
                    {
                        index = lLines.Select((line, index) => new { Line = line, Index = index })
                       .Where(x => x.Line.ToLower().Contains(SearchText.ToLower())).Select(x => x.Index).FirstOrDefault();

                        sLine = (DeleteText) ? lLines[index].Replace(SearchText, "").Trim() : sLine = lLines[index].Trim();

                        break; //Si encuentra algo sale.
                    }
                }

                sLine = (sLine.Length == 0) ? IsNullDefaultValue : sLine;
            }
            catch (Exception) {
                throw;
            }
            return sLine;
        }

        public DateTime DatetimeConvert(string Fecha) 
        {
            DateTime d;
            int iDay = 0;
            int iMonth = 0;
            int iYear = 0;
            try
            {
                if (DateTime.TryParseExact(Fecha, "dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None, out DateTime fechaConvertida))
                {
                    iDay = fechaConvertida.Day;
                    iMonth = fechaConvertida.Month;
                    iYear = fechaConvertida.Year;
                }
                d = new DateTime(iYear,iMonth,iDay);
            }
            catch (Exception) 
            {
                throw;
            }
            return d;
        }

        public string CamelCase(string s)
        {
            return Regex.Replace(s, @"\b[a-z]\w+", delegate (Match match)
            {
                string v = match.ToString();
                return char.ToUpper(v[0]) + v.Substring(1);
            });
        }


    }
}
