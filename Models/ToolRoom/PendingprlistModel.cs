/***********************************************************************
 * <copyright file="Pendingprlist.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    bi-shan.huang@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 8/5/2020 11:39:07 AM
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

    public class PendingprlistModel : BaseModel
    {        
		public string PendingPRID { get; set; }
        
		[Required]
		public int OrdinalNumber { get; set; }
        
		[Required]
		[MaxLength(20)]
		public string PrId { get; set; }
        
		[Required]
		[MaxLength(30)]
		public string PRCreater { get; set; }
        
		[Required]
		[MaxLength(50)]
		public string CreatedDate { get; set; }
        
		[Required]
		[MaxLength(30)]
		public string ProcessStatus { get; set; }
        
		[Required]
		[MaxLength(30)]
		public string Processer { get; set; }
        
		[Required]
		[MaxLength(50)]
		public string LastTransaction { get; set; }
        
		[Required]
		[MaxLength(50)]
		public string Amount { get; set; }
        
		[Required]
		public DateTime? WorkingDate { get; set; }
        
    }
}
