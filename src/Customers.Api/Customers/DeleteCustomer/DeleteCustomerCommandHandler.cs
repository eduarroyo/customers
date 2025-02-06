using BuildingBlocks.CQRS;
using Customers.Api.Data;
using Customers.Api.Data.Entities;
using Customers.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Customers.Api.Customers.DeleteCustomer;

public record DeleteCustomerCommand(Guid Id) : ICommand<DeleteCustomerResult>;

public record DeleteCustomerResult(bool IsSuccess);

public class DeleteCustomerCommandHandler
    (CustomersContext dbContext)
    : ICommandHandler<DeleteCustomerCommand, DeleteCustomerResult>
{
    public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        Customer? toDelete = await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == command.Id, cancellationToken);

        if(toDelete is null)
        {
            throw new CustomerNotFoundException(command.Id);
        }

        dbContext.Customers.Remove(toDelete);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteCustomerResult(true);
    }
}