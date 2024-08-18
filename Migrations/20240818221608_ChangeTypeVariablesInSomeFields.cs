using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyConverter.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeVariablesInSomeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "ConverterHistories",
                newName: "Amount");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "ConverterHistories",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<double>(
                name: "Result",
                table: "ConverterHistories",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "ConverterHistories");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ConverterHistories",
                newName: "amount");

            migrationBuilder.AlterColumn<int>(
                name: "amount",
                table: "ConverterHistories",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
