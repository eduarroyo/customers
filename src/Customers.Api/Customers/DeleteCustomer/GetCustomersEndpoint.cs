using Carter;
using Customers.Api.Data.Entities;
using Mapster;
using MediatR;

namespace Customers.Api.Customers.DeleteCustomer;

public record GetCustomersRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetCustomersResponse(IEnumerable<Customer> Customers);

public class GetCustomersEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapGet("/customers", async ([AsParameters] GetCustomersRequest request, ISender sender) =>
        {
            GetCustomersQuery query = request.Adapt<GetCustomersQuery>();
            GetCustomersResult result = await sender.Send(query);
            GetCustomersResponse response = result.Adapt<GetCustomersResponse>();
            return Results.Ok(response);
        })
        .WithName("GetCustomers")
        .Produces<GetCustomersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get customers")
        .WithDescription("Get all customers");

    }
}
