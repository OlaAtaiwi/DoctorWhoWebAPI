using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    public partial class SeedingTablesWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "varchar(400)",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldDefaultValueSql: "NULL");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Gosho Aoyama" },
                    { 2, "Rudyard Kipling" },
                    { 3, "Kozu Kozuha" },
                    { 4, "Guy Ritchie" },
                    { 5, "Akira Kurosawa" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Polly", "Anneke Wills" },
                    { 2, "Zoe Heriot", "Wendy Padbury" },
                    { 3, "Nyssa", "Sarah Sutton" },
                    { 4, "Mickey Smith", "Noel Clarke" },
                    { 5, "Nardole", "Matt Lucas" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "DoctorName", "DoctorNumber" },
                values: new object[,]
                {
                    { 1, "William", 1 },
                    { 2, "Patrick", 2 },
                    { 3, "Jon", 3 },
                    { 4, "Tom", 4 },
                    { 5, "Peter", 5 }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "Hunter", "Hisoka" },
                    { 2, "Snow White and the Seven Dwarfs", "Queen Grimhilde" },
                    { 3, "Cinderella", "Lady Tremaine" },
                    { 4, "The lion is the king of the jungle", "Scar" },
                    { 5, "the little Mermaid", "Ursula" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 4, 2, new DateTime(2002, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Classic", 1, "The Heirs of the Dragon" },
                    { 2, 4, 2, new DateTime(2002, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Classic", 1, "The Rogue Prince" },
                    { 3, 5, 1, new DateTime(2002, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Classic", 1, "Second of His Name" },
                    { 4, 3, 3, new DateTime(2002, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Classic", 2, "King of the Narrow Sea" },
                    { 5, 1, 4, new DateTime(2002, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Classic", 2, "We Light the Way" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanions",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 4, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 3 },
                    { 5, 3, 4 },
                    { 6, 1, 5 },
                    { 7, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemies",
                columns: new[] { "EpisodeEnemyId", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 3, 1 },
                    { 3, 2, 2 },
                    { 4, 4, 2 },
                    { 5, 1, 3 },
                    { 6, 3, 4 },
                    { 7, 3, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "varchar(400)",
                nullable: false,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }
    }
}
