using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Learning_Managerment_SystemMarket_Core.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>()
                    .HasData(
                        new Language { Id = 1, LanguageName = "English", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new Language { Id = 2, LanguageName = "Vietnamese", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new Language { Id = 3, LanguageName = "Korean", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                            );

            modelBuilder.Entity<Category>()
                    .HasData(
                        new Category
                        {
                            Id = 1,
                            CategoryName = "Photography",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 2,
                            CategoryName = "Marketing",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 3,
                            CategoryName = "Development",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 4,
                            CategoryName = "Business",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 5,
                            CategoryName = "Design",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 6,
                            CategoryName = "Music",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 7,
                            CategoryName = "IT & Software",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 8,
                            CategoryName = "Finance & Accounting",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 9,
                            CategoryName = "Office Productivity",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 10,
                            CategoryName = "Personal Development",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 11,
                            CategoryName = "Lifestyle",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 12,
                            CategoryName = "Health & Fitness",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new Category
                        {
                            Id = 13,
                            CategoryName = "Teaching & Academics",
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        }
                            );
            modelBuilder.Entity<SubCategory>()
                    .HasData(
                        new SubCategory
                        {
                            Id = 1,
                            SubCategoryName = "CSS",
                            CategoryId = 1,
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new SubCategory
                        {
                            Id = 2,
                            SubCategoryName = "JS",
                            CategoryId = 1,
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new SubCategory
                        {
                            Id = 3,
                            SubCategoryName = "Digital Marketing",
                            CategoryId = 2,
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new SubCategory
                        {
                            Id = 4,
                            SubCategoryName = "UI Design",
                            CategoryId = 5,
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new SubCategory
                        {
                            Id = 5,
                            SubCategoryName = "Full Stack Development",
                            CategoryId = 3,
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new SubCategory
                        {
                            Id = 6,
                            SubCategoryName = "B2B Business",
                            CategoryId = 4,
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new SubCategory
                        {
                            Id = 7,
                            SubCategoryName = "Python",
                            CategoryId = 3,
                            Status = Status.IsActive,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        }
                            );

            modelBuilder.Entity<NotificationTemplate>()
                    .HasData(
                        new NotificationTemplate
                        {
                            Id = 1,
                            ForWhat = "Cource Approved",
                            ForWho = 2,
                            EmailTitle = "Cource Approved",
                            Subject = "Cource Approved",
                            NotificationTitle = "Cource Approved",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new NotificationTemplate
                        {
                            Id = 2,
                            ForWhat = "Course Sell",
                            ForWho = 2,
                            EmailTitle = "Course Sell",
                            Subject = "Course Sell",
                            NotificationTitle = "Course Sell",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new NotificationTemplate
                        {
                            Id = 3,
                            ForWhat = "Payout Update",
                            ForWho = 2,
                            EmailTitle = "Payout Update",
                            Subject = "Payout Update",
                            NotificationTitle = "Payout Update",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new NotificationTemplate
                        {
                            Id = 4,
                            ForWhat = "Review Added",
                            ForWho = 2,
                            EmailTitle = "Review Added",
                            Subject = "Review Added",
                            NotificationTitle = "Review Added",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new NotificationTemplate
                        {
                            Id = 5,
                            ForWhat = "Thanks For Review",
                            ForWho = 1,
                            EmailTitle = "Thanks For Review",
                            Subject = "Thanks For Review",
                            NotificationTitle = "Thanks For Review",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new NotificationTemplate
                        {
                            Id = 6,
                            ForWhat = "Report Feedback",
                            ForWho = 1,
                            EmailTitle = "Report Feedback",
                            Subject = "Report Feedback",
                            NotificationTitle = "Report Feedback",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new NotificationTemplate
                        {
                            Id = 7,
                            ForWhat = "Cource Block",
                            ForWho = 2,
                            EmailTitle = "Cource Block",
                            Subject = "Cource Block",
                            NotificationTitle = "Cource Block",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new NotificationTemplate
                        {
                            Id = 8,
                            ForWhat = "Live Now (Subscribe Institute)",
                            ForWho = 1,
                            EmailTitle = "Live Now (Subscribe Institute)",
                            Subject = "Live Now (Subscribe Institute)",
                            NotificationTitle = "Live Now (Subscribe Institute)",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new NotificationTemplate
                        {
                            Id = 9,
                            ForWhat = "New Course (Subscribe Institute)",
                            ForWho = 1,
                            EmailTitle = "New Course (Subscribe Institute)",
                            Subject = "New Course (Subscribe Institute)",
                            NotificationTitle = "New Course (Subscribe Institute)",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        }
                            );

            modelBuilder.Entity<AdminSetting>()
                    .HasData(
                        new AdminSetting { Id = 1, KeyNameID = "c_p", Value = "Copyright Policy<br>", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 2, KeyNameID = "p_p", Value = "Privacy Policy<br>", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 3, KeyNameID = "terms", Value = "terms", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 4, KeyNameID = "logo", Value = "/frontend/images/logo.svg", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 5, KeyNameID = "favicon", Value = "/frontend/images/fav.png", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 6, KeyNameID = "admin_commission", Value = "3", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 7, KeyNameID = "currency_code", Value = "USD", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 8, KeyNameID = "currency_symbole", Value = "$", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 9, KeyNameID = "notification", Value = "0", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 10, KeyNameID = "default_theme", Value = "night-mode", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 11, KeyNameID = "instructor_verification", Value = "0", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 12, KeyNameID = "user_verification", Value = "0", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 13, KeyNameID = "facebook", Value = "facebook", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 14, KeyNameID = "twitter", Value = "twitter", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 15, KeyNameID = "linkedin", Value = "linkedin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 16, KeyNameID = "Instagram", Value = "Instagram", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 17, KeyNameID = "youtube", Value = "youtube", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 18, KeyNameID = "pinterest", Value = "pinterest", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 19, KeyNameID = "verification_subscriber", Value = "500", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 20, KeyNameID = "verification_sell", Value = "100", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 21, KeyNameID = "paypal", Value = "0", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 22, KeyNameID = "palypal_client_id", Value = "", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 23, KeyNameID = "stripe", Value = "0", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 24, KeyNameID = "stripe_pk", Value = "0", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 25, KeyNameID = "razorpay", Value = "0", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 26, KeyNameID = "seo_title", Value = "Online Courses - Anytime, Anywhere Cursus", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 27, KeyNameID = "seo_description", Value = "is the world&#39;s largest destination for online courses. Discover an online course and start learning a new skill today.", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 28, KeyNameID = "seo_meta", Value = "online,courses,learning,teaching", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 29, KeyNameID = "seo_twitter_title", Value = "Online Courses - Anytime, Anywhere", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 30, KeyNameID = "seo_canonical", Value = "https://coursearly.com/cursus/public/", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 31, KeyNameID = "dark_logo", Value = null, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new AdminSetting { Id = 32, KeyNameID = "footer_logo", Value = "footerlpgo.png", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                            );
            modelBuilder.Entity<FAQ>()
                    .HasData(
                        new FAQ { Id = 1, FAQFor = 0, Question = "Account/Profile", Answer = "Manage your account settings.", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                        new FAQ { Id = 2, FAQFor = 1, Question = "Account/Profile", Answer = "Manage your account settings.", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                            );

            modelBuilder.Entity<Role>()
                        .HasData(
                                new Role { Id = 1, Name = "Admin S", GuardName = "Web", NormalizedName = "Admin S", ConcurrencyStamp = Guid.NewGuid().ToString() }
                                 );
            modelBuilder.Entity<Claim>()
                        .HasData(
                            new Claim { Id = 1, RoleId = 1, ClaimType = "Role_Create", ClaimValue = "Role_Create" },
                            new Claim { Id = 2, RoleId = 1, ClaimType = "Role_Edit", ClaimValue = "Role_Edit" },
                            new Claim { Id = 3, RoleId = 1, ClaimType = "Role_Access", ClaimValue = "Role_Access" },
                            new Claim { Id = 4, RoleId = 1, ClaimType = "Role_Access", ClaimValue = "Role_Access" },
                            new Claim { Id = 5, RoleId = 1, ClaimType = "Role_Delete", ClaimValue = "Role_Delete" },
                            new Claim { Id = 6, RoleId = 1, ClaimType = "User_Create", ClaimValue = "User_Create" },
                            new Claim { Id = 7, RoleId = 1, ClaimType = "User_Edit", ClaimValue = "User_Edit" },
                            new Claim { Id = 8, RoleId = 1, ClaimType = "User_Access", ClaimValue = "User_Access" },
                            new Claim { Id = 9, RoleId = 1, ClaimType = "User_Show", ClaimValue = "User_Show" },
                            new Claim { Id = 10, RoleId = 1, ClaimType = "User_Delete", ClaimValue = "User_Delete" },
                            new Claim { Id = 11, RoleId = 1, ClaimType = "Language_Create", ClaimValue = "Language_Create" },
                            new Claim { Id = 12, RoleId = 1, ClaimType = "Language_Edit", ClaimValue = "Language_Edit" },
                            new Claim { Id = 13, RoleId = 1, ClaimType = "Language_Access", ClaimValue = "Language_Access" },
                            new Claim { Id = 14, RoleId = 1, ClaimType = "Language_Show", ClaimValue = "Language_Show" },
                            new Claim { Id = 15, RoleId = 1, ClaimType = "Language_Delete", ClaimValue = "Language_Delete" },
                            new Claim { Id = 16, RoleId = 1, ClaimType = "Category_Create", ClaimValue = "Category_Create" },
                            new Claim { Id = 17, RoleId = 1, ClaimType = "Category_Edit", ClaimValue = "Category_Edit" },
                            new Claim { Id = 18, RoleId = 1, ClaimType = "Category_Access", ClaimValue = "Category_Access" },
                            new Claim { Id = 19, RoleId = 1, ClaimType = "Category_Show", ClaimValue = "Category_Show" },
                            new Claim { Id = 20, RoleId = 1, ClaimType = "Category_Delete", ClaimValue = "Category_Delete" },
                            new Claim { Id = 21, RoleId = 1, ClaimType = "SubCategory_Create", ClaimValue = "SubCategory_Create" },
                            new Claim { Id = 22, RoleId = 1, ClaimType = "SubCategory_Edit", ClaimValue = "SubCategory_Edit" },
                            new Claim { Id = 23, RoleId = 1, ClaimType = "SubCategory_Access", ClaimValue = "SubCategory_Access" },
                            new Claim { Id = 24, RoleId = 1, ClaimType = "SubCategory_Show", ClaimValue = "SubCategory_Show" },
                            new Claim { Id = 25, RoleId = 1, ClaimType = "SubCategory_Delete", ClaimValue = "SubCategory_Delete" },
                            new Claim { Id = 26, RoleId = 1, ClaimType = "Instructor_Edit", ClaimValue = "Instructor_Edit" },
                            new Claim { Id = 27, RoleId = 1, ClaimType = "Instructor_Access", ClaimValue = "Instructor_Access" },
                            new Claim { Id = 28, RoleId = 1, ClaimType = "Instructor_Show", ClaimValue = "Instructor_Show" },
                            new Claim { Id = 29, RoleId = 1, ClaimType = "Course_Access", ClaimValue = "Course_Access" },
                            new Claim { Id = 30, RoleId = 1, ClaimType = "Course_Show", ClaimValue = "Course_Show" },
                            new Claim { Id = 31, RoleId = 1, ClaimType = "Verification_Access", ClaimValue = "Verification_Access" },
                            new Claim { Id = 32, RoleId = 1, ClaimType = "FAQ_Create", ClaimValue = "FAQ_Create" },
                            new Claim { Id = 33, RoleId = 1, ClaimType = "FAQ_Show", ClaimValue = "FAQ_Show" },
                            new Claim { Id = 34, RoleId = 1, ClaimType = "FAQ_Edit", ClaimValue = "FAQ_Edit" },
                            new Claim { Id = 35, RoleId = 1, ClaimType = "FAQ_Access", ClaimValue = "FAQ_Access" },
                            new Claim { Id = 36, RoleId = 1, ClaimType = "FAQ_Delete", ClaimValue = "FAQ_Delete" },
                            new Claim { Id = 37, RoleId = 1, ClaimType = "Student_Edit", ClaimValue = "Student_Edit" },
                            new Claim { Id = 38, RoleId = 1, ClaimType = "Student_Access", ClaimValue = "Student_Access" },
                            new Claim { Id = 39, RoleId = 1, ClaimType = "Student_Show", ClaimValue = "Student_Show" },
                            new Claim { Id = 40, RoleId = 1, ClaimType = "PayOut_Access", ClaimValue = "PayOut_Access" },
                            new Claim { Id = 41, RoleId = 1, ClaimType = "Setting_Access", ClaimValue = "Setting_Access" },
                            new Claim { Id = 42, RoleId = 1, ClaimType = "Report_Access", ClaimValue = "Report_Access" },
                            new Claim { Id = 43, RoleId = 1, ClaimType = "Notification_Access", ClaimValue = "Notification_Access" },
                            new Claim { Id = 44, RoleId = 1, ClaimType = "FeedBack_Access", ClaimValue = "FeedBack_Access" },
                            new Claim { Id = 45, RoleId = 1, ClaimType = "Lang_Access", ClaimValue = "Lang_Access" },
                            new Claim { Id = 46, RoleId = 1, ClaimType = "Lang_Create", ClaimValue = "Lang_Create" },
                            new Claim { Id = 47, RoleId = 1, ClaimType = "Lang_Delete", ClaimValue = "Lang_Delete" },
                            new Claim { Id = 48, RoleId = 1, ClaimType = "Lang_Edit", ClaimValue = "Lang_Edit" }
                                );

        }
    }
}
