using BusinessControlBackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessControlBackEnd.Dtos
{
    public class UnidadMedidaDTO
    {
        public int Id { get; set; }
        [EnumDataType(typeof(DescripcionUMEnum))]
        public string Description { get; set; }
        public string Abreviatura { get; set; }
        public bool Active { get; set; }

    }
}