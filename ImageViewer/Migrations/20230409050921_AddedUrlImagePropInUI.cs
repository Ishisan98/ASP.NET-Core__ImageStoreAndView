using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageViewer.Migrations
{
    /// <inheritdoc />
    public partial class AddedUrlImagePropInUI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Images");
        }
    }
}
