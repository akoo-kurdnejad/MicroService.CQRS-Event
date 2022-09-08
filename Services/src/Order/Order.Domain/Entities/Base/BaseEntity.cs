using System.ComponentModel.DataAnnotations;

namespace Order.Domain.Entities.Base
{
    public class BaseEntity 
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
