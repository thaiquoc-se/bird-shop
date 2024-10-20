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
        public string? WeightofBirds { get; set; }
        public string? BirdDescription { get; set; }
        public bool? BirdStatus { get; set; }

        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblComment> TblComments { get; set; }
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
        public virtual ICollection<Tblchildrenbird> Tblchildrenbirds { get; set; }
    }
}
