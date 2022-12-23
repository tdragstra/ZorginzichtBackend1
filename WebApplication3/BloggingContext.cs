using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using ZorginzichtBackend.Models;


public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions options) : base(options) { }
    public DbSet<Customer> customers { get; set; }
    public DbSet<Policy> policies { get; set; }
    public DbSet<AdditonalInsurrance> additional_insurances { get; set; }
    public DbSet<Invoice> invoices { get; set; }
    public DbSet<InsuranceType> insurance_types { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // initialise insurance type data // SEED 
        modelBuilder.Entity<InsuranceType>().HasData(
            new InsuranceType { id = 1, name = "Tand", type_name = "Tand" },
            new InsuranceType { id = 2, name = "Fysio", type_name = "Fysio" }
        );
  
        modelBuilder.Entity<Invoice>()
            .HasOne(p => p.Customer)
            .WithMany(b => b.invoices)
            .OnDelete(DeleteBehavior.ClientSetNull);


        // initialise invoice data // SEED 
        modelBuilder.Entity<Invoice>().HasData(
            new Invoice { id = 1, costs = 50.25f, created = DateTime.Now, InsuranceTypeId = 1, CustomerId = 1, PolicyId = 1 }
        );
        // initialise customer data // SEED 
        modelBuilder.Entity<Customer>().HasData(
            new Customer { id = 1, customer_number = 1001, name = "Robin", email = "robin@gmail.com", password = "123", postal_code = "5653 LR", address = "Rambam 12", city = "Eindhoven"}
           /* new Customer { id = 99, customer_number = 1011, name = "Leonie Mills", email = "leonie@gmail.com", password = "123", postal_code = "5653 LR", address = "Rambam 12", city = "Eindhoven" }*/
        );

        // initialise policy data // SEED 
        modelBuilder.Entity<Policy>().HasData(
            new Policy { id = 1, policy_nr = 1, policyname = "Interpolis 1", insurance = "My insurance", costs = 120.50f, active=true, CustomerId=1}
            /*new Policy { id = 10, policy_nr = 2, policyname = "Achmea Zorg", insurance = "Zorgverzekering", costs = 120.50f, active = true, CustomerId = 1 }*/
        );
        // initialise additinal inssurence data // SEED 
        modelBuilder.Entity<AdditonalInsurrance>().HasData(
            new AdditonalInsurrance { id = 1, name = "Tand 1", max_coverage=250, InsuranceTypeId=1, costs = 10 },
            new AdditonalInsurrance { id = 2, name = "Tand 2", max_coverage = 500, InsuranceTypeId = 1, costs = 20 },
            new AdditonalInsurrance { id = 3, name = "Tand 3", max_coverage = 750, InsuranceTypeId = 1, costs = 30 },
            new AdditonalInsurrance { id = 4, name = "Fysio 1", max_coverage = 250, InsuranceTypeId = 2, costs = 5 },
            new AdditonalInsurrance { id = 5, name = "Fysio 2", max_coverage = 500, InsuranceTypeId = 2, costs = 10 },
            new AdditonalInsurrance { id = 6, name = "Fysio 3", max_coverage = 750, InsuranceTypeId = 2, costs = 15 }

        );




    }
}