using System.Net.Mail;
using ToolsQA;
using OpenQA.Selenium;

namespace ToolsQA
{
    public class Functions
    {
        
        public static string SendEmailAttachment(string subject, string body)
        {
            string message = "",
                username = "amrudincatic@hotmail.com",
                password = "??????";


            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.hotmail.com");

                mail.From = new MailAddress("amrudincatic@hotmail.com");
                mail.To.Add("amrudincatic@hotmail.com");
                mail.Subject = subject;
                mail.Body = body;

                System.Net.Mail.Attachment attachment;

                DirectoryInfo d = new DirectoryInfo(@"/Users/amrudincatic/VS_Projects/Screenshoos/");
                FileInfo[] Files = d.GetFiles("*.jpeg", SearchOption.AllDirectories);

                foreach (FileInfo file in Files)
                {
                    attachment = new System.Net.Mail.Attachment(file.FullName);
                    mail.Attachments.Add(attachment);
                }

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                mail.Dispose();

            }
        
            
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            return message;
        }

        public static void TakeScreenShot()
        {
            Random r = new Random();

            ((ITakesScreenshot)Driver.Instance).GetScreenshot().SaveAsFile("/Users/amrudincatic/VS_Projects/Screenshots/" + "/Screenshot" + r.Next(0, 100000) + DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".jpeg", ScreenshotImageFormat.Jpeg);
        }
    }
}