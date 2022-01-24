/***********************************************************************
 * <copyright file="NreDetail.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 8/20/2020 4:35:31 PM
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
    
    public sealed class NreDetailController : BaseApiController
    {
        private static readonly INreDetailDao NreDetailDao = DataAccess.NreDetailDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.NreDetail.Get")]
        public IHttpActionResult GetById([FromUri] NreDetailCriteria criteria)
        {
            try
            {
                var result= NreDetailDao.Get(criteria.Nreid);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.NreDetail.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= NreDetailDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }        
        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.NreDetail.Get")]
        public IHttpActionResult GetPaged([FromUri] NreDetailCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = NreDetailDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.NreDetail.Post")]
        public IHttpActionResult Post([FromBody] NreDetailModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var nreDetails = model.FromModel();
                if (!nreDetails.Validate())
                {
                    var message = nreDetails.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = NreDetailDao.Insert(nreDetails);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.NreDetail.Put")]
        public IHttpActionResult Update([FromBody] NreDetailModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var nreDetails = model.FromModel();
                if (!nreDetails.Validate())
                {
                    var message = nreDetails.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = NreDetailDao.Update(nreDetails);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.NreDetail.Delete")]
        public IHttpActionResult Delete([FromUri] NreDetailCriteria criteria)
        {            
            try
            {
                var nreDetails = NreDetailDao.Get(criteria.Nreid);
                if (nreDetails == null)
                    return DataNotFound();
                
                var rowAffected = NreDetailDao.Delete(nreDetails);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
