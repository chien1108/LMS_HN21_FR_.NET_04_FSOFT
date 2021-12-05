using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_Managerment_SystemMarket_Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyNameID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAQFor = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedBackName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailNotification = table.Column<int>(type: "int", nullable: false),
                    PushNotification = table.Column<int>(type: "int", nullable: false),
                    EmailVerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForWhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForWho = table.Column<int>(type: "int", nullable: false),
                    EmailTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhoIs = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRtl = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorVerifies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorVerifies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorVerifies_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayOuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusPay = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayOuts_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorDiscusstions",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dislikes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorDiscusstions", x => new { x.StudentId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_InstructorDiscusstions_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorDiscusstions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WhoIs = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubScriptions",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubScriptions", x => new { x.StudentId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_SubScriptions_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubScriptions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsBestseller = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CoverImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PromotionVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Dislike = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Share = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Views = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_SubCategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Carts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseContents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseRates",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Messge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Star = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRates", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseRates_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRates_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeDislikeCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ForWhat = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeDislikeCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_LikeDislikeCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeDislikeCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    AdminCommission = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportAbuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAbuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportAbuses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportAbuses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedCourses", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_SavedCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", precision: 8, scale: 5, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialDiscounts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseContentId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Positon = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_CourseContents_CourseContentId",
                        column: x => x.CourseContentId,
                        principalTable: "CourseContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaytabsInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseCode = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Curency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaytabsInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaytabsInvoices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminSettings",
                columns: new[] { "Id", "CreatedDate", "KeyNameID", "ModifiedDate", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4340), "c_p", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4350), "Copyright Policy<br>" },
                    { 32, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4665), "footer_logo", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4667), "footerlpgo.png" },
                    { 31, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4659), "dark_logo", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4662), null },
                    { 29, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4648), "seo_twitter_title", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4650), "Online Courses - Anytime, Anywhere" },
                    { 28, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4642), "seo_meta", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4645), "online,courses,learning,teaching" },
                    { 27, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4637), "seo_description", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4639), "is the world&#39;s largest destination for online courses. Discover an online course and start learning a new skill today." },
                    { 26, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4631), "seo_title", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4634), "Online Courses - Anytime, Anywhere Cursus" },
                    { 25, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4626), "razorpay", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4628), "0" },
                    { 24, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4620), "stripe_pk", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4622), "0" },
                    { 23, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4613), "stripe", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4616), "0" },
                    { 22, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4608), "palypal_client_id", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4610), "" },
                    { 21, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4600), "paypal", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4602), "0" },
                    { 20, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4594), "verification_sell", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4597), "100" },
                    { 19, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4588), "verification_subscriber", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4591), "500" },
                    { 18, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4582), "pinterest", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4584), "pinterest" },
                    { 17, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4576), "youtube", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4579), "youtube" },
                    { 30, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4654), "seo_canonical", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4656), "https://coursearly.com/cursus/public/" },
                    { 15, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4564), "linkedin", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4566), "linkedin" },
                    { 2, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4358), "p_p", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4360), "Privacy Policy<br>" },
                    { 3, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4365), "terms", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4368), "terms" },
                    { 4, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4371), "logo", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4376), "/frontend/images/logo.svg" },
                    { 6, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4389), "admin_commission", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4392), "3" },
                    { 7, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4396), "currency_code", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4398), "USD" },
                    { 8, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4518), "currency_symbole", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4520), "$" },
                    { 5, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4382), "favicon", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4384), "/frontend/images/fav.png" },
                    { 10, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4534), "default_theme", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4537), "night-mode" },
                    { 11, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4540), "instructor_verification", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4542), "0" },
                    { 12, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4546), "user_verification", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4548), "0" },
                    { 13, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4552), "facebook", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4555), "facebook" },
                    { 14, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4558), "twitter", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4560), "twitter" },
                    { 9, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4528), "notification", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4530), "0" },
                    { 16, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4570), "Instagram", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(4572), "Instagram" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 8, "Finance & Accounting", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5059), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5061), 1 },
                    { 13, "Teaching & Academics", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5088), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5091), 1 },
                    { 12, "Health & Fitness", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5083), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5085), 1 },
                    { 11, "Lifestyle", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5077), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5079), 1 },
                    { 10, "Personal Development", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5071), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5073), 1 },
                    { 9, "Office Productivity", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5065), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5067), 1 },
                    { 7, "IT & Software", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5053), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5055), 1 },
                    { 5, "Design", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5041), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5044), 1 },
                    { 4, "Business", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5035), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5038), 1 },
                    { 3, "Development", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5029), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5032), 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 2, "Marketing", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5023), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5025), 1 },
                    { 1, "Photography", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(4989), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5016), 1 },
                    { 6, "Music", new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5047), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(5049), 1 }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "CreatedDate", "FAQFor", "ModifiedDate", "Question" },
                values: new object[,]
                {
                    { 1, "Manage your account settings.", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(7573), 0, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(7586), "Account/Profile" },
                    { 2, "Manage your account settings.", new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(7593), 1, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(7596), "Account/Profile" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedDate", "LanguageName", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 12, 3, 14, 37, 26, 92, DateTimeKind.Local).AddTicks(953), "Vietnamese", new DateTime(2021, 12, 3, 14, 37, 26, 92, DateTimeKind.Local).AddTicks(964), 0 },
                    { 3, new DateTime(2021, 12, 3, 14, 37, 26, 92, DateTimeKind.Local).AddTicks(968), "Korean", new DateTime(2021, 12, 3, 14, 37, 26, 92, DateTimeKind.Local).AddTicks(970), 0 },
                    { 1, new DateTime(2021, 12, 3, 14, 37, 26, 90, DateTimeKind.Local).AddTicks(1137), "English", new DateTime(2021, 12, 3, 14, 37, 26, 91, DateTimeKind.Local).AddTicks(9997), 0 }
                });

            migrationBuilder.InsertData(
                table: "NotificationTemplates",
                columns: new[] { "Id", "CreatedDate", "EmailTitle", "ForWhat", "ForWho", "ModifiedDate", "NotificationTitle", "Subject" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2304), "New Course (Subscribe Institute)", "New Course (Subscribe Institute)", 1, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2306), "New Course (Subscribe Institute)", "New Course (Subscribe Institute)" },
                    { 1, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2233), "Cource Approved", "Cource Approved", 2, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2245), "Cource Approved", "Cource Approved" },
                    { 2, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2255), "Course Sell", "Course Sell", 2, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2257), "Course Sell", "Course Sell" },
                    { 3, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2262), "Payout Update", "Payout Update", 2, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2264), "Payout Update", "Payout Update" },
                    { 4, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2269), "Review Added", "Review Added", 2, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2272), "Review Added", "Review Added" },
                    { 5, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2277), "Thanks For Review", "Thanks For Review", 1, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2280), "Thanks For Review", "Thanks For Review" },
                    { 6, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2283), "Report Feedback", "Report Feedback", 1, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2286), "Report Feedback", "Report Feedback" },
                    { 7, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2290), "Cource Block", "Cource Block", 2, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2292), "Cource Block", "Cource Block" },
                    { 8, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2297), "Live Now (Subscribe Institute)", "Live Now (Subscribe Institute)", 1, new DateTime(2021, 12, 3, 14, 37, 26, 95, DateTimeKind.Local).AddTicks(2300), "Live Now (Subscribe Institute)", "Live Now (Subscribe Institute)" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "GuardName", "Name", "NormalizedName" },
                values: new object[] { 1, "047c4f31-97a3-4dcc-9ab9-2b6f6d4bd6fc", "Web", "Admin S", "Admin S" });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "RoleId" },
                values: new object[,]
                {
                    { 21, "SubCategory_Create", "SubCategory_Create", "Claim", 1 },
                    { 23, "SubCategory_Access", "SubCategory_Access", "Claim", 1 },
                    { 24, "SubCategory_Show", "SubCategory_Show", "Claim", 1 },
                    { 25, "SubCategory_Delete", "SubCategory_Delete", "Claim", 1 },
                    { 26, "Instructor_Edit", "Instructor_Edit", "Claim", 1 },
                    { 27, "Instructor_Access", "Instructor_Access", "Claim", 1 },
                    { 28, "Instructor_Show", "Instructor_Show", "Claim", 1 },
                    { 29, "Course_Access", "Course_Access", "Claim", 1 },
                    { 30, "Course_Show", "Course_Show", "Claim", 1 },
                    { 31, "Verification_Access", "Verification_Access", "Claim", 1 },
                    { 32, "FAQ_Create", "FAQ_Create", "Claim", 1 },
                    { 33, "FAQ_Show", "FAQ_Show", "Claim", 1 },
                    { 22, "SubCategory_Edit", "SubCategory_Edit", "Claim", 1 },
                    { 34, "FAQ_Edit", "FAQ_Edit", "Claim", 1 },
                    { 36, "FAQ_Delete", "FAQ_Delete", "Claim", 1 },
                    { 37, "Student_Edit", "Student_Edit", "Claim", 1 },
                    { 38, "Student_Access", "Student_Access", "Claim", 1 },
                    { 39, "Student_Show", "Student_Show", "Claim", 1 },
                    { 40, "PayOut_Access", "PayOut_Access", "Claim", 1 },
                    { 41, "Setting_Access", "Setting_Access", "Claim", 1 },
                    { 42, "Report_Access", "Report_Access", "Claim", 1 },
                    { 43, "Notification_Access", "Notification_Access", "Claim", 1 },
                    { 44, "FeedBack_Access", "FeedBack_Access", "Claim", 1 },
                    { 45, "Lang_Access", "Lang_Access", "Claim", 1 },
                    { 46, "Lang_Create", "Lang_Create", "Claim", 1 },
                    { 35, "FAQ_Access", "FAQ_Access", "Claim", 1 },
                    { 47, "Lang_Delete", "Lang_Delete", "Claim", 1 },
                    { 48, "Lang_Edit", "Lang_Edit", "Claim", 1 },
                    { 19, "Category_Show", "Category_Show", "Claim", 1 },
                    { 1, "Role_Create", "Role_Create", "Claim", 1 },
                    { 2, "Role_Edit", "Role_Edit", "Claim", 1 },
                    { 3, "Role_Access", "Role_Access", "Claim", 1 },
                    { 4, "Role_Access", "Role_Access", "Claim", 1 },
                    { 5, "Role_Delete", "Role_Delete", "Claim", 1 },
                    { 20, "Category_Delete", "Category_Delete", "Claim", 1 },
                    { 7, "User_Edit", "User_Edit", "Claim", 1 },
                    { 8, "User_Access", "User_Access", "Claim", 1 },
                    { 9, "User_Show", "User_Show", "Claim", 1 },
                    { 6, "User_Create", "User_Create", "Claim", 1 },
                    { 11, "Language_Create", "Language_Create", "Claim", 1 },
                    { 12, "Language_Edit", "Language_Edit", "Claim", 1 },
                    { 13, "Language_Access", "Language_Access", "Claim", 1 }
                });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "RoleId" },
                values: new object[,]
                {
                    { 14, "Language_Show", "Language_Show", "Claim", 1 },
                    { 15, "Language_Delete", "Language_Delete", "Claim", 1 },
                    { 16, "Category_Create", "Category_Create", "Claim", 1 },
                    { 17, "Category_Edit", "Category_Edit", "Claim", 1 },
                    { 18, "Category_Access", "Category_Access", "Claim", 1 },
                    { 10, "User_Delete", "User_Delete", "Claim", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "ModifiedDate", "Status", "SubCategoryName" },
                values: new object[,]
                {
                    { 4, 5, new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8431), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8433), 1, "UI Design" },
                    { 6, 4, new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8447), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8449), 1, "B2B Business" },
                    { 7, 3, new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8453), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8455), 1, "Python" },
                    { 5, 3, new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8437), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8439), 1, "Full Stack Development" },
                    { 3, 2, new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8424), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8427), 1, "Digital Marketing" },
                    { 2, 1, new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8418), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8420), 1, "JS" },
                    { 1, 1, new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8397), new DateTime(2021, 12, 3, 14, 37, 26, 94, DateTimeKind.Local).AddTicks(8410), 1, "CSS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CourseId",
                table: "Carts",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseContents_CourseId",
                table: "CourseContents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRates_StudentId",
                table: "CourseRates",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LanguageId",
                table: "Courses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubcategoryId",
                table: "Courses",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorDiscusstions_InstructorId",
                table: "InstructorDiscusstions",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorVerifies_InstructorId",
                table: "InstructorVerifies",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseContentId",
                table: "Lectures",
                column: "CourseContentId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeDislikeCourses_CourseId",
                table: "LikeDislikeCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_InstructorId",
                table: "Notifications",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_StudentId",
                table: "Notifications",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CourseId",
                table: "Orders",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StudentId",
                table: "Orders",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PayOuts_InstructorId",
                table: "PayOuts",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaytabsInvoices_OrderId",
                table: "PaytabsInvoices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAbuses_CourseId",
                table: "ReportAbuses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAbuses_StudentId",
                table: "ReportAbuses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SavedCourses_StudentId",
                table: "SavedCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDiscounts_CourseId",
                table: "SpecialDiscounts",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubScriptions_InstructorId",
                table: "SubScriptions",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminSettings");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "CourseRates");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "InstructorDiscusstions");

            migrationBuilder.DropTable(
                name: "InstructorVerifies");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "LikeDislikeCourses");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationTemplates");

            migrationBuilder.DropTable(
                name: "PayOuts");

            migrationBuilder.DropTable(
                name: "PaytabsInvoices");

            migrationBuilder.DropTable(
                name: "ReportAbuses");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SavedCourses");

            migrationBuilder.DropTable(
                name: "SpecialDiscounts");

            migrationBuilder.DropTable(
                name: "SubScriptions");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "WebLanguages");

            migrationBuilder.DropTable(
                name: "CourseContents");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
