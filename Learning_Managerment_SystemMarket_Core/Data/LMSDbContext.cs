using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        //Test Role Custom 
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ModelHasPermission> ModelHasPermissions { get; set; }
        public virtual DbSet<ModelHasRole> ModelHasRoles { get; set; }
        public virtual DbSet<RoleHasPermission> RoleHasPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminSetting>(entity =>
            {

            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(k => new { k.StudentId, k.CourseId ,k.Id});
                //entity.HasOne(pk => pk.Student)
                //        .WithMany(m => m.Carts)
                //        .HasForeignKey(fk => fk.Student);
                //entity.HasOne(pk => pk.Course)
                //        .WithMany(m => m.Carts)
                //        .HasForeignKey(fk => fk.CourseId);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(k => new { k.Id });
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(k => new { k.Id });
            });
            modelBuilder.Entity<CourseContent>(entity =>
            {

            });
            modelBuilder.Entity<CourseRate>(entity =>
            {

            });
            modelBuilder.Entity<FAQ>(entity =>
            {

            });
            modelBuilder.Entity<FeedBack>(entity =>
            {

            });
            modelBuilder.Entity<Instructor>(entity =>
            {

            });
            modelBuilder.Entity<InstructorDiscusstion>(entity =>
            {

            });
            modelBuilder.Entity<InstructorVerify>(entity =>
            {

            });
            modelBuilder.Entity<Language>(entity =>
            {

            });
            modelBuilder.Entity<Lecture>(entity =>
            {

            });
            modelBuilder.Entity<LikeDislikeCourse>(entity =>
            {

            });
            modelBuilder.Entity<ModelHasPermission>(entity =>
            {
                entity.HasKey(k => new { k.UserId, k.PermissionId });

            });
            modelBuilder.Entity<ModelHasRole>(entity =>
            {
                entity.HasKey(k => new { k.UserId, k.RoleId });
            });
            modelBuilder.Entity<Notification>(entity =>
            {

            });
            modelBuilder.Entity<NotificationTemplate>(entity =>
            {

            });
            modelBuilder.Entity<Order>(entity =>
            {

            });
            modelBuilder.Entity<PayOut>(entity =>
            {

            });
            modelBuilder.Entity<PaytabsInvoice>(entity =>
            {

            });
            modelBuilder.Entity<Permission>(entity =>
            {

            });
            modelBuilder.Entity<ReportAbuse>(entity =>
            {

            });
            modelBuilder.Entity<Role>(entity =>
            {

            });
            modelBuilder.Entity<RoleHasPermission>(entity =>
            {
                entity.HasKey(k => new { k.RoleId, k.PermissionId });
            });
            modelBuilder.Entity<SavedCourse>(entity =>
            {

            });
            modelBuilder.Entity<SpecialDiscount>(entity =>
            {
                entity.HasKey(k => new { k.CourseId, k.Id, k.InstructorId });
            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(k => new { k.Id });
                //entity.HasMany(m => m.Carts)
                //       .WithOne(o => o.Student);
            });
            modelBuilder.Entity<SubCategory>(entity =>
            {

            });
            modelBuilder.Entity<SubScription>(entity =>
            {

            });
            modelBuilder.Entity<User>(entity =>
            {

            });
            modelBuilder.Entity<WebLanguage>(entity =>
            {

            });
        }

        // some method override
        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSaveChanges()
        {
            var entities = ChangeTracker.Entries();
            var now = DateTime.Now;
            foreach (var entity in entities)
            {
                if (entity.Entity is IBaseEntity baseEntity)
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            {
                                baseEntity.Status = Status.IsActive;
                                baseEntity.CreatedDate = now;
                                baseEntity.ModifiedDate = now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                baseEntity.ModifiedDate = now;
                                break;
                            }
                    }
                }
            }
        }
    }
}
