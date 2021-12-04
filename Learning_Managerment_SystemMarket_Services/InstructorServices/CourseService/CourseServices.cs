using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.ResponseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService
{
    public class CourseServices : ICourseServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        ResponseResult _responseResult;
        public CourseServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseResult = new ResponseResult
            {
                Code = true
            };
        }

        public async Task<ResponseResult> CreateCourse(CreateCourseVm model, List<CreateCourseContentVm> createCourseContentVms, List<CreateLectureVm> createLectureVms)
        {
            try
            {
                var course = _mapper.Map<Course>(model);
                //Dùng tạm InstructorId có sẵn
                course.InstructorId = 2;
                await _unitOfWork.Courses.Create(course);

                foreach (var courseContentItem in createCourseContentVms)
                {
                    int idFake = courseContentItem.IdFake;

                    var courseContent = _mapper.Map<CourseContent>(courseContentItem);
                    courseContent.Course = course;
                    await _unitOfWork.CourseContents.Create(courseContent);

                    foreach (var lectureItem in createLectureVms)
                    {
                        if (lectureItem.IdFake == idFake)
                        {
                            var lecture = _mapper.Map<Lecture>(lectureItem);
                            lecture.CourseContent = courseContent;
                            await _unitOfWork.Lectures.Create(lecture);
                        }
                    }
                }
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _responseResult.Message = ex.Message;
                throw;
            }

            return _responseResult;
        }

        public async Task<ServiceResponse<DisCountCourseVm>> ChangeStatus(int id)
        {
            try
            {
                var discountCourse = await _unitOfWork.SpecialDiscounts.FindByCondition(x => x.Id == id);
                var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == discountCourse.CourseId);
                if (course.DiscountPrice != 0)
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = false, Message = "Already have discount" };
                }
                if (discountCourse.Status == Status.IsActive)
                {
                    discountCourse.Status = Status.IsDeleted;
                    course.DiscountPrice = 0;
                }
                else
                {
                    discountCourse.Status = Status.IsActive;
                    course.DiscountPrice = course.Price - ((course.Price * discountCourse.Percentage) / 100);
                }
                var isSuccess = await _unitOfWork.Save();
                if (isSuccess == true)
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = true, Message = "Change Status Success" };
                }
                else
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = false, Message = "Change Status Fail" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<DisCountCourseVm> { Success = false, Message = ex.Message };

            }
        }

        public async Task<ServiceResponse<CourseVm>> ChangeStatusToDraft(int id)
        {
            try
            {
                var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == id);
                course.Status = StatusCourse.Draft;
                var isSuccess = await _unitOfWork.Save();
                if (isSuccess == true)
                {
                    return new ServiceResponse<CourseVm> { Success = true, Message = "Change to Draft Success" };
                }
                else
                {
                    return new ServiceResponse<CourseVm> { Success = false, Message = "Change to Draft Fail" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<CourseVm> { Success = false, Message = ex.Message };
            }

        }

        public async Task<ServiceResponse<CourseVm>> ChangeStatusToPending(int id)
        {
            try
            {
                var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == id);
                course.Status = StatusCourse.WaitForApproced;
                var isSuccess = await _unitOfWork.Save();
                if (isSuccess == true)
                {
                    return new ServiceResponse<CourseVm> { Success = true, Message = "Change to Pending Success" };
                }
                else
                {
                    return new ServiceResponse<CourseVm> { Success = false, Message = "Change to Pending Fail" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<CourseVm> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<DisCountCourseVm>> CreateDiscount(DisCountCourseVm entity)
        {
            try
            {
                var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == entity.CourseId);
                entity.InstructorId = course.InstructorId;
                entity.Status = Status.IsDeleted;
                var map = _mapper.Map<SpecialDiscount>(entity);
                map.Course = course;

                await _unitOfWork.SpecialDiscounts.Create(map);
                var isSuccess = await _unitOfWork.Save();
                if (isSuccess == true)
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = true, Message = "Create Discount for Course Success" };
                }
                else
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = false, Message = "Create Discount for Course Fail" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<DisCountCourseVm> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<CourseVm>> Delete(int id)
        {
            try
            {
                var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == id);
                _unitOfWork.Courses.Delete(course);
                var isSuccess = await _unitOfWork.Save();
                if (isSuccess == true)
                {
                    return new ServiceResponse<CourseVm> { Success = true, Message = "Delete Course Success" };
                }
                else
                {
                    return new ServiceResponse<CourseVm> { Success = false, Message = "Delete Course Fail" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<CourseVm> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<DisCountCourseVm>> DeleteDiscount(int id)
        {
            try
            {
                var discountCourse = await _unitOfWork.SpecialDiscounts.FindByCondition(x => x.Id == id);
                _unitOfWork.SpecialDiscounts.Delete(discountCourse);
                var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == discountCourse.CourseId);
                course.DiscountPrice = 0;
                var isSuccess = await _unitOfWork.Save();
                if (isSuccess == true)
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = true, Message = "Delete Discount Success" };
                }
                else
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = false, Message = "Delete Discount Fail" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<DisCountCourseVm> { Success = false, Message = ex.Message };
            }
        }

        public async Task<IList<CourseVm>> GetAllCourses(int id)
        {
            var courses = await _unitOfWork.Courses.GetAll(includes: new List<string> { "Category" }, expression: x => x.InstructorId == id);
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach (var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }

        public async Task<IList<DisCountCourseVm>> GetAllDiscountCourses(int id)
        {
            var discountCourses = await _unitOfWork.SpecialDiscounts.GetAll(expression: x => x.InstructorId == id);
            var map = _mapper.Map<List<DisCountCourseVm>>(discountCourses);

            return map;
        }

        public async Task<IList<CourseVm>> GetAllDraftCourses(int id)
        {
            var courses = await _unitOfWork.Courses.GetAll(expression: x => x.Status == StatusCourse.Draft && x.InstructorId == id, includes: new List<string> { "Category" });
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach (var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }

        public async Task<IList<CourseVm>> GetAllUpcomingCourses(int id)
        {
            var courses = await _unitOfWork.Courses.GetAll(expression: x => x.Status == StatusCourse.WaitForApproced && x.InstructorId == id, includes: new List<string> { "Category" });
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach (var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }

        public async Task<DisCountCourseVm> GetDiscountById(int id)
        {
            var discount = await _unitOfWork.SpecialDiscounts.FindByCondition(x => x.Id == id);
            var map = _mapper.Map<DisCountCourseVm>(discount);
            var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == discount.CourseId);
            map.CourseName = course.Title;

            return map;
        }

        public async Task<ViewCourseVm> GetViewCourses(int id)
        {
            var map = new ViewCourseVm
            {
                Courses = await GetAllCourses(id),
                DraftCourses = await GetAllDraftCourses(id),
                UpcomingCourses = await GetAllUpcomingCourses(id),
                DisCountCourses = await GetAllDiscountCourses(id),
            };

            return map;
        }

        public async Task<ServiceResponse<DisCountCourseVm>> UpdateDiscount(DisCountCourseVm entity)
        {
            try
            {
                var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == entity.CourseId);
                var map = _mapper.Map<SpecialDiscount>(entity);
                map.ModifiedDate = DateTime.Now;
                map.Course = course;

                if (course.DiscountPrice != 0)
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = false, Message = "Already have discount" };
                }

                _unitOfWork.SpecialDiscounts.Update(map);
                course.DiscountPrice = course.Price - (course.Price * entity.Percentage) / 100;
                var isSuccess = await _unitOfWork.Save();
                if (isSuccess == true)
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = true, Message = "Update Discount Success" };
                }
                else
                {
                    return new ServiceResponse<DisCountCourseVm> { Success = false, Message = "Update Discount Fail" };
                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<DisCountCourseVm> { Success = false, Message = ex.Message };


            }
        }

        public async Task<CourseVm> GetCourseById(int id)
        {
            var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == id);
            var map = _mapper.Map<CourseVm>(course);

            return map;
        }

        public async Task<ServiceResponse<DisCountCourseVm>> ClearDiscountExpire()
        {
            var discountCourses = await _unitOfWork.SpecialDiscounts.GetAll(expression: x => x.InstructorId == 1);
            foreach (var item in discountCourses)
            {
                if (item.EndDate < DateTime.Now)
                {
                    _unitOfWork.SpecialDiscounts.Delete(item);
                    if (item.Status == Status.IsActive)
                    {
                        var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == item.CourseId);
                        course.DiscountPrice = 0;
                    }
                }
            }

            var result = await _unitOfWork.Save();
            if (result == true)
            {
                return new ServiceResponse<DisCountCourseVm> { Success = true, Message = "Clear Discount Expire Success" };
            }
            else
            {
                return new ServiceResponse<DisCountCourseVm> { Success = false, Message = "Clear Discount Expire Fail" };
            }
        }

        public async Task<IList<CourseVm>> GetAllCourseWaitApprove()
        {
            var courses = await _unitOfWork.Courses.GetAll(expression: x => x.Status == StatusCourse.WaitForApproced);
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach (var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }
    }
}
