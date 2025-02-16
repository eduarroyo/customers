namespace Customers.Api.Data.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public EGender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string Email { get; set; } = default!;
}

public enum EGender
{
    Male,
    Female,
    Other
}