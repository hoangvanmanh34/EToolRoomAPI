/***********************************************************************
 * <copyright file="Prtopo.cs" company="Foxconn">
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
    
    public sealed class PrtopoController : BaseApiController
    {
        private static readonly IPrtopoDao PrtopoDao = DataAccess.PrtopoDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Prtopo.Get")]
        public IHttpActionResult GetById([FromUri] PrtopoCriteria criteria)
        {
            try
            {
                var result= PrtopoDao.Get(criteria.Prtopoid);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Prtopo.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= PrtopoDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }        
        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Prtopo.Get")]
        public IHttpActionResult GetPaged([FromUri] PrtopoCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = PrtopoDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetList_By_PR_No([FromUri] PrtopoCriteria criteria)
        {
            try
            {
                var result = PrtopoDao.GetList_By_PR_No(criteria.PRNo);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "System,Dbo.Prtopo.Post")]
        public IHttpActionResult Post([FromBody] PrtopoModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var prtopos = model.FromModel();
                if (!prtopos.Validate())
                {
                    var message = prtopos.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = PrtopoDao.Insert(prtopos);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.Prtopo.Put")]
        public IHttpActionResult Update([FromBody] PrtopoModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var prtopos = model.FromModel();
                if (!prtopos.Validate())
                {
                    var message = prtopos.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = PrtopoDao.Update(prtopos);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.Prtopo.Delete")]
        public IHttpActionResult Delete([FromUri] PrtopoCriteria criteria)
        {            
            try
            {
                var prtopos = PrtopoDao.Get(criteria.Prtopoid);
                if (prtopos == null)
                    return DataNotFound();
                
                var rowAffected = PrtopoDao.Delete(prtopos);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
