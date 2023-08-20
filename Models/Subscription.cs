using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string Id { get; set; } = null!;
        public string? SubscriberCode { get; set; }
        public int? RealStateType { get; set; }
        public int? UnitNo { get; set; }
        public bool? IsThereSanitation { get; set; }
        public int? LastReading { get; set; }
        public string? Notes { get; set; }
        
        public virtual RealStateType? RealStateTypeNavigation { get; set; }
       
        public virtual Subscriber? SubscriberCodeNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
