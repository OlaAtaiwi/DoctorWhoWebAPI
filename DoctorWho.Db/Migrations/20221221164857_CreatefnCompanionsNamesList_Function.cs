using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class CreatefnCompanionsNamesList_Function : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER FUNCTION fnCompanionsNamesList (@EpsoidId INT)
                 RETURNS TABLE AS
                 RETURN
                 SELECT CompanionName
                 FROM EpisodeCompanions e JOIN Companions c ON(e.CompanionId=c.CompanionId)
                 WHERE e.EpisodeId = @EpsoidId;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION fnCompanionsNamesList");
        }
    }
}
