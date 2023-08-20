using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Subscriber
    {
        public Subscriber()
        {
            Invoices = new HashSet<Invoice>();
            Subscriptions = new HashSet<Subscription>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? Mobile { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
