using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessControlBackEnd.Models
{
    public class Rubro
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
        public ICollection<Store> Stores { get; set; }
    }

}