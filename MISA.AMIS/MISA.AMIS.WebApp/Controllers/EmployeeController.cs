using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.WebApp.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Phân trang dữ liệu
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// CreatedBy:ntquan(11/05/2021)
        [HttpGet("paging")]
        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            var entities = _employeeService.GetPaging(pageIndex, pageSize);
            return Ok(entities);
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreatedBy:ntquan(11/055/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            var entities = _employeeService.GetNewEmployeeCode();
            return Ok(entities);
        }

        [HttpGet("CheckEmployeeCodeExist")]
        public IActionResult CheckEmployeeCodeExist(string employeeCode)
        {
            var isExist = _employeeService.CheckEmployeeCodeExits(employeeCode);
            return Ok(isExist);
        }

        [HttpGet("employeeFilter")]
        public IActionResult GetEmployeeFilter(int pageIndex,int pageSize,string employeeFilter)
        {
            var entities = _employeeService.GetEmployeeFilter(pageIndex, pageSize, employeeFilter);
            return Ok(entities);
        }
    }
}
