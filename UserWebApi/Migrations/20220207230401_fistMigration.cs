using Microsoft.EntityFrameworkCore.Migrations;

namespace UserWebApi.Migrations
{
    public partial class fistMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(type: "TEXT", nullable: true),
                    node_id = table.Column<string>(type: "TEXT", nullable: true),
                    avatar_url = table.Column<string>(type: "TEXT", nullable: true),
                    gravatar_id = table.Column<string>(type: "TEXT", nullable: true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    html_url = table.Column<string>(type: "TEXT", nullable: true),
                    followers_url = table.Column<string>(type: "TEXT", nullable: true),
                    gists_url = table.Column<string>(type: "TEXT", nullable: true),
                    following_url = table.Column<string>(type: "TEXT", nullable: true),
                    starred_url = table.Column<string>(type: "TEXT", nullable: true),
                    subscriptions_url = table.Column<string>(type: "TEXT", nullable: true),
                    organizations_url = table.Column<string>(type: "TEXT", nullable: true),
                    repos_url = table.Column<string>(type: "TEXT", nullable: true),
                    events_url = table.Column<string>(type: "TEXT", nullable: true),
                    received_events_url = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    site_admin = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
