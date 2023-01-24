using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessControlBackEnd.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? BuyPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal SellPrice { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cantidad { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int UnidadMedidaId { get; set; }
        public UnidadMedida UnidadMedida { get; set; }

        [DefaultValue(null)]
        public int? CompoundProductId { get; set; }
        public ICollection<ProductStore> StoresFP { get; set; }

    }
}