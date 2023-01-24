using System.ComponentModel.DataAnnotations;

namespace BusinessControlBackEnd.Models
{
    public class ProductStore
    {
        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Key]
        public int StoreId { get; set; }
        public Store Store { get; set; }

    }
}

