using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicWebSite.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class updateClassUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Users",
                newName: "Role");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Image", "Name", "Password" },
                values: new object[] { 1, "praimgg@gmail.com", "", "Ivan", "12345678" });
        }
    }
}
