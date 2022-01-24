/***********************************************************************
 * <copyright file="PoProgress.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 7/17/2020 4:29:58 PM
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
    
    public sealed class PoProgressController : BaseApiController
    {
        private static readonly IPoProgressDao PoProgressDao = DataAccess.PoProgressDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.PoProgress.Get")]
        public IHttpActionResult GetById([FromUri] PoProgressCriteria criteria)
        {
            try
            {
                var result= PoProgressDao.GetById(criteria.PoCode);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.PoProgress.Get")]
        public IHttpActionResult GetListByWorkingDate([FromUri] PoProgressCriteria criteria)
        {
            try
            {
                var result = PoProgressDao.GetByWorkingDate(criteria.WorkingDate);
                return result == null ? DataNotFound() : DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.PoProgress.Get")]
        public IHttpActionResult GetListByExpectDate([FromUri] PoProgressCriteria criteria)
        {
            try
            {
                var result = PoProgressDao.GetByExpectDate(criteria.ExpectDate);
                return result == null ? DataNotFound() : DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.PoProgress.Get")]
        public IHttpActionResult GetByModel([FromUri] PoProgressCriteria criteria)
        {
            try
            {
                var result = PoProgressDao.GetByModel(criteria.Modelname);

                return result == null ? DataNotFound() : DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.PoProgress.Get")]
        public IHttpActionResult GetByModelExpectDate([FromUri] PoProgressCriteria criteria)
        {
            try
            {
                var result = PoProgressDao.GetByModelExpectDate(criteria.Modelname, criteria.ExpectDate);

                return result == null ? DataNotFound() : DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.PoProgress.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result = PoProgressDao.GetList();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        } 

        [HttpGet]
        [Authorize(Roles = "System,Dbo.PoProgress.Get")]
        public IHttpActionResult GetListModel()
        {
            try
            {
                var result= PoProgressDao.GetListModel();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }        
        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.PoProgress.Get")]
        public IHttpActionResult GetPaged([FromUri] PoProgressCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = PoProgressDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.PoProgress.Post")]
        public IHttpActionResult Post([FromBody] PoProgressModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var poProgress = model.FromModel();
                if (!poProgress.Validate())
                {
                    var message = poProgress.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = PoProgressDao.Insert(poProgress);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.PoProgress.Put")]
        public IHttpActionResult Update([FromBody] PoProgressModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var poProgress = model.FromModel();
                if (!poProgress.Validate())
                {
                    var message = poProgress.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = PoProgressDao.Update(poProgress);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.PoProgress.Delete")]
        public IHttpActionResult Delete([FromUri] PoProgressCriteria criteria)
        {            
            try
            {
                var poProgress = PoProgressDao.GetById(criteria.PoProgressId);
                if (poProgress == null)
                    return DataNotFound();
                
                var rowAffected = PoProgressDao.Delete(poProgress);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
