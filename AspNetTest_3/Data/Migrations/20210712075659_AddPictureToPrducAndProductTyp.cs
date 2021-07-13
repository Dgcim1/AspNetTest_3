using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetTest_3.Data.Migrations
{
    public partial class AddPictureToPrducAndProductTyp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");
        }
    }
}
