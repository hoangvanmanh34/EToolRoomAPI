﻿/***********************************************************************
 * <copyright file="OrderHistory.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    bi-shan.huang@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 6/20/2020 11:05:57 AM
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

    public class OrderHistoryModel : BaseModel
    {        
		public string OrderHisId { get; set; }
        
		[Required]
		public string OrderId { get; set; }
        
		public int? RealExport { get; set; }
        
		[Required]
		public DateTime? SignDate { get; set; }
        
		[MaxLength(100)]
		public string Remark { get; set; }
        
    }
}
