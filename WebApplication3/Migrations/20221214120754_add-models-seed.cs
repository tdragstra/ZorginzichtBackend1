using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class addmodelsseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "additional_insurances",
                keyColumn: "id",
                keyValue: 1,
                column: "max_coverage",
                value: 250);

            migrationBuilder.InsertData(
                table: "additional_insurances",
                columns: new[] { "id", "InsuranceTypeId", "costs", "max_coverage", "name" },
                values: new object[,]
                {
                    { 2, 1, 0, 500, "Tand 2" },
                    { 3, 1, 0, 750, "Tand 3" }
                });

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "customer_number", "postal_code" },
                values: new object[] { 1001, "" });

            migrationBuilder.UpdateData(
                table: "insurance_types",
                keyColumn: "id",
                keyValue: 1,
                column: "type_name",
                value: "Tand");

            migrationBuilder.InsertData(
                table: "insurance_types",
                columns: new[] { "id", "name", "type_name" },
                values: new object[] { 2, "Fysio", "Fysio" });

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "id",
                keyValue: 1,
                column: "created",
                value: new DateTime(2022, 12, 14, 13, 7, 54, 172, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "policies",
                keyColumn: "id",
                keyValue: 1,
                column: "policy_nr",
                value: 1);

            migrationBuilder.InsertData(
                table: "additional_insurances",
                columns: new[] { "id", "InsuranceTypeId", "costs", "max_coverage", "name" },
                values: new object[,]
                {
                    { 4, 2, 0, 250, "Fysio 1" },
                    { 5, 2, 0, 500, "Fysio 2" },
                    { 6, 2, 0, 750, "Fysio 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "additional_insurances",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "additional_insurances",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "additional_insurances",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "additional_insurances",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "additional_insurances",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "insurance_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "additional_insurances",
                keyColumn: "id",
                keyValue: 1,
                column: "max_coverage",
                value: 0);

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "customer_number", "postal_code" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "insurance_types",
                keyColumn: "id",
                keyValue: 1,
                column: "type_name",
                value: null);

            migrationBuilder.UpdateData(
                table: "invoices",
                keyColumn: "id",
                keyValue: 1,
                column: "created",
                value: new DateTime(2022, 12, 14, 13, 3, 16, 278, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "policies",
                keyColumn: "id",
                keyValue: 1,
                column: "policy_nr",
                value: 0);
        }
    }
}
