using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore.Migrations
{
    public partial class InitialCreate0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CmpCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "IpInfos",
                columns: table => new
                {
                    IpInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<byte[]>(type: "varbinary(16)", maxLength: 16, nullable: true),
                    PermissionSendingType = table.Column<short>(type: "smallint", nullable: false),
                    PermissionYn = table.Column<bool>(type: "bit", nullable: true),
                    UseYn = table.Column<bool>(type: "bit", nullable: true),
                    UserInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpInfos", x => x.IpInfoId);
                    table.ForeignKey(
                        name: "FK_IpInfos_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IpInfos_IpAddress",
                table: "IpInfos",
                column: "IpAddress");

            migrationBuilder.CreateIndex(
                name: "IX_IpInfos_UserInfoId",
                table: "IpInfos",
                column: "UserInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IpInfos");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
