/***********************************************************************
 * <copyright file="OrderDetail.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 6/20/2020 11:05:56 AM
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
 
using System;
using System.Linq;
using System.Web.Http;
using BaseSystem.API;
using BaseSystem.Security.Models;
using BaseSystem.DataObject.Shared;
using DataObjects;
using EToolRoomAPI.Models.V1;
using EToolRoomAPI.Criteria.V1;
namespace EToolRoomAPI.Controllers.V1.ToolRoom
{    
    
    public sealed class OrderDetailController : BaseApiController
    {
        private static readonly IOrderDetailDao OrderDetailDao = DataAccess.OrderDetailDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetById([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result= OrderDetailDao.Get(criteria.OrderId);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= OrderDetailDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetListModel()
        {
            try
            {
                var result = OrderDetailDao.GetListModel();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetListEquipmentIdByModel([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result = OrderDetailDao.GetListEquipmentIdByModel(criteria.EquipmentType, criteria.ModelName, criteria.FromDate, criteria.DueDate);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetListDetailByEquipmentId([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result = OrderDetailDao.GetListDetailByEquipmentId(criteria.EquipmentId, criteria.FromDate, criteria.DueDate);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetListDetailByEquipmentName([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result = OrderDetailDao.GetListDetailByEquipmentName(criteria.EquipmentName, criteria.FromDate, criteria.DueDate);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetListByAppId([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result= OrderDetailDao.GetListByAppId(criteria.AppId);
                return DataOk(result.ToModels());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetListEquipmentIdByEquipmentName([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result = OrderDetailDao.GetListEquipmentIdByEquipmentName(criteria.EquipmentType, criteria.EquipmentName, criteria.FromDate, criteria.DueDate);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetListEquipmentSpecByEquipmentName([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result = OrderDetailDao.GetListEquipmentSpecByEquipmentName(criteria.EquipmentType, criteria.EquipmentName, criteria.FromDate, criteria.DueDate);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetListEquipmentSpecByEquipmentId([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result = OrderDetailDao.GetListEquipmentSpecByEquipmentId(criteria.EquipmentId);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderDetail.Get")]
        public IHttpActionResult GetPaged([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = OrderDetailDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.OrderDetail.Post")]
        public IHttpActionResult Post([FromBody] OrderDetailModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var orderDetails = model.FromModel();
                if (!orderDetails.Validate())
                {
                    var message = orderDetails.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = OrderDetailDao.Insert(orderDetails);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        //[Authorize(Roles = "System,Dbo.OrderDetail.Put")]
        [AllowAnonymous]
        public IHttpActionResult Update([FromBody] OrderDetailModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var orderDetails = model.FromModel();
                if (!orderDetails.Validate())
                {
                    var message = orderDetails.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = OrderDetailDao.Update(orderDetails);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpPut]
        //[Authorize(Roles = "System,Dbo.OrderDetail.Put")]
        [AllowAnonymous]
        public IHttpActionResult Signature([FromBody] OrderDetailModel model)
        {
            try
            {
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);

                var orderDetails = model.FromModel();
                if (!orderDetails.Validate())
                {
                    var message = orderDetails.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                orderDetails.SignDate = DateTime.Now;
                var result = OrderDetailDao.Update(orderDetails);
                return result == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.OrderDetail.Delete")]
        public IHttpActionResult Delete([FromUri] OrderDetailCriteria criteria)
        {            
            try
            {
                var orderDetails = OrderDetailDao.Get(criteria.OrderId);
                if (orderDetails == null)
                    return DataNotFound();
                
                var rowAffected = OrderDetailDao.Delete(orderDetails);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
