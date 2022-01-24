/***********************************************************************
 * <copyright file="Finishprlist.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    bi-shan.huang@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 8/13/2020 11:03:35 AM
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

    public class FinishprlistModel : BaseModel
    {        
		public string FinishPRID { get; set; }
        
		public int? OrdinalNumber { get; set; }
        
		[MaxLength(50)]
		public string PrId { get; set; }

        [MaxLength(50)]
        public string PrCreater { get; set; }

        [MaxLength(50)]
		public string CreatedDate { get; set; }
        
		[MaxLength(50)]
		public string ProcessStatus { get; set; }
        
		[MaxLength(50)]
		public string Processer { get; set; }
        
		[MaxLength(50)]
		public string LastTransaction { get; set; }
        
		[MaxLength(50)]
		public string Amount { get; set; }
        
		public DateTime? WorkingDate { get; set; }
        
    }
}
