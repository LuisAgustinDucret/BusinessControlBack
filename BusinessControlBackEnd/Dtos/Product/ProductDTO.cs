
namespace BusinessControlBackEnd.Dtos
{
    public class ProductDTO : ProductCreateUpdateDTO
    {
        public CategoriaDTO Categoria { get; set; }
        public UnidadMedidaDTO UnidadMedida { get; set; }
    }
}
