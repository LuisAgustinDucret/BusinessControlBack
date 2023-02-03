using System.ComponentModel;

public class ProductCreateUpdateDTO 
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public int CategoriaId { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public decimal Cantidad { get; set; }
    public int UnidadMedidaId { get; set; }

    public int? CompoundProductId { get; set; }

    [DefaultValue(false)]
    public bool IsCompoundProduct { get ; set; }

}
