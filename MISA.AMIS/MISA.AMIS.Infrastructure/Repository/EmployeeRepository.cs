using Dapper;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public bool CheckDepartmentExits(Guid? departmentId)
        {
            var storeName = $"Proc_CheckDepartmentExist";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@departmentId", departmentId.ToString());

            var res = _dbConnection.QueryFirstOrDefault<bool>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public bool CheckEmployeeCodeExits(string employeeCode)
        {
            var storeName = $"Proc_Check{_tableName}CodeExist";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeCode", employeeCode);

            var res = _dbConnection.QueryFirstOrDefault<bool>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public string GetMaxEmployeeCode()
        {
            var storeName = $"Proc_GetMaxEmployeeCode";

            var res = _dbConnection.QueryFirstOrDefault<string>(storeName, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Employee> GetPaging(int pageIndex, int pageSize)
        {
            var storeName = $"Proc_Get{_tableName}Paging";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@pageIndex", pageIndex);
            dynamicParameters.Add($"@pageSize", pageSize);

            var entity = _dbConnection.Query<Employee>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
    }
}
