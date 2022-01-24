/***********************************************************************
 * <copyright file="Finishprlist.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 8/13/2020 11:03:35 AM
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
    
    public sealed class FinishprlistController : BaseApiController
    {
        private static readonly IFinishprlistDao FinishprlistDao = DataAccess.FinishprlistDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Finishprlist.Get")]
        public IHttpActionResult GetById([FromUri] FinishprlistCriteria criteria)
        {
            try
            {
                var result= FinishprlistDao.Get(criteria.FinishPRID);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
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
                var result = FinishprlistDao.GetListByPRID(criteria.prId);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Finishprlist.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= FinishprlistDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        //[Authorize(Roles = "System,dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetList_PR_No()
        {
            try
            {
                var result = FinishprlistDao.GetList_PR_No();
                return DataOk(result.PRIDToModel());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "System,Dbo.Finishprlist.Get")]
        public IHttpActionResult GetPaged([FromUri] FinishprlistCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = FinishprlistDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "System,Dbo.Finishprlist.Post")]
        public IHttpActionResult Post([FromBody] FinishprlistModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var finishprlist = model.FromModel();
                if (!finishprlist.Validate())
                {
                    var message = finishprlist.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = FinishprlistDao.Insert(finishprlist);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.Finishprlist.Put")]
        public IHttpActionResult Update([FromBody] FinishprlistModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var finishprlist = model.FromModel();
                if (!finishprlist.Validate())
                {
                    var message = finishprlist.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = FinishprlistDao.Update(finishprlist);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.Finishprlist.Delete")]
        public IHttpActionResult Delete([FromUri] FinishprlistCriteria criteria)
        {            
            try
            {
                var finishprlist = FinishprlistDao.Get(criteria.FinishPRID);
                if (finishprlist == null)
                    return DataNotFound();
                
                var rowAffected = FinishprlistDao.Delete(finishprlist);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
