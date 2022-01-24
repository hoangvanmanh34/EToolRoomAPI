using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EToolRoomAPI.Models;

namespace EToolRoomAPI.Models.V1.ToolRoom
{
    public class COrder_HistorysModel: BaseModel
    {
        public int ORDER_HIS_ID { get; set; }

        public int ORDER_ID { get; set; }

        public int REAL_EXPORT { get; set; }

        public DateTime SIGN_DATE { get; set; }

        public string REMARK { get; set; }
    }
}