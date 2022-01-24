/***********************************************************************
 * <copyright file="Summary.cs" company="Foxconn">
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

    public class SummaryModel : BaseModel
    {        
		public string SummaryId { get; set; }
        
		[Required]
		[MaxLength(50)]
		public string EquipmentId { get; set; }
        
		[Required]
		[MaxLength(50)]
		public string EquipmentName { get; set; }

        [MaxLength(300)]
        public string Specification { get; set; }

        [Required]
		[MaxLength(15)]
		public string EquipmentType { get; set; }
        
		[Required]
		public int Quantity { get; set; }
        
		[Required]
		public int Lend { get; set; }
        
		[Required]
		public int Export { get; set; }
        
		[Required]
		public int Remain { get; set; }
        
		public DateTime? Workdate { get; set; }
        
    }
}
