using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Data;
using Learning_Managerment_SystemMarket_Core.Repositories.AdminSettingRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.CategoryRepo;
using Learning_Managerment_SystemMarket_Core.Repositories.ClaimRepo;
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

namespace Learning_Managerment_SystemMarket_Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LMSDbContext _context;
        private IAdminSettingRepository _adminSettingRepository;
        private IInstructorRepository _instructorRepository;
        private ISpecialDiscountRepository _specialDiscountRepository;
        private IStudentRepository _studentRepository;
        private ICategoryRepository _categoryRepository;
        private ICourseRepository _courseRepository;
        private ICourseContentRepository _courseContentRepository;
        private ICourseRateRepository _courseRate;
        private IFAQRepository _fAQRepository;
        private IFeedBackRepository _feedBackRepository;
        private IInstructorDiscusstionRepository _instructorDiscusstionRepository;
        private IInstructorVerifyRepository _instructorVerifyRepository;
        private ILanguageRepository _languageRepository;
        private ILectureRepository _lectureRepository;
        private ILikeDislikeCourseRepository _likeDislikeCourseRepository;
        private INotificationRepository _notificationRepository;
        private INotificationTemplateRepository _notificationTemplateRepository;
        private IOrderRepository _orderRepository;
        private IPayOutRepository _payOutRepository;
        private IPaytabsInvoiceRepository _paytabsInvoiceRepository;
        private ISubCategoryRepository _subCategoryRepository;
        private IClaimRepository _claimRepository;
        public UnitOfWork(LMSDbContext context)
        {
            _context = context;
        }

        public IAdminSettingRepository AdminSettings => _adminSettingRepository ??= new AdminSettingRepository(_context);

        public IInstructorRepository Instructors => _instructorRepository ??= new InstructorRepository(_context);

        public ISpecialDiscountRepository SpecialDiscounts => _specialDiscountRepository ??= new SpecialDiscountRepository(_context);

        public IStudentRepository Students => _studentRepository ??= new StudentRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);

        public ICourseRepository Courses => _courseRepository ??= new CourseRepository(_context);

        public ICourseContentRepository CourseContents => _courseContentRepository ??= new CourseContentRepository(_context);

        public ICourseRateRepository CourseRates => _courseRate ??= new CourseRateRepository(_context);

        public IFAQRepository FAQs => _fAQRepository ??= new FAQRepository(_context);

        public IFeedBackRepository FeedBacks => _feedBackRepository ??= new FeedBackRepository(_context);

        public IInstructorDiscusstionRepository InstructorDiscusstions => _instructorDiscusstionRepository ??= new InstructorDiscusstionRepository(_context);

        public IInstructorVerifyRepository InstructorVerifies => _instructorVerifyRepository ??= new InstructorVerifyRepository(_context);

        public ILanguageRepository Languages => _languageRepository ??= new LanguageRepository(_context);

        public ILectureRepository Lectures => _lectureRepository ??= new LectureRepository(_context);

        public ILikeDislikeCourseRepository LikeDislikeCourses => _likeDislikeCourseRepository ??= new LikeDislikeCourseRepository(_context);

        public INotificationRepository Notifications => _notificationRepository ??= new NotificationRepository(_context);

        public INotificationTemplateRepository NotificationTemplates => _notificationTemplateRepository ??= new NotificationTemplateRepository(_context);

        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

        public IPayOutRepository PayOuts => _payOutRepository ??= new PayOutRepository(_context);

        public IPaytabsInvoiceRepository PaytabsInvoices => _paytabsInvoiceRepository ??= new PaytabsInvoiceRepository(_context);

        public ISubCategoryRepository SubCategories => _subCategoryRepository ??= new SubCategoryRepository(_context);

        public IClaimRepository Claims => _claimRepository ??= new ClaimRepository(_context);
        public LMSDbContext Context => _context;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }

        public async Task<bool> Save() => await _context.SaveChangesAsync() > 0;
    }
}