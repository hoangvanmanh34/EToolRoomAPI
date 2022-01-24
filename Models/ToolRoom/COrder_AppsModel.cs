using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EToolRoomAPI.Models;

namespace EToolRoomAPI.Models.V1.ToolRoom
{
    public class COrder_AppsModel: BaseModel
    {
        public string APP_ID { get; set; }

        public string APPROVE_REJECT { get; set; }

        public string STATUS { get; set; }

        public int SIGN_DATE { get; set; }

        public string REMARK { get; set; }
    }
}