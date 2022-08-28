using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneDirectory.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentLeadId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.EmployeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone1 = table.Column<string>(type: "TEXT", nullable: true),
                    Phone2 = table.Column<string>(type: "TEXT", nullable: true),
                    Extension = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "EmployeeTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentEmployee",
                columns: table => new
                {
                    DepartmentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEmployee", x => new { x.DepartmentsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_DepartmentEmployee_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentLeadId", "Name" },
                values: new object[] { 1, null, "Executive" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentLeadId", "Name" },
                values: new object[] { 2, null, "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentLeadId", "Name" },
                values: new object[] { 3, null, "Accounting" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentLeadId", "Name" },
                values: new object[] { 4, null, "IT" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentLeadId", "Name" },
                values: new object[] { 5, null, "Maintenance" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "DisplayOrder", "Title" },
                values: new object[] { 1, 1, "Vice_President" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "DisplayOrder", "Title" },
                values: new object[] { 2, 2, "Director" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "DisplayOrder", "Title" },
                values: new object[] { 3, 3, "Assistant_Director" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "DisplayOrder", "Title" },
                values: new object[] { 4, 4, "Manager" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "DisplayOrder", "Title" },
                values: new object[] { 5, 5, "Assistant_Manager" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "DisplayOrder", "Title" },
                values: new object[] { 6, 6, "Supervisor" });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "DisplayOrder", "Title" },
                values: new object[] { 7, 7, "Employee" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 1, "atalat@acme.com", 1, 10, "Arif", "Talat", null, "951-555-1210", "213-555-1001" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 2, "acaryn@acme.com", 1, 11, "Aileas", "Caryn", null, "951-555-1211", "213-555-1002" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 3, "afatma@acme.com", 1, 12, "Ajay", "Fatma", null, "951-555-1212", "213-555-1003" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 4, "jadsila@acme.com", 1, 13, "Jacira", "Adsila", null, "951-555-1213", "213-555-1004" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 5, "aumukoro@acme.com", 1, 14, "Alister", "Umukoro", null, "951-555-1214", "213-555-1005" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 6, "mfitzgerald@acme.com", 2, 15, "Malaika", "Fitzgerald", null, "951-555-1215", "213-555-1006" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 7, "cgregory@acme.com", 2, 16, "Charleigh", "Gregory", null, "951-555-1216", "213-555-1007" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 8, "aingram@acme.com", 2, 17, "Anais ", "Ingram", null, "951-555-1217", "213-555-1008" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 9, "bbruce@acme.com", 2, 18, "Blane", "Bruce", null, "951-555-1218", "213-555-1009" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 10, "evasquez@acme.com", 2, 19, "Elli", "Vasquez", null, "951-555-1219", "213-555-1010" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 11, "eschroeder@acme.com", 3, 20, "Efan", "Schroeder", null, "951-555-1220", "213-555-1011" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 12, "kedwards@acme.com", 3, 21, "Kelsea", "Edwards", null, "951-555-1221", "213-555-1012" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 13, "kmcneill@acme.com", 3, 22, "Kaja ", "Mcneill", null, "951-555-1222", "213-555-1013" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 14, "cnewton@acme.com", 3, 23, "Cherise", "Newton", null, "951-555-1223", "213-555-1014" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 15, "mburton@acme.com", 3, 24, "Maud", "Burton", null, "951-555-1224", "213-555-1015" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 16, "shutton@acme.com", 4, 25, "Sheridan", "Hutton", null, "951-555-1225", "213-555-1016" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 17, "cfleming@acme.com", 4, 26, "Cassandra", "Fleming", null, "951-555-1226", "213-555-1017" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 18, "mandrew@acme.com", 4, 27, "Maariyah", "Andrew", null, "951-555-1227", "213-555-1018" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 19, "mmejia@acme.com", 4, 28, "Nathaniel", "Mejia", null, "951-555-1228", "213-555-1019" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 20, "hboone@acme.com", 4, 29, "Hawa", "Boone", null, "951-555-1229", "213-555-1020" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 21, "thamilton@acme.com", 5, 30, "Tahmid", "Hamilton", null, "951-555-1230", "213-555-1021" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 22, "rkent@acme.com", 5, 31, "Raiden", "Kent", null, "951-555-1231", "213-555-1022" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 23, "rallison@acme.com", 5, 32, "Rania", "Allison", null, "951-555-1232", "213-555-1023" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 24, "dmcnamara@acme.com", 5, 33, "Dotty", "Mcnamara", null, "951-555-1233", "213-555-1024" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 25, "hburris@acme.com", 5, 34, "Helen", "Burris", null, "951-555-1234", "213-555-1025" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 26, "ljenkins@acme.com", 6, 35, "Lilah", "Jenkins", null, "951-555-1235", "213-555-1026" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 27, "amccullough@acme.com", 6, 36, "Ajay", "Mccullough", null, "951-555-1236", "213-555-1027" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 28, "jgolden@acme.com", 6, 37, "Joss", "Golden", null, "951-555-1237", "213-555-1028" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 29, "fhoughton@acme.com", 6, 38, "Franklin", "Houghton", null, "951-555-1238", "213-555-1029" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 30, "owilcox@acme.com", 6, 39, "Oscar", "Wilcox", null, "951-555-1239", "213-555-1030" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 31, "mhoughton@acme.com", 7, 40, "Martyna", "Houghton", null, "951-555-1240", "213-555-1031" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 32, "ppugh@acme.com", 7, 41, "Prince", "Pugh", null, "951-555-1241", "213-555-1032" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 33, "ibull@acme.com", 7, 42, "Irene", "Bull", null, "951-555-1242", "213-555-1033" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 34, "hmcneil@acme.com", 7, 43, "Herbert", "Mcneil", null, "951-555-1243", "213-555-1034" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "EmployeeTypeId", "Extension", "FirstName", "LastName", "Notes", "Phone1", "Phone2" },
                values: new object[] { 35, "bhuber@acme.com", 7, 44, "Benjamin", "Huber", null, "951-555-1244", "213-555-1035" });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 1, 11 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 1, 16 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 1, 21 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 1, 26 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 1, 31 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 2, 7 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 2, 12 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 2, 17 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 2, 22 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 2, 27 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 2, 32 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 3, 8 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 3, 13 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 3, 18 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 3, 23 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 3, 28 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 3, 33 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 4, 9 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 4, 14 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 4, 19 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 4, 24 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 4, 29 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 4, 34 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 5, 10 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 5, 15 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 5, 20 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 5, 25 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 5, 30 });

            migrationBuilder.InsertData(
                table: "DepartmentEmployee",
                columns: new[] { "DepartmentsId", "EmployeesId" },
                values: new object[] { 5, 35 });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEmployee_EmployeesId",
                table: "DepartmentEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentEmployee");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");
        }
    }
}
