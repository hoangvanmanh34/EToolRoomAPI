using BusinessObjects;
using System.Collections.Generic;
using System.Linq;
using BaseSystem.Security.Models;
using EToolRoomAPI.Models.V1.ToolRoom;
using EToolRoomAPI.Models.V1;
//using ToolRoomAPI.Models.V1;

namespace EToolRoomAPI.Models.V1
{
    /// <summary>
    /// Maps Models (Model Objects) to BOs (Business Objects) and vice versa.
    /// </summary>
    public static class Mapper
    {
        public static CEquipmentModel ToModel(this CEquipment cEquipment)
        {
            if (cEquipment == null) return null;

            return new CEquipmentModel
            {
                EQUIPMENT_ID = cEquipment.EQUIPMENT_ID,
                EQUIPMENT_NAME = cEquipment.EQUIPMENT_NAME,
                EQUIPMENT_TYPE = cEquipment.EQUIPMENT_TYPE,
                QUANTITY = cEquipment.QUANTITY,
                PRICE = cEquipment.PRICE,
                IMPORT_DATE = cEquipment.IMPORT_DATE,
                SPECIFICATIONS = cEquipment.SPECIFICATIONS,
                UNIT_TYPE = cEquipment.UNIT_TYPE,
                VENDER_NAME = cEquipment.VENDER_NAME,
                STORAGESPACE = cEquipment.STORAGESPACE,
                REMARK = cEquipment.REMARK,
                PURCHASE_ID = cEquipment.PURCHASE_ID,
                ModelName = cEquipment.ModelName,
                StationName = cEquipment.StationName,
                LineName = cEquipment.LineName,
                FactoryName = cEquipment.FactoryName,
            };
        }

        public static CEquipmentModel NameToModel(this CEquipment cEquipment)
        {
            if (cEquipment == null) return null;

            return new CEquipmentModel
            {
                EQUIPMENT_NAME = cEquipment.EQUIPMENT_NAME
            };
        }

        /// <summary>
        public static IList<CEquipmentModel> ToModels(this IEnumerable<CEquipment> cEquipment)
        {
            return cEquipment?.Select(ToModel).ToList();
        }
        public static IList<CEquipmentModel> NameToModels(this IEnumerable<CEquipment> cEquipment)
        {
            return cEquipment?.Select(NameToModel).ToList();
        }

        public static CEquipment FromModel(this CEquipmentModel cEquipment)
        {
            if (cEquipment == null) return null;

            return new CEquipment
            {
                EQUIPMENT_ID = cEquipment.EQUIPMENT_ID,
                EQUIPMENT_NAME = cEquipment.EQUIPMENT_NAME,
                EQUIPMENT_TYPE = cEquipment.EQUIPMENT_TYPE,
                QUANTITY = cEquipment.QUANTITY,
                PRICE = cEquipment.PRICE,
                IMPORT_DATE = cEquipment.IMPORT_DATE,
                SPECIFICATIONS = cEquipment.SPECIFICATIONS,
                UNIT_TYPE = cEquipment.UNIT_TYPE,
                VENDER_NAME = cEquipment.VENDER_NAME,
                STORAGESPACE = cEquipment.STORAGESPACE,
                REMARK = cEquipment.REMARK,
                PURCHASE_ID = cEquipment.PURCHASE_ID,
                ModelName = cEquipment.ModelName,
                StationName = cEquipment.StationName,
                LineName = cEquipment.LineName,
                FactoryName = cEquipment.FactoryName,
            };
        }

        /// <summary>
        public static IList<CEquipment> FromModels(this IEnumerable<CEquipmentModel> cEquipment)
        {
            return cEquipment?.Select(FromModel).ToList();
        }

        //-----------------------APP------------------------------------------------------------
        public static COrder_DetailsModel ToModel(this COrderDetail cOrderDetail)
        {
            if (cOrderDetail == null) return null;

            return new COrder_DetailsModel
            {
                ORDER_ID = cOrderDetail.ORDER_ID,
                APP_ID = cOrderDetail.APP_ID,
                EQUIPMENT_ID = cOrderDetail.EQUIPMENT_ID,
                QUANTITY = cOrderDetail.QUANTITY,
                STATION_NAME = cOrderDetail.STATION_NAME,
                MODEL_NAME = cOrderDetail.MODEL_NAME,
                LINE_NAME = cOrderDetail.LINE_NAME,
                FACTORY_NAME = cOrderDetail.FACTORY_NAME,
                APP_TYPE = cOrderDetail.APP_TYPE,
                REAL_EXPORT = cOrderDetail.REAL_EXPORT,
                FROM_DATE = cOrderDetail.FROM_DATE,
                DUE_DATE = cOrderDetail.DUE_DATE,
                APPROVE_REJECT = cOrderDetail.APPROVE_REJECT,
                STATUSS = cOrderDetail.STATUSS,
                SIGN_DATE = cOrderDetail.SIGN_DATE,
                REMARK = cOrderDetail.REMARK,
                EQUIPMENT_NAME = cOrderDetail.EQUIPMENT_NAME,
                EQUIPMENT_TYPE = cOrderDetail.EQUIPMENT_TYPE,
            };
        }
        public static COrder_DetailsModel NameToModel(this COrderDetail cOrderDetail)
        {
            if (cOrderDetail == null) return null;

            return new COrder_DetailsModel
            {
                ORDER_ID = cOrderDetail.ORDER_ID
            };
        }
        public static IList<COrder_DetailsModel> NameToModels(this IEnumerable<COrderDetail> cOrderDetail)
        {
            return cOrderDetail?.Select(NameToModel).ToList();
        }

        public static IList<COrder_DetailsModel> ToModels(this IEnumerable<COrderDetail> cOrderDetail)
        {
            return cOrderDetail?.Select(ToModel).ToList();
        }
        public static COrderDetail FromModel(this COrder_DetailsModel cOrderDetail)
        {
            if (cOrderDetail == null) return null;

            return new COrderDetail
            {
                ORDER_ID = cOrderDetail.ORDER_ID,
                APP_ID = cOrderDetail.APP_ID,
                EQUIPMENT_ID = cOrderDetail.EQUIPMENT_ID,
                QUANTITY = cOrderDetail.QUANTITY,
                STATION_NAME = cOrderDetail.STATION_NAME,
                MODEL_NAME = cOrderDetail.MODEL_NAME,
                LINE_NAME = cOrderDetail.LINE_NAME,
                FACTORY_NAME = cOrderDetail.FACTORY_NAME,
                APP_TYPE = cOrderDetail.APP_TYPE,
                REAL_EXPORT = cOrderDetail.REAL_EXPORT,
                FROM_DATE = cOrderDetail.FROM_DATE,
                DUE_DATE = cOrderDetail.DUE_DATE,
                APPROVE_REJECT = cOrderDetail.APPROVE_REJECT,
                STATUSS = cOrderDetail.STATUSS,
                SIGN_DATE = cOrderDetail.SIGN_DATE,
                REMARK = cOrderDetail.REMARK,
                EQUIPMENT_NAME = cOrderDetail.EQUIPMENT_NAME,
                EQUIPMENT_TYPE = cOrderDetail.EQUIPMENT_TYPE,
            };
        }

        public static IList<COrderDetail> FromModels(this IEnumerable<COrder_DetailsModel> cOrderDetail)
        {
            return cOrderDetail?.Select(FromModel).ToList();
        }

        /// <summary>
        /// Transforms equipments BO to equipments Model.
        /// </summary>
        /// <param name="equipments">Equipment BO.</param>
        /// <returns>Category Model.</returns>
        public static EquipmentModel ToModel(this Equipment equipments)
        {
            if (equipments == null) return null;

            return new EquipmentModel
            {
                Eid = equipments.Eid,
                EquipmentId = equipments.EquipmentId,
                EquipmentSn = equipments.EquipmentSn,
                EquipmentName = equipments.EquipmentName,
                EquipmentType = equipments.EquipmentType,
                Quantity = equipments.Quantity,
                Price = equipments.Price,
                ImportDate = equipments.ImportDate,
                Specification = equipments.Specification,
                Storagespace = equipments.Storagespace,
                Remark = equipments.Remark,
                PurchaseId = equipments.PurchaseId,
                UnitType = equipments.UnitType,
                VenderName = equipments.VenderName,
                Lend = equipments.Lend,
                Export = equipments.Export,
                Remain = equipments.Remain,
                ModelName = equipments.ModelName,
                StationName = equipments.StationName,
                LineName = equipments.LineName,
                FactoryName = equipments.FactoryName,
                FourId = equipments.FourId,
                EquipmentIdnew = equipments.EquipmentIdnew,
                Currency = equipments.Currency,
                IdDecrypt = equipments.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of equipments BOs list of equipments Models.
        /// </summary>
        /// <param name="equipments">List of equipments BOs.</param>
        /// <returns>List of equipments Models.</returns>
        public static IList<EquipmentModel> ToModels(this IEnumerable<Equipment> equipments)
        {
            return equipments?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Equipment Model to Equipment BO.
        /// </summary>
        /// <param name="equipments">Equipment Model.</param>
        /// <returns>Equipment BO.</returns>
        public static Equipment FromModel(this EquipmentModel equipments)
        {
            if (equipments == null) return null;

            return new Equipment
            {
                Eid = equipments.Eid,
                EquipmentId = equipments.EquipmentId,
                EquipmentSn = equipments.EquipmentSn,
                EquipmentName = equipments.EquipmentName,
                EquipmentType = equipments.EquipmentType,
                Quantity = equipments.Quantity,
                Price = equipments.Price,
                ImportDate = equipments.ImportDate,
                Specification = equipments.Specification,
                Storagespace = equipments.Storagespace,
                Remark = equipments.Remark,
                PurchaseId = equipments.PurchaseId,
                UnitType = equipments.UnitType,
                VenderName = equipments.VenderName,
                Lend = equipments.Lend,
                Export = equipments.Export,
                Remain = equipments.Remain,
                ModelName = equipments.ModelName,
                StationName = equipments.StationName,
                LineName = equipments.LineName,
                FactoryName = equipments.FactoryName,
                FourId = equipments.FourId,
                EquipmentIdnew = equipments.EquipmentIdnew,
                Currency = equipments.Currency,
                IdDecrypt = equipments.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of equipments BOs list of equipments Models.
        /// </summary>
        /// <param name="equipments">List of equipments BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<Equipment> FromModels(this IEnumerable<EquipmentModel> equipments)
        {
            return equipments?.Select(FromModel).ToList();
        }
        //----------------------------------------------------------------------------------------------
        public static LineEquipmentModel ToModel(this LineEquipment equipments)
        {
            if (equipments == null) return null;

            return new LineEquipmentModel
            {
                LineEquipmentId = equipments.LineEquipmentId,
                EquipmentId = equipments.EquipmentId,
                EquipmentSn = equipments.EquipmentSn,
                Station = equipments.Station,
                Machinename = equipments.Machinename,
                Type = equipments.Type,
                Ip = equipments.Ip,
                Datetime = equipments.Datetime,
                IdDecrypt = equipments.IdDecrypt
            };
        }

        

        /// <summary>
        /// Transforms list of equipments BOs list of equipments Models.
        /// </summary>
        /// <param name="equipments">List of equipments BOs.</param>
        /// <returns>List of equipments Models.</returns>
        public static IList<LineEquipmentModel> ToModels(this IEnumerable<LineEquipment> equipments)
        {
            return equipments?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Equipment Model to Equipment BO.
        /// </summary>
        /// <param name="equipments">Equipment Model.</param>
        /// <returns>Equipment BO.</returns>
        public static LineEquipment FromModel(this LineEquipmentModel equipments)
        {
            if (equipments == null) return null;

            return new LineEquipment
            {
                LineEquipmentId = equipments.LineEquipmentId,
                EquipmentId = equipments.EquipmentId,
                EquipmentSn = equipments.EquipmentSn,
                Station = equipments.Station,
                Machinename = equipments.Machinename,
                Type = equipments.Type,
                Ip = equipments.Ip,
                Datetime = equipments.Datetime,
                IdDecrypt = equipments.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of equipments BOs list of equipments Models.
        /// </summary>
        /// <param name="equipments">List of equipments BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<LineEquipment> FromModels(this IEnumerable<LineEquipmentModel> equipments)
        {
            return equipments?.Select(FromModel).ToList();
        }

        /// <summary>
        /// Transforms orderApps BO to orderApps Model.
        /// </summary>
        /// <param name="orderApps">OrderApp BO.</param>
        /// <returns>Category Model.</returns>
        public static OrderAppModel ToModel(this OrderApp orderApps)
        {
            if (orderApps == null) return null;

            return new OrderAppModel
            {
                AppId = orderApps.AppId,
                ApproveReject = orderApps.ApproveReject,
                Statuss = orderApps.Statuss,
                SignDate = orderApps.SignDate,
                Remark = orderApps.Remark,
                CreateBy = orderApps.CreateBy,
                CreateDate = orderApps.CreateDate,
                IdDecrypt = orderApps.IdDecrypt
            };
        }


        public static EquipmentModel NameToModel(this Equipment cEquipment)
        {
            if (cEquipment == null) return null;

            return new EquipmentModel
            {
                EquipmentName = cEquipment.EquipmentName
            };
        }

        public static EquipmentModel IdToModel(this Equipment cEquipment)
        {
            if (cEquipment == null) return null;

            return new EquipmentModel
            {
                EquipmentId = cEquipment.EquipmentId
            };
        }

        /// <summary>
        /// Transforms list of orderApps BOs list of orderApps Models.
        /// </summary>
        /// <param name="orderApps">List of orderApps BOs.</param>
        /// <returns>List of orderApps Models.</returns>
        public static IList<OrderAppModel> ToModels(this IEnumerable<OrderApp> orderApps)
        {
            return orderApps?.Select(ToModel).ToList();
        }

        public static IList<EquipmentModel> NameToModels(this IEnumerable<Equipment> cEquipment)
        {
            return cEquipment?.Select(NameToModel).ToList();
        }
        public static IList<EquipmentModel> IdToModels(this IEnumerable<Equipment> cEquipment)
        {
            return cEquipment?.Select(IdToModel).ToList();
        }
        /// <summary>
        /// Transforms nreCycletimes BO to nreCycletimes Model.
        /// </summary>
        /// <param name="nreCycletimes">NreCycletime BO.</param>
        /// <returns>Category Model.</returns>
        public static NreCycletimeModel ToModel(this NreCycletime nreCycletimes)
        {
            if (nreCycletimes == null) return null;

            return new NreCycletimeModel
            {
                Ctid = nreCycletimes.Ctid,
                ModelName = nreCycletimes.ModelName,
                WorkStation = nreCycletimes.WorkStation,
                StationName = nreCycletimes.StationName,
                Capacity = nreCycletimes.Capacity,
                TestTime = nreCycletimes.TestTime,
                HandlingTime = nreCycletimes.HandlingTime,
                CycleTime = nreCycletimes.CycleTime,
                PiecePerPanel = nreCycletimes.PiecePerPanel,
                OutputPerHour = nreCycletimes.OutputPerHour,
                WorkingPerShift = nreCycletimes.WorkingPerShift,
                ShiftPerDay = nreCycletimes.ShiftPerDay,
                YieldRate = nreCycletimes.YieldRate,
                DailyOutputOne = nreCycletimes.DailyOutputOne,
                NumberTester = nreCycletimes.NumberTester,
                DailyOutput = nreCycletimes.DailyOutput,
                Remark = nreCycletimes.Remark,
                CreateBy = nreCycletimes.CreateBy,
                CreateByName = nreCycletimes.CreateByName,
                IdDecrypt = nreCycletimes.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of nreCycletimes BOs list of nreCycletimes Models.
        /// </summary>
        /// <param name="nreCycletimes">List of nreCycletimes BOs.</param>
        /// <returns>List of nreCycletimes Models.</returns>
        public static IList<NreCycletimeModel> ToModels(this IEnumerable<NreCycletime> nreCycletimes)
        {
            return nreCycletimes?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers NreCycletime Model to NreCycletime BO.
        /// </summary>
        /// <param name="nreCycletimes">NreCycletime Model.</param>
        /// <returns>NreCycletime BO.</returns>
        public static NreCycletime FromModel(this NreCycletimeModel nreCycletimes)
        {
            if (nreCycletimes == null) return null;

            return new NreCycletime
            {
                Ctid = nreCycletimes.Ctid,
                ModelName = nreCycletimes.ModelName,
                WorkStation = nreCycletimes.WorkStation,
                StationName = nreCycletimes.StationName,
                Capacity = nreCycletimes.Capacity,
                TestTime = nreCycletimes.TestTime,
                HandlingTime = nreCycletimes.HandlingTime,
                CycleTime = nreCycletimes.CycleTime,
                PiecePerPanel = nreCycletimes.PiecePerPanel,
                OutputPerHour = nreCycletimes.OutputPerHour,
                WorkingPerShift = nreCycletimes.WorkingPerShift,
                ShiftPerDay = nreCycletimes.ShiftPerDay,
                YieldRate = nreCycletimes.YieldRate,
                DailyOutputOne = nreCycletimes.DailyOutputOne,
                NumberTester = nreCycletimes.NumberTester,
                DailyOutput = nreCycletimes.DailyOutput,
                Remark = nreCycletimes.Remark,
                CreateBy = nreCycletimes.CreateBy,
                CreateByName = nreCycletimes.CreateByName,
                IdDecrypt = nreCycletimes.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of nreCycletimes BOs list of nreCycletimes Models.
        /// </summary>
        /// <param name="nreCycletimes">List of nreCycletimes BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<NreCycletime> FromModels(this IEnumerable<NreCycletimeModel> nreCycletimes)
        {
            return nreCycletimes?.Select(FromModel).ToList();
        }

        /// <summary>
        /// Transforms nreDetails BO to nreDetails Model.
        /// </summary>
        /// <param name="nreDetails">NreDetail BO.</param>
        /// <returns>Category Model.</returns>
        public static NreDetailModel ToModel(this NreDetail nreDetails)
        {
            if (nreDetails == null) return null;

            return new NreDetailModel
            {
                Nreid = nreDetails.Nreid,
                ModelName = nreDetails.ModelName,
                WorkStation = nreDetails.WorkStation,
                StationName = nreDetails.StationName,
                Capacity = nreDetails.Capacity,
                EquipmentId = nreDetails.EquipmentId,
                EquipmentName = nreDetails.EquipmentName,
                Specifications = nreDetails.Specifications,
                LeaveTime = nreDetails.LeaveTime,
                UnitPrice = nreDetails.UnitPrice,
                Qpt = nreDetails.Qpt,
                NumberTester = nreDetails.NumberTester,
                Qpl = nreDetails.Qpl,
                SumCost = nreDetails.SumCost,
                Remark = nreDetails.Remark,
                CreateBy = nreDetails.CreateBy,
                CreateByName = nreDetails.CreateByName,
                IdDecrypt = nreDetails.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of nreDetails BOs list of nreDetails Models.
        /// </summary>
        /// <param name="nreDetails">List of nreDetails BOs.</param>
        /// <returns>List of nreDetails Models.</returns>
        public static IList<NreDetailModel> ToModels(this IEnumerable<NreDetail> nreDetails)
        {
            return nreDetails?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers NreDetail Model to NreDetail BO.
        /// </summary>
        /// <param name="nreDetails">NreDetail Model.</param>
        /// <returns>NreDetail BO.</returns>
        public static NreDetail FromModel(this NreDetailModel nreDetails)
        {
            if (nreDetails == null) return null;

            return new NreDetail
            {
                Nreid = nreDetails.Nreid,
                ModelName = nreDetails.ModelName,
                WorkStation = nreDetails.WorkStation,
                StationName = nreDetails.StationName,
                Capacity = nreDetails.Capacity,
                EquipmentId = nreDetails.EquipmentId,
                EquipmentName = nreDetails.EquipmentName,
                Specifications = nreDetails.Specifications,
                LeaveTime = nreDetails.LeaveTime,
                UnitPrice = nreDetails.UnitPrice,
                Qpt = nreDetails.Qpt,
                NumberTester = nreDetails.NumberTester,
                Qpl = nreDetails.Qpl,
                SumCost = nreDetails.SumCost,
                Remark = nreDetails.Remark,
                CreateBy = nreDetails.CreateBy,
                CreateByName = nreDetails.CreateByName,
                IdDecrypt = nreDetails.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of nreDetails BOs list of nreDetails Models.
        /// </summary>
        /// <param name="nreDetails">List of nreDetails BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<NreDetail> FromModels(this IEnumerable<NreDetailModel> nreDetails)
        {
            return nreDetails?.Select(FromModel).ToList();
        }

        /// <summary>
        /// Transfers OrderApp Model to OrderApp BO.
        /// </summary>
        /// <param name="orderApps">OrderApp Model.</param>
        /// <returns>OrderApp BO.</returns>
        public static OrderApp FromModel(this OrderAppModel orderApps)
        {
            if (orderApps == null) return null;

            return new OrderApp
            {
                AppId = orderApps.AppId,
                ApproveReject = orderApps.ApproveReject,
                Statuss = orderApps.Statuss,
                SignDate = orderApps.SignDate,
                Remark = orderApps.Remark,
                CreateBy = orderApps.CreateBy,
                CreateDate = orderApps.CreateDate,
                IdDecrypt = orderApps.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of orderApps BOs list of orderApps Models.
        /// </summary>
        /// <param name="orderApps">List of orderApps BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<OrderApp> FromModels(this IEnumerable<OrderAppModel> orderApps)
        {
            return orderApps?.Select(FromModel).ToList();
        }

        /// <summary>
        /// Transforms orderDetails BO to orderDetails Model.
        /// </summary>
        /// <param name="orderDetails">OrderDetail BO.</param>
        /// <returns>Category Model.</returns>
        public static OrderDetailModel ToModel(this OrderDetail orderDetails)
        {
            if (orderDetails == null) return null;

            return new OrderDetailModel
            {
                OrderId = orderDetails.OrderId,
                AppId = orderDetails.AppId,
                EquipmentId = orderDetails.EquipmentId,
                Quantity = orderDetails.Quantity,
                StationName = orderDetails.StationName,
                ModelName = orderDetails.ModelName,
                LineName = orderDetails.LineName,
                FactoryName = orderDetails.FactoryName,
                AppType = orderDetails.AppType,
                RealExport = orderDetails.RealExport,
                FromDate = orderDetails.FromDate,
                DueDate = orderDetails.DueDate,
                ApproveReject = orderDetails.ApproveReject,
                Statuss = orderDetails.Statuss,
                SignDate = orderDetails.SignDate,
                Remark = orderDetails.Remark,
                EquipmentName = orderDetails.EquipmentName,
                EquipmentType = orderDetails.EquipmentType,
                CreateBy = orderDetails.CreateBy,
                SignBy = orderDetails.SignBy,
                ExportBy = orderDetails.ExportBy,
                CreateDate = orderDetails.CreateDate,
                ExportDate = orderDetails.ExportDate,
                LastExport = orderDetails.LastExport,
                Specification = orderDetails.Specification,
                RemainWarehouse = orderDetails.RemainWarehouse,
                Endoforder = orderDetails.Endoforder,
                IdDecrypt = orderDetails.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of orderDetails BOs list of orderDetails Models.
        /// </summary>
        /// <param name="orderDetails">List of orderDetails BOs.</param>
        /// <returns>List of orderDetails Models.</returns>
        public static IList<OrderDetailModel> ToModels(this IEnumerable<OrderDetail> orderDetails)
        {
            return orderDetails?.Select(ToModel).ToList();
        }
        /// <summary>
        /// Transfers OrderDetail Model to OrderDetail BO.
        /// </summary>
        /// <param name="orderDetails">OrderDetail Model.</param>
        /// <returns>OrderDetail BO.</returns>
        public static OrderDetail FromModel(this OrderDetailModel orderDetails)
        {
            if (orderDetails == null) return null;

            return new OrderDetail
            {
                OrderId = orderDetails.OrderId,
                AppId = orderDetails.AppId,
                EquipmentId = orderDetails.EquipmentId,
                Quantity = orderDetails.Quantity,
                StationName = orderDetails.StationName,
                ModelName = orderDetails.ModelName,
                LineName = orderDetails.LineName,
                FactoryName = orderDetails.FactoryName,
                AppType = orderDetails.AppType,
                RealExport = orderDetails.RealExport,
                FromDate = orderDetails.FromDate,
                DueDate = orderDetails.DueDate,
                ApproveReject = orderDetails.ApproveReject,
                Statuss = orderDetails.Statuss,
                SignDate = orderDetails.SignDate,
                Remark = orderDetails.Remark,
                EquipmentName = orderDetails.EquipmentName,
                EquipmentType = orderDetails.EquipmentType,
                CreateBy = orderDetails.CreateBy,
                SignBy = orderDetails.SignBy,
                ExportBy = orderDetails.ExportBy,
                CreateDate = orderDetails.CreateDate,
                ExportDate = orderDetails.ExportDate,
                LastExport = orderDetails.LastExport,
                Specification = orderDetails.Specification,
                RemainWarehouse = orderDetails.RemainWarehouse,
                Endoforder = orderDetails.Endoforder,
                IdDecrypt = orderDetails.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms returnWarehouseApp BO to returnWarehouseApp Model.
        /// </summary>
        /// <param name="returnWarehouseApp">ReturnWarehouseApp BO.</param>
        /// <returns>Category Model.</returns>
        public static ReturnWarehouseAppModel ToModel(this ReturnWarehouseApp returnWarehouseApp)
        {
            if (returnWarehouseApp == null) return null;

            return new ReturnWarehouseAppModel
            {
                AppId = returnWarehouseApp.AppId,
                AppNum = returnWarehouseApp.AppNum,
                EquipmentId = returnWarehouseApp.EquipmentId,
                EquipmentName = returnWarehouseApp.EquipmentName,
                Quantity = returnWarehouseApp.Quantity,
                AppCreateDate = returnWarehouseApp.AppCreateDate,
                AppReason = returnWarehouseApp.AppReason,
                ApproveReject = returnWarehouseApp.ApproveReject,
                ApproveRejectDate = returnWarehouseApp.ApproveRejectDate,
                EmpComment = returnWarehouseApp.EmpComment,
                CreateById = returnWarehouseApp.CreateById,
                CreateByName = returnWarehouseApp.CreateByName,
                EmpId = returnWarehouseApp.EmpId,
                EmpName = returnWarehouseApp.EmpName,
                Remark = returnWarehouseApp.Remark,
                IdDecrypt = returnWarehouseApp.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of returnWarehouseApp BOs list of returnWarehouseApp Models.
        /// </summary>
        /// <param name="returnWarehouseApps">List of returnWarehouseApp BOs.</param>
        /// <returns>List of returnWarehouseApps Models.</returns>
        public static IList<ReturnWarehouseAppModel> ToModels(this IEnumerable<ReturnWarehouseApp> returnWarehouseApps)
        {
            return returnWarehouseApps?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers ReturnWarehouseApp Model to ReturnWarehouseApp BO.
        /// </summary>
        /// <param name="returnWarehouseApp">ReturnWarehouseApp Model.</param>
        /// <returns>ReturnWarehouseApp BO.</returns>
        public static ReturnWarehouseApp FromModel(this ReturnWarehouseAppModel returnWarehouseApp)
        {
            if (returnWarehouseApp == null) return null;

            return new ReturnWarehouseApp
            {
                AppId = returnWarehouseApp.AppId,
                AppNum = returnWarehouseApp.AppNum,
                EquipmentId = returnWarehouseApp.EquipmentId,
                EquipmentName = returnWarehouseApp.EquipmentName,
                Quantity = returnWarehouseApp.Quantity,
                AppCreateDate = returnWarehouseApp.AppCreateDate,
                AppReason = returnWarehouseApp.AppReason,
                ApproveReject = returnWarehouseApp.ApproveReject,
                ApproveRejectDate = returnWarehouseApp.ApproveRejectDate,
                EmpComment = returnWarehouseApp.EmpComment,
                CreateById = returnWarehouseApp.CreateById,
                CreateByName = returnWarehouseApp.CreateByName,
                EmpId = returnWarehouseApp.EmpId,
                EmpName = returnWarehouseApp.EmpName,
                Remark = returnWarehouseApp.Remark,
                IdDecrypt = returnWarehouseApp.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of returnWarehouseApp BOs list of returnWarehouseApp Models.
        /// </summary>
        /// <param name="returnWarehouseApps">List of returnWarehouseApps BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<ReturnWarehouseApp> FromModels(this IEnumerable<ReturnWarehouseAppModel> returnWarehouseApps)
        {
            return returnWarehouseApps?.Select(FromModel).ToList();
        }

        /// <summary>
        /// Transforms orderHistorys BO to orderHistorys Model.
        /// </summary>
        /// <param name="orderHistorys">OrderHistory BO.</param>
        /// <returns>Category Model.</returns>
        public static OrderHistoryModel ToModel(this OrderHistory orderHistorys)
        {
            if (orderHistorys == null) return null;

            return new OrderHistoryModel
            {
                OrderHisId = orderHistorys.OrderHisId,
                OrderId = orderHistorys.OrderId,
                RealExport = orderHistorys.RealExport,
                SignDate = orderHistorys.SignDate,
                Remark = orderHistorys.Remark,
                IdDecrypt = orderHistorys.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of orderHistorys BOs list of orderHistorys Models.
        /// </summary>
        /// <param name="orderHistorys">List of orderHistorys BOs.</param>
        /// <returns>List of orderHistorys Models.</returns>
        public static IList<OrderHistoryModel> ToModels(this IEnumerable<OrderHistory> orderHistorys)
        {
            return orderHistorys?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers OrderHistory Model to OrderHistory BO.
        /// </summary>
        /// <param name="orderHistorys">OrderHistory Model.</param>
        /// <returns>OrderHistory BO.</returns>
        public static OrderHistory FromModel(this OrderHistoryModel orderHistorys)
        {
            if (orderHistorys == null) return null;

            return new OrderHistory
            {
                OrderHisId = orderHistorys.OrderHisId,
                OrderId = orderHistorys.OrderId,
                RealExport = orderHistorys.RealExport,
                SignDate = orderHistorys.SignDate,
                Remark = orderHistorys.Remark,
                IdDecrypt = orderHistorys.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of orderHistorys BOs list of orderHistorys Models.
        /// </summary>
        /// <param name="orderHistorys">List of orderHistorys BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<OrderHistory> FromModels(this IEnumerable<OrderHistoryModel> orderHistorys)
        {
            return orderHistorys?.Select(FromModel).ToList();
        }
        
        /// <summary>
        /// Transforms summarys BO to summarys Model.
        /// </summary>
        /// <param name="summarys">Summary BO.</param>
        /// <returns>Category Model.</returns>
        public static SummaryModel ToModel(this Summary summarys)
        {
            if (summarys == null) return null;

            return new SummaryModel
            {
                SummaryId = summarys.SummaryId,
                EquipmentId = summarys.EquipmentId,
                EquipmentName = summarys.EquipmentName,
                Specification = summarys.Specification,
                EquipmentType = summarys.EquipmentType,
                Quantity = summarys.Quantity,
                Lend = summarys.Lend,
                Export = summarys.Export,
                Remain = summarys.Remain,
                Workdate = summarys.Workdate,
                IdDecrypt = summarys.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of summarys BOs list of summarys Models.
        /// </summary>
        /// <param name="summarys">List of summarys BOs.</param>
        /// <returns>List of summarys Models.</returns>
        public static IList<SummaryModel> ToModels(this IEnumerable<Summary> summarys)
        {
            return summarys?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Summary Model to Summary BO.
        /// </summary>
        /// <param name="summarys">Summary Model.</param>
        /// <returns>Summary BO.</returns>
        public static Summary FromModel(this SummaryModel summarys)
        {
            if (summarys == null) return null;

            return new Summary
            {
                SummaryId = summarys.SummaryId,
                EquipmentId = summarys.EquipmentId,
                EquipmentName = summarys.EquipmentName,
                Specification = summarys.Specification,
                EquipmentType = summarys.EquipmentType,
                Quantity = summarys.Quantity,
                Lend = summarys.Lend,
                Export = summarys.Export,
                Remain = summarys.Remain,
                Workdate = summarys.Workdate,
                IdDecrypt = summarys.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of summarys BOs list of summarys Models.
        /// </summary>
        /// <param name="summarys">List of summarys BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<Summary> FromModels(this IEnumerable<SummaryModel> summarys)
        {
            return summarys?.Select(FromModel).ToList();
        }

        /// <summary>
        /// Transforms unittypes BO to unittypes Model.
        /// </summary>
        /// <param name="unittypes">Unittype BO.</param>
        /// <returns>Category Model.</returns>
        public static UnittypeModel ToModel(this Unittype unittypes)
        {
            if (unittypes == null) return null;

            return new UnittypeModel
            {
                UnitType = unittypes.UnitType,
                Remark = unittypes.Remark,
                IdDecrypt = unittypes.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of unittypes BOs list of unittypes Models.
        /// </summary>
        /// <param name="unittypes">List of unittypes BOs.</param>
        /// <returns>List of unittypes Models.</returns>
        public static IList<UnittypeModel> ToModels(this IEnumerable<Unittype> unittypes)
        {
            return unittypes?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Unittype Model to Unittype BO.
        /// </summary>
        /// <param name="unittypes">Unittype Model.</param>
        /// <returns>Unittype BO.</returns>
        public static Unittype FromModel(this UnittypeModel unittypes)
        {
            if (unittypes == null) return null;

            return new Unittype
            {
                UnitType = unittypes.UnitType,
                Remark = unittypes.Remark,
                IdDecrypt = unittypes.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of unittypes BOs list of unittypes Models.
        /// </summary>
        /// <param name="unittypes">List of unittypes BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<Unittype> FromModels(this IEnumerable<UnittypeModel> unittypes)
        {
            return unittypes?.Select(FromModel).ToList();
        }
        
        /// <summary>
        /// Transforms venders BO to venders Model.
        /// </summary>
        /// <param name="venders">Vender BO.</param>
        /// <returns>Category Model.</returns>
        public static VenderModel ToModel(this Vender venders)
        {
            if (venders == null) return null;

            return new VenderModel
            {
                VenderName = venders.VenderName,
                Remark = venders.Remark,
                IdDecrypt = venders.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of venders BOs list of venders Models.
        /// </summary>
        /// <param name="venders">List of venders BOs.</param>
        /// <returns>List of venders Models.</returns>
        public static IList<VenderModel> ToModels(this IEnumerable<Vender> venders)
        {
            return venders?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Vender Model to Vender BO.
        /// </summary>
        /// <param name="venders">Vender Model.</param>
        /// <returns>Vender BO.</returns>
        public static Vender FromModel(this VenderModel venders)
        {
            if (venders == null) return null;

            return new Vender
            {
                VenderName = venders.VenderName,
                Remark = venders.Remark,
                IdDecrypt = venders.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of venders BOs list of venders Models.
        /// </summary>
        /// <param name="venders">List of venders BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<Vender> FromModels(this IEnumerable<VenderModel> venders)
        {
            return venders?.Select(FromModel).ToList();
        }


        /// <summary>
        /// Transforms pendingprlist BO to pendingprlist Model.
        /// </summary>
        /// <param name="pendingprlist">Pendingprlist BO.</param>
        /// <returns>Category Model.</returns>
        public static PendingprlistModel ToModel(this Pendingprlist pendingprlist)
        {
            if (pendingprlist == null) return null;

            return new PendingprlistModel
            {
                PendingPRID = pendingprlist.PendingPRID,
                OrdinalNumber = pendingprlist.OrdinalNumber,
                PrId = pendingprlist.PrId,
                PRCreater = pendingprlist.PRCreater,
                CreatedDate = pendingprlist.CreatedDate,
                ProcessStatus = pendingprlist.ProcessStatus,
                Processer = pendingprlist.Processer,
                LastTransaction = pendingprlist.LastTransaction,
                Amount = pendingprlist.Amount,
                WorkingDate = pendingprlist.WorkingDate,
                IdDecrypt = pendingprlist.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of pendingprlist BOs list of pendingprlist Models.
        /// </summary>
        /// <param name="pendingprlists">List of pendingprlist BOs.</param>
        /// <returns>List of pendingprlists Models.</returns>
        public static IList<PendingprlistModel> ToModels(this IEnumerable<Pendingprlist> pendingprlists)
        {
            return pendingprlists?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Pendingprlist Model to Pendingprlist BO.
        /// </summary>
        /// <param name="pendingprlist">Pendingprlist Model.</param>
        /// <returns>Pendingprlist BO.</returns>
        public static Pendingprlist FromModel(this PendingprlistModel pendingprlist)
        {
            if (pendingprlist == null) return null;

            return new Pendingprlist
            {
                PendingPRID = pendingprlist.PendingPRID,
                OrdinalNumber = pendingprlist.OrdinalNumber,
                PrId = pendingprlist.PrId,
                PRCreater = pendingprlist.PRCreater,
                CreatedDate = pendingprlist.CreatedDate,
                ProcessStatus = pendingprlist.ProcessStatus,
                Processer = pendingprlist.Processer,
                LastTransaction = pendingprlist.LastTransaction,
                Amount = pendingprlist.Amount,
                WorkingDate = pendingprlist.WorkingDate,
                IdDecrypt = pendingprlist.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of pendingprlist BOs list of pendingprlist Models.
        /// </summary>
        /// <param name="pendingprlists">List of pendingprlists BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<Pendingprlist> FromModels(this IEnumerable<PendingprlistModel> pendingprlists)
        {
            return pendingprlists?.Select(FromModel).ToList();
        }

        /// <summary>
        /// Transforms processingprlist BO to processingprlist Model.
        /// </summary>
        /// <param name="processingprlist">Processingprlist BO.</param>
        /// <returns>Category Model.</returns>
        public static ProcessingprlistModel ToModel(this Processingprlist processingprlist)
        {
            if (processingprlist == null) return null;

            return new ProcessingprlistModel
            {
                ProcessingPRID = processingprlist.ProcessingPRID,
                OrdinalNumber = processingprlist.OrdinalNumber,
                PrId = processingprlist.PrId,
                PRCreater = processingprlist.PRCreater,
                CreatedDate = processingprlist.CreatedDate,
                ProcessStatus = processingprlist.ProcessStatus,
                Processer = processingprlist.Processer,
                LastTransaction = processingprlist.LastTransaction,
                Amount = processingprlist.Amount,
                WorkingDate = processingprlist.WorkingDate,
                IdDecrypt = processingprlist.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of processingprlist BOs list of processingprlist Models.
        /// </summary>
        /// <param name="processingprlists">List of processingprlist BOs.</param>
        /// <returns>List of processingprlists Models.</returns>
        public static IList<ProcessingprlistModel> ToModels(this IEnumerable<Processingprlist> processingprlists)
        {
            return processingprlists?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Processingprlist Model to Processingprlist BO.
        /// </summary>
        /// <param name="processingprlist">Processingprlist Model.</param>
        /// <returns>Processingprlist BO.</returns>
        public static Processingprlist FromModel(this ProcessingprlistModel processingprlist)
        {
            if (processingprlist == null) return null;

            return new Processingprlist
            {
                ProcessingPRID = processingprlist.ProcessingPRID,
                OrdinalNumber = processingprlist.OrdinalNumber,
                PrId = processingprlist.PrId,
                PRCreater = processingprlist.PRCreater,
                CreatedDate = processingprlist.CreatedDate,
                ProcessStatus = processingprlist.ProcessStatus,
                Processer = processingprlist.Processer,
                LastTransaction = processingprlist.LastTransaction,
                Amount = processingprlist.Amount,
                WorkingDate = processingprlist.WorkingDate,
                IdDecrypt = processingprlist.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of processingprlist BOs list of processingprlist Models.
        /// </summary>
        /// <param name="processingprlists">List of processingprlists BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<Processingprlist> FromModels(this IEnumerable<ProcessingprlistModel> processingprlists)
        {
            return processingprlists?.Select(FromModel).ToList();
        }

        public static FinishprlistModel ToModel(this Finishprlist finishprlist)
        {
            if (finishprlist == null) return null;

            return new FinishprlistModel
            {
                FinishPRID = finishprlist.FinishPRID,
                OrdinalNumber = finishprlist.OrdinalNumber,
                PrId = finishprlist.PrId,
                PrCreater = finishprlist.PrCreater,
                CreatedDate = finishprlist.CreatedDate,
                ProcessStatus = finishprlist.ProcessStatus,
                Processer = finishprlist.Processer,
                LastTransaction = finishprlist.LastTransaction,
                Amount = finishprlist.Amount,
                WorkingDate = finishprlist.WorkingDate,
                IdDecrypt = finishprlist.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of finishprlist BOs list of finishprlist Models.
        /// </summary>
        /// <param name="finishprlists">List of finishprlist BOs.</param>
        /// <returns>List of finishprlists Models.</returns>
        public static IList<FinishprlistModel> ToModels(this IEnumerable<Finishprlist> finishprlists)
        {
            return finishprlists?.Select(ToModel).ToList();
        }
        public static FinishprlistModel PRIDToModel(this Finishprlist finishprlist)
        {
            if (finishprlist == null) return null;

            return new FinishprlistModel
            {
                PrId = finishprlist.PrId
            };
        }

        /// <summary>
        /// Transforms list of finishprlist BOs list of finishprlist Models.
        /// </summary>
        /// <param name="finishprlists">List of finishprlist BOs.</param>
        /// <returns>List of finishprlists Models.</returns>
        public static IList<FinishprlistModel> PRIDToModel(this IEnumerable<Finishprlist> finishprlists)
        {
            return finishprlists?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Finishprlist Model to Finishprlist BO.
        /// </summary>
        /// <param name="finishprlist">Finishprlist Model.</param>
        /// <returns>Finishprlist BO.</returns>
        public static Finishprlist FromModel(this FinishprlistModel finishprlist)
        {
            if (finishprlist == null) return null;

            return new Finishprlist
            {
                FinishPRID = finishprlist.FinishPRID,
                OrdinalNumber = finishprlist.OrdinalNumber,
                PrId = finishprlist.PrId,
                PrCreater = finishprlist.PrCreater,
                CreatedDate = finishprlist.CreatedDate,
                ProcessStatus = finishprlist.ProcessStatus,
                Processer = finishprlist.Processer,
                LastTransaction = finishprlist.LastTransaction,
                Amount = finishprlist.Amount,
                WorkingDate = finishprlist.WorkingDate,
                IdDecrypt = finishprlist.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of finishprlist BOs list of finishprlist Models.
        /// </summary>
        /// <param name="finishprlists">List of finishprlists BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<Finishprlist> FromModels(this IEnumerable<FinishprlistModel> finishprlists)
        {
            return finishprlists?.Select(FromModel).ToList();
        }

        public static PoProgressModel ToModel(this PoProgress poProgress)
        {
            if (poProgress == null) return null;

            return new PoProgressModel
            {
                PoProgressId = poProgress.PoProgressId,
                PoCode = poProgress.PoCode,
                PrCode = poProgress.PrCode,
                Modelname = poProgress.Modelname,
                PoContent = poProgress.PoContent,
                ExpectDate = poProgress.ExpectDate,
                ActualDate = poProgress.ActualDate,
                Remark = poProgress.Remark,
                WorkingDate = poProgress.WorkingDate,
                IdDecrypt = poProgress.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of poProgress BOs list of poProgress Models.
        /// </summary>
        /// <param name="poProgresses">List of poProgress BOs.</param>
        /// <returns>List of poProgresses Models.</returns>
        public static IList<PoProgressModel> ToModels(this IEnumerable<PoProgress> poProgresses)
        {
            return poProgresses?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers PoProgress Model to PoProgress BO.
        /// </summary>
        /// <param name="poProgress">PoProgress Model.</param>
        /// <returns>PoProgress BO.</returns>
        public static PoProgress FromModel(this PoProgressModel poProgress)
        {
            if (poProgress == null) return null;

            return new PoProgress
            {
                PoProgressId = poProgress.PoProgressId,
                PoCode = poProgress.PoCode,
                PrCode = poProgress.PrCode,
                Modelname = poProgress.Modelname,
                PoContent = poProgress.PoContent,
                ExpectDate = poProgress.ExpectDate,
                ActualDate = poProgress.ActualDate,
                Remark = poProgress.Remark,
                WorkingDate = poProgress.WorkingDate,
                IdDecrypt = poProgress.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of poProgress BOs list of poProgress Models.
        /// </summary>
        /// <param name="poProgresses">List of poProgresses BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<PoProgress> FromModels(this IEnumerable<PoProgressModel> poProgresses)
        {
            return poProgresses?.Select(FromModel).ToList();
        }


        /// <summary>
        /// Transforms prtopos BO to prtopos Model.
        /// </summary>
        /// <param name="prtopos">Prtopo BO.</param>
        /// <returns>Category Model.</returns>
        public static PrtopoModel ToModel(this Prtopo prtopos)
        {
            if (prtopos == null) return null;

            return new PrtopoModel
            {
                Prtopoid = prtopos.Prtopoid,
                Partnumber = prtopos.Partnumber,
                Prno = prtopos.Prno,
                Pono = prtopos.Pono,
                Productname = prtopos.Productname,
                Brand = prtopos.Brand,
                Spec = prtopos.Spec,
                Unit = prtopos.Unit,
                Workingdate = prtopos.Workingdate,
                IdDecrypt = prtopos.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of prtopos BOs list of prtopos Models.
        /// </summary>
        /// <param name="prtopos">List of prtopos BOs.</param>
        /// <returns>List of prtopos Models.</returns>
        public static IList<PrtopoModel> ToModels(this IEnumerable<Prtopo> prtopos)
        {
            return prtopos?.Select(ToModel).ToList();
        }

        /// <summary>
        /// Transfers Prtopo Model to Prtopo BO.
        /// </summary>
        /// <param name="prtopos">Prtopo Model.</param>
        /// <returns>Prtopo BO.</returns>
        public static Prtopo FromModel(this PrtopoModel prtopos)
        {
            if (prtopos == null) return null;

            return new Prtopo
            {
                Prtopoid = prtopos.Prtopoid,
                Partnumber = prtopos.Partnumber,
                Prno = prtopos.Prno,
                Pono = prtopos.Pono,
                Productname = prtopos.Productname,
                Brand = prtopos.Brand,
                Spec = prtopos.Spec,
                Unit = prtopos.Unit,
                Workingdate = prtopos.Workingdate,
                IdDecrypt = prtopos.IdDecrypt
            };
        }

        /// <summary>
        /// Transforms list of prtopos BOs list of prtopos Models.
        /// </summary>
        /// <param name="prtopos">List of prtopos BOs.</param>
        /// <returns>List of category Models.</returns>
        public static IList<Prtopo> FromModels(this IEnumerable<PrtopoModel> prtopos)
        {
            return prtopos?.Select(FromModel).ToList();
        }
    }
}
