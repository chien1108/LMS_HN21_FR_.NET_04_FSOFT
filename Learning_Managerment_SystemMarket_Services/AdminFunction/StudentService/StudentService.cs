﻿using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Student>> Create(Student newStudent)
        {
            var studentFromDb = await Find(x => x.Id == newStudent.Id);
            if (studentFromDb == null)
            {
                await _unitOfWork.Students.Create(newStudent);
                return new ServiceResponse<Student> { Success = true, Message = "Add Student Success" };
            }
            else
            {
                return new ServiceResponse<Student> { Success = false, Message = "Student is Exist" };
            }
        }

        public async Task<ServiceResponse<Student>> Delete(Student student)
        {
            var studentFromDb = await Find(x => x.Id == student.Id);
            if (studentFromDb != null)
            {
                _unitOfWork.Students.Delete(student);
                return new ServiceResponse<Student> { Success = true, Message = "Delete Student Success" };
            }
            else
            {
                return new ServiceResponse<Student> { Success = false, Message = "Not Found Student" };
            }
        }

        public async Task<Student> Find(Expression<Func<Student, bool>> expression = null,
                                        List<string> includes = null)
            => await _unitOfWork.Students.FindByCondition(expression, includes);

        public async Task<IList<Student>> FindAll(Expression<Func<Student, bool>> expression = null,
                                                  Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null,
                                                  List<string> includes = null)
            => await _unitOfWork.Students.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<Student, bool>> expression = null)
            => await _unitOfWork.Students.IsExists(expression);

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<Student>> Update(Student updateStudent)
        {
            var studentFromDb = await Find(x => x.Id == updateStudent.Id);
            if (studentFromDb != null)
            {
                _unitOfWork.Students.Update(updateStudent);
                return new ServiceResponse<Student> { Success = true, Message = "Update Student Success" };
            }
            else
            {
                return new ServiceResponse<Student> { Success = false, Message = "Not Found Student" };
            }
        }
    }
}