using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ordering.Domain.SeedWork;

namespace Ordering.Domain.OrderModel;

[Table("order")]
public class Order : BaseEntity
{

    public int OrderId { get; set; }

    [Display(Name ="Descripcion")]
    public string Description { get; set; }

    [Display(Name = "Codigo")]
    public string Code { get; set; }
    [Display(Name = "ClientId")]
    public int ClientId { get; set; }

}