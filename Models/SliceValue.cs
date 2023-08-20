using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SliceValue
    {
        public int Id { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
        public int? ValuesCondition { get; set; }
        public decimal? WaterPrice { get; set; }
        public decimal? SanitationPrice { get; set; }
        public string? Notes { get; set; }
    }
}
