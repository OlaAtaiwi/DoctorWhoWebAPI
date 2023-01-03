using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class CreateSummariseEpisodes_Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE spSummariseEpisodes AS
                BEGIN
	            SELECT TOP 3 c.CompanionName AS [Most Frequent Companions]
	            FROM EpisodeCompanions e
	            JOIN Companions c ON e.CompanionId = c.CompanionId
	            GROUP BY c.CompanionName
	            ORDER BY COUNT(e.CompanionId) DESC

	            SELECT TOP 3 e.EnemyName AS [Most Frequent Enemies]
	            FROM Enemies e
	            JOIN EpisodeEnemies ep ON e.EnemyId = ep.EnemyId
	            GROUP BY e.EnemyName
	            ORDER BY COUNT(ep.EnemyID) DESC
                END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE spSummariseEpisodes");
        }
    }
}
