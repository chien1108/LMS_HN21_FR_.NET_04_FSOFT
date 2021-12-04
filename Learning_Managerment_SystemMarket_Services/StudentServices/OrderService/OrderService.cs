using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.StudentServices.OrderService
{
   public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public OrderService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }

        public async Task<Order> Find(Expression<Func<Order, bool>> expression = null, List<string> includes = null)
        {
            var order = await _unitOfWork.Orders.FindByCondition(expression, includes);
            return order;
        }

        public async Task<ICollection<Order>> FindAll(Expression<Func<Order, bool>> expression = null,
            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
            List<string> includes = null)
        {
            var orders = await _unitOfWork.Orders.GetAll(expression, orderBy, includes);
            foreach (var order in orders)
            {
                order.Course = await _unitOfWork.Courses.FindByCondition(
                    expression: c => c.Id == order.CourseId,
                    includes: new List<string> { "Instructor", "Category" });
            }
            return orders;
        }

        public async Task<int> GetAllStudentEnrollCourse(int id)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            var listFromDb = await _unitOfWork.Courses.GetAll(x =>x.InstructorId == id);
=======
            var listFromDb = await _unitOfWork.Courses.GetAll(x => x.InstructorId == id);
>>>>>>> 053dae937b129d2a642b64c67ab6bc992975f967
=======
            var listFromDb = await _unitOfWork.Courses.GetAll(x => x.InstructorId == id);
>>>>>>> 98beadc8cd1998ad9a347470423af675aa3bc5c0
            int count = 0;
            foreach (var item in listFromDb)
            {
                var enroll = await FindAll(x => x.CourseId == item.Id);
                count += enroll.GroupBy(x => x.StudentId).Select(g => g.First()).Count();
            }
            return count;
        }
    }
}
