using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Members = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Steck = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDtos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserDtos",
                columns: new[] { "Id", "Description", "Email", "Image", "Name", "Role", "Skills", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "WOSPODJRSGCVXGFERZFL", "WOYQRKF", null, "GEZFE", null, "VBLHTIGYCZAWVRGQKROF", "Open", "MMQSRINAFB" },
                    { 2, "CJFZPQPYKETGRIAZWTAM", "VHMWQVE", null, "NDGXL", null, "FKMZFEEEJVLMCVZQSLDA", "Open", "TASAOPOIIM" },
                    { 3, "MRBKVBZZHYMVNQBYXGPN", "ZTZPLNY", null, "LCIMF", null, "VYJXMCHHGCRTLDIHRQWJ", "Open", "KWRFVCDLKQ" },
                    { 4, "CPIZZODRHZOONQIIELRH", "NPUYZZX", null, "HCSCB", null, "LDTHVSHZJVEPLJRPZSKS", "Open", "AUOASTXOIF" },
                    { 5, "KNAQDCEPANIERTZVBDGA", "JHNPPRX", null, "KLNZK", null, "LCZKQRUDVDJCBUTRVIIL", "Open", "DUOXIVBLMY" },
                    { 6, "XZKJEZPEGAMQJQLFMRVF", "OWIKUWK", null, "IYLTU", null, "GKUWTVZEMTPCFEIUSSEU", "Open", "ZDYGJTMTSJ" },
                    { 7, "BZLHFKZCNDDYAYLUPDAP", "TLJMCVE", null, "MWNNN", null, "GUSFXPDPZEPEISCVVXQV", "Open", "EGAGTEIBNC" },
                    { 8, "OZNHIUJBGQALNJQLIVKN", "IVJJOYF", null, "QVBLA", null, "USXUIVFUVGUDIHIVMZKT", "Open", "YAPWDVKERD" },
                    { 9, "GATIZFZHPZUDQZLZIUEG", "YNZAXRB", null, "PFYIZ", null, "TJKAQGFLTLVXCYSWGGZI", "Open", "ELEUKRWIHP" },
                    { 10, "LUKDEZPEQZQZIYVJNXGL", "XIBNSWG", null, "MUKFY", null, "MHJUYIIFRBBZEIKAZLES", "Open", "MLXDNIKKKI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDtos");

            migrationBuilder.DropTable(
                name: "UserDtos");
        }
    }
}
