using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Architecture.Utility
{
    public class EmailConfigration
    {
        private readonly IConfiguration _config;
        private IHostingEnvironment _env;

        public EmailConfigration(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        private MailMessage GetMailMessage(string Email, string link)
        {
            // mail message
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_config["EmailCredentials:EmailUsername"]);
            mail.To.Add(Email);
            mail.Subject = "";
            mail.Body = link;
            mail.IsBodyHtml = true;
            return mail;
        }

        public async Task<string> SendExceptionNotificationEmail(string Email, string HTMLContent = null)
        {
            // mail message
            var mail = GetMailMessage(Email, HTMLContent);
            mail.Subject = "Exception Occurred in ECommerce Application";
            //get email template
            mail.Body = HTMLContent;
            // Smtp client
            await SendEmail(mail);
            return await Task.FromResult("Email Sent Successfully!");
        }

        //public async Task<string> SendForgotPasswordLink(string Email, string token, string link, string HTMLContent = null)
        //{
        //    // mail message
        //    var mail = GetMailMessage(Email, link);
        //    mail.Subject = "Forgot Password";
        //    //get email template
        //    mail.Body = GenerateForgetPasswordMailBody(Email, token, link, HTMLContent);

        //    // Smtp client
        //    await SendEmail(mail);
        //    return await Task.FromResult("Email Sent Successfully!");
        //}


        //public async Task<string> SendVerifyEmailLink(string Email, string link, string HTMLContent = null)
        //{
        //    // mail message
        //    var mail = GetMailMessage(Email, link);
        //    mail.Subject = "Verify Email";
        //    //get email template
        //    mail.Body = GenerateVerifyEmailBody(Email, link, HTMLContent);

        //    // Smtp client
        //    await SendEmail(mail);
        //    return await Task.FromResult("Email Sent Successfully!");
        //}


        //public async void SendOrderEmail(string Email, Orders orders, List<OrderEmailResponseModel> orderItems, UserAddressesEntity DeliveryAddressEntity, string HTMLContent = null)
        //{
        //    // mail message
        //    // var mail = GetMailMessage(Email, model);
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress(_config["EmailCredentials:EmailUsername"]);
        //    mail.To.Add(Email);
        //    mail.Subject = "";
        //    mail.Body = orders.OrderNumber;
        //    mail.IsBodyHtml = true;
        //    mail.Subject = "Order Created";

        //    //get email template
        //    mail.Body = GenerateOrderEmailBody(Email, orders, orderItems, DeliveryAddressEntity, HTMLContent);
        //    var AttachmentInBytes = createPdf(mail.Body);
        //    mail.Attachments.Add(new Attachment(new MemoryStream(AttachmentInBytes), orders.OrderNumber + ".pdf"));
        //    // Smtp client
        //    await SendEmail(mail);
        //}


        public string GetOrderEmailTemplate()
        {
            var stringContent = string.Empty;
            var pathToFile = _env.WebRootPath
                                   + Path.DirectorySeparatorChar.ToString()
                                   + "EmailTemplate"
                                   + Path.DirectorySeparatorChar.ToString()
                                   + "OrderEmailTemplate.html";
            using (StreamReader reader = File.OpenText(pathToFile))
            {
                stringContent = reader.ReadToEnd();
            }
            return stringContent;
        }

        public string GetVerifyEmailTemplate()
        {
            var stringContent = string.Empty;
            var pathToFile = _env.WebRootPath
                                   + Path.DirectorySeparatorChar.ToString()
                                   + "EmailTemplate"
                                   + Path.DirectorySeparatorChar.ToString()
                                   + "VerifyEmailTemplate.html";
            using (StreamReader reader = File.OpenText(pathToFile))
            {
                stringContent = reader.ReadToEnd();
            }
            return stringContent;
        }


        public string GetForgotPasswordLinkEmailTemplate()
        {
            var stringContent = string.Empty;
            var pathToFile = _env.WebRootPath
                                   + Path.DirectorySeparatorChar.ToString()
                                   + "EmailTemplate"
                                   + Path.DirectorySeparatorChar.ToString()
                                   + "ForgotPasswordLinkEmailTemplate.html";
            using (StreamReader reader = File.OpenText(pathToFile))
            {
                stringContent = reader.ReadToEnd();
            }
            return stringContent;
        }


        #region PRIVATE METHODS

        private async Task<bool> SendEmail(MailMessage mail)
        {
            var credentials = new NetworkCredential(_config["EmailCredentials:EmailUsername"], _config["EmailCredentials:EmailPassword"]);
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = _config["EmailCredentials:EmailHost"];
                smtp.EnableSsl = Convert.ToBoolean(_config["EmailCredentials:EnableSsl"]);
                smtp.UseDefaultCredentials = Convert.ToBoolean(_config["EmailCredentials:UseDefaultCredentials"]);
                smtp.Credentials = credentials;
                smtp.Port = Convert.ToInt32(_config["EmailCredentials:EmailPort"]);
                smtp.Send(mail);
                return await Task.FromResult(true);
            }
        }


        //private string GenerateOrderEmailBody(string Email, Orders orders, List<OrderEmailResponseModel> orderItems, UserAddressesEntity DeliveryAddressEntity, string HTMLContent)
        //{
        //    CurrencyEntity curr = JsonSerializeDeserializer.JSONStringToObject<CurrencyEntity>(orders.Currency.ToSafeString());
        //    string Body = string.Empty;
        //    if (HTMLContent.CheckIsNull())
        //    {
        //        Body = GetOrderEmailTemplate();
        //    }
        //    else
        //    {
        //        Body = HTMLContent;
        //    }
        //    Body = Body.Replace("{Email}", Email);
        //    Body = Body.Replace("{OrderNumber}", orders.OrderNumber.ToString());
        //    Body = Body.Replace("{CreatedDate}", orders.CreatedDate.ToString());
        //    Body = Body.Replace("{SubTotal}", curr.NullToEmpty().CurrencySymbol.ToSafeString() + orders.OrderTotal.ToString());
        //    Body = Body.Replace("{Total}", curr.NullToEmpty().CurrencySymbol.ToSafeString() + orders.OrderTotal.ToString());
        //    Body = Body.Replace("{NAME}", DeliveryAddressEntity.NullToEmpty().Name);
        //    Body = Body.Replace("{CONTACTNUMBER}", DeliveryAddressEntity.NullToEmpty().Mobile);
        //    Body = Body.Replace("{ADDRESS}", string.Join(",",
        //        DeliveryAddressEntity.NullToEmpty().Street1,
        //        DeliveryAddressEntity.NullToEmpty().Street2,
        //        DeliveryAddressEntity.NullToEmpty().City,
        //        DeliveryAddressEntity.NullToEmpty().State,
        //        DeliveryAddressEntity.NullToEmpty().Country,
        //        DeliveryAddressEntity.NullToEmpty().PinCode));

        //    string htmlTrStart = "<tr>";
        //    string htmlTrEnd = "</tr>";
        //    string htmlTdStartLeftAlign = "  <td style=\"text-align:left;vertical-align:middle;border:0px solid #eee;word-wrap:break-word;color:black;padding:12px;width:80%;\" colspan=2>";
        //    string htmlTdStartRightAligh = " <td style=\"text-align:right;vertical-align:middle;border:1px solid #eee;word-wrap:break-word;color:black;padding:12px\">";
        //    string htmlTdEnd = "</td>";
        //    string DIVStart = "<div>";
        //    string DIVWithFlexStart = "<div style=\"display: flex\">";
        //    string DIVWithPaddingLR = "<div style=\"margin: 0 10px;\">";
        //    string DIVEnd = "</div>";
        //    string StrongStart = "<strong>";
        //    string StrongEnd = "</strong>";
        //    string htmlImgstart = "<img src=\"";
        //    string htmlImgEnd = "\" width=\"100\" height=\"100\"/>";
        //    string messageBody = "";
        //    foreach (var item in orderItems)
        //    {

        //        item.MediaFile = _config["APISettings:URL"] + item.MediaFile;

        //        messageBody = messageBody + htmlTrStart;
        //        messageBody = messageBody +
        //            htmlTdStartLeftAlign +
        //                DIVWithFlexStart +
        //                    htmlImgstart + item.MediaFile +
        //                    htmlImgEnd +
        //                    DIVWithPaddingLR +
        //                        StrongStart + item.ProductName +
        //                        StrongEnd +
        //                        DIVStart + "QTY: " + item.Quantity +
        //                        DIVEnd +
        //                    DIVEnd +
        //                DIVEnd +
        //            htmlTdEnd;
        //        //messageBody = messageBody + htmlTdStartLeftAlign + item.Quantity + htmlTdEnd;
        //        messageBody = messageBody + htmlTdStartRightAligh + curr.NullToEmpty().CurrencySymbol.ToSafeString() + item.UnitPrice + htmlTdEnd;
        //        messageBody = messageBody + htmlTrEnd;
        //    }

        //    Body = Body.Replace("{Note}", orders.Note);
        //    Body = Body.Replace("{messageBody}", messageBody);
        //    return Body;
        //}
        private string GenerateVerifyEmailBody(string Email, string link, string HTMLContent)
        {
            string Body = string.Empty;
            if (HTMLContent.CheckIsNull())
            {
                Body = GetVerifyEmailTemplate();

            }
            else
            {
                Body = HTMLContent;
            }
            Body = Body.Replace("{Email}", Email);
            Body = Body.Replace("{link}", link);
            return Body;
        }
        private string GenerateForgetPasswordMailBody(string Email, string token, string link, string HTMLContent)
        {
            string Body = string.Empty;
            if (HTMLContent.CheckIsNull())
            {

                Body = GetForgotPasswordLinkEmailTemplate();
            }
            else
            {
                Body = HTMLContent;
            }
            Body = Body.Replace("{token}", token);
            Body = Body.Replace("{Email}", Email);
            Body = Body.Replace("{link}", link);
            return Body;
        }
        #endregion
    }
}