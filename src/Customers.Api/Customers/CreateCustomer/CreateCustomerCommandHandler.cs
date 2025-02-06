using BuildingBlocks.CQRS;
using Customers.Api.Data;
using Customers.Api.Data.Entities;

namespace Customers.Api.Customers.CreateCustomer;

public record CreateCustomerCommand
(
    string Name,
    string Surname,
    EGender Gender,
    DateTime BirthDate,
    string Email,
    string Address,
    string Country,
    string PostalCode
) : ICommand<CreateCustomerResult>;

public record CreateCustomerResult(Guid Id);

internal class CreateCustomerCommandHandler
    (CustomersContext dbcontext)
    : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        Customer customer = new()
        {
            Name = command.Name,
            Surname = command.Surname,
            Gender = command.Gender,
            BirthDate = command.BirthDate,
            Email = command.Email,
            Address = command.Address,
            Country = command.Country,
            PostalCode = command.PostalCode
        };

        dbcontext.Customers.Add(customer);
        await dbcontext.SaveChangesAsync(cancellationToken);

        return new CreateCustomerResult(customer.Id);
    }
}