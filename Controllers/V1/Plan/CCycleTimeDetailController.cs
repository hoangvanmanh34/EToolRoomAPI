/***********************************************************************
 * <copyright file="CCycleTimeDetail.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 4/7/2020 11:07:44 AM
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
using BusinessObjects;
using DataObjects;
using EToolRoomAPI.Models.V1;
using TotallyAPI.Models.V1;
using TotallyAPI.Criteria.V1;
namespace TotallyAPI.Controllers.V1.Plan
{

    public sealed class CCycleTimeDetailController : BaseApiController
    {
        private static readonly ICCycleTimeDetailDao CCycleTimeDetailDao = DataAccess.CCycleTimeDetailDao;

        [HttpGet]
        [Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetById([FromUri] CCycleTimeDetailCriteria criteria)
        {
            try
            {
                var result = CCycleTimeDetailDao.Get(criteria.CycleTimeDetailId);
                return result == null ? DataNotFound() : DataOk(result.ToModel());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetList()
        {
            try
            {
                var result = CCycleTimeDetailDao.GetList();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByModelNameAndSectionNameAndLineName([FromUri] CCycleTimeDetailCriteria criteria)
        {
            try
            {
                var result = CCycleTimeDetailDao.GetListByModelNameAndSectionNameAndLineName(criteria.ModelName, criteria.SectionName, criteria.LineName);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetPaged([FromUri] CCycleTimeDetailCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = CCycleTimeDetailDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "System,Production.CCycleTimeDetail.Post")]
        public IHttpActionResult Post([FromBody] CCycleTimeDetailModel model)
        {
            try
            {
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                model.CreatedBy = UserName;

                var cCycleTimeDetails = model.FromModel();
                if (!cCycleTimeDetails.Validate())
                {
                    var message = cCycleTimeDetails.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }

                var result = CCycleTimeDetailDao.Insert(cCycleTimeDetails);
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "System,Production.CCycleTimeDetail.Put")]
        public IHttpActionResult Update([FromBody] CCycleTimeDetailModel model)
        {
            try
            {
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                model.ModifiedBy = UserName;

                var cCycleTimeDetails = model.FromModel();
                if (!cCycleTimeDetails.Validate())
                {
                    var message = cCycleTimeDetails.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }

                var result = CCycleTimeDetailDao.Update(cCycleTimeDetails);
                return result == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "System,Production.CCycleTimeDetail.Delete")]
        public IHttpActionResult Delete([FromUri] CCycleTimeDetailCriteria criteria)
        {
            try
            {
                var cCycleTimeDetails = CCycleTimeDetailDao.Get(criteria.CycleTimeDetailId);
                if (cCycleTimeDetails == null)
                    return DataNotFound();

                var rowAffected = CCycleTimeDetailDao.Delete(cCycleTimeDetails);
                return DataOk(rowAffected);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }
    }
}
