using AutoMapper;
using Learning_Managerment_SystemMarket_Services.AdminFunction.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.AdminFunction.Controllers
{
    [Area("AdminFunction")]
    public class DashboardController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public DashboardController(ILogger<UserController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        // GET: DashboardController
        public ActionResult Index()
        {
            return View();
        }
    }
}
