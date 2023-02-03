using BusinessControlBackEnd.Models;
using System.ComponentModel;

namespace BusinessControlBackEnd.Dtos
{
    public class StoreWithProductsDTO
    {
        public int id { get; set; }
        public List<ProductViewDTO> Products { get; set; }
    }
}
 