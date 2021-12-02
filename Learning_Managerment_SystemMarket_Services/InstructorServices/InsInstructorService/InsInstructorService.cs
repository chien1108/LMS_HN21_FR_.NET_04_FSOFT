using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.InstructorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.InsInstructorService
{
    public class InsInstructorService : IInsInstructorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsInstructorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderVM>> GetAllOrders(int id)
        {
            //var instructor = await _unitOfWork.Instructors.FindByCondition(x => x.Id == id);
            var orders = await _unitOfWork.Orders.GetAllOrders(id);
            foreach (var item in orders)
            {
                item.Course = await _unitOfWork.Courses.FindByCondition(x => x.Id == item.CourseId);
            }
            var map = _mapper.Map<List<OrderVM>>(orders);

            return map;
        }

        public async Task<EarningView> GetBalanceInstructor(int id)
        {
            var instructor = await _unitOfWork.Instructors.FindByCondition(x => x.Id == id);
            var earning = _unitOfWork.Orders.SumOrderByInstructorId(id);
            var model = new EarningView()
            {
                Balance = instructor.Balance + earning,
                Earning = earning,
                Fee = 0
            };

            return model;
        }

        public async Task<OrderVM> GetOrderById(int id)
        {
            var order = await _unitOfWork.Orders.FindByCondition(x => x.Id == id);
            var map = _mapper.Map<OrderVM>(order);
            var course = await _unitOfWork.Courses.FindByCondition(x => x.Id == order.CourseId);
            map.CourseName = course.Title;

            return map;
        }

        public async Task<List<OrderVM>> GetOrdersByMonthAndYear(int month, int year, int id)
        {
            //var instructor = await _unitOfWork.Instructors.FindByCondition(x => x.Id == id);
            var orders = await _unitOfWork.Orders.GetOrdersByMonthAndYear(month, year, id);
            foreach(var item in orders)
            {
                item.Course = await _unitOfWork.Courses.FindByCondition(x => x.Id == item.CourseId);
            }
            var map = _mapper.Map<List<OrderVM>>(orders);

            return map;
        }
    }
}
