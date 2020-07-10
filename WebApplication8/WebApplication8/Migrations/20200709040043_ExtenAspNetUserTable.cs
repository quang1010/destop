using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class ExtenAspNetUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Flowers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 2,
                column: "AvatarPath",
                value: "images/giaytim.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "quang@gmail.com");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarPath", "Email" },
                values: new object[] { "images/giaytim.jpn", "quag@gmail.com" });
        }
    }
}
