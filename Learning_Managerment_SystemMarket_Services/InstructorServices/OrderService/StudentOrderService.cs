using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.OrderService
{
    public class StudentOrderService : IStudentOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentOrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderVm>> FindAll(Expression<Func<Order, bool>> expression = null, Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, List<string> includes = null)
        {
            var orders = await _unitOfWork.Orders.GetAll(expression, orderBy, includes);
            var model = _mapper.Map<IList<OrderVm>>(orders);
            return model;
        }
    }
}
