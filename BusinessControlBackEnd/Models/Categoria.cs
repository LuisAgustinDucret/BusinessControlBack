using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessControlBackEnd.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}