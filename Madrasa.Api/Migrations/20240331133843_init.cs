using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madrasa.Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maison",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostal = table.Column<int>(type: "int", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelDomicile = table.Column<int>(type: "int", nullable: true),
                    Adherent = table.Column<bool>(type: "bit", nullable: true),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maison", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arabe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Traduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Principale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Professeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumJour = table.Column<int>(type: "int", nullable: false),
                    Jour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDeb = table.Column<TimeSpan>(type: "time", nullable: false),
                    HFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Duree = table.Column<TimeSpan>(type: "time", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horaire_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelMobile = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaisonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parent_Maison_MaisonId",
                        column: x => x.MaisonId,
                        principalTable: "Maison",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfesseurId = table.Column<int>(type: "int", nullable: false),
                    ProfesseursId = table.Column<int>(type: "int", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Professeurs_ProfesseursId",
                        column: x => x.ProfesseursId,
                        principalTable: "Professeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SN = table.Column<int>(type: "int", nullable: false),
                    Suspendu = table.Column<bool>(type: "bit", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LieuNaissance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaisonId = table.Column<int>(type: "int", nullable: true),
                    ClassesId = table.Column<int>(type: "int", nullable: true),
                    DateEntree = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eleves_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Eleves_Maison_MaisonId",
                        column: x => x.MaisonId,
                        principalTable: "Maison",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Examen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnneeScolaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semestre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassesId = table.Column<int>(type: "int", nullable: true),
                    ProfesseursId = table.Column<int>(type: "int", nullable: true),
                    MatiereID = table.Column<int>(type: "int", nullable: false),
                    MP = table.Column<int>(type: "int", nullable: true),
                    MPB = table.Column<int>(type: "int", nullable: true),
                    MS1Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MS1Note = table.Column<int>(type: "int", nullable: true),
                    MS2Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MS2Note = table.Column<int>(type: "int", nullable: true),
                    MS3Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MS3Note = table.Column<int>(type: "int", nullable: true),
                    MS4Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MS4Note = table.Column<int>(type: "int", nullable: true),
                    MS5Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MS5Note = table.Column<int>(type: "int", nullable: true),
                    MS6Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MS6Note = table.Column<int>(type: "int", nullable: true),
                    MS7Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MS7Note = table.Column<int>(type: "int", nullable: true),
                    Akhlaq = table.Column<int>(type: "int", nullable: true),
                    Hudhur = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true),
                    Actif = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examen_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Examen_Professeurs_ProfesseursId",
                        column: x => x.ProfesseursId,
                        principalTable: "Professeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bulletin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevesId = table.Column<int>(type: "int", nullable: true),
                    ExamenId = table.Column<int>(type: "int", nullable: true),
                    Mention = table.Column<int>(type: "int", nullable: true),
                    MP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MS1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MS2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MS3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MS4 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MS5 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MS6 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MS7 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Akhlaq = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hudhur = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bulletin_Eleves_ElevesId",
                        column: x => x.ElevesId,
                        principalTable: "Eleves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bulletin_Examen_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bulletin_ElevesId",
                table: "Bulletin",
                column: "ElevesId");

            migrationBuilder.CreateIndex(
                name: "IX_Bulletin_ExamenId",
                table: "Bulletin",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GroupeId",
                table: "Classes",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ProfesseursId",
                table: "Classes",
                column: "ProfesseursId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleves_ClassesId",
                table: "Eleves",
                column: "ClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleves_MaisonId",
                table: "Eleves",
                column: "MaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_ClassesId",
                table: "Examen",
                column: "ClassesId",
                unique: true,
                filter: "[ClassesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_ProfesseursId",
                table: "Examen",
                column: "ProfesseursId",
                unique: true,
                filter: "[ProfesseursId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Horaire_GroupeId",
                table: "Horaire",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_MaisonId",
                table: "Parent",
                column: "MaisonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bulletin");

            migrationBuilder.DropTable(
                name: "Horaire");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "Eleves");

            migrationBuilder.DropTable(
                name: "Examen");

            migrationBuilder.DropTable(
                name: "Maison");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropTable(
                name: "Professeurs");
        }
    }
}
