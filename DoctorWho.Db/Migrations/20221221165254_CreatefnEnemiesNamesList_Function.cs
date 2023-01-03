using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class CreatefnEnemiesNamesList_Function : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER FUNCTION fnEnemiesNamesList (@EpsoidId INT)
                RETURNS TABLE AS
                RETURN
	            SELECT EnemyName
	            FROM EpisodeEnemies e JOIN Enemies c ON(e.EnemyId=c.EnemyId)
	            WHERE e.EpisodeId = @EpsoidId
                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION fnEnemiesNamesList");
        }
    }
}
