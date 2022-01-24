/***********************************************************************
 * <copyright file="Unittype.cs" company="Foxconn">
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
    
    public sealed class UnittypeController : BaseApiController
    {
        private static readonly IUnittypeDao UnittypeDao = DataAccess.UnittypeDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Unittype.Get")]
        public IHttpActionResult GetById([FromUri] UnittypeCriteria criteria)
        {
            try
            {
                var result= UnittypeDao.Get(criteria.UnitType);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Unittype.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= UnittypeDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }        
        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Unittype.Get")]
        public IHttpActionResult GetPaged([FromUri] UnittypeCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = UnittypeDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.Unittype.Post")]
        public IHttpActionResult Post([FromBody] UnittypeModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var unittypes = model.FromModel();
                if (!unittypes.Validate())
                {
                    var message = unittypes.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = UnittypeDao.Insert(unittypes);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.Unittype.Put")]
        public IHttpActionResult Update([FromBody] UnittypeModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var unittypes = model.FromModel();
                if (!unittypes.Validate())
                {
                    var message = unittypes.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = UnittypeDao.Update(unittypes);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.Unittype.Delete")]
        public IHttpActionResult Delete([FromUri] UnittypeCriteria criteria)
        {            
            try
            {
                var unittypes = UnittypeDao.Get(criteria.UnitType);
                if (unittypes == null)
                    return DataNotFound();
                
                var rowAffected = UnittypeDao.Delete(unittypes);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
