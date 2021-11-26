using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.ResponseResult
{
    public class ResponseResult
    {
        public bool Code { get; set; }

        public object Data { get; set; }
        
        public string Message { get; set; }
    }
}
