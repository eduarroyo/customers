using BuildingBlocks.Exceptions;

namespace Customers.Api.Exceptions;

public class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(Guid customerId): base($"Customer with id {customerId} not found")
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; }
}
