using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<short>(type: "smallint", nullable: false, comment: "1. Administrator; 2. BasicUser"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectorMovie",
                columns: table => new
                {
                    DirectorsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovie", x => new { x.DirectorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_DirectorMovie_Directors_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Actor1" },
                    { 28, "Actor28" },
                    { 29, "Actor29" },
                    { 30, "Actor30" },
                    { 31, "Actor31" },
                    { 32, "Actor32" },
                    { 33, "Actor33" },
                    { 34, "Actor34" },
                    { 35, "Actor35" },
                    { 36, "Actor36" },
                    { 37, "Actor37" },
                    { 27, "Actor27" },
                    { 39, "Actor39" },
                    { 41, "Actor41" },
                    { 42, "Actor42" },
                    { 43, "Actor43" },
                    { 44, "Actor44" },
                    { 45, "Actor45" },
                    { 46, "Actor46" },
                    { 47, "Actor47" },
                    { 48, "Actor48" },
                    { 49, "Actor49" },
                    { 50, "Actor50" },
                    { 40, "Actor40" },
                    { 26, "Actor26" },
                    { 38, "Actor38" },
                    { 24, "Actor24" },
                    { 25, "Actor25" },
                    { 2, "Actor2" },
                    { 3, "Actor3" },
                    { 4, "Actor4" },
                    { 5, "Actor5" },
                    { 6, "Actor6" },
                    { 7, "Actor7" },
                    { 9, "Actor9" },
                    { 10, "Actor10" },
                    { 11, "Actor11" },
                    { 12, "Actor12" },
                    { 8, "Actor8" },
                    { 22, "Actor22" },
                    { 14, "Actor14" },
                    { 15, "Actor15" }
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 16, "Actor16" },
                    { 17, "Actor17" },
                    { 18, "Actor18" },
                    { 19, "Actor19" },
                    { 20, "Actor20" },
                    { 21, "Actor21" },
                    { 13, "Actor13" },
                    { 23, "Actor23" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 36, "Director36" },
                    { 35, "Director35" },
                    { 34, "Director34" },
                    { 33, "Director33" },
                    { 28, "Director28" },
                    { 31, "Director31" },
                    { 30, "Director30" },
                    { 29, "Director29" },
                    { 37, "Director37" },
                    { 32, "Director32" },
                    { 38, "Director38" },
                    { 50, "Director50" },
                    { 40, "Director40" },
                    { 41, "Director41" },
                    { 42, "Director42" },
                    { 43, "Director43" },
                    { 44, "Director44" },
                    { 45, "Director45" },
                    { 46, "Director46" },
                    { 47, "Director47" },
                    { 48, "Director48" },
                    { 49, "Director49" },
                    { 27, "Director27" },
                    { 39, "Director39" },
                    { 26, "Director26" },
                    { 11, "Director11" },
                    { 24, "Director24" },
                    { 1, "Director1" },
                    { 25, "Director25" },
                    { 3, "Director3" },
                    { 4, "Director4" },
                    { 5, "Director5" },
                    { 6, "Director6" },
                    { 7, "Director7" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Director8" },
                    { 9, "Director9" },
                    { 10, "Director10" },
                    { 12, "Director12" },
                    { 2, "Director2" },
                    { 23, "Director23" },
                    { 14, "Director14" },
                    { 15, "Director15" },
                    { 16, "Director16" },
                    { 17, "Director17" },
                    { 18, "Director18" },
                    { 19, "Director19" },
                    { 20, "Director20" },
                    { 21, "Director21" },
                    { 22, "Director22" },
                    { 13, "Director13" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13, "Genre13" },
                    { 14, "Genre14" },
                    { 15, "Genre15" },
                    { 20, "Genre20" },
                    { 17, "Genre17" },
                    { 18, "Genre18" },
                    { 19, "Genre19" },
                    { 12, "Genre12" },
                    { 16, "Genre16" },
                    { 11, "Genre11" },
                    { 5, "Genre5" },
                    { 9, "Genre9" },
                    { 8, "Genre8" },
                    { 7, "Genre7" },
                    { 6, "Genre6" },
                    { 4, "Genre4" },
                    { 3, "Genre3" },
                    { 2, "Genre2" },
                    { 1, "Genre1" },
                    { 10, "Genre10" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Login", "Role" },
                values: new object[] { 1, true, "admin", (short)1 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Movie1" },
                    { 18, 18, "Movie18" },
                    { 17, 17, "Movie17" },
                    { 16, 16, "Movie16" },
                    { 15, 15, "Movie15" },
                    { 14, 14, "Movie14" },
                    { 13, 13, "Movie13" },
                    { 12, 12, "Movie12" },
                    { 11, 11, "Movie11" },
                    { 10, 10, "Movie10" },
                    { 9, 9, "Movie9" },
                    { 8, 8, "Movie8" },
                    { 7, 7, "Movie7" },
                    { 6, 6, "Movie6" },
                    { 5, 5, "Movie5" },
                    { 4, 4, "Movie4" },
                    { 3, 3, "Movie3" },
                    { 2, 2, "Movie2" },
                    { 19, 19, "Movie19" },
                    { 20, 20, "Movie20" }
                });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "DirectorMovie",
                columns: new[] { "DirectorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_Name",
                table: "Actors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovie_MoviesId",
                table: "DirectorMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_Name",
                table: "Directors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Name",
                table: "Movies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "DirectorMovie");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
