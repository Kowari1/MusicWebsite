using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicWEB.DataAcess.Migrations
{
    public partial class imageСorrectionGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Pop.jfif");

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
                keyValue: 5,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Electronic.png");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Jazz.png");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Classical.jpg");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Metall.jpg");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Funk.jpg");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Blues.jpg");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Latino.jfif");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Punk.jfif");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Soul.jpg");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Techno.jpg");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Disco.jpg");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Alternative.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Pop");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Rock");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Hip-Hop");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Rap");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Electronic");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Jazz");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Classical");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Metall");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Funk");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Blues");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Latino");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Punk");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Soul");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Techno");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Disco");

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "/files\\image\\GenreImages\\Alternative");
        }
    }
}
