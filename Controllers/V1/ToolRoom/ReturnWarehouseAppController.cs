/***********************************************************************
 * <copyright file="ReturnWarehouseApp.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 4/1/2021 8:18:59 AM
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
namespace EToolRoomAPI.Controllers.V1.Dbo
{    
    
    public sealed class ReturnWarehouseAppController : BaseApiController
    {
        private static readonly IReturnWarehouseAppDao ReturnWarehouseAppDao = DataAccess.ReturnWarehouseAppDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.ReturnWarehouseApp.Get")]
        public IHttpActionResult GetById([FromUri] ReturnWarehouseAppCriteria criteria)
        {
            try
            {
                var result= ReturnWarehouseAppDao.Get(criteria.AppId);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.ReturnWarehouseApp.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= ReturnWarehouseAppDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }        
        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.ReturnWarehouseApp.Get")]
        public IHttpActionResult GetPaged([FromUri] ReturnWarehouseAppCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = ReturnWarehouseAppDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.ReturnWarehouseApp.Post")]
        public IHttpActionResult Post([FromBody] ReturnWarehouseAppModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var returnWarehouseApp = model.FromModel();
                if (!returnWarehouseApp.Validate())
                {
                    var message = returnWarehouseApp.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = ReturnWarehouseAppDao.Insert(returnWarehouseApp);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.ReturnWarehouseApp.Put")]
        public IHttpActionResult Update([FromBody] ReturnWarehouseAppModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var returnWarehouseApp = model.FromModel();
                if (!returnWarehouseApp.Validate())
                {
                    var message = returnWarehouseApp.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = ReturnWarehouseAppDao.Update(returnWarehouseApp);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.ReturnWarehouseApp.Delete")]
        public IHttpActionResult Delete([FromUri] ReturnWarehouseAppCriteria criteria)
        {            
            try
            {
                var returnWarehouseApp = ReturnWarehouseAppDao.Get(criteria.AppId);
                if (returnWarehouseApp == null)
                    return DataNotFound();
                
                var rowAffected = ReturnWarehouseAppDao.Delete(returnWarehouseApp);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
