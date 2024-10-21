using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Bird
    {
        public Bird()
        {
            TblComments = new HashSet<TblComment>();
            TblOrderDetails = new HashSet<TblOrderDetail>();
            Tblchildrenbirds = new HashSet<Tblchildrenbird>();
        }

        public int BirdId { get; set; }
        public string BirdName { get; set; } = null!;
        public int UserId { get; set; }
        public int? Estimation { get; set; }
        public string? Gender { get; set; }
        public double WeightofBirds { get; set; }
        public string? BirdDescription { get; set; }
        public bool? BirdStatus { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Image { get; set; }
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }

        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblComment> TblComments { get; set; }
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
        public virtual ICollection<Tblchildrenbird> Tblchildrenbirds { get; set; }
    }
}
