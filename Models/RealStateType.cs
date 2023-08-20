using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class RealStateType
    {
        public RealStateType()
        {
            Invoices = new HashSet<Invoice>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [JsonIgnore]
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
