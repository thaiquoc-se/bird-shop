using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblOrder
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int? TimeId { get; set; }
        public string? ReasonContent { get; set; }
        public string? TypeOrder { get; set; }
        public bool? OrderStatus { get; set; }

        public virtual TblTime? Time { get; set; }
        public virtual TblUser User { get; set; } = null!;
        public virtual TblOrderDetail? TblOrderDetail { get; set; }
    }
}
