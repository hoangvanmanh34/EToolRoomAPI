/***********************************************************************
 * <copyright file="NreCycletime.cs" company="Foxconn">
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
    
    public sealed class NreCycletimeController : BaseApiController
    {
        private static readonly INreCycletimeDao NreCycletimeDao = DataAccess.NreCycletimeDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.NreCycletime.Get")]
        public IHttpActionResult GetById([FromUri] NreCycletimeCriteria criteria)
        {
            try
            {
                var result= NreCycletimeDao.Get(criteria.Ctid);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.NreCycletime.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= NreCycletimeDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.NreCycletime.Get")]
        public IHttpActionResult Get_By([FromUri] NreCycletimeCriteria criteria)
        {
            try
            {
                var result = NreCycletimeDao.Get_By(criteria.modelName, criteria.workStation, criteria.stationName, criteria.capacity);
                return result == null ? DataNotFound() : DataOk(result.ToModel());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "System,Dbo.NreCycletime.Get")]
        public IHttpActionResult GetPaged([FromUri] NreCycletimeCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = NreCycletimeDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        [Authorize(Roles = "System,Dbo.NreCycletime.Post")]
        public IHttpActionResult Post([FromBody] NreCycletimeModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var nreCycletimes = model.FromModel();
                if (!nreCycletimes.Validate())
                {
                    var message = nreCycletimes.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = NreCycletimeDao.Insert(nreCycletimes);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.NreCycletime.Put")]
        public IHttpActionResult Update([FromBody] NreCycletimeModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var nreCycletimes = model.FromModel();
                if (!nreCycletimes.Validate())
                {
                    var message = nreCycletimes.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = NreCycletimeDao.Update(nreCycletimes);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.NreCycletime.Delete")]
        public IHttpActionResult Delete([FromUri] NreCycletimeCriteria criteria)
        {            
            try
            {
                var nreCycletimes = NreCycletimeDao.Get(criteria.Ctid);
                if (nreCycletimes == null)
                    return DataNotFound();
                
                var rowAffected = NreCycletimeDao.Delete(nreCycletimes);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
