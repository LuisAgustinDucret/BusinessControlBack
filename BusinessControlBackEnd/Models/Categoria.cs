using System.ComponentModel.DataAnnotations;

namespace BusinessControlBackEnd.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        public bool Active { get; set; }
    }

}