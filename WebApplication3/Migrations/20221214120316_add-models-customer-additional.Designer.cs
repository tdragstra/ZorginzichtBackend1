﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20221214120316_add-models-customer-additional")]
    partial class addmodelscustomeradditional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdditonalInsurrancePolicy", b =>
                {
                    b.Property<int>("additional_insurancesid")
                        .HasColumnType("int");

                    b.Property<int>("policiesid")
                        .HasColumnType("int");

                    b.HasKey("additional_insurancesid", "policiesid");

                    b.HasIndex("policiesid");

                    b.ToTable("AdditonalInsurrancePolicy");
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.AdditonalInsurrance", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("InsuranceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("costs")
                        .HasColumnType("int");

                    b.Property<int>("max_coverage")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("InsuranceTypeId");

                    b.ToTable("additional_insurances");

                    b.HasData(
                        new
                        {
                            id = 1,
                            InsuranceTypeId = 1,
                            costs = 0,
                            maxcoverage = 500,
                            name = "Tand 1"
                        });
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("customer_number")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postal_code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("customers");

                    b.HasData(
                        new
                        {
                            id = 1,
                            address = "",
                            city = "",
                            customernumber = 1001,
                            email = "robin@gmail.com",
                            name = "Robin",
                            password = "123",
                            postalcode = ""
                        });
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.InsuranceType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("insurance_types");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Tand",
                            typename = "Tand"
                        });
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.Invoice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("InsuranceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.Property<double>("costs")
                        .HasColumnType("float");

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InsuranceTypeId");

                    b.HasIndex("PolicyId");

                    b.ToTable("invoices");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CustomerId = 1,
                            InsuranceTypeId = 1,
                            PolicyId = 1,
                            costs = 50.25,
                            created = new DateTime(2022, 12, 14, 13, 3, 16, 278, DateTimeKind.Local).AddTicks(519)
                        });
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.Policy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<float?>("costs")
                        .HasColumnType("real");

                    b.Property<string>("insurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("policy_nr")
                        .HasColumnType("int");

                    b.Property<string>("policyname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CustomerId");

                    b.ToTable("policies");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CustomerId = 1,
                            active = true,
                            costs = 120.5f,
                            insurance = "My insurance",
                            policynr = 1,
                            policyname = "Interpolis 1"
                        });
                });

            modelBuilder.Entity("AdditonalInsurrancePolicy", b =>
                {
                    b.HasOne("ZorginzichtBackend.Models.AdditonalInsurrance", null)
                        .WithMany()
                        .HasForeignKey("additional_insurancesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZorginzichtBackend.Models.Policy", null)
                        .WithMany()
                        .HasForeignKey("policiesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.AdditonalInsurrance", b =>
                {
                    b.HasOne("ZorginzichtBackend.Models.InsuranceType", "InsuranceType")
                        .WithMany("additonal_insurrances")
                        .HasForeignKey("InsuranceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsuranceType");
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.Invoice", b =>
                {
                    b.HasOne("ZorginzichtBackend.Models.Customer", "Customer")
                        .WithMany("invoices")
                        .HasForeignKey("CustomerId")
                        .IsRequired();

                    b.HasOne("ZorginzichtBackend.Models.InsuranceType", "InsuranceType")
                        .WithMany("invoices")
                        .HasForeignKey("InsuranceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZorginzichtBackend.Models.Policy", "Policy")
                        .WithMany("Invoices")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("InsuranceType");

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.Policy", b =>
                {
                    b.HasOne("ZorginzichtBackend.Models.Customer", "Customer")
                        .WithMany("policies")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.Customer", b =>
                {
                    b.Navigation("invoices");

                    b.Navigation("policies");
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.InsuranceType", b =>
                {
                    b.Navigation("additonal_insurrances");

                    b.Navigation("invoices");
                });

            modelBuilder.Entity("ZorginzichtBackend.Models.Policy", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
