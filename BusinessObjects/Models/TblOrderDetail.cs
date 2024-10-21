using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblOrderDetail
    {
        public int OrderId { get; set; }
        public int BirdId { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Quantity { get; set; }
        public string? CostsIncurred { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual TblOrder Order { get; set; } = null!;
    }
}
