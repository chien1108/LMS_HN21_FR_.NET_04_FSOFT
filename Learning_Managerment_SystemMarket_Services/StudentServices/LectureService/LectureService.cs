using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.LectureService
{
    public class LectureService : ILectureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public LectureService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }

        public async Task<Lecture> Find(Expression<Func<Lecture, bool>> expression = null, List<string> includes = null)
            => await _unitOfWork.Lectures.FindByCondition(expression, includes);

        public async Task<ICollection<Lecture>> FindAll(Expression<Func<Lecture, bool>> expression = null, Func<IQueryable<Lecture>, IOrderedQueryable<Lecture>> orderBy = null, List<string> includes = null)
            => await _unitOfWork.Lectures.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<Lecture, bool>> expression = null)
        {
            var isExist = await _unitOfWork.Lectures.FindByCondition(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ICollection<CourseContent>> GetCourseContentByCourseId(int courseId)
        {
            var courseContent = await _unitOfWork.CourseContents.GetAll(x => x.CourseId == courseId);
            return courseContent;
        }

        public async Task<bool> SaveChange()
            => await _unitOfWork.Lectures.Save();
    }
}
