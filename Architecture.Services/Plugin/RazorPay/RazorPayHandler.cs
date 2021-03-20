using Microsoft.Extensions.Configuration;
using Razorpay.Api;
using Razorpay.Api.Errors;
using System;
using System.Collections.Generic;

namespace Architecture.Services.Plugin.RazorPay
{
    public class RazorPayHandler
    {
        private readonly string razorkey;
        private readonly string secret;
        private readonly string WebHookSecret;
        private IConfiguration _config;
        public RazorPayHandler(IConfiguration config)
        {
            _config = config;
            razorkey = Convert.ToString(_config["RazorPayConfiguration:key_id"]);
            secret = Convert.ToString(_config["RazorPayConfiguration:key_secret"]);
            WebHookSecret = Convert.ToString(_config["RazorPayConfiguration:webhookSecret"]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"> In Actual amount. We convert it to paisa and send to RazorPay.</param>
        /// <param name="currencyCode"> Currency Code = INR.</param>
        /// <param name="receipt"></param>
        /// <returns></returns>
        /// TO use this  Razorpay.Api.Order RZOrder = _razorPayHandler.CreateOrder(CreateOrders.OrderTotal, currencyInfo.CurrencyCode, JsonSerializeDeserializer.JsonString((OrderId: CreateOrders.Id, CreateOrders.OrderNumber)));
        public Order CreateOrder(decimal amount, string currencyCode, string receipt = "")
        {
            RazorpayClient client = new RazorpayClient(razorkey, secret);
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", amount * 100);
            input.Add("receipt", receipt);
            input.Add("currency", currencyCode);
            input.Add("payment_capture", "1");
            Order order = client.Order.Create(input);
            return order;
        }
        public bool ValidateWebHook(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
        {
            try
            {
                Utils.verifyWebhookSignature(razorpay_order_id + '|' + razorpay_payment_id, razorpay_signature, WebHookSecret);
                RazorpayClient client = new RazorpayClient(razorkey, secret);
                Payment payment = client.Payment.Fetch(razorpay_payment_id);
            }
            catch (BadRequestError ex)
            {
            }
            catch (SignatureVerificationError ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public bool ValidatePayment(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
        {
            try
            {
                Dictionary<string, string> attributes = new Dictionary<string, string>();

                attributes.Add("razorpay_order_id", razorpay_order_id);
                attributes.Add("razorpay_payment_id", razorpay_payment_id);
                attributes.Add("razorpay_signature", razorpay_signature);
                Utils.verifyPaymentSignature(attributes);
            }
            catch (BadRequestError ex)
            {
            }
            catch (SignatureVerificationError ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public Payment PaymentCapture(string amountToBeCaptured, string currency)
        {
            RazorpayClient client = new RazorpayClient(razorkey, secret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amountToBeCaptured);
            options.Add("currency", currency);
            Payment payment = client.Payment.Capture(options);
            return payment;
        }
    }
}
