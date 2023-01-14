using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BusinessControlBackEnd.Models
{
    public class UnidadMedida
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public DescripcionUMEnum Description { get; set; }
        [MaxLength(3)]
        public string Abreviatura { get; set; }
        public bool Active { get; set; }

    }
}
