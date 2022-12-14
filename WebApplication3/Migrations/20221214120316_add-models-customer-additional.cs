using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class addmodelscustomeradditional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "percentage_coverage",
                table: "additional_insurances",
                newName: "costs");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "customer_number",
                table: "customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "postal_code",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "additional_insurances",
                keyColumn: "id",
                keyValue: 1,
                column: "max_coverage",
                value: 500);

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "address", "city", "customer_number", "postal_code" },
                values: new object[] { "", "", 1001, "" });

            migrationBuilder.UpdateData(
                table: "insurance_types",
                keyColumn: "id",
                keyValue: 1,
                column: "type_name",
                value: "Tand");

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
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "city",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "postal_code",
                table: "customers");

            migrationBuilder.RenameColumn(
                name: "costs",
                table: "additional_insurances",
                newName: "percentage_coverage");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "customer_number",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                column: "customer_number",
                value: 0);

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
                value: new DateTime(2022, 12, 13, 23, 40, 54, 406, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "policies",
                keyColumn: "id",
                keyValue: 1,
                column: "policy_nr",
                value: 0);
        }
    }
}
