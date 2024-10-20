using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblComment
    {
        public int CommentId { get; set; }
        public int BirdId { get; set; }
        public int UserId { get; set; }
        public DateTime? CommentDate { get; set; }
        public string? Content { get; set; }
        public int? Rating { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
