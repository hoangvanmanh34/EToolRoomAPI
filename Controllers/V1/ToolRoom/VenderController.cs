/***********************************************************************
 * <copyright file="Vender.cs" company="Foxconn">
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
    
    public sealed class VenderController : BaseApiController
    {
        private static readonly IVenderDao VenderDao = DataAccess.VenderDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Vender.Get")]
        public IHttpActionResult GetById([FromUri] VenderCriteria criteria)
        {
            try
            {
                var result= VenderDao.Get(criteria.VenderName);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Vender.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= VenderDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }        
        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Vender.Get")]
        public IHttpActionResult GetPaged([FromUri] VenderCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = VenderDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.Vender.Post")]
        public IHttpActionResult Post([FromBody] VenderModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var venders = model.FromModel();
                if (!venders.Validate())
                {
                    var message = venders.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = VenderDao.Insert(venders);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.Vender.Put")]
        public IHttpActionResult Update([FromBody] VenderModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var venders = model.FromModel();
                if (!venders.Validate())
                {
                    var message = venders.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = VenderDao.Update(venders);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.Vender.Delete")]
        public IHttpActionResult Delete([FromUri] VenderCriteria criteria)
        {            
            try
            {
                var venders = VenderDao.Get(criteria.VenderName);
                if (venders == null)
                    return DataNotFound();
                
                var rowAffected = VenderDao.Delete(venders);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
