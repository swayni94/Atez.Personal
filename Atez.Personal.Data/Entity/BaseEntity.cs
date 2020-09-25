using System;
namespace Atez.Personal.Data.Entity
{
    public class BaseEntity
    {
        public int id { get; set; }
        public int CreatedId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public int? UpdatedId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
