using Architecture.BusinessLogic;
using Architecture.Services.Plugin.RazorPay;
using Architecture.Services.Plugin.RazorPay.Models;
using Architecture.Utility;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Architechture.Web.Controllers
{
    public class RazorPayWebHookController : Controller
    {
        private readonly RazorPayHandler _razorPayHandler;
        private readonly ILogEntryBL _logEntryBL;

        public RazorPayWebHookController(RazorPayHandler razorPayHandler, ILogEntryBL logEntryBL)
        {
            _logEntryBL = logEntryBL;
            _razorPayHandler = razorPayHandler;
        }

        public IActionResult CreateOrder()
        {
            Order RZOrder = _razorPayHandler.CreateOrder(100, "INR", JsonSerializeDeserializer.JsonString((OrderId: 100, "ORD1000")));
            return View();
        }
        [HttpPost]
        [Route("api/RazorPay/WebHook/PaymentSuccess")]
        public async Task<IActionResult> PaymentSuccess([FromBody] dynamic data)
        {
            try
            {
                string headers = String.Empty;
                foreach (var key in Request.Headers.Keys)
                    headers += key + "=" + Request.Headers[key] + Environment.NewLine;


                var logEntry = new Architecture.Entities.LogEntryEntity()
                {
                    TimeStamp = DateTime.UtcNow,
                    //ActionDescriptor = ActionDescriptor.DisplayName,
                    IpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                    Message = "Successful Payment Received from Payment Gateway",
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    RequestPath = HttpContext.Request.Path,
                    Source = headers,
                    StackTrace = data.ToString(),
                    Type = "PAYMENT SUCCESS LOG",
                };
                _logEntryBL.CreataLogEntry(logEntry);
                OrderPaidResponse payment = JsonSerializeDeserializer.JSONStringToObject<OrderPaidResponse>(data.ToString());
                //await _orderBl.UpdateSuccessPayment(payment);
                return Ok();
            }
            catch (Exception e)
            {
                _logEntryBL.CreataLogEntry(new Architecture.Entities.LogEntryEntity()
                {
                    TimeStamp = DateTime.UtcNow,
                    //ActionDescriptor = ActionDescriptor.DisplayName,
                    IpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                    Message = e.Message,
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    RequestPath = HttpContext.Request.Path,
                    Source = e.Source,
                    StackTrace = e.StackTrace,
                    Type = e.GetType().ToString(),
                });
                return Ok();
            }
        }
        [HttpPost]
        [Route("api/RazorPay/WebHook/PaymentFailed")]
        public async Task<IActionResult> PaymentFailed([FromBody] dynamic data)
        {
            try
            {
                string headers = String.Empty;
                foreach (var key in Request.Headers.Keys)
                    headers += key + "=" + Request.Headers[key] + Environment.NewLine;

                var logEntry = new Architecture.Entities.LogEntryEntity()
                {
                    TimeStamp = DateTime.UtcNow,
                    //ActionDescriptor = ActionDescriptor.DisplayName,
                    IpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                    Message = "Failed Payment Received from Payment Gateway",
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    RequestPath = HttpContext.Request.Path,
                    Source = headers,
                    StackTrace = data.ToString(),
                    Type = "PAYMENT FAILED LOG",
                };
                _logEntryBL.CreataLogEntry(logEntry);
                PaymentFailedResponse payment = JsonSerializeDeserializer.JSONStringToObject<PaymentFailedResponse>(data.ToString());

                //await _orderBl.UpdateFailedPayment(payment);

                return Ok();
            }
            catch (Exception e)
            {
                _logEntryBL.CreataLogEntry(new Architecture.Entities.LogEntryEntity()
                {
                    TimeStamp = DateTime.UtcNow,
                    //ActionDescriptor = ActionDescriptor.DisplayName,
                    IpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                    Message = e.Message,
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    RequestPath = HttpContext.Request.Path,
                    Source = e.Source,
                    StackTrace = e.StackTrace,
                    Type = e.GetType().ToString(),
                });
                return Ok();
            }
        }
    }
}
