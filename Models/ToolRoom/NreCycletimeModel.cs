/***********************************************************************
 * <copyright file="NreCycletime.cs" company="Foxconn">
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

    public class NreCycletimeModel : BaseModel
    {        
		public string Ctid { get; set; }
        
		[MaxLength(50)]
		public string ModelName { get; set; }

        [MaxLength(50)]
        public string WorkStation { get; set; }

        [MaxLength(50)]
		public string StationName { get; set; }

        public int? Capacity { get; set; }

        public int? TestTime { get; set; }
        
		public int? HandlingTime { get; set; }
        
		public int? CycleTime { get; set; }
        
		public int? PiecePerPanel { get; set; }
        
		public double? OutputPerHour { get; set; }
        
		public double? WorkingPerShift { get; set; }
        
		public int? ShiftPerDay { get; set; }
        
		public double? YieldRate { get; set; }
        
		public double? DailyOutputOne { get; set; }
        
		public int? NumberTester { get; set; }
        
		public int? DailyOutput { get; set; }
        
		[MaxLength(200)]
		public string Remark { get; set; }

        [MaxLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public string CreateByName { get; set; }

    }
}
