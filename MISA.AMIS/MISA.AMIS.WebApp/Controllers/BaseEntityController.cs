﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Interfaces.Service;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region Declare
        protected string _tableName = string.Empty;
        protected string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= MF796_MISA_AMIS";
        protected IDbConnection _dbConnection;
        IBaseService<MISAEntity> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion


        #region Method

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Nếu có dữ liệu: trả vễ HttpCode 200; 204 nếu không có dữ liệu</returns>
        /// CreatedBy: ntquan(29/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        /// <param name="entityId">Id của bảng dữ liệu</param>
        /// <returns>Thông tin của 1 đối tượng</returns>
        /// CreatedBy: ntquan(29/04/2021)
        [HttpGet("{entityId}")]
        public IActionResult Get(string entityId)
        {
            var entity = _baseService.GetById(Guid.Parse(entityId));
            if (entity == null)
            {
                return NoContent();
            }
            return Ok(entity);
        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thực thể muốn thêm mới</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: ntquan(29/04/2021)
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            var result = _baseService.Insert(entity);
            if (result.MISACode == Core.Enums.MISACode.NotValid)
            {
                return BadRequest(result.data);
            }
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="entity">Thực thể cập nhật</param>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>
        ///  - HttpCode: 201 nếu cập nhật được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        ///  CreatedBy: ntquan(05/05/2021)
        [HttpPut]
        public IActionResult Put([FromBody] MISAEntity entity, Guid entityId)
        {
            var result = _baseService.Update(entity, entityId);
            if (result.MISACode == Core.Enums.MISACode.NotValid)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Xoá 
        /// </summary>
        /// <param name="id"> Id thực thể</param>
        /// <returns></returns>
        /// CreatedBy: ntquan(05/05/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _baseService.Delete(id);
            return Ok(entity);
        }
        #endregion

    }
}
