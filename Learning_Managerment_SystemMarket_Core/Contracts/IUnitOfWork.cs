using Learning_Managerment_SystemMarket_Core.Data;
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
using System;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminSettingRepository AdminSettings { get; }
        ICategoryRepository Categories { get; }
        ICourseRepository Courses { get; }
        ICourseContentRepository CourseContents { get; }
        ICourseRateRepository CourseRates { get; }
        IFAQRepository FAQs { get; }
        IFeedBackRepository FeedBacks { get; }
        IInstructorRepository Instructors { get; }
        IInstructorDiscusstionRepository InstructorDiscusstions { get; }
        IInstructorVerifyRepository InstructorVerifies { get; }
        ILanguageRepository Languages { get; }
        ILectureRepository Lectures { get; }
        ILikeDislikeCourseRepository LikeDislikeCourses { get; }
        INotificationRepository Notifications { get; }
        INotificationTemplateRepository NotificationTemplates { get; }
        IOrderRepository Orders { get; }
        IPayOutRepository PayOuts { get; }
        IPaytabsInvoiceRepository PaytabsInvoices { get; }
        ISpecialDiscountRepository SpecialDiscounts { get; }
        IStudentRepository Students { get; }
        ISubCategoryRepository SubCategories { get; }
        LMSDbContext Context { get; }
        Task<bool> Save();
    }
}
