using Newtonsoft.Json;
using System.Collections.Generic;

namespace Architecture.Services.Plugin.RazorPay.Models
{
    public partial class PaymentSuccessResponse
    {
        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("contains")]
        public List<string> Contains { get; set; }

        [JsonProperty("payload")]
        public PayloadSuccess Payload { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }

    public partial class PayloadSuccess
    {
        [JsonProperty("payment")]
        public PaymentSuccess Payment { get; set; }

        [JsonProperty("order")]
        public OrderSuccess Order { get; set; }
    }

    public partial class PaymentSuccess
    {
        [JsonProperty("entity")]
        public EntitySuccess Entity { get; set; }
    }

    public partial class EntitySuccess
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("entity")]
        public string EntityEntity { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("invoice_id")]
        public object InvoiceId { get; set; }

        [JsonProperty("international")]
        public bool International { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("amount_refunded")]
        public long AmountRefunded { get; set; }

        [JsonProperty("refund_status")]
        public object RefundStatus { get; set; }

        [JsonProperty("captured")]
        public bool Captured { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("card_id")]
        public object CardId { get; set; }

        [JsonProperty("card")]
        public CardSuccess Card { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("wallet")]
        public object Wallet { get; set; }

        [JsonProperty("vpa")]
        public object Vpa { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("notes")]
        public NotesSuccess Notes { get; set; }

        [JsonProperty("fee")]
        public object Fee { get; set; }

        [JsonProperty("tax")]
        public object Tax { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error_source")]
        public string ErrorSource { get; set; }

        [JsonProperty("error_step")]
        public string ErrorStep { get; set; }

        [JsonProperty("error_reason")]
        public string ErrorReason { get; set; }

        [JsonProperty("acquirer_data")]
        public AcquirerDataSuccess AcquirerData { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }

    public partial class AcquirerDataSuccess
    {
        [JsonProperty("bank_transaction_id")]
        public string BankTransactionId { get; set; }
    }
    public partial class NotesSuccess
    {
        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public partial class CardSuccess
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last4")]
        public string Last4 { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("issuer")]
        public object Issuer { get; set; }

        [JsonProperty("international")]
        public bool International { get; set; }

        [JsonProperty("emi")]
        public bool Emi { get; set; }
    }

    public partial class OrderSuccess
    {
        [JsonProperty("entity")]
        public OrderEntitySuccess Entity { get; set; }
    }

    public class OrderEntitySuccess
    {
        [JsonProperty("Id")]
        public string id { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("amount_paid")]
        public int AmountPaid { get; set; }

        [JsonProperty("amount_due")]
        public int AmountDue { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("receipt")]
        public string Receipt { get; set; }

        [JsonProperty("offer_id")]
        public object OfferId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("attempts")]
        public int Attempts { get; set; }

        [JsonProperty("notes")]
        public NotesSuccess Notes { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }
}
