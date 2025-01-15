using System.ComponentModel.DataAnnotations;


namespace Ecommerce.Domain.Entity
{
    public class Role
    {
        [Key]
        public int Id{ get; set; }
        public required string Name { get; set; }
    }
}
