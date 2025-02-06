using Carter;
using Mapster;
using MediatR;

namespace Customers.Api.Customers.DeleteCustomer;

//public record DeleteCustomerRequest();
public record DeleteCustomerResponse(bool IsSuccess);

public class DeleteCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/customers/{id}", async (Guid id, ISender sender) =>
        {
            DeleteCustomerResult result = await sender.Send(new DeleteCustomerCommand(id));
            DeleteCustomerResponse response = result.Adapt<DeleteCustomerResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteCustomers")
        .Produces<DeleteCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Customer")
        .WithDescription("Delete Customer");
    }
}
