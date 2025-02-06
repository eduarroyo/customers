namespace Customers.Api.Data.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public EGender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
}

public enum EGender
{
    Male,
    Female,
    Other
}