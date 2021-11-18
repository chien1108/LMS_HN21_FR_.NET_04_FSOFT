using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Data
{
    public class LMSDbContext :DbContext
    {
        public LMSDbContext()
        {

        }
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {

        }

        //DbSet
        public virtual DbSet<AdminSetting> AdminSettings { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseContent> CourseContents { get; set; }
        public virtual DbSet<CourseRate> CourseRates { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<InstructorDiscusstion> InstructorDiscusstions { get; set; }
        public virtual DbSet<InstructorVerify> InstructorVerifies { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<LikeDislikeCourse> LikeDislikeCourses { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PayOut> PayOuts { get; set; }
        public virtual DbSet<PaytabsInvoice> PaytabsInvoices { get; set; }
        public virtual DbSet<ReportAbuse> ReportAbuses { get; set; }
        public virtual DbSet<SavedCourse> SavedCourses { get; set; }
        public virtual DbSet<SpecialDiscount> SpecialDiscounts { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<SubScription> SubScriptions { get; set; }
        public virtual DbSet<WebLanguage> WebLanguages { get; set; }
    }
}
