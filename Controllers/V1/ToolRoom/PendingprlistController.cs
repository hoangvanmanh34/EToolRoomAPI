/***********************************************************************
 * <copyright file="Pendingprlist.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 8/5/2020 11:39:07 AM
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
    
    public sealed class PendingprlistController : BaseApiController
    {
        private static readonly IPendingprlistDao PendingprlistDao = DataAccess.PendingprlistDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Pendingprlist.Get")]
        public IHttpActionResult GetById([FromUri] PendingprlistCriteria criteria)
        {
            try
            {
                var result= PendingprlistDao.Get(criteria.PendingPRID);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Pendingprlist.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= PendingprlistDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "System,Dbo.Pendingprlist.Get")]
        public IHttpActionResult GetListPRID()
        {
            try
            {
                var result = PendingprlistDao.GetListPRID();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Pendingprlist.Get")]
        public IHttpActionResult GetListByPRID([FromUri] PendingprlistCriteria criteria)
        {
            try
            {
                var result = PendingprlistDao.GetListByPRID(criteria.prId);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Pendingprlist.Get")]
        public IHttpActionResult GetPaged([FromUri] PendingprlistCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = PendingprlistDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.Pendingprlist.Post")]
        public IHttpActionResult Post([FromBody] PendingprlistModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var pendingprlist = model.FromModel();
                if (!pendingprlist.Validate())
                {
                    var message = pendingprlist.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = PendingprlistDao.Insert(pendingprlist);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.Pendingprlist.Put")]
        public IHttpActionResult Update([FromBody] PendingprlistModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var pendingprlist = model.FromModel();
                if (!pendingprlist.Validate())
                {
                    var message = pendingprlist.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = PendingprlistDao.Update(pendingprlist);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.Pendingprlist.Delete")]
        public IHttpActionResult Delete([FromUri] PendingprlistCriteria criteria)
        {            
            try
            {
                var pendingprlist = PendingprlistDao.Get(criteria.PendingPRID);
                if (pendingprlist == null)
                    return DataNotFound();
                
                var rowAffected = PendingprlistDao.Delete(pendingprlist);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
