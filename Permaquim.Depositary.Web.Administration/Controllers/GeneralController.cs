using System.Net.Mail;

namespace Permaquim.Depositary.Web.Administration.Controllers
{
    public static class GeneralController
    {
        public static string EnviarMail(string smtpHost, string smtpPort, string usuarioEmailEnvia, string passwordEmailEnvia, List<string> usuarioEmailsReciben, string asunto, string cuerpo)
        {
            string resultado = "";

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = smtpHost;
            smtpClient.Port = Convert.ToInt16(smtpPort);
            smtpClient.Credentials = new System.Net.NetworkCredential(usuarioEmailEnvia, passwordEmailEnvia);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(usuarioEmailEnvia);

            //if (!ValidarCredencialesMail(usuarioEmailEnvia, passwordEmailEnvia, smtpHost, Convert.ToInt32(smtpPort), true))
            //{
            //    resultado = "Error al intentar loguear a la cuenta de email " + usuarioEmailEnvia;
            //}
            //else
            //{
            if (usuarioEmailsReciben != null)
            {
                foreach (string email in usuarioEmailsReciben)
                {
                    if (!string.IsNullOrEmpty(email))
                    {
                        mailMessage.To.Add(email);
                    }
                }
            }

            mailMessage.Subject = asunto;
            mailMessage.Body = cuerpo;
            mailMessage.IsBodyHtml = true;

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                return ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }

            return resultado;
        }


        public static bool ValidarCredencialesMail(string usuarioEmailEnvia, string passwordEmailEnvia, string smtpHost, int smtpPort, bool validarCertificacion)
        {
            bool resultado = false;
            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    try
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => validarCertificacion;
                        client.Connect(smtpHost, smtpPort, false);
                        client.Authenticate(usuarioEmailEnvia, passwordEmailEnvia);
                        client.Disconnect(true);

                        resultado = true;
                    }
                    catch (Exception ex)
                    {
                        resultado = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;

        }
    }
}
