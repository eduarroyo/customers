using BuildingBlocks.CQRS;
using Customers.Api.Data;
using Customers.Api.Data.Entities;
using Customers.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Microstore.Services.CatalogApi.Customers.UpdateCustomer;

public record UpdateCustomerCommand
(
    Guid Id,
    string Name,
    string Surname,
    EGender Gender,
    DateTime BirthDate,
    string Email,
    string Address = default!,
    string Country = default!,
    string PostalCode = default!
) : ICommand<UpdateCustomerResult>;

public record UpdateCustomerResult(bool IsSuccess);

internal class UpdateCustomerCommandHandler
    (CustomersContext dbContext)
    : ICommandHandler<UpdateCustomerCommand, UpdateCustomerResult>
{
    public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        Customer? customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == command.Id, cancellationToken);
        if (customer is null)
        {
            throw new CustomerNotFoundException(command.Id);
        }

        customer.Name = command.Name;
        customer.Surname = command.Surname;
        customer.Gender = command.Gender;
        customer.BirthDate = command.BirthDate;
        customer.Email = command.Email;
        customer.Address = command.Address;
        customer.Country = command.Country;
        customer.PostalCode = command.PostalCode;

        dbContext.Customers.Update(customer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCustomerResult(true);
    }
}