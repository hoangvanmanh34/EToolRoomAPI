using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EToolRoomAPI.Models;

namespace EToolRoomAPI.Models.V1.ToolRoom
{
    public class COrder_DetailsModel: BaseModel
    {
        public int ORDER_ID { get; set; }

        public string APP_ID { get; set; }

        public string EQUIPMENT_ID { get; set; }

        public int QUANTITY { get; set; }

        public string STATION_NAME { get; set; }

        public string MODEL_NAME { get; set; }

        public string LINE_NAME { get; set; }

        public string FACTORY_NAME { get; set; }

        public string APP_TYPE { get; set; }

        public int REAL_EXPORT { get; set; }

        public DateTime? FROM_DATE { get; set; }

        public DateTime? DUE_DATE { get; set; }

        public string APPROVE_REJECT { get; set; }

        public string STATUSS { get; set; }

        public DateTime? SIGN_DATE { get; set; }

        public string REMARK { get; set; }

        public string EQUIPMENT_NAME { get; set; }

        public string EQUIPMENT_TYPE { get; set; }

        public string CREATE_BY { get; set; }

        public string SIGN_BY { get; set; }

        public string EXPORT_BY { get; set; }
    }
}