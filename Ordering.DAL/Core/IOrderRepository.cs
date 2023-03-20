using Ordering.Domain.OrderModel;

namespace Ordering.DAL.Core;

public interface IOrderRepository  : IGenericRepository<Order>
{
  //De ser necesario crear una nueva funcion si es muy especifica.
}

