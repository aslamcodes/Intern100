using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestRaisedBy = table.Column<int>(type: "int", nullable: false),
                    RequestClosedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestNumber);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_RequestClosedBy",
                        column: x => x.RequestClosedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_RequestRaisedBy",
                        column: x => x.RequestRaisedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestSolutions",
                columns: table => new
                {
                    SolutionNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolutionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAccepted = table.Column<bool>(type: "bit", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SolutionPostedBy = table.Column<int>(type: "int", nullable: false),
                    RequestNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSolutions", x => x.SolutionNumber);
                    table.ForeignKey(
                        name: "FK_RequestSolutions_Employees_SolutionPostedBy",
                        column: x => x.SolutionPostedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestSolutions_Requests_RequestNumber",
                        column: x => x.RequestNumber,
                        principalTable: "Requests",
                        principalColumn: "RequestNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 101, "Ramu", "ramu123", "Admin" },
                    { 102, "Somu", "somu123", "Admin" },
                    { 103, "Bimu", "bimu123", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolutions_RequestNumber",
                table: "RequestSolutions",
                column: "RequestNumber");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolutions_SolutionPostedBy",
                table: "RequestSolutions",
                column: "SolutionPostedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestSolutions");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
