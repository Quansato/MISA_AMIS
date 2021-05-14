using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        /// <param name="pageIndex">Trang </param>
        /// <param name="pageSize">Số bản ghi / trang</param>
        /// <returns>Số lượng bản ghi theo pageSize</returns>
        /// CreatedBy: ntquan(11/05/2021)
        IEnumerable<Employee> GetPaging(int pageIndex, int pageSize);

        /// <summary>
        /// Kieemr tra max nhaan vieen
        /// </summary>
        /// <param name="employeeCode">string: mã nhân viên</param>
        /// <returns>true - nếu đã có; false - nếu chưa có</returns>
        /// CreatedBy: ntquan(11/05/2021)
        bool CheckEmployeeCodeExits(string employeeCode);

        /// <summary>
        /// Kiểm tra phòng ban có tồn tại hay không
        /// </summary>
        /// <param name="departmentId"> id phòng ban</param>
        /// <returns> true nếu tồn tại;false nếu không tồn tại</returns>
        /// CreatedBy: ntquan(11/05/2021)
        bool CheckDepartmentExits(Guid? departmentId);

        /// <summary>
        /// Lấy mã nhân viên mới nhất trong database
        /// </summary>
        /// <returns>mã nhân viên</returns>
        /// CreatedBy: ntquan(11/05/2021)   
        string GetMaxEmployeeCode();

        IEnumerable<Employee> GetEmployeeFilter(int pageIndex, int pageSize, string employeeFilter);
    }
}
