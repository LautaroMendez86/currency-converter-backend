using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyConverter.Migrations
{
    public partial class AddDataToSubscriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Name", "Price", "TotalAvailableConversions" },
                values: new object[] { 1, "Suscripción Free", 0, 10 });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Name", "Price", "TotalAvailableConversions" },
                values: new object[] { 2, "Suscripción Trial", 5, 100 });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Name", "Price", "TotalAvailableConversions" },
                values: new object[] { 3, "Suscripción Pro", 10, 9999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
