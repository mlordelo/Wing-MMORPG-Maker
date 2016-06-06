using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.ComponentModel;

namespace ACESERVER
{
    class Mail
    {
        public static void Send_ActivationCode(int index, string email)
        {
            //Define os dados do e-mail
            string nomeRemetente = Globals.GAME_NAME;
            string emailRemetente = Globals.SMTP_USER;

            Console.WriteLine("Enviado para" + email);

            string emailDestinatario = email;
            string emailComCopia = email;
            string emailComCopiaOculta = email;

            string assuntoMensagem = Globals.GAME_NAME + " - Código de confirmação";

            int code = Globals.Rand(1000, 9999);

            PStruct.tempplayer[index].ActivationCode = code;

            Console.WriteLine(email);

            string conteudoMensagem = "Seu código de ativação é: " + code;

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            try
            {
                objEmail.To.Add(emailDestinatario);
            }
            catch
            {
                SendData.SendToUser(index, String.Format("<5 {0};{1}>h</5>\n", "", ""));
                Database.DeleteAccount(PStruct.player[index].Email);
            }

            //Enviar cópia para.
            //objEmail.CC.Add(emailComCopia);

            //Enviar cópia oculta para.
            //objEmail.Bcc.Add(emailComCopiaOculta);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = assuntoMensagem;

            //Define o corpo do e-mail.
            objEmail.Body = conteudoMensagem;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            SmtpClient SmtpServer = new SmtpClient(Globals.SMTP_SERVER);
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Globals.SMTP_USER, Globals.SMTP_PASS);
            SmtpServer.EnableSsl = true;


            //Enviamos o e-mail através do método .send()
            try
            {
                SmtpServer.SendAsync(objEmail, null);
            }
            catch (Exception ex)
            {
                SendData.SendToUser(index, String.Format("<5 {0};{1}>h</5>\n", "", ""));
                Database.DeleteAccount(PStruct.player[index].Email);
                Console.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }

        }
        public static void Send_Account(int index, int type, string data)
        {

            string user;
            string password;
            string email;

            //Verifica se o arquivo existe
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Data/Accounts/" + data + ".dat"))
            {

                //representa o arquivo
                FileStream file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Data/Accounts/" + data + ".dat", FileMode.Open);

                //cria o leitor do arquivo
                BinaryReader br = new BinaryReader(file);

                //Lê primeiros dados
                email = br.ReadString();
                password = br.ReadString();
                user = br.ReadString();

                //Fecha o leitor
                br.Close();

            }
            else
            {
                SendData.SendToUser(index, String.Format("<5 {0};{1}>o</5>\n", "", ""));
                return;
            }

            //Define os dados do e-mail
            string nomeRemetente = Globals.GAME_NAME;
            string emailRemetente = Globals.SMTP_USER;

            string emailDestinatario = email;
            string emailComCopia = email;
            string emailComCopiaOculta = email;

            string assuntoMensagem = Globals.GAME_NAME + " - Recuperação de conta";
            string conteudoMensagem = "Email: " + email + " Login: " + user + " Senha: " + password ;

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            objEmail.To.Add(emailDestinatario);

            //Enviar cópia para.
            //objEmail.CC.Add(emailComCopia);

            //Enviar cópia oculta para.
            //objEmail.Bcc.Add(emailComCopiaOculta);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = assuntoMensagem;

            //Define o corpo do e-mail.
            objEmail.Body = conteudoMensagem;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


            // Caso queira enviar um arquivo anexo
            //Caminho do arquivo a ser enviado como anexo
            //string arquivo = Server.MapPath("arquivo.jpg");

            // Ou especifique o caminho manualmente
            //string arquivo = @"e:\home\LoginFTP\Web\arquivo.jpg";

            // Cria o anexo para o e-mail
            //Attachment anexo = new Attachment(arquivo, System.Net.Mime.MediaTypeNames.Application.Octet);

            // Anexa o arquivo a mensagemn
            //objEmail.Attachments.Add(anexo);


            SmtpClient SmtpServer = new SmtpClient(Globals.SMTP_SERVER);
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Globals.SMTP_USER, Globals.SMTP_PASS);
            SmtpServer.EnableSsl = true;


            //Enviamos o e-mail através do método .send()
            try
            {
                SmtpServer.SendAsync(objEmail, null);
                SendData.SendToUser(index, String.Format("<5 {0};{1}>k</5>\n", "", ""));
                //Response.Write("E-mail enviado com sucesso !");
            }
            catch (Exception ex)
            {
                SendData.SendToUser(index, String.Format("<5 {0};{1}>o</5>\n", "", ""));
                Console.WriteLine("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }

        }
    }
}
