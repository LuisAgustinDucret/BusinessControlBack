using Microsoft.EntityFrameworkCore;

namespace BusinessControlBackEnd.Models
{
    public class UnidadMedida
    {
        public int Id { get; set; }
        public DescripcionUMEnum Description { get; set; }
        public string Abreviatura { get; set; }
        public bool Active { get; set; }

    }
}
