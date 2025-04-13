using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WebApi.Entity;

namespace WebApi.Biz
{


    public class QuiniBiz
    {


        public Quini Get(Byte dd, Byte mm, int yyyy)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument oDoc = new HtmlDocument();
            const string LINK = "http://www.quini6.net/resultados/";
            StringBuilder sbFecha = new StringBuilder();
            StringBuilder sbLink = new StringBuilder();
            string s = string.Empty;
            string sId = string.Empty;
            HtmlNodeCollection hc;
            string[] ls;
            Quini q = new Quini();
            try
            {
                sbLink.Append(LINK);

                if (dd < 10)
                {
                    sbLink.Append("0");
                }
                sbFecha.Append(dd);
                sbLink.Append(dd);
                sbFecha.Append("-");
                sbLink.Append("-");

                if (mm < 10)
                {
                    sbLink.Append("0");
                }
                sbFecha.Append(mm);
                sbLink.Append(mm);
                sbLink.Append("-");
                sbFecha.Append("-");
                sbFecha.Append(yyyy);
                sbLink.Append(yyyy);

                oDoc = web.Load(sbLink.ToString());
                hc = oDoc.DocumentNode.SelectNodes("//div[contains(@class, 'numbers')]");
                
                foreach (HtmlNode h in hc)
                {
                    if (h.InnerText.Replace("\n", "").Trim().Contains("Sorteo Número:") && h.InnerText.Replace("\n", "").Trim().Length < 20)
                    {
                        sId = "0";//h.InnerText.Replace("\n", "").Trim().Replace("Sorteo Número:", "");
                    }

                    if (h.InnerText.Trim().Replace("\r\n", "").Replace(" ", "").Length == 17)
                    {
                        ls = h.InnerText.Trim().Replace("\r\n", "").Replace(" ", "").Split("-");
                        //q.Id = int.Parse(sId);
                        q.N1 = ls[0];
                        q.N2 = ls[1];
                        q.N3 = ls[2];
                        q.N4 = ls[3];
                        q.N5 = ls[4];
                        q.N6 = ls[5];
                        q.DD = dd;
                        q.MM = mm;
                        q.YYYY = yyyy;
                        q.Fecha = sbFecha.ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return q;
        }

        public List<Quini> Get(Byte mm, int yyyy)
        {
            List<Quini> lq = new List<Quini>();
            Quini q;
            DateTime dFecha;
            try
            {
                for (Byte i = 1; i < 31; i++)
                {
                    if (ValidarFecha(i, mm, yyyy) == string.Empty)
                    {
                        continue;
                    }

                    dFecha = new DateTime(yyyy, mm, i);

                    if (dFecha.DayOfWeek == DayOfWeek.Wednesday || dFecha.DayOfWeek == DayOfWeek.Sunday)
                    {
                        q = Get(i, mm, yyyy);

                        if (q.Id != 0)
                        {
                            lq.Add(q);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lq;
        }

        public List<Quini> Get(int yyyy)
        {
            List<Quini> lQuini;
            List<Quini> lQuiniAnual = new List<Quini>();
            try
            {
                for (Byte i = 1; i <= 12; i++)
                {
                    lQuini = Get(i, yyyy);
                    lQuiniAnual.AddRange(lQuini);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lQuiniAnual;
        }

        public string ValidarFecha(Byte dd, Byte mm, int yyyy)
        {
            DateTime dt1 = DateTime.Now;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
            var styles = DateTimeStyles.None;
            StringBuilder sbFecha = new StringBuilder();
            bool fechaValida = false;
            try
            {

                if (dd > DateTime.Now.Day && mm == DateTime.Now.Month && yyyy == DateTime.Now.Year)
                {
                    return string.Empty;
                }

                if (dd < 10)
                {
                    sbFecha.Append("0");
                }
                sbFecha.Append(dd);
                sbFecha.Append("/");

                if (mm < 10)
                {
                    sbFecha.Append("0");
                }
                sbFecha.Append(mm);
                sbFecha.Append("/");
                sbFecha.Append(yyyy);

                fechaValida = DateTime.TryParse(sbFecha.ToString(), culture, styles, out dt1);

                if (!fechaValida)
                {
                    sbFecha.Clear();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return sbFecha.ToString();
        }





    }
}
