using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUPClub.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "433D71D7-3843-4EF9-B934-5177D755F545",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "241ec0a5-488d-471c-8c9f-e08dd04f5c8b", "AQAAAAIAAYagAAAAEDRop8FsO7hG7FHbEgrrYF7+goHEunYDpCdcYNJWFnWY3bSPpzt3DWDJci4kensr4A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "433D71D7-3843-4EF9-B934-5177D755F545",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d534023-21c4-45ec-a7f5-12afd96374ef", "AQAAAAIAAYagAAAAEFc+Oj3/z8kA5qwAnG8ACwi1IK3r0l9gcpFHSrKuWxdr45I9OdlNHjuRePBRPsQIhA==" });
        }
    }
}
