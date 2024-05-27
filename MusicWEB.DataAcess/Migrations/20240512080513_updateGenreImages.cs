using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicWEB.DataAcess.Migrations
{
    public partial class updateGenreImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Rock.png");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Hip-Hop.png");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Rap.png");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Blues.png", "Blues" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Latino.jfif", "Latino" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Punk.jfif", "Punk" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Disco.png", "Disco" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Alternative.png", "Alternative" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 8, "/files\\image\\GenreImages\\Metall.jpg", "Metall" },
                    { 9, "/files\\image\\GenreImages\\Funk.png", "Funk" },
                    { 13, "/files\\image\\GenreImages\\Soul.png", "Soul" },
                    { 14, "/files\\image\\GenreImages\\Techno.jpg", "Techno" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Rock.jfif");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Hip-Hop.jfif");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Rap.jpg");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Metall.jpg", "Metall" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Funk.jpg", "Funk" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Blues.jpg", "Blues" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Latino.jfif", "Latino" });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/files\\image\\GenreImages\\Punk.jfif", "Punk" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 17, "/files\\image\\GenreImages\\Soul.jpg", "Soul" },
                    { 18, "/files\\image\\GenreImages\\Techno.jpg", "Techno" },
                    { 20, "/files\\image\\GenreImages\\Disco.jpg", "Disco" },
                    { 21, "/files\\image\\GenreImages\\Alternative.jpg", "Alternative" }
                });
        }
    }
}
