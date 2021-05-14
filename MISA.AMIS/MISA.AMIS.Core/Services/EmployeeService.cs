using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeReponsitory;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeReponsitory = employeeRepository;
        }

        public bool CheckEmployeeCodeExits(string employeeCode)
        {
            var isExist = _employeeReponsitory.CheckEmployeeCodeExits(employeeCode);
            return isExist;
        }

        public IEnumerable<Employee> GetEmployeeFilter(int pageIndex, int pageSize, string employeeFilter)
        {
            var entities = _employeeReponsitory.GetEmployeeFilter(pageIndex, pageSize,employeeFilter);
            return entities;
        }

        public string GetNewEmployeeCode()
        {
            var code = _employeeReponsitory.GetMaxEmployeeCode();
            string letters = string.Empty;
            string numbers = string.Empty;

            foreach (char c in code)
            {
                if (Char.IsLetter(c))
                {
                    letters += c;
                }
                if (Char.IsNumber(c))
                {
                    numbers += c;
                }
            }
            var newCode = $"{letters}{Int32.Parse(numbers) + 1}";
            return newCode;
        }

        public IEnumerable<Employee> GetPaging(int pageIndex, int pageSize)
        {
            var entities = _employeeReponsitory.GetPaging(pageIndex, pageSize);
            return entities;
        }

        protected override void ValidateCustom(Employee employee)
        {
            //Check phòng ban có tồn tại hay không
            if (!string.IsNullOrEmpty(employee.DepartmentId.ToString()))
            {
                var res = _employeeReponsitory.CheckDepartmentExits(employee.DepartmentId);
                if (!res)
                {
                    throw new ValidateExceptions("Thông tin phòng ban không tồn tại trong hệ thống");
                }
            }

        }
    }
}
