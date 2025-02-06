using Carter;
using Customers.Api.Data.Entities;
using Mapster;
using MediatR;

namespace Microstore.Services.CatalogApi.Customers.UpdateCustomer;

public record UpdateCustomerRequest
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
);

public record UpdateCustomerResponse(bool IsSuccess);

public class UpdateCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/customers", async (UpdateCustomerRequest request, ISender sender) =>
        {
            UpdateCustomerCommand command = request.Adapt<UpdateCustomerCommand>();
            UpdateCustomerResult result = await sender.Send(command);
            UpdateCustomerResponse response = result.Adapt<UpdateCustomerResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateCustomer")
        .Produces<UpdateCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update Customer")
        .WithDescription("Update Customer");
    }
}
