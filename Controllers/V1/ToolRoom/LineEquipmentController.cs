/***********************************************************************
 * <copyright file="Equipment.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    son.hb@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 6/20/2020 11:05:56 AM
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
    
    public sealed class LineEquipmentController : BaseApiController
    {
        private static readonly ILineEquipmentDao LineEquipmentDao = DataAccess.LineEquipmentDao;

        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetById([FromUri] LineEquipmentCriteria criteria)
        {
            try
            {
                var result = LineEquipmentDao.Get(criteria.EquipmentId);
                return result == null ? DataNotFound() : DataOk(result.ToModel());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListById([FromUri] LineEquipmentCriteria criteria)
        {
            try
            {
                var result= LineEquipmentDao.GetListById(criteria.LineEquipmentId);
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetList()
        {
            try
            {
                var result= LineEquipmentDao.GetList();
                return DataOk(result.ToModels());
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListByType([FromUri] LineEquipmentCriteria criteria)
        {
            try
            {
                var result = LineEquipmentDao.GetListByType(criteria.EquipmentType);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListEquipmentId()
        {
            try
            {
                var result = LineEquipmentDao.GetListEquipmentId();
                return DataOk(result.IdToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListType()
        {
            try
            {
                var result = LineEquipmentDao.GetListType();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        /*
        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListModel()
        {
            try
            {
                var result = LineEquipmentDao.GetListModel();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        //[Authorize(Roles = "System,dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListEquipmentName()
        {
            try
            {
                var result = LineEquipmentDao.GetListEquipmentName();
                return DataOk(result.NameToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListEquipmentNamebyType([FromUri] LineEquipmentCriteria criteria)
        {
            try
            {
                var result = LineEquipmentDao.GetListEquipmentNamebyType(criteria.EquipmentType);
                return DataOk(result.NameToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        

        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByName([FromUri] LineEquipmentCriteria criteria)
        {
            try
            {
                var result = LineEquipmentDao.GetListByName(criteria.EquipmentName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByEquipmentName([FromUri] LineEquipmentCriteria criteria)
        {
            try
            {
                var result = LineEquipmentDao.GetListByEquipmentName(criteria.EquipmentName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByEquipmentModelName([FromUri] EquipmentDetailCriteria criteria)
        {
            try
            {
                var result = LineEquipmentDao.GetListByEquipmentModelName(criteria.equipmentName, criteria.modelName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }    */

        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        public IHttpActionResult GetPaged([FromUri] LineEquipmentCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = LineEquipmentDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
                return DataOk(result.ToModels(), totalPage);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }        

        [HttpPost]
        //[Authorize(Roles = "System,Dbo.Equipment.Post")]
        [AllowAnonymous]
        public IHttpActionResult Post([FromBody] LineEquipmentModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var equipments = model.FromModel();
                if (!equipments.Validate())
                {
                    var message = equipments.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = LineEquipmentDao.Insert(equipments);                
                return result.AsInt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        //[Authorize(Roles = "System,Dbo.Equipment.Put")]
        public IHttpActionResult Update([FromBody] LineEquipmentModel model)
        {
            try
            {                
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                
                var equipments = model.FromModel();
                if (!equipments.Validate())
                {
                    var message = equipments.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }
                
                var result = LineEquipmentDao.Update(equipments);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpDelete]
        //[Authorize(Roles = "System,Dbo.Equipment.Delete")]
        [AllowAnonymous]
        public IHttpActionResult Delete([FromUri] LineEquipmentCriteria criteria)
        {            
            try
            {
                var equipments = LineEquipmentDao.Get(criteria.LineEquipmentId);
                if (equipments == null)
                    return DataNotFound();
                
                var rowAffected = LineEquipmentDao.Delete(equipments);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
