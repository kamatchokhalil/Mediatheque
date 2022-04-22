using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbEmpruntsMax = table.Column<int>(type: "int", nullable: false),
                    Cotisation = table.Column<double>(type: "float", nullable: false),
                    CoefTarif = table.Column<double>(type: "float", nullable: false),
                    CoefDuree = table.Column<double>(type: "float", nullable: false),
                    CodeReductionActif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mediatheques",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mediatheques", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeRedusction = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    MediathequeKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Mediatheques_MediathequeKey",
                        column: x => x.MediathequeKey,
                        principalTable: "Mediatheques",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Annee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediathequeKey = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duree = table.Column<int>(type: "int", nullable: true),
                    Tarif = table.Column<double>(type: "float", nullable: true),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbPage = table.Column<int>(type: "int", nullable: true),
                    Livre_Duree = table.Column<int>(type: "int", nullable: true),
                    Livre_Tarif = table.Column<double>(type: "float", nullable: true),
                    DureeFilm = table.Column<int>(type: "int", nullable: true),
                    MentionLegale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video_Duree = table.Column<int>(type: "int", nullable: true),
                    Video_Tarif = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Documents_Mediatheques_MediathequeKey",
                        column: x => x.MediathequeKey,
                        principalTable: "Mediatheques",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientDocument",
                columns: table => new
                {
                    ClientsClientId = table.Column<int>(type: "int", nullable: false),
                    DocumentsKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDocument", x => new { x.ClientsClientId, x.DocumentsKey });
                    table.ForeignKey(
                        name: "FK_ClientDocument_Clients_ClientsClientId",
                        column: x => x.ClientsClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientDocument_Documents_DocumentsKey",
                        column: x => x.DocumentsKey,
                        principalTable: "Documents",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprunts",
                columns: table => new
                {
                    key = table.Column<int>(type: "int", nullable: false),
                    DateEmprunt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRappel = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRetour = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tarif = table.Column<double>(type: "float", nullable: false),
                    ClientFk = table.Column<int>(type: "int", nullable: false),
                    DocumentFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprunts", x => new { x.DateEmprunt, x.key });
                    table.ForeignKey(
                        name: "FK_Emprunts_Clients_ClientFk",
                        column: x => x.ClientFk,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprunts_Documents_DocumentFk",
                        column: x => x.DocumentFk,
                        principalTable: "Documents",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDocument_DocumentsKey",
                table: "ClientDocument",
                column: "DocumentsKey");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CategoryId",
                table: "Clients",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MediathequeKey",
                table: "Clients",
                column: "MediathequeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MediathequeKey",
                table: "Documents",
                column: "MediathequeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_ClientFk",
                table: "Emprunts",
                column: "ClientFk");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_DocumentFk",
                table: "Emprunts",
                column: "DocumentFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDocument");

            migrationBuilder.DropTable(
                name: "Emprunts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Mediatheques");
        }
    }
}
