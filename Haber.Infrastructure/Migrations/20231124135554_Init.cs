using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Haber.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 3 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 2 INCREMENT BY 1"),
                    AD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SOYAD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KATEGORILER",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 5 INCREMENT BY 1"),
                    KategoriAdi = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SilmeTarihi = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    KayitDurumu = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KATEGORILER", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RoleId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HABERLER",
                columns: table => new
                {
                    HaberID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Baslik = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Detay = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResimYolu = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    GoruntulenmeSayisi = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SilmeTarihi = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    KayitDurumu = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HaberEkleyenID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    KategoriID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HABERLER", x => x.HaberID);
                    table.ForeignKey(
                        name: "FK_HABERLER_AspNetUsers_HaberEkleyenID",
                        column: x => x.HaberEkleyenID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HABERLER_KATEGORILER_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "KATEGORILER",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAVORILER",
                columns: table => new
                {
                    FavoriID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HaberID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SilmeTarihi = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    KayitDurumu = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORILER", x => x.FavoriID);
                    table.ForeignKey(
                        name: "FK_FAVORILER_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAVORILER_HABERLER_HaberID",
                        column: x => x.HaberID,
                        principalTable: "HABERLER",
                        principalColumn: "HaberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YORUMLAR",
                columns: table => new
                {
                    YorumID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HaberID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Mesaj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SilmeTarihi = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    KayitDurumu = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YORUMLAR", x => x.YorumID);
                    table.ForeignKey(
                        name: "FK_YORUMLAR_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YORUMLAR_HABERLER_HaberID",
                        column: x => x.HaberID,
                        principalTable: "HABERLER",
                        principalColumn: "HaberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "fa304122-b98e-470c-8283-c17bf8f78d42", "Admin", "ADMIN" },
                    { 2, "68b3dee6-41d4-461c-838e-52f499c826e2", "Uye", "UYE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AD", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SOYAD", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "Cevdet", "8b9e4e82-a3af-4d7a-9ed7-bb57fd32f31b", "cevdet@deneme.com", false, false, null, "CEVDET@DENEME.COM", "CEVDO", "AQAAAAEAACcQAAAAEEhldUn7Xc0tprsGeZDQHa3b4WpoL4Fg+UcVFP2D8+4d8k+rE3NxiJIobDb1tXRCsg==", null, false, "ebaae3ec-77c2-4479-adde-918e69430aa0", "Korkmaz", false, "Cevdo" });

            migrationBuilder.InsertData(
                table: "KATEGORILER",
                columns: new[] { "KategoriID", "EklemeTarih", "GuncellemeTarihi", "KategoriAdi", "KayitDurumu", "SilmeTarihi" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ekonomi", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teknoloji", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spor", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magazin", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "\"NormalizedName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "\"NormalizedUserName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FAVORILER_HaberID",
                table: "FAVORILER",
                column: "HaberID");

            migrationBuilder.CreateIndex(
                name: "IX_FAVORILER_UserID",
                table: "FAVORILER",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_HABERLER_HaberEkleyenID",
                table: "HABERLER",
                column: "HaberEkleyenID");

            migrationBuilder.CreateIndex(
                name: "IX_HABERLER_KategoriID",
                table: "HABERLER",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_YORUMLAR_HaberID",
                table: "YORUMLAR",
                column: "HaberID");

            migrationBuilder.CreateIndex(
                name: "IX_YORUMLAR_UserID",
                table: "YORUMLAR",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FAVORILER");

            migrationBuilder.DropTable(
                name: "YORUMLAR");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "HABERLER");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "KATEGORILER");
        }
    }
}
