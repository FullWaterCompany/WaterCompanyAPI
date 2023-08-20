using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public partial class Invoice
    {
        public string Id { get; set; } = null!;
        public string? Year { get; set; }
        public int? RealStateType { get; set; }
        public string? SubscriptionNo { get; set; }
        public string? SubscriberNo { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? PreviousConsumption { get; set; }
        public int? CurrentConsumption { get; set; }
        public int? AmountConsumption { get; set; }
        public decimal? ServiceFee { get; set; }
        public decimal? TaxRate { get; set; }
        public bool? IsThereSanitation { get; set; }
        public decimal? ConsumptionValue { get; set; }
        public decimal? WastewaterConsumption { get; set; }
        public decimal? TotalInvoice { get; set; }
        public decimal TaxValue { get; set; }
        public decimal? TotalBill { get; set; }
        public string? Notes { get; set; }
        [JsonIgnore]
        public virtual RealStateType? RealStateTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual Subscriber? SubscriberNoNavigation { get; set; }
        [JsonIgnore]
        public virtual Subscription? SubscriptionNoNavigation { get; set; }
    }
}
