using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public partial class TblStaff
    {
        public int StaffId { get; set; }
        public int UserId { get; set; }
        public string? WorkDescription { get; set; }
        public string? WorkName { get; set; }
        public string? Shift { get; set; }
        public string? WorkStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public virtual TblUser User { get; set; } = null!;
    }
}
