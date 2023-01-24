using BusinessControlBackEnd.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BusinessControlBackEnd.Dtos;

public class ProductViewDTO 
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public int buyPrice { get; set; }
    public int sellPrice { get; set; }
    public decimal Cantidad { get; set; }
}             
