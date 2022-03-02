using Microsoft.EntityFrameworkCore.Migrations;

namespace POSTest.Migrations
{
    public partial class seedproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Size" },
                values: new object[] { 1, "Beef Burger", "3.5 BHD", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
