using System.ComponentModel.DataAnnotations;


namespace Ecommerce.Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Name { get; set; }
    }
}
