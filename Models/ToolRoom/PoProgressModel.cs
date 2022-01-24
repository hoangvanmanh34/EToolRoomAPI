/***********************************************************************
 * <copyright file="PoProgress.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    bi-shan.huang@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 7/17/2020 4:29:58 PM
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

    public class PoProgressModel : BaseModel
    {
        public string PoProgressId { get; set; }

        public string PoCode { get; set; }
        
		[Required]
		[MaxLength(50)]
		public string PrCode { get; set; }
        
		[MaxLength(50)]
		public string Modelname { get; set; }
        
		[MaxLength(200)]
		public string PoContent { get; set; }
        
		public DateTime? ExpectDate { get; set; }
        
		public DateTime? ActualDate { get; set; }
        
		[MaxLength(200)]
		public string Remark { get; set; }

        public string Status { get; set; }

        public DateTime? WorkingDate { get; set; }
    }
}
