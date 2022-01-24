/***********************************************************************
 * <copyright file="Processingprlist.cs" company="Foxconn">
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
    
    public sealed class ProcessingprlistController : BaseApiController
    {
        private static readonly IProcessingprlistDao ProcessingprlistDao = DataAccess.ProcessingprlistDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Processingprlist.Get")]
        public IHttpActionResult GetById([FromUri] ProcessingprlistCriteria criteria)
        {
            try
            {
                var result= ProcessingprlistDao.Get(criteria.ProcessingPRID);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Processingprlist.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= ProcessingprlistDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "System,Dbo.Processingprlist.Get")]
        public IHttpActionResult GetListPRID()
        {
            try
            {
                var result = ProcessingprlistDao.GetListPRID();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Processingprlist.Get")]
        public IHttpActionResult GetListByPRID([FromUri] ProcessingprlistCriteria criteria)
        {
            try
            {
                var result = ProcessingprlistDao.GetListByPRID(criteria.prId);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Processingprlist.Get")]
        public IHttpActionResult GetPaged([FromUri] ProcessingprlistCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = ProcessingprlistDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.Processingprlist.Post")]
        public IHttpActionResult Post([FromBody] ProcessingprlistModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var processingprlist = model.FromModel();
                if (!processingprlist.Validate())
                {
                    var message = processingprlist.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = ProcessingprlistDao.Insert(processingprlist);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.Processingprlist.Put")]
        public IHttpActionResult Update([FromBody] ProcessingprlistModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var processingprlist = model.FromModel();
                if (!processingprlist.Validate())
                {
                    var message = processingprlist.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = ProcessingprlistDao.Update(processingprlist);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.Processingprlist.Delete")]
        public IHttpActionResult Delete([FromUri] ProcessingprlistCriteria criteria)
        {            
            try
            {
                var processingprlist = ProcessingprlistDao.Get(criteria.ProcessingPRID);
                if (processingprlist == null)
                    return DataNotFound();
                
                var rowAffected = ProcessingprlistDao.Delete(processingprlist);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
