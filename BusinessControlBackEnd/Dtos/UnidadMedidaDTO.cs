using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Dtos
{
    public class UnidadMedidaDTO
    {
        public int Id { get; set; }
        public int Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public bool Active { get; set; }

    }
}