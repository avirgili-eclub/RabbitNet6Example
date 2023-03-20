namespace Ordering.Domain.SeedWork;

public class BaseEntity
{
    //Aqui deberia ir Id, Fecha_Creacion, Fecha_edicion, Actualizado_Por, etc.
    //TODO: buenas practicas tener dos IDs, uno Guid y el otro AutoIncrementable. Guid exponer externamente y 
    //autoincrementable para uso interno.
    public Guid Id { get; set; }
}