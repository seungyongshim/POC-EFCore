using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpNo = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    CmpCode = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true)
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
                    IpAddress = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    GrantSend = table.Column<short>(type: "smallint", nullable: true),
                    UserInfoId = table.Column<int>(type: "int", nullable: true),
                    PermissionYN = table.Column<bool>(type: "bit", nullable: true),
                    UseYN = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpInfos", x => x.IpInfoId);
                    table.ForeignKey(
                        name: "FK_IpInfos_UserInfoId_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IpInfo_1",
                table: "IpInfos",
                column: "IpAddress");

            migrationBuilder.CreateIndex(
                name: "IX_IpInfos_UserInfoId",
                table: "IpInfos",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "UQ_IpInfo_1",
                table: "IpInfos",
                column: "IpAddress",
                unique: true,
                filter: "[IpAddress] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_1",
                table: "UserInfos",
                columns: new[] { "EmpNo", "CmpCode" });

            migrationBuilder.CreateIndex(
                name: "UQ_UserInfo_1",
                table: "UserInfos",
                columns: new[] { "EmpNo", "CmpCode" },
                unique: true,
                filter: "[EmpNo] IS NOT NULL AND [CmpCode] IS NOT NULL");
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
