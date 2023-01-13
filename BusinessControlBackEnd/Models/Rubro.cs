using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessControlBackEnd.Models
{
    public class Rubro
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [DefaultValue(true)]
        public bool Active { get; set; }
        public ICollection<Store> Stores { get; set; }
    }

}