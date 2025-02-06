using Customers.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Api.Data;

public class CustomersContext: DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildCustomerEntity(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerSeed());
    }

    private void BuildCustomerEntity(ModelBuilder modelBuilder)
    {
        EntityTypeBuilder<Customer> customerEntityBuilder = modelBuilder.Entity<Customer>();
        customerEntityBuilder
            .ToTable("Customers")
            .HasKey(c => c.Id);

        customerEntityBuilder
            .Property(c => c.Name)
            .HasMaxLength(200)
            .IsRequired();

        customerEntityBuilder
            .Property(c => c.Surname)
            .HasMaxLength(200)
            .IsRequired();

        customerEntityBuilder
            .Property(c => c.Gender)
            .HasConversion(
                g => g.ToString(),
                g => (EGender)Enum.Parse(typeof(EGender), g)
            );

        customerEntityBuilder
            .Property(c => c.BirthDate)
            .IsRequired()
            .HasConversion(
                g => g.Date,
                g => g.Date
            );

        customerEntityBuilder
            .Property(c => c.Address)
            .HasMaxLength(500);

        customerEntityBuilder
            .Property(c => c.Country)
            .HasMaxLength(200);

        customerEntityBuilder
            .Property(c => c.PostalCode)
            .HasMaxLength(20);

        customerEntityBuilder
            .Property(c => c.Email)
            .HasMaxLength(320)
            .IsRequired();
    }
}
