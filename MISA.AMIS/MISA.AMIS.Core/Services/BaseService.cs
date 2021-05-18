﻿using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : BaseEntity
    {
        #region Declare
        IBaseRepository<MISAEntity> _baseRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Method
        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

        public MISAEntity GetById(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            return entity;
        }


        public ServiceResult Insert(MISAEntity entity)
        {
            try
            {
                // Gắn trạng thái - phân biệt validate thêm
                entity.EntityState = Enums.EntityState.AddNew;
                ValidateObject(entity);
                // Nếu dữ liệu đầu vào ok thì mới tiếp tục:
                _serviceResult.data = _baseRepository.Insert(entity);
                _serviceResult.Msg = "Thêm mới dữ liệu thành công";
                _serviceResult.MISACode = Enums.MISACode.Success;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                throw new ValidateExceptions(ex.Message);
            }

        }

        public ServiceResult Update(MISAEntity entity, Guid entityId)
        {
            try
            {

                entity.EntityState = Enums.EntityState.Update;
                ValidateObject(entity);
                _serviceResult.data = _baseRepository.Update(entity, entityId);
                _serviceResult.Msg = "Cập nhật dữ liệu thành công";
                _serviceResult.MISACode = Enums.MISACode.Success;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                throw new ValidateExceptions(ex.Message);

            }
        }
        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.data = _baseRepository.Delete(entityId);
            return _serviceResult;
        }


        /// <summary>
        /// Kiểm tra dữ liệu trước khi thực hiện Insert,Update
        /// </summary>
        /// <param name="entity">thực thể cần kiểm tra</param>
        /// CreatedBy:ntquan(07/05/2021)
        private void ValidateObject(MISAEntity entity)
        {
            // Validate với các trường thông tin bắt buộc nhập:

            // Lấy ra các property của class:
            var properties = typeof(MISAEntity).GetProperties();

            foreach (var property in properties)
            {
                // check xem property đó có Attribute là MISAREquired hay không:

                // Lấy ra giá trị:
                var propertyValue = property.GetValue(entity);
                //Lấy tên trường
                var propertyName = property.Name;

                var propertyRequireds = property.GetCustomAttributes(typeof(Required), true);

                var propertyMaxLengths = property.GetCustomAttributes(typeof(MaxLength), true);


                if (propertyRequireds.Length > 0)
                {
                    if (propertyValue == null)
                    {
                        throw new ValidateExceptions($"Không tìm thấy giá trị của trường [{propertyName}]");
                    }
                    // Lấy ra câu thông báo tùy chọn:
                    var userMsg = (propertyRequireds[0] as Required).UserMsg;
                    if (string.IsNullOrEmpty(userMsg))
                    {
                        userMsg = $"[{propertyName}]";
                        if (string.IsNullOrEmpty(propertyValue.ToString()))
                        {
                            var errorMsg = $"Thông tin {userMsg} không được phép để trống";
                            throw new ValidateExceptions(errorMsg);
                        }
                    }
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var errorMsg = $"{userMsg}";
                        throw new ValidateExceptions(errorMsg);
                    }
                }


                if (propertyMaxLengths.Length > 0)
                {
                    // Lấy ra độ dài tối đa cho phép của chuỗi:
                    var maxLength = (propertyMaxLengths[0] as MaxLength).Length;
                    if (propertyValue != null && propertyValue.ToString().Length > maxLength)
                    {
                        throw new ValidateExceptions((propertyMaxLengths[0] as MaxLength).ErrorMaxLength);
                    }
                }

                // Kiểm tra xem có attribute cần validate không
                if (property.IsDefined(typeof(IsDuplicate), false))
                {
                    // check trùng dữ liệu:
                    var entityDulicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDulicate != null)
                    {
                        var errorMsg = $"Thông tin {propertyName} đã tồn tại";
                        throw new ValidateExceptions(errorMsg);
                    }
                }

                //Xử lí Email
                if (property.IsDefined(typeof(IsNotEmail), false))
                {
                    try
                    {
                        var mail = new MailAddress(propertyValue.ToString());
                        bool isValidEmail = mail.Host.Contains(".");
                        if (!isValidEmail)
                        {
                            var errorMsg = "Email không đúng định dạng";
                            throw new ValidateExceptions(errorMsg);
                        }

                    }
                    catch (Exception)
                    {
                        var errorMsg = "Email không đúng định dạng";
                        throw new ValidateExceptions(errorMsg);
                    }
                }


            }

            // Gọi đến hàm validate tùy chọn:
            ValidateCustom(entity);
        }

        protected virtual void ValidateCustom(MISAEntity entity)
        {

        }
        #endregion

    }
}
