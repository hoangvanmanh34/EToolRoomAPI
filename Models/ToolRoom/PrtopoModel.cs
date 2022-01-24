/***********************************************************************
 * <copyright file="Prtopo.cs" company="Foxconn">
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

    public class PrtopoModel : BaseModel
    {        
		public string Prtopoid { get; set; }
        
		[MaxLength(50)]
		public string Partnumber { get; set; }
        
		[MaxLength(50)]
		public string Prno { get; set; }
        
		[MaxLength(50)]
		public string Pono { get; set; }
        
		[MaxLength(50)]
		public string Productname { get; set; }
        
		[MaxLength(50)]
		public string Brand { get; set; }
        
		[MaxLength(50)]
		public string Spec { get; set; }
        
		[MaxLength(50)]
		public string Unit { get; set; }
        
		public DateTime? Workingdate { get; set; }
        
    }
}
