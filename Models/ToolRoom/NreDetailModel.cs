/***********************************************************************
 * <copyright file="NreDetail.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    bi-shan.huang@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 8/20/2020 4:35:31 PM
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace EToolRoomAPI.Models.V1
{

    public class NreDetailModel : BaseModel
    {        
		public string Nreid { get; set; }

        [MaxLength(50)]
        public string ModelName { get; set; }

        [MaxLength(50)]
        public string WorkStation { get; set; }

        [MaxLength(50)]
		public string StationName { get; set; }

        public int? Capacity { get; set; }

        [MaxLength(50)]
		public string EquipmentId { get; set; }
        
		[MaxLength(200)]
		public string EquipmentName { get; set; }

        [MaxLength(300)]
        public string Specifications { get; set; }

        public int? LeaveTime { get; set; }
        
		public int? UnitPrice { get; set; }
        
		public int? Qpt { get; set; }

		public int? NumberTester { get; set; }
        
		public int? Qpl { get; set; }
        
		public int? SumCost { get; set; }
        
		[MaxLength(200)]
		public string Remark { get; set; }

        [MaxLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public string CreateByName { get; set; }

    }
}
