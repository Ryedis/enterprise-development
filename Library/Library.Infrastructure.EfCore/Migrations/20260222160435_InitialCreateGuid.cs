using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EditionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AlphabetCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EditionTypeId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_EditionTypes_EditionTypeId",
                        column: x => x.EditionTypeId,
                        principalTable: "EditionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookIssues_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookIssues_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EditionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Монография" },
                    { 2, "Методическое пособие" },
                    { 3, "Энциклопедия" },
                    { 4, "Биография" },
                    { 5, "Фэнтези" },
                    { 6, "Техническая литература" },
                    { 7, "Публицистика" },
                    { 8, "Поэзия" },
                    { 9, "Психология" },
                    { 10, "Бизнес-литература" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Бином" },
                    { 2, "Инфра-М" },
                    { 3, "Юрайт" },
                    { 4, "ДМК Пресс" },
                    { 5, "Лань" },
                    { 6, "Альпина Паблишер" },
                    { 7, "МИФ" },
                    { 8, "Вильямс" },
                    { 9, "Самокат" },
                    { 10, "Энергия" }
                });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "Address", "FullName", "Phone", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "ул. Березовая, 12", "Орлов Денис Сергеевич", "89110000001", new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "ул. Солнечная, 45", "Мельников Артем Игоревич", "89110000002", new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "ул. Полевая, 7", "Белов Кирилл Андреевич", "89110000003", new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "ул. Озерная, 21", "Егорова Марина Олеговна", "89110000004", new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "ул. Лесная, 3", "Тарасов Максим Дмитриевич", "89110000005", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, "ул. Школьная, 9", "Крылова Анастасия Павловна", "89110000006", new DateTime(2025, 6, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, "ул. Центральная, 15", "Никитин Роман Евгеньевич", "89110000007", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, "ул. Мира, 19", "Волкова Дарья Ильинична", "89110000008", new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, "ул. Новая, 8", "Зайцев Павел Николаевич", "89110000009", new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, "ул. Южная, 14", "Громова София Артемовна", "89110000010", new DateTime(2025, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AlphabetCode", "Authors", "EditionTypeId", "InventoryNumber", "PublisherId", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "И-101", "И. Ньютон", 1, "BK-101", 5, "Математические начала", 1687 },
                    { 2, "Т-210", "А. Тьюринг", 6, "BK-102", 4, "Вычислительные машины", 1936 },
                    { 3, "К-310", "И. Кант", 7, "BK-103", 6, "Критика чистого разума", 1781 },
                    { 4, "Р-410", "Д. Роулинг", 5, "BK-104", 9, "Тайная комната", 1998 },
                    { 5, "М-510", "М. Портер", 10, "BK-105", 7, "Конкурентная стратегия", 1980 },
                    { 6, "С-610", "К. Саган", 3, "BK-106", 1, "Космос", 1980 },
                    { 7, "Ф-710", "З. Фрейд", 9, "BK-107", 6, "Толкование сновидений", 1899 },
                    { 8, "Л-810", "С. Лем", 5, "BK-108", 2, "Солярис", 1961 },
                    { 9, "Х-910", "Ю. Харари", 4, "BK-109", 6, "Sapiens", 2011 },
                    { 10, "Г-999", "А. Гауди", 1, "BK-110", 10, "Архитектура форм", 1925 }
                });

            migrationBuilder.InsertData(
                table: "BookIssues",
                columns: new[] { "Id", "BookId", "Days", "IssueDate", "ReaderId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, 30, new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1, null },
                    { 2, 2, 60, new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc), 1, null },
                    { 3, 3, 14, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, null },
                    { 4, 4, 10, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), 2, null },
                    { 5, 5, 21, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), 3, null },
                    { 6, 6, 14, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), 4, null },
                    { 7, 7, 7, new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), 5, null },
                    { 8, 8, 30, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc), 6, null },
                    { 9, 9, 20, new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), 7, null },
                    { 10, 10, 14, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), 8, null },
                    { 11, 1, 10, new DateTime(2026, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), 9, null },
                    { 12, 2, 30, new DateTime(2025, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), 10, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookIssues_BookId",
                table: "BookIssues",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssues_ReaderId",
                table: "BookIssues",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AlphabetCode",
                table: "Books",
                column: "AlphabetCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_EditionTypeId",
                table: "Books",
                column: "EditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_InventoryNumber",
                table: "Books",
                column: "InventoryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_EditionTypes_Name",
                table: "EditionTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Name",
                table: "Publishers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_FullName",
                table: "Readers",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_Phone",
                table: "Readers",
                column: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookIssues");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "EditionTypes");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
