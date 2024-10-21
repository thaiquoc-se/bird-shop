using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string? ReasonContent { get; set; }
        public string? TypeOrder { get; set; }
        public string? OrderStatus { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]

        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public string ShipAddress { get; set; } = null!;

        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
