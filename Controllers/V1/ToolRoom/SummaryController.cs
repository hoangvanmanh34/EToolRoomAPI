/***********************************************************************
 * <copyright file="Summary.cs" company="Foxconn">
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
    
    public sealed class SummaryController : BaseApiController
    {
        private static readonly ISummaryDao SummaryDao = DataAccess.SummaryDao;
                
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetById([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var result= SummaryDao.Get(criteria.SummaryId);
                return result == null ? DataNotFound() : DataOk(result.ToModel());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= SummaryDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }        
        
        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetListByEquipmentId([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var result= SummaryDao.GetListByEquipmentId(criteria.EquipmentId);
                return DataOk(result.ToModels());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetListByEquipmentName([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var result = SummaryDao.GetListByEquipmentName(criteria.EquipmentName);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetListByDate([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var result = SummaryDao.GetListByDate(criteria.FromDate, criteria.DueDate);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }
        public IHttpActionResult GetListByDateDetail([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var result = SummaryDao.GetListByDateDetail(criteria.FromDate, criteria.DueDate);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetPaged([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = SummaryDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetEquipmentPaged([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = SummaryDao.GetEquipmentPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetEquipmentDetailPaged([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = SummaryDao.GetEquipmentDetailPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Dbo.Summary.Get")]
        public IHttpActionResult GetConsumablesPaged([FromUri] SummaryCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = SummaryDao.GetConsumablesPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "System,Dbo.Summary.Post")]
        public IHttpActionResult Post([FromBody] SummaryModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var summarys = model.FromModel();
                if (!summarys.Validate())
                {
                    var message = summarys.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = SummaryDao.Insert(summarys);                
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        [Authorize(Roles = "System,Dbo.Summary.Put")]
        public IHttpActionResult Update([FromBody] SummaryModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var summarys = model.FromModel();
                if (!summarys.Validate())
                {
                    var message = summarys.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = SummaryDao.Update(summarys);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Dbo.Summary.Delete")]
        public IHttpActionResult Delete([FromUri] SummaryCriteria criteria)
        {            
            try
            {
                var summarys = SummaryDao.Get(criteria.SummaryId);
                if (summarys == null)
                    return DataNotFound();
                
                var rowAffected = SummaryDao.Delete(summarys);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
