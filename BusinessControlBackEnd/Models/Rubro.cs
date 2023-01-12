namespace BusinessControlBackEnd.Models
{
    public class Rubro
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Store> Stores { get; set; }
    }

}