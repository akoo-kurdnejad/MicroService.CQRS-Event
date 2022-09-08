using System.ComponentModel.DataAnnotations;

namespace Basket.Domain.Entities.Base
{
    public class BaseEntity 
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
