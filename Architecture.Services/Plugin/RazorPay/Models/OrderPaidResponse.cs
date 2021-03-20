using Newtonsoft.Json;

namespace Architecture.Services.Plugin.RazorPay.Models
{
    public partial class OrderPaidResponse
    {
        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("contains")]
        public string[] Contains { get; set; }

        [JsonProperty("payload")]
        public Payload Payload { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }

    public partial class Payload
    {
        [JsonProperty("payment")]
        public OrderPaidPayment Payment { get; set; }

        [JsonProperty("order")]
        public OrderPaidOrder Order { get; set; }
    }

    public partial class OrderPaidOrder
    {
        [JsonProperty("entity")]
        public OrderEntity Entity { get; set; }
    }

    public partial class OrderEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("amount_paid")]
        public long AmountPaid { get; set; }

        [JsonProperty("amount_due")]
        public long AmountDue { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("receipt")]
        public string Receipt { get; set; }

        [JsonProperty("offer_id")]
        public object OfferId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("attempts")]
        public long Attempts { get; set; }


        [JsonProperty("notes")]
        public object[] Notes { get; set; }


        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }

    public partial class NotesPaidPayment
    {
        [JsonProperty("address")]
        public string Address { get; set; }
    }
    public partial class OrderPaidPayment
    {
        [JsonProperty("entity")]
        public PaymentEntity Entity { get; set; }
    }

    public partial class OrderPaidCard
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
    public partial class PaymentEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

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
        public OrderPaidCard Card { get; set; }

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
        public NotesPaidPayment Notes { get; set; }
        [JsonProperty("fee")]
        public long Fee { get; set; }

        [JsonProperty("tax")]
        public long Tax { get; set; }

        [JsonProperty("error_code")]
        public object ErrorCode { get; set; }

        [JsonProperty("error_description")]
        public object ErrorDescription { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }
}
