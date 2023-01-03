using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class CreatefnEnemies_Function : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER FUNCTION fnEnemies (@EpisodeId INT)
                RETURNS VARCHAR(MAX) AS
                BEGIN 
	            DECLARE @Result AS VARCHAR(MAX)
	            SELECT @Result=STRING_AGG (EnemyName,',') 
	            FROM fnEnemiesNamesList(@EpisodeId);
	            RETURN @Result
                END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION fnEnemies");
        }
    }
}
