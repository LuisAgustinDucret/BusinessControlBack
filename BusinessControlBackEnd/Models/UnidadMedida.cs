using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessControlBackEnd.Models
{
    public class UnidadMedida
    {
        public int Id { get; set; }

        [EnumDataType(typeof(DescripcionUMEnum))]
        public DescripcionUMEnum Description { get; set; }

        [Column(TypeName = "varchar"), MaxLength(3)]
        public string Abreviatura { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
