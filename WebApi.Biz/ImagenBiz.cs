using System.Collections.Generic;
using WebApi.Data;
using WebApi.Entity;
using System.Net;
using System.Net.Mail;

namespace WebApi.Biz
{
    public class ImagenBiz
    {
        private readonly string _ConectionString = string.Empty;
        
        public ImagenBiz(string ConnectionString)
        {
            _ConectionString = ConnectionString;
        }

        public List<ImagenTest> List() 
        {
            ImagenTestData Serv = new ImagenTestData(_ConectionString);
            return Serv.List();
        }

        public void Insert(ImagenTest imagenTest) 
        {
            ImagenTestData Serv = new ImagenTestData(_ConectionString);
            Serv.Insert(imagenTest);
        }

        public void Delete(int Id) 
        {
            ImagenTestData Serv = new ImagenTestData(_ConectionString);
            Serv.Delete(Id);
        }

        public void SendMail(string from, string password, string to, string subject, string body, string[] archivosAdjuntos) 
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true; // o false si es texto plano


            //Attachment.

            // Agregar archivos adjuntos
            //if (archivosAdjuntos != null)
            //{
            //    foreach (string archivo in archivosAdjuntos)
            //    {
            //        if (System.IO.File.Exists(archivo))
            //        {
            //            Attachment adjunto = new Attachment(archivo);
            //            mail.Attachments.Add(adjunto);
            //        }
            //    }
            //}


            //mail.Attachments.Add()
            // Configurar cliente SMTP (ejemplo con Gmail)
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }


    }
}
