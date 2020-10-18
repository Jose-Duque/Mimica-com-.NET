using ProjectAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProjectAspNet.Library.Mail
{
    public class EnviarEmail
    {
       public static void EnviarMsgContato(Contato contato)
        {
            string conteudo = string.Format("Nome: {0}<br/> E-mail: {1}<br/> Assunto: {2}<br/> Mensagem: {3} ", contato.Name, contato.Email, contato.Assunto, contato.Msg);

            // Configuração do Servidor SMTP
            SmtpClient smtp = new SmtpClient(Constants.ServerSMTP, Constants.PortSMTP);
            smtp.EnableSsl = true; //Protocolo seguro
            smtp.UseDefaultCredentials = false; // Não usar modo de credencial padrão
            smtp.Credentials = new NetworkCredential(Constants.User, Constants.Password);

            // Mensagem de Email
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("joseduquefilho03@gmail.com");
            msg.To.Add("joseduquefilho03@gmail.com");
            msg.Subject = "Formulário de contato";

            msg.IsBodyHtml = true;
            msg.Body = "<h1>Formulario de contato </h1> " + conteudo ;

            // Para enviar
            smtp.Send(msg);
        }
       
    }
}
