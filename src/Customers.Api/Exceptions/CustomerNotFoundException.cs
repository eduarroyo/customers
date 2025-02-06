namespace Customers.Api.Exceptions;

public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException(Guid customerId): base($"Customer with id {customerId} not found")
    {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; }
}
