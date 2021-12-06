using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService
{
    public class StudentHomePageService : IStudentHomePageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _map;

        public StudentHomePageService(IUnitOfWork unitOfWork, IMapper map)
        {
            this.unitOfWork = unitOfWork;
            _map = map;
        }

        public async Task<ServiceResponse<StudentHomePageVM>> Create(StudentHomePageVM studentHomeVM)
        {
            try
            {
                var course = _map.Map<Course>(studentHomeVM);
                await unitOfWork.Courses.Create(course);
                if (!await SaveChange())
                {
                    return new ServiceResponse<StudentHomePageVM> { Success = false, Message = "Create fail" };
                }
                return new ServiceResponse<StudentHomePageVM> { Success = false, Message = "Create successfull" };
            }
            catch (Exception)
            {
                return new ServiceResponse<StudentHomePageVM> { Success = false, Message = "Create fail" };
            }
        }

        public void Delete(StudentHomePageVM studentHomeVM)
        {
            var course = _map.Map<Course>(studentHomeVM);
            unitOfWork.Courses.Delete(course);
        }

        public async Task<CardCourseVM> FindCourse(Expression<Func<Course, bool>> expression = null, List<string> includes = null)
        {
            var course = await unitOfWork.Courses.FindByCondition(expression, includes);
            return _map.Map<CardCourseVM>(course);
        }

        public async Task<IList<CardCourseVM>> FindAllCourse(Expression<Func<Course, bool>> expression = null, Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null, List<string> includes = null)
        {
            var course = await this.unitOfWork.Courses.GetAll(expression, orderBy, includes: new List<string> { "Instructor" });
            return _map.Map<IList<CardCourseVM>>(course);
        }

        public async Task<IList<StudentHomePageVM>> GetAllCourseIsActive()
        {
            var listCourse = await unitOfWork.Courses.GetAll(x => x.Status == StatusCourse.Active);
            return _map.Map<List<StudentHomePageVM>>(listCourse);
        }

        public async Task<CourseDetailVM> GetDetailsCourseById(int id)
        {
            var course = await unitOfWork.Courses.FindByCondition(x => x.Status == StatusCourse.Active && x.Id == id);
            return _map.Map<CourseDetailVM>(course);
        }

        public async Task<bool> isExisted(Expression<Func<Course, bool>> expression = null)
        {
            return await unitOfWork.Courses.IsExists(expression);
        }

        public async Task<bool> SaveChange()
        {
            return await unitOfWork.Save();
        }

        public void Update(StudentHomePageVM studentHomeVM)
        {
            var course = _map.Map<Course>(studentHomeVM);
            unitOfWork.Courses.Update(course);
        }

        public async Task<ICollection<Course>> GetFeatureCourse(int size)
        {
            var course = await unitOfWork.Courses.GetFeatureCourse(size);
            return course;
        }

        public async Task<ICollection<Course>> GetNewestCourse(int size)
        {
            var course = await unitOfWork.Courses.GetNewestCourse(size);
            return course;
        }

        public async Task<IList<CategoryDetailVM>> GetAllCategory()
        {
            var categories = await unitOfWork.Categories.GetAll();
            return _map.Map<IList<CategoryDetailVM>>(categories);
        }

        public async Task<IList<CardCourseVM>> FindCoursesNewestByCondition(int? categoryId,int? languageId
            ,bool? isFree,decimal? courseDuration)
        {
            if (categoryId != null)
            {
                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Category.Id == categoryId
                    , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                    .ThenByDescending(a => a.CreatedDate)
                    , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (languageId != null)
            {
                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Language.Id == languageId
                    , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                    .ThenByDescending(a => a.CreatedDate)
                    , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (isFree != null)
            {
                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if(categoryId != null&& languageId != null)
            {

                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Category.Id == categoryId
                     &&x.Language.Id==languageId
                    , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                    .ThenByDescending(a => a.CreatedDate)
                    , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if(categoryId != null && isFree != null)
            {
                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Category.Id == categoryId
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (languageId != null && isFree != null)
            {

                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Language.Id == languageId
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if(categoryId!=null&&languageId != null && isFree != null)
            {
                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Category.Id == categoryId
                    &&x.Language.Id==languageId
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else
            {
                var courses = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                     .ThenByDescending(a => a.CreatedDate)
                    , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return courses;
            }
        }

        public async Task<IList<CardCourseVM>> FindCoursesLowestPriceByCondition(int? categoryId, int? languageId
            , bool? isFree, decimal? courseDuration)
        {
            if (categoryId != null)
            {
                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Category.Id == categoryId
                     , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (languageId != null)
            {
                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Language.Id == languageId
                     , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (isFree != null)
            {
                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (categoryId != null && languageId != null)
            {

                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Category.Id == categoryId
                     && x.Language.Id == languageId
                    , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (categoryId != null && isFree != null)
            {
                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Category.Id == categoryId
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (languageId != null && isFree != null)
            {

                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Language.Id == languageId
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (categoryId != null && languageId != null && isFree != null)
            {
                var courses = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Category.Id == categoryId
                    && x.Language.Id == languageId
                    && x.IsFree == isFree
                    , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return courses;
            }
            else
            {
                var courses = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                     , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return courses;
            }
        }

        public async Task<IList<CardCourseVM>> FindCoursesHighestPriceByCondition(int? categoryId, int? languageId
            , bool? isFree, decimal? courseDuration)
        {
            if (categoryId != null)
            {
                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Category.Id == categoryId
                     , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (languageId != null)
            {
                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Language.Id == languageId
                    , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (isFree != null)
            {
                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.IsFree == isFree
                    , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (categoryId != null && languageId != null)
            {

                var coursesNewest = await FindAllCourse(
                     expression: x => x.Status == StatusCourse.Active
                     && x.Category.Id == categoryId
                     && x.Language.Id == languageId
                     , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (categoryId != null && isFree != null)
            {
                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Category.Id == categoryId
                    && x.IsFree == isFree
                    , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
 
                return coursesNewest;
            }
            else if (languageId != null && isFree != null)
            {

                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Language.Id == languageId
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else if (categoryId != null && languageId != null && isFree != null)
            {
                var coursesNewest = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.Category.Id == categoryId
                    && x.Language.Id == languageId
                    && x.IsFree == isFree
                   , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return coursesNewest;
            }
            else
            {
                var courses = await FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return courses;
            }
        }
    }
}