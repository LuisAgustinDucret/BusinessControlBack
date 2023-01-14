using System.ComponentModel.DataAnnotations;

namespace BusinessControlBackEnd.Models
{
    public class Store
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool? Active { get; set; }
        public int RubroId { get; set; }
        public Rubro Rubro { get; set; }
    }
}

