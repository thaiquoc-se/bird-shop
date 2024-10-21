using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Tblchildrenbird
    {
        public int ChildrenBirdId { get; set; }
        public int? BirdId { get; set; }
        public string? ChildrenBirdName { get; set; }
        public string? ChildrenBirdOfType { get; set; }
        public decimal Price { get; set; }
        public bool? StatusChildrenBird { get; set; }
        public string? Image { get; set; }

        public virtual Bird? Bird { get; set; }
    }
}
