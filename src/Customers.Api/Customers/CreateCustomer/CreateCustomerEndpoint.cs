using Carter;
using Customers.Api.Data.Entities;
using Mapster;
using MediatR;

namespace Customers.Api.Customers.CreateCustomer;

public record CreateCustomerRequest
(
    string Name,
    string Surname,
    EGender Gender,
    DateTime BirthDate,
    string Email,
    string Address = default!,
    string Country = default!,
    string PostalCode = default!
);

public record class CreateCustomerResponse(Guid Id);

public class CreateCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/customers", async (CreateCustomerRequest request, ISender sender) =>
        {
            CreateCustomerCommand command = request.Adapt<CreateCustomerCommand>();
            CreateCustomerResult result = await sender.Send(command);
            CreateCustomerResponse response = result.Adapt<CreateCustomerResponse>();

            return Results.Created($"/customers/{response.Id}", response);
        })
        .WithName("CreateCustomer")
        .Produces<CreateCustomerResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Customer")
        .WithDescription("Create Customer");
    }
}
