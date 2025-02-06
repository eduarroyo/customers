using Customers.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Api.Data;

public class CustomerSeed: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            new Customer
            {
                Id = Guid.Parse("587f00f2-66b5-4f46-af06-3a75232ff8c3"),
                Name = "John",
                Surname = "Doe",
                Gender = EGender.Male,
                BirthDate = new DateTime(1980, 5, 4),
                Address = "123 Main",
                Country = "Spain",
                PostalCode = "12345",
                Email = "johndoe@fakeserver.com"
            },
            new Customer
            {
                Id = Guid.Parse("151808be-4000-424f-8990-474ac9e7c68d"),
                Name = "Jane",
                Surname = "Curtis",
                Gender = EGender.Female,
                BirthDate = new DateTime(1985, 9, 4),
                Address = "53 Pepper Av.",
                Country = "Spain",
                PostalCode = "12345",
                Email = "janecurtis@fakeserver.com"
            });

    }
}
