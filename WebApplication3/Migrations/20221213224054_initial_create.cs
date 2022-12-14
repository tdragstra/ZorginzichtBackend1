using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customernumber = table.Column<int>(name: "customer_number", type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insurance_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typename = table.Column<string>(name: "type_name", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "policies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    policynr = table.Column<int>(name: "policy_nr", type: "int", nullable: false),
                    policyname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    costs = table.Column<float>(type: "real", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policies", x => x.id);
                    table.ForeignKey(
                        name: "FK_policies_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "additional_insurances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxcoverage = table.Column<int>(name: "max_coverage", type: "int", nullable: false),
                    percentagecoverage = table.Column<int>(name: "percentage_coverage", type: "int", nullable: false),
                    InsuranceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_additional_insurances", x => x.id);
                    table.ForeignKey(
                        name: "FK_additional_insurances_insurance_types_InsuranceTypeId",
                        column: x => x.InsuranceTypeId,
                        principalTable: "insurance_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    costs = table.Column<double>(type: "float", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsuranceTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoices_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_invoices_insurance_types_InsuranceTypeId",
                        column: x => x.InsuranceTypeId,
                        principalTable: "insurance_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "policies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditonalInsurrancePolicy",
                columns: table => new
                {
                    additionalinsurancesid = table.Column<int>(name: "additional_insurancesid", type: "int", nullable: false),
                    policiesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditonalInsurrancePolicy", x => new { x.additionalinsurancesid, x.policiesid });
                    table.ForeignKey(
                        name: "FK_AdditonalInsurrancePolicy_additional_insurances_additional_insurancesid",
                        column: x => x.additionalinsurancesid,
                        principalTable: "additional_insurances",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditonalInsurrancePolicy_policies_policiesid",
                        column: x => x.policiesid,
                        principalTable: "policies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "customer_number", "email", "name", "password" },
                values: new object[] { 1, 1001, "robin@gmail.com", "Robin", "123" });

            migrationBuilder.InsertData(
                table: "insurance_types",
                columns: new[] { "id", "name", "type_name" },
                values: new object[] { 1, "Tand", "Tand" });

            migrationBuilder.InsertData(
                table: "additional_insurances",
                columns: new[] { "id", "InsuranceTypeId", "max_coverage", "name", "percentage_coverage" },
                values: new object[] { 1, 1, 500, "Tand 1", 80 });

            migrationBuilder.InsertData(
                table: "policies",
                columns: new[] { "id", "CustomerId", "active", "costs", "insurance", "policy_nr", "policyname" },
                values: new object[] { 1, 1, true, 120.5f, "My insurance", 1, "Interpolis 1" });

            migrationBuilder.InsertData(
                table: "invoices",
                columns: new[] { "id", "CustomerId", "InsuranceTypeId", "PolicyId", "costs", "created" },
                values: new object[] { 1, 1, 1, 1, 50.25, new DateTime(2022, 12, 13, 23, 40, 54, 406, DateTimeKind.Local).AddTicks(8134) });

            migrationBuilder.InsertData(
                table: "AdditonalInsurrancePolicy",
                columns: new[] { "policiesid", "additional_insurancesid" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_additional_insurances_InsuranceTypeId",
                table: "additional_insurances",
                column: "InsuranceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditonalInsurrancePolicy_policiesid",
                table: "AdditonalInsurrancePolicy",
                column: "policiesid");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_CustomerId",
                table: "invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_InsuranceTypeId",
                table: "invoices",
                column: "InsuranceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_PolicyId",
                table: "invoices",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_policies_CustomerId",
                table: "policies",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditonalInsurrancePolicy");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "additional_insurances");

            migrationBuilder.DropTable(
                name: "policies");

            migrationBuilder.DropTable(
                name: "insurance_types");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
