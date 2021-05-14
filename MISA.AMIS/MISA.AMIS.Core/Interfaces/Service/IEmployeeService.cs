﻿using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Service
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        /// <summary>
        /// Phân trang dữ liệu
        /// </summary>
        /// <param name="pageIndex">Trang hiện tại</param>
        /// <param name="pageSize">số bản ghi trên 1 trang</param>
        /// <returns></returns>
        /// CreatedBy:ntquan(11/05/2021)
        IEnumerable<Employee> GetPaging(int pageIndex, int pageSize);

        /// <summary>
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:ntquan(11/05/2021)
        string GetNewEmployeeCode();

        /// <summary>
        /// Kieemr tra max nhaan vieen
        /// </summary>
        /// <param name="employeeCode">string: mã nhân viên</param>
        /// <returns>true - nếu đã có; false - nếu chưa có</returns>
        /// CreatedBy: ntquan(11/05/2021)
        bool CheckEmployeeCodeExits(string employeeCode);

        /// <summary>
        /// Tìm kiếm nhân viên
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="employeeFilter"></param>
        /// <returns></returns>
        IEnumerable<Employee> GetEmployeeFilter(int pageIndex, int pageSize, string employeeFilter);

    }
}
