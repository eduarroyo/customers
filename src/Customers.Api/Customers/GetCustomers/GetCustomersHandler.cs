using BuildingBlocks.CQRS;
using Customers.Api.Data;
using Customers.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customers.Api.Customers.GetCustomers;

public record GetCustomersQuery(int PageNumber = 1, int PageSize = 10) : IQuery<GetCustomersResult>;

public record GetCustomersResult(IEnumerable<Customer> Customers);

public class GetCustomersQueryHandler
    (CustomersContext context)
    : IQueryHandler<GetCustomersQuery, GetCustomersResult>
{
    public async Task<GetCustomersResult> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
    {
        IEnumerable<Customer> customers = await context.Customers
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);
        return new GetCustomersResult(customers);
    }
}
