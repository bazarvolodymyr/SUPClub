using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUPClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreateById",
                table: "HireSubCategories",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateById",
                table: "HireCategories",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateById",
                table: "Equipments",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirsName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "433D71D7-3843-4EF9-B934-5177D755F545",
                columns: new[] { "ConcurrencyStamp", "FirsName", "LastName", "PasswordHash" },
                values: new object[] { "9d534023-21c4-45ec-a7f5-12afd96374ef", null, null, "AQAAAAIAAYagAAAAEFc+Oj3/z8kA5qwAnG8ACwi1IK3r0l9gcpFHSrKuWxdr45I9OdlNHjuRePBRPsQIhA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirsName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CreateById",
                table: "HireSubCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "CreateById",
                table: "HireCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "CreateById",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "433D71D7-3843-4EF9-B934-5177D755F545",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4bbb6bed-04e2-4bf8-bce3-4057a1453758", "AQAAAAIAAYagAAAAEF0B42nyGpPl7er2xlXUrmA9iPp3b96WauYp4mfCn7myS2bF6YjtsXsTDsf+2bOl5g==" });
        }
    }
}
