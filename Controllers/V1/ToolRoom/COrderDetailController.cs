using BaseSystem.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EToolRoomAPI.Models.V1.ToolRoom;
using DataObjects.AdoNet;
using DataObjects;
using EToolRoomAPI.Models.V1;
using BaseSystem.DataObject.Shared;
using EToolRoomAPI.Criteria.V1;

namespace EToolRoomAPI.Controllers.V1.ToolRoom
{
    public class COrderDetailController : BaseApiController
    {
        /*// GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string equipment)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]CEquipmentModel equipment)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }*/

        private static readonly ICOrderDetailDao cOrderDetailDao = DataAccess.cOrderDetailDao;

        /*[HttpGet]
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
        }*/

        [HttpGet]
        //[Authorize(Roles = "System,dbc.CEquipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetList()
        {
            try
            {
                var result = cOrderDetailDao.GetList();
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,dbc.CEquipment.Get")]
        [AllowAnonymous]
        public IHttpActionResult GetListOrderID()
        {
            try
            {
                var result = cOrderDetailDao.GetListOrderID();
                return DataOk(result.NameToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "System,Production.CCycleTimeDetail.Get")]
        public IHttpActionResult GetListByOrderID([FromUri] OrderDetailCriteria criteria)
        {
            try
            {
                var result = cOrderDetailDao.GetListByOrderID(criteria.OrderId);
                return DataOk(result.ToModels());
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "System,Production.COrderDetail.Post")]
        public IHttpActionResult Post([FromBody] COrder_DetailsModel model)
        {
            try
            {
                if (!ModelState.IsValid) return DataConflict(ModelErrorMessage);
                //model.CreatedBy = UserName;

                var cOrderDetails = model.FromModel();
                if (!cOrderDetails.Validate())
                {
                    var message = cOrderDetails.ValidationErrors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
                    return DataException(message);
                }

                var result = cOrderDetailDao.Insert(cOrderDetails);
                return result.AsIdDecrypt() == 0 ? DataNoAffected() : DataOk(result);
            }
            catch (Exception e)
            {
                return DataException(e.Message);
            }
        }

        /*[HttpGet]
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
        }*/
    }
}