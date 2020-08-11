using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coworking.Api.DataAccess.Migrations
{
    public partial class changeAdminEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Offices_Id",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Offices",
                nullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Admins",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Offices_AdminId",
                table: "Offices",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Admins_AdminId",
                table: "Offices",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Admins_AdminId",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Offices_AdminId",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Offices");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Admins",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Admins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Offices_Id",
                table: "Admins",
                column: "Id",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
