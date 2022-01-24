/***********************************************************************
 * <copyright file="OrderHistory.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 6/20/2020 11:05:57 AM
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
    
    public sealed class OrderHistoryController : BaseApiController
    {
        private static readonly IOrderHistoryDao OrderHistoryDao = DataAccess.OrderHistoryDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderHistory.Get")]
        public IHttpActionResult GetById([FromUri] OrderHistoryCriteria criteria)
        {
            try
            {
                var result= OrderHistoryDao.Get(criteria.OrderHisId);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderHistory.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= OrderHistoryDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderHistory.Get")]
        public IHttpActionResult GetListByOrderId([FromUri] OrderHistoryCriteria criteria)
        {
            try
            {
                var result= OrderHistoryDao.GetListByOrderId(criteria.OrderId);
                return DataOk(result.ToModels());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderHistory.Get")]
        public IHttpActionResult GetPaged([FromUri] OrderHistoryCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = OrderHistoryDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.OrderHistory.Post")]
        public IHttpActionResult Post([FromBody] OrderHistoryModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var orderHistorys = model.FromModel();
                if (!orderHistorys.Validate())
                {
                    var message = orderHistorys.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = OrderHistoryDao.Insert(orderHistorys);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.OrderHistory.Put")]
        public IHttpActionResult Update([FromBody] OrderHistoryModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var orderHistorys = model.FromModel();
                if (!orderHistorys.Validate())
                {
                    var message = orderHistorys.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = OrderHistoryDao.Update(orderHistorys);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.OrderHistory.Delete")]
        public IHttpActionResult Delete([FromUri] OrderHistoryCriteria criteria)
        {            
            try
            {
                var orderHistorys = OrderHistoryDao.Get(criteria.OrderHisId);
                if (orderHistorys == null)
                    return DataNotFound();
                
                var rowAffected = OrderHistoryDao.Delete(orderHistorys);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
