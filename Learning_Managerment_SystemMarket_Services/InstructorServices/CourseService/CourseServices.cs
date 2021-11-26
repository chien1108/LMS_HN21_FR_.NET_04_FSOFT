using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.ResponseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                course.InstructorId = 1;
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

        public async Task<IList<CourseVm>> GetAllCourses()
        {
            var courses = await _unitOfWork.Courses.GetAll(includes: new List<string> { "Category" });
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach (var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }

        public async Task<IList<CourseVm>> GetAllDraftCourses()
        {
            var courses = await _unitOfWork.Courses.GetAll(expression: x => x.Status == StatusCourse.Draft, includes: new List<string> { "Category" });
            var map = _mapper.Map<List<CourseVm>>(courses);
            foreach (var item in map)
            {
                item.Parts = _unitOfWork.Context.CourseContents.Count(x => x.CourseId == item.Id);
                item.Sales = _unitOfWork.Context.Orders.Count(x => x.CourseId == item.Id);
            }

            return map;
        }

        public async Task<IList<CourseVm>> GetAllUpcomingCourses()
        {
            var courses = await _unitOfWork.Courses.GetAll(expression: x => x.Status == StatusCourse.WaitForApproced, includes: new List<string> { "Category" });
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
