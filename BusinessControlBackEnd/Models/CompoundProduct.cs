using System.ComponentModel.DataAnnotations;

namespace BusinessControlBackEnd.Models
{
    public class CompoundProduct
    {
        [Key]
        public int CompoundProductId { get; set; }
        [Key]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
