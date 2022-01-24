/***********************************************************************
 * <copyright file="OrderApp.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    bi-shan.huang@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 6/20/2020 11:05:56 AM
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

    public class OrderAppModel : BaseModel
    {        
		public string AppId { get; set; }
        
		[MaxLength(50)]
		public string ApproveReject { get; set; }
        
		[MaxLength(50)]
		public string Statuss { get; set; }
        
		public DateTime? SignDate { get; set; }
        
		[MaxLength(100)]
		public string Remark { get; set; }

        [MaxLength(50)]
        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

    }
}
