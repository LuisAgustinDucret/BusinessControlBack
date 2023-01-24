
namespace BusinessControlBackEnd.Dtos
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int RubroId { get; set; }
        public RubroDTO Rubro { get; set; }

    }
}
