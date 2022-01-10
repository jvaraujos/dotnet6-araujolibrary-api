using System;
using System.ComponentModel.DataAnnotations;

namespace JvA.Library.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
