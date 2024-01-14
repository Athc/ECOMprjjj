using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOMMERCE.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public int Id { get; set; }
        
        [Required, MaxLength(20)]
        public string? StatusName { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
