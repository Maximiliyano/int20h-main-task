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
                name: "ResumeDtos",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    resume_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resume_template = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    job_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pd_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_at = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeDtos", x => x.id);
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
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiveId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    Invite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProjectDtos",
                columns: new[] { "Id", "Capacity", "Description", "EndDate", "Members", "Name", "ProjectState", "Rating", "StartDate", "Steck" },
                values: new object[,]
                {
                    { 1, 12, "DGMCXXHVDRRFHXSLXEXZ", "10/04/2024", "IRLGY", "DTUJB", "InProgress", 2.0, "5/03/2023", "IHESDJJYQWHXTDEKTERK" },
                    { 2, 16, "WLERDCQFTHMLAAZDCRZP", "10/04/2024", "OUAYB", "PWLBM", "InProgress", 4.0, "5/03/2023", "KZPCMOPOAZCAAZNKVKKT" },
                    { 3, 17, "CNTFYLFCEMISTSQTMXJE", "10/04/2024", "LYJGA", "QAYBW", "Planning", 2.0, "5/03/2023", "DODOQLZYGTXXUUKPIOKG" },
                    { 4, 14, "UCRMHLTJQCAEZIDSRXTK", "10/04/2024", "BIIQW", "INLJS", "Planning", 3.0, "5/03/2023", "JQTVNVVPHHOMMLHAKLYU" },
                    { 5, 23, "DHRGZOVGXNCCKCFAJGRG", "10/04/2024", "EDELN", "VDSTK", "Completed", 4.0, "5/03/2023", "GNLGIYBVUKGCCLZPAHBT" },
                    { 6, 21, "CZAAMECQXOSEKOPOVVMX", "10/04/2024", "QKHDM", "UWFSA", "Completed", 1.0, "5/03/2023", "RUIJPDKEVMYJGVLXHHWR" },
                    { 7, 20, "SATBCLDUIFSXPZCMAHOE", "10/04/2024", "ACDAQ", "AQBWB", "Planning", 2.0, "5/03/2023", "GYVHPGANBKZVBCUFPUYN" },
                    { 8, 25, "UEBAURMADGJLSTKGWIRE", "10/04/2024", "EADEU", "NYUHU", "InProgress", 2.0, "5/03/2023", "OAVXDJOGWMQSFMQBAJWI" },
                    { 9, 23, "ZFYNUJBDNNHMWUJDQTAU", "10/04/2024", "VVCMD", "YFWNJ", "LookingForParticipants", 4.0, "5/03/2023", "PXEIXQNMOYWBYHERLCGW" },
                    { 10, 15, "HOLMZAZURPAWZYDJJJXC", "10/04/2024", "KVDGY", "YIQBT", "InProgress", 2.0, "5/03/2023", "RNIVHUADAZJHJWRJNMRI" }
                });

            migrationBuilder.InsertData(
                table: "UserDtos",
                columns: new[] { "Id", "Description", "Email", "Image", "Name", "ProjectId", "ResumeId", "Role", "Skills", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "CDPOJYAJYELPBBWCWUCC", "FEYRIFH", null, "GKVSQ", 0, 0, null, "ZAZUNVOOYAQIFHNDVNEA", "Planning", "SNIOTFMPCW" },
                    { 2, "BRGVBVSGLBJFEVRGTSOB", "OAPKEJH", null, "AJCIV", 0, 0, null, "ZXSWGCAAQVAXYCIUVKIG", "LookingForParticipants", "OPMGORACOP" },
                    { 3, "UKDUYGBRKUJBDMVHRTPJ", "CAPQZLG", null, "OQJRX", 0, 0, null, "LKYVGYWXLCPKBTUPJVBF", "LookingForParticipants", "IUACFFCNXX" },
                    { 4, "WTDNTXVMEYKCUNRQZMRQ", "VNQBZZO", null, "DNXSS", 0, 0, null, "QECJYQWJVJNBRQVWDLNG", "InProgress", "ILKDWRCYOX" },
                    { 5, "XYOTICHRLXZRIZNXQPBQ", "CRHOAAZ", null, "XEPBY", 0, 0, null, "EWYSJIIJWTVJXZVBDYUK", "Completed", "ZTSHDGDXAX" },
                    { 6, "SIIPNVWNVSHASYSLDDZY", "PTAMVTY", null, "HNZQQ", 0, 0, null, "HXEZSULUORKJDORMLWRN", "InProgress", "LEHIDONIJK" },
                    { 7, "EHYNGWBNKIOOTMPXLVXY", "SOSGUDK", null, "TAOSL", 0, 0, null, "TJZUUVVQORWJCZTRSMBB", "Completed", "NGQKQNXHHN" },
                    { 8, "PWVSNEKASRTWECTSBTIA", "FDQGDAZ", null, "THBOR", 0, 0, null, "LQXJAJEZHSVOIMRXMBHC", "Completed", "IDTLMEWOBW" },
                    { 9, "ACXWTQGXBSCHTBXQLDUI", "CCNJEPM", null, "YGNRJ", 0, 0, null, "KQHALYZXWAUCNRJUNGGS", "InProgress", "XJJWISFJVI" },
                    { 10, "OVDDCDLDGQMOHXGETSLS", "YTIHFHI", null, "RGOED", 0, 0, null, "GKIAPMYPEENBXFKXXBGS", "Planning", "IRWOFPPUDZ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDtos");

            migrationBuilder.DropTable(
                name: "ResumeDtos");

            migrationBuilder.DropTable(
                name: "UserDtos");

            migrationBuilder.DropTable(
                name: "UserNotifications");
        }
    }
}
