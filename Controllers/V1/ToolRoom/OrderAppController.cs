/***********************************************************************
 * <copyright file="OrderApp.cs" company="Foxconn">
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
    
    public sealed class OrderAppController : BaseApiController
    {
        private static readonly IOrderAppDao OrderAppDao = DataAccess.OrderAppDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderApp.Get")]
        public IHttpActionResult GetById([FromUri] OrderAppCriteria criteria)
        {
            try
            {
                var result= OrderAppDao.Get(criteria.AppId);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderApp.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= OrderAppDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderApp.Get")]
        public IHttpActionResult GetListAppId()
        {
            try
            {
                var result = OrderAppDao.GetList_AppId();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderApp.Get")]
        public IHttpActionResult GetAppIdNew()
        {
            try
            {
                var result = OrderAppDao.GetAppId_New();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderApp.Get")]
        public IHttpActionResult GetWaitList()
        {
            try
            {
                var result = OrderAppDao.GetWaitList();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderApp.Get")]
        public IHttpActionResult getListCreateBy()
        {
            try
            {
                var result = OrderAppDao.getList_CreateBy();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderApp.Get")]
        public IHttpActionResult getListByCreateBy([FromUri] OrderAppCriteria criteria)
        {
            try
            {
                var result = OrderAppDao.getListByCreateBy(criteria.CreateBy);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.OrderApp.Get")]
        public IHttpActionResult GetPaged([FromUri] OrderAppCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = OrderAppDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "System,Dbo.OrderApp.Post")]
        public IHttpActionResult AddNew([FromUri] OrderAppModel model)
        {
            try
            {
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);

                var orderApps = model.FromModel();
                if (!orderApps.Validate())
                {
                    var message = orderApps.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }

                var result = OrderAppDao.AddNew(orderApps);
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "System,Dbo.OrderApp.Post")]
        public IHttpActionResult Post([FromBody] OrderAppModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var orderApps = model.FromModel();
                if (!orderApps.Validate())
                {
                    var message = orderApps.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = OrderAppDao.Insert(orderApps);
                return result.AsInt() == 0 ? DataNoAffected() : DataOk(result);           

            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.OrderApp.Put")]
        public IHttpActionResult Update([FromBody] OrderAppModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var orderApps = model.FromModel();
                if (!orderApps.Validate())
                {
                    var message = orderApps.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = OrderAppDao.Update(orderApps);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.OrderApp.Delete")]
        public IHttpActionResult Delete([FromUri] OrderAppCriteria criteria)
        {            
            try
            {
                var orderApps = criteria.AppId;// OrderAppDao.Get(criteria.AppId);
                if (orderApps == null)
                    return DataNotFound();
                
                var rowAffected = OrderAppDao.Delete(orderApps);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
