using Microsoft.EntityFrameworkCore;
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
        // initialise policy data // SEED 
        modelBuilder.Entity<InsuranceType>().HasData(
            new InsuranceType { id = 1, name = "Tand", type_name = "Tand" }
        );
        // initialise policy data // SEED 
        modelBuilder.Entity<Invoice>().HasData(
            new Invoice { id = 1, costs = 50.25f, created = DateTime.Now, InsuranceTypeId = 1, CustomerId = 1, PolicyId = 1 }
        );
        // initialise customer data // SEED 
        modelBuilder.Entity<Customer>().HasData(
            new Customer { id = 1, customer_number = 1001, name = "Robin", email = "robin@gmail.com", password = "123"}
        );

        // initialise policy data // SEED 
        modelBuilder.Entity<Policy>().HasData(
            new Policy { id = 1, policy_nr = 1, policy_name = "Interpolis 1", insurance = "My insurance", costs = 120.50f, active=true, CustomerId=1}
        );
        // initialise policy data // SEED 
        modelBuilder.Entity<AdditonalInsurrance>().HasData(
            new AdditonalInsurrance { id = 1, name = "Tand 1", max_coverage=500, percentage_coverage=80, InsuranceTypeId=1 }
        );




    }
}