
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Shared.Entities;
using static PhoneDirectory.Shared.Entities.EmployeeType;

namespace PhoneDirectory.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeType>()
                .Property(p => p.Title)
                .HasConversion<string>();

            modelBuilder.Entity<EmployeeType>()
                .HasData
                (
                    new EmployeeType { EmployeeTypeId = 1, Title = EmployeeTitle.Vice_President, DisplayOrder = 1 },
                    new EmployeeType { EmployeeTypeId = 2, Title = EmployeeTitle.Director, DisplayOrder = 2 },
                    new EmployeeType { EmployeeTypeId = 3, Title = EmployeeTitle.Assistant_Director, DisplayOrder = 3 },
                    new EmployeeType { EmployeeTypeId = 4, Title = EmployeeTitle.Manager, DisplayOrder = 4 },
                    new EmployeeType { EmployeeTypeId = 5, Title = EmployeeTitle.Assistant_Manager, DisplayOrder = 5 },
                    new EmployeeType { EmployeeTypeId = 6, Title = EmployeeTitle.Supervisor, DisplayOrder = 6 },
                    new EmployeeType { EmployeeTypeId = 7, Title = EmployeeTitle.Employee, DisplayOrder = 7 }
                );


            modelBuilder.Entity<Department>()
                .HasData(
                 new Department { Id = 1, Name = "Executive" },
                 new Department { Id = 2, Name = "HR" },
                 new Department { Id = 3, Name = "Accounting" },
                 new Department { Id = 4, Name = "IT" },
                 new Department { Id = 5, Name = "Maintenance" }
                );

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { Id = 1, FirstName = "Arif", LastName = "Talat", EmployeeTypeId = 1, Email = "atalat@acme.com", Phone1="951-555-1210", Phone2 = "213-555-1001", Extension = 10 },
                    new Employee { Id = 2, FirstName = "Aileas", LastName = "Caryn", EmployeeTypeId = 1, Email = "acaryn@acme.com", Phone1 = "951-555-1211", Phone2 = "213-555-1002", Extension = 11 },
                    new Employee { Id = 3, FirstName = "Ajay", LastName = "Fatma", EmployeeTypeId = 1, Email = "afatma@acme.com", Phone1 = "951-555-1212", Phone2 = "213-555-1003", Extension = 12 },
                    new Employee { Id = 4, FirstName = "Jacira", LastName = "Adsila", EmployeeTypeId = 1, Email = "jadsila@acme.com", Phone1 = "951-555-1213", Phone2 = "213-555-1004", Extension = 13 },
                    new Employee { Id = 5, FirstName = "Alister", LastName = "Umukoro", EmployeeTypeId = 1, Email = "aumukoro@acme.com", Phone1 = "951-555-1214", Phone2 = "213-555-1005", Extension = 14 },
                    new Employee { Id = 6, FirstName = "Malaika", LastName = "Fitzgerald", EmployeeTypeId = 2, Email = "mfitzgerald@acme.com", Phone1 = "951-555-1215", Phone2 = "213-555-1006", Extension = 15 },
                    new Employee { Id = 7, FirstName = "Charleigh", LastName = "Gregory", EmployeeTypeId = 2, Email = "cgregory@acme.com", Phone1 = "951-555-1216", Phone2 = "213-555-1007", Extension = 16 },
                    new Employee { Id = 8, FirstName = "Anais ", LastName = "Ingram", EmployeeTypeId = 2, Email = "aingram@acme.com", Phone1 = "951-555-1217", Phone2 = "213-555-1008", Extension = 17 },
                    new Employee { Id = 9, FirstName = "Blane", LastName = "Bruce", EmployeeTypeId = 2, Email = "bbruce@acme.com", Phone1 = "951-555-1218", Phone2 = "213-555-1009", Extension = 18 },
                    new Employee { Id = 10, FirstName = "Elli", LastName = "Vasquez", EmployeeTypeId = 2, Email = "evasquez@acme.com", Phone1 = "951-555-1219", Phone2 = "213-555-1010", Extension = 19 },
                    new Employee { Id = 11, FirstName = "Efan", LastName = "Schroeder", EmployeeTypeId = 3, Email = "eschroeder@acme.com", Phone1 = "951-555-1220", Phone2 = "213-555-1011", Extension = 20 },
                    new Employee { Id = 12, FirstName = "Kelsea", LastName = "Edwards", EmployeeTypeId = 3, Email = "kedwards@acme.com", Phone1 = "951-555-1221", Phone2 = "213-555-1012", Extension = 21 },
                    new Employee { Id = 13, FirstName = "Kaja ", LastName = "Mcneill", EmployeeTypeId = 3, Email = "kmcneill@acme.com", Phone1 = "951-555-1222", Phone2 = "213-555-1013", Extension = 22 },
                    new Employee { Id = 14, FirstName = "Cherise", LastName = "Newton", EmployeeTypeId = 3, Email = "cnewton@acme.com", Phone1 = "951-555-1223", Phone2 = "213-555-1014", Extension = 23 },
                    new Employee { Id = 15, FirstName = "Maud", LastName = "Burton", EmployeeTypeId = 3, Email = "mburton@acme.com", Phone1 = "951-555-1224", Phone2 = "213-555-1015", Extension = 24 },
                    new Employee { Id = 16, FirstName = "Sheridan", LastName = "Hutton", EmployeeTypeId = 4, Email = "shutton@acme.com", Phone1 = "951-555-1225", Phone2 = "213-555-1016", Extension = 25 },
                    new Employee { Id = 17, FirstName = "Cassandra", LastName = "Fleming", EmployeeTypeId = 4, Email = "cfleming@acme.com", Phone1 = "951-555-1226", Phone2 = "213-555-1017", Extension = 26 },
                    new Employee { Id = 18, FirstName = "Maariyah", LastName = "Andrew", EmployeeTypeId = 4, Email = "mandrew@acme.com", Phone1 = "951-555-1227", Phone2 = "213-555-1018", Extension = 27 },
                    new Employee { Id = 19, FirstName = "Nathaniel", LastName = "Mejia", EmployeeTypeId = 4, Email = "mmejia@acme.com", Phone1 = "951-555-1228", Phone2 = "213-555-1019", Extension = 28 },
                    new Employee { Id = 20, FirstName = "Hawa", LastName = "Boone", EmployeeTypeId = 4, Email = "hboone@acme.com", Phone1 = "951-555-1229", Phone2 = "213-555-1020", Extension = 29 },
                    new Employee { Id = 21, FirstName = "Tahmid", LastName = "Hamilton", EmployeeTypeId = 5, Email = "thamilton@acme.com", Phone1 = "951-555-1230", Phone2 = "213-555-1021", Extension = 30 },
                    new Employee { Id = 22, FirstName = "Raiden", LastName = "Kent", EmployeeTypeId = 5, Email = "rkent@acme.com", Phone1 = "951-555-1231", Phone2 = "213-555-1022", Extension = 31 },
                    new Employee { Id = 23, FirstName = "Rania", LastName = "Allison", EmployeeTypeId = 5, Email = "rallison@acme.com", Phone1 = "951-555-1232", Phone2 = "213-555-1023", Extension = 32 },
                    new Employee { Id = 24, FirstName = "Dotty", LastName = "Mcnamara", EmployeeTypeId = 5, Email = "dmcnamara@acme.com", Phone1 = "951-555-1233", Phone2 = "213-555-1024", Extension = 33 },
                    new Employee { Id = 25, FirstName = "Helen", LastName = "Burris", EmployeeTypeId = 5, Email = "hburris@acme.com", Phone1 = "951-555-1234", Phone2 = "213-555-1025", Extension = 34 },
                    new Employee { Id = 26, FirstName = "Lilah", LastName = "Jenkins", EmployeeTypeId = 6, Email = "ljenkins@acme.com", Phone1 = "951-555-1235", Phone2 = "213-555-1026", Extension = 35 },
                    new Employee { Id = 27, FirstName = "Ajay", LastName = "Mccullough", EmployeeTypeId = 6, Email = "amccullough@acme.com", Phone1 = "951-555-1236", Phone2 = "213-555-1027", Extension = 36 },
                    new Employee { Id = 28, FirstName = "Joss", LastName = "Golden", EmployeeTypeId = 6, Email = "jgolden@acme.com", Phone1 = "951-555-1237", Phone2 = "213-555-1028", Extension = 37 },
                    new Employee { Id = 29, FirstName = "Franklin", LastName = "Houghton", EmployeeTypeId = 6, Email = "fhoughton@acme.com", Phone1 = "951-555-1238", Phone2 = "213-555-1029", Extension = 38 },
                    new Employee { Id = 30, FirstName = "Oscar", LastName = "Wilcox", EmployeeTypeId = 6, Email = "owilcox@acme.com", Phone1 = "951-555-1239", Phone2 = "213-555-1030", Extension = 39 },
                    new Employee { Id = 31, FirstName = "Martyna", LastName = "Houghton", EmployeeTypeId = 7, Email = "mhoughton@acme.com", Phone1 = "951-555-1240", Phone2 = "213-555-1031", Extension = 40 },
                    new Employee { Id = 32, FirstName = "Prince", LastName = "Pugh", EmployeeTypeId = 7, Email = "ppugh@acme.com", Phone1 = "951-555-1241", Phone2 = "213-555-1032", Extension = 41 },
                    new Employee { Id = 33, FirstName = "Irene", LastName = "Bull", EmployeeTypeId = 7, Email = "ibull@acme.com", Phone1 = "951-555-1242", Phone2 = "213-555-1033", Extension = 42 },
                    new Employee { Id = 34, FirstName = "Herbert", LastName = "Mcneil", EmployeeTypeId = 7, Email = "hmcneil@acme.com", Phone1 = "951-555-1243", Phone2 = "213-555-1034", Extension = 43 },
                    new Employee { Id = 35, FirstName = "Benjamin", LastName = "Huber", EmployeeTypeId = 7, Email = "bhuber@acme.com", Phone1 = "951-555-1244", Phone2 = "213-555-1035", Extension = 44 }
                );


            modelBuilder.Entity<Employee>()
                .HasMany(m => m.Departments)
                .WithMany(w => w.Employees)
                .UsingEntity(u => u.HasData(
                    new { DepartmentsId = 1, EmployeesId = 1 },
                    new { DepartmentsId = 2, EmployeesId = 2 },
                    new { DepartmentsId = 3, EmployeesId = 3 },
                    new { DepartmentsId = 4, EmployeesId = 4 },
                    new { DepartmentsId = 5, EmployeesId = 5 },
                    new { DepartmentsId = 1, EmployeesId = 6 },
                    new { DepartmentsId = 2, EmployeesId = 7 },
                    new { DepartmentsId = 3, EmployeesId = 8 },
                    new { DepartmentsId = 4, EmployeesId = 9 },
                    new { DepartmentsId = 5, EmployeesId = 10 }, 
                    new { DepartmentsId = 1, EmployeesId = 11 },
                    new { DepartmentsId = 2, EmployeesId = 12 },
                    new { DepartmentsId = 3, EmployeesId = 13 },
                    new { DepartmentsId = 4, EmployeesId = 14 },
                    new { DepartmentsId = 5, EmployeesId = 15 },
                    new { DepartmentsId = 1, EmployeesId = 16 },
                    new { DepartmentsId = 2, EmployeesId = 17 },
                    new { DepartmentsId = 3, EmployeesId = 18 },
                    new { DepartmentsId = 4, EmployeesId = 19 },
                    new { DepartmentsId = 5, EmployeesId = 20 },
                    new { DepartmentsId = 1, EmployeesId = 21 },
                    new { DepartmentsId = 2, EmployeesId = 22 },
                    new { DepartmentsId = 3, EmployeesId = 23 },
                    new { DepartmentsId = 4, EmployeesId = 24 },
                    new { DepartmentsId = 5, EmployeesId = 25 },
                    new { DepartmentsId = 1, EmployeesId = 26 },
                    new { DepartmentsId = 2, EmployeesId = 27 },
                    new { DepartmentsId = 3, EmployeesId = 28 },
                    new { DepartmentsId = 4, EmployeesId = 29 },
                    new { DepartmentsId = 5, EmployeesId = 30 },
                    new { DepartmentsId = 1, EmployeesId = 31 },
                    new { DepartmentsId = 2, EmployeesId = 32 },
                    new { DepartmentsId = 3, EmployeesId = 33 },
                    new { DepartmentsId = 4, EmployeesId = 34 },
                    new { DepartmentsId = 5, EmployeesId = 35 }
                    )
                );


            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
    }
}
