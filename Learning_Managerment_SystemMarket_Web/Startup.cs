using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.AdminSettingRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.CategoryRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.CourseContentRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.CourseRateRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.CourseRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.FAQRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.FeedBackRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorDiscusstionRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorVerifyRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.LanguageRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.LectureRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.LikeDislikeCourseRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.NotificationRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.NotificationTemplateRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.OrderRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.PayOutRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.PaytabsInvoiceRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.SpecialDiscountRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.StudentRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.SubCategoryRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.UnitOfWork;
using Learning_Managerment_SystemMarket_Services.AdminFunction.CategoryServices;
using Learning_Managerment_SystemMarket_Services.AdminFunction.LanguageService;
using Learning_Managerment_SystemMarket_Services.AdminFunction.SubCategoryService;
using Learning_Managerment_SystemMarket_Services.AdminFunction.RoleService;
using Learning_Managerment_SystemMarket_Services.AdminFunction.UserService;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CategoryService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.LanguageService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.SubCategoryService;
using Learning_Managerment_SystemMarket_Web.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning_Managerment_SystemMarket_Core.Repositories.ClaimRepo;
using Learning_Managerment_SystemMarket_Services.AdminFunction.ClaimService;

namespace Learning_Managerment_SystemMarket_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //config context SQL
            services.AddDbContext<LMSDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Config for Dependence Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAdminSettingRepository, AdminSettingRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<ISpecialDiscountRepository, SpecialDiscountRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseContentRepository, CourseContentRepository>();
            services.AddScoped<ICourseRateRepository, CourseRateRepository>();
            services.AddScoped<IFAQRepository, FAQRepository>();
            services.AddScoped<IFeedBackRepository, FeedBackRepository>();
            services.AddScoped<IInstructorDiscusstionRepository, InstructorDiscusstionRepository>();
            services.AddScoped<IInstructorVerifyRepository, InstructorVerifyRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILectureRepository, LectureRepository>();
            services.AddScoped<ILikeDislikeCourseRepository, LikeDislikeCourseRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationTemplateRepository, NotificationTemplateRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPayOutRepository, PayOutRepository>();
            services.AddScoped<IPaytabsInvoiceRepository, PaytabsInvoiceRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            //Add service
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStudentHomePageService, StudentHomePageService>();
            services.AddScoped<IStudentExploreService, StudentExploreService>();
            services.AddScoped<ISavedCourseService, SavedCourseService>();

            services.AddTransient<ICourseServices, CourseServices>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<ISubCategoryService, SubCategoryService>();

            //Config for Dependence Service

            services.AddAutoMapper(typeof(MapperProfile));

            services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<LMSDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "areaRoute",
                     pattern: "{area:exists}/{controller}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:?}/{controller=Home}/{action=Index}/{id?}");
                    name: "instuctor",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                    pattern: "{area=StudentFunction}/{controller=Student}/{action=Index}/{id?}");
            });
        }
    }
}