using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class EventCategory
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
