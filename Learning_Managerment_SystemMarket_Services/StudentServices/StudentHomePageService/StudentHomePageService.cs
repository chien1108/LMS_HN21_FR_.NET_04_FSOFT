﻿using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public void Create(StudentHomePageVM studentHomeVM)
        {
            var course = _map.Map<Course>(studentHomeVM);
            unitOfWork.Courses.Create(course);
        }

        public void Delete(StudentHomePageVM studentHomeVM)
        {
            var course = _map.Map<Course>(studentHomeVM);
            unitOfWork.Courses.Delete(course);
        }

        public async Task<CourseDetailVM> FindCourse(Expression<Func<Course, bool>> expression = null, List<string> includes = null)
        {
            var course = await unitOfWork.Courses.FindByCondition(expression, includes);
            return _map.Map<CourseDetailVM>(course);
        }

        public async Task<IList<CourseDetailVM>> FindAllCourse(Expression<Func<Course, bool>> expression = null, Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null, List<string> includes = null)
        {
            var course = await this.unitOfWork.Courses.GetAll(expression, orderBy, includes: new List<string> { "Instructor" });
            return _map.Map<IList<CourseDetailVM>>(course);
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

        public async Task<ICollection<Course>> GetCourseByStudentId(int id)
        {
            var courses = await unitOfWork.Courses.GetCoursesByStudentId(id);
            return courses;
        }
        public async Task<ICollection<Course>> GetCourseByStudent()
        {
            var courses = await unitOfWork.Courses.GetCoursesByStudent();
            return courses;
        }
    }
}