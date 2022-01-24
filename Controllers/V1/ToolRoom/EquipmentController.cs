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
    
    public sealed class EquipmentController : BaseApiController
    {
        private static readonly IEquipmentDao EquipmentDao = DataAccess.EquipmentDao;
                
        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetByEId([FromUri] EquipmentCriteria criteria)
        {
            try
            {
                var result= EquipmentDao.GetListByEId(criteria.EquipmentId);
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
        public IHttpActionResult GetById([FromUri] EquipmentCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListById(criteria.EquipmentId);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
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
                var result= EquipmentDao.GetList();
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
        public IHttpActionResult GetListWithoutConsumables()
        {
            try
            {
                var result = EquipmentDao.GetListWithoutConsumables();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListModel()
        {
            try
            {
                var result = EquipmentDao.GetListModel();
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
                var result = EquipmentDao.GetListEquipmentName();
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
        public IHttpActionResult GetListEquipmentNamebyType([FromUri] EquipmentCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListEquipmentNamebyType(criteria.EquipmentType);
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
        public IHttpActionResult GetListEquipmentNameE()
        {
            try
            {
                var result = EquipmentDao.GetListEquipmentNameE();
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
        public IHttpActionResult GetListEquipmentId()
        {
            try
            {
                var result = EquipmentDao.GetListEquipmentId();
                return DataOk(result.IdToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByName([FromUri] EquipmentDetailCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListByName(criteria.equipmentName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByEquipmentName([FromUri] EquipmentDetailCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListByEquipmentName(criteria.equipmentName);
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
                var result = EquipmentDao.GetListByEquipmentModelName(criteria.equipmentName, criteria.modelName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        public IHttpActionResult GetListByEquipmentNameRemain([FromUri] EquipmentDetailCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListByEquipmentNameRemain(criteria.equipmentName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByEquipmentNamExport([FromUri] EquipmentDetailCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListByEquipmentNamExport(criteria.equipmentName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByEquipmentNameLend([FromUri] EquipmentDetailCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListByEquipmentNameLend(criteria.equipmentName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByEquipmentNameExportLend([FromUri] EquipmentDetailCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListByEquipmentNameExportLend(criteria.equipmentName);
                return DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        public IHttpActionResult GetListByUnitType([FromUri] EquipmentCriteria criteria)
        {
            try
            {
                var result= EquipmentDao.GetListByUnitType(criteria.UnitType);
                return DataOk(result.ToModels());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }
        
        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        public IHttpActionResult GetListByVenderName([FromUri] EquipmentCriteria criteria)
        {
            try
            {
                var result= EquipmentDao.GetListByVenderName(criteria.VenderName);
                return DataOk(result.ToModels());                
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        public IHttpActionResult GetListByNotInLine([FromUri] EquipmentCriteria criteria)
        {
            try
            {
                var result = EquipmentDao.GetListByNotInLine(criteria.FromDate);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpGet]
        //[Authorize(Roles = "System,Dbo.Equipment.Get")]
        public IHttpActionResult GetPaged([FromUri] EquipmentCriteria criteria)
        {
            try
            {
                var totalPage = criteria.TotalPage;
                var result = EquipmentDao.GetPaged(criteria.PageIndex, criteria.PageSize, ref totalPage);
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
        public IHttpActionResult Post([FromBody] EquipmentModel model)
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
                
                var result = EquipmentDao.Insert(equipments);                
                return result.AsInt() == 0 ? DataNoAffected() : DataOk(result);           
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }            
        }

        [HttpPut]
        //[Authorize(Roles = "System,Dbo.Equipment.Put")]
        public IHttpActionResult Update([FromBody] EquipmentModel model)
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
                
                var result = EquipmentDao.Update(equipments);
                return result == 0 ? DataNoAffected() : DataOk(result);              
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPut]
        //[Authorize(Roles = "System,Dbo.Equipment.Put")]
        public IHttpActionResult returnWareHouse([FromBody] EquipmentModel model)
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

                var result = EquipmentDao.returnWareHouse(equipments);
                return result == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPut]
        //[Authorize(Roles = "System,Dbo.Equipment.Put")]
        public IHttpActionResult SetToExport([FromBody] EquipmentModel model)
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

                var result = EquipmentDao.SetToExport(equipments);
                return result == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }


        [HttpPut]
        //[Authorize(Roles = "System,Dbo.Equipment.Put")]
        public IHttpActionResult SetToLend([FromBody] EquipmentModel model)
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

                var result = EquipmentDao.SetToLend(equipments);
                return result == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPut]
        //[Authorize(Roles = "System,Dbo.Equipment.Put")]
        public IHttpActionResult Update_Quantity([FromBody] EquipmentModel model)
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

                var result = EquipmentDao.UpdateQuantity(equipments);
                return result == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPut]
        //[Authorize(Roles = "System,Dbo.Equipment.Put")]
        public IHttpActionResult Update_ID([FromBody] EquipmentModel model)
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

                var result = EquipmentDao.Update_ID(equipments);
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
        public IHttpActionResult Delete([FromUri] EquipmentCriteria criteria)
        {            
            try
            {
                var equipments = criteria.EquipmentId;// EquipmentDao.Get(criteria.EquipmentId);
                if (equipments == null)
                    return DataNotFound();
                
                var rowAffected = EquipmentDao.Delete(equipments);
                return DataOk(rowAffected);
            }
            catch(Exception e)
            {
                return DataException(e.Message);
            }            
        }
    }
}
