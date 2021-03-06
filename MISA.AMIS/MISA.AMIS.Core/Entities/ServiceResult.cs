using MISA.AMIS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    public class ServiceResult
    {
        #region Declare

        #endregion

        #region Constructor

        #endregion

        #region Property
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public Object data { get; set; }

        /// <summary>
        /// Message trả về
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Mã lỗi trả về
        /// </summary>
        public MISACode MISACode { get; set; }

        /// <summary>
        /// Tổng bản ghi
        /// </summary>
        public int? Total { get; set; }
        #endregion
    }
}
