using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EToolRoomAPI.Models;

namespace EToolRoomAPI.Models.V1.ToolRoom
{
    public class CEquipmentModel: BaseModel
    {
        public string EQUIPMENT_ID { get; set; }

        public string EQUIPMENT_NAME { get; set; }

        public string EQUIPMENT_TYPE { get; set; }

        public int QUANTITY { get; set; }

        public double PRICE { get; set; }

        public DateTime? IMPORT_DATE { get; set; }

        public string SPECIFICATIONS { get; set; }

        public string UNIT_TYPE { get; set; }

        public string VENDER_NAME { get; set; }

        public string STORAGESPACE { get; set; }

        public string REMARK { get; set; }

        public string PURCHASE_ID { get; set; }

        public string ModelName { get; set; }

        public string StationName { get; set; }

        public string LineName { get; set; }

        public string FactoryName { get; set; }

        public string FOURID { get; set; }
    }
}