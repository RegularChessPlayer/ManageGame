using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ManageGameApi.Migrations
{
    public partial class inital_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usermanage",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usermanage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "friend",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    usermanageid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friend", x => x.id);
                    table.ForeignKey(
                        name: "FK_friend_usermanage_usermanageid",
                        column: x => x.usermanageid,
                        principalTable: "usermanage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    usermanageid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.id);
                    table.ForeignKey(
                        name: "FK_game_usermanage_usermanageid",
                        column: x => x.usermanageid,
                        principalTable: "usermanage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locategame",
                columns: table => new
                {
                    gameid = table.Column<long>(type: "bigint", nullable: false),
                    friendid = table.Column<long>(type: "bigint", nullable: false),
                    usermanageid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locategame", x => new { x.gameid, x.friendid });
                    table.ForeignKey(
                        name: "FK_locategame_usermanage_usermanageid",
                        column: x => x.usermanageid,
                        principalTable: "usermanage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "usermanage",
                columns: new[] { "id", "email", "password", "role" },
                values: new object[] { 100L, "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "friend",
                columns: new[] { "id", "name", "usermanageid" },
                values: new object[,]
                {
                    { 90L, "Jhon Dean", 100L },
                    { 91L, "Derick Jhonson", 100L }
                });

            migrationBuilder.InsertData(
                table: "game",
                columns: new[] { "id", "name", "usermanageid" },
                values: new object[,]
                {
                    { 100L, "God of War", 100L },
                    { 101L, "Derick Jhonson", 100L }
                });

            migrationBuilder.InsertData(
                table: "locategame",
                columns: new[] { "friendid", "gameid", "usermanageid" },
                values: new object[] { 90L, 100L, 100L });

            migrationBuilder.CreateIndex(
                name: "IX_friend_usermanageid",
                table: "friend",
                column: "usermanageid");

            migrationBuilder.CreateIndex(
                name: "IX_game_usermanageid",
                table: "game",
                column: "usermanageid");

            migrationBuilder.CreateIndex(
                name: "IX_locategame_usermanageid",
                table: "locategame",
                column: "usermanageid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "friend");

            migrationBuilder.DropTable(
                name: "game");

            migrationBuilder.DropTable(
                name: "locategame");

            migrationBuilder.DropTable(
                name: "usermanage");
        }
    }
}
