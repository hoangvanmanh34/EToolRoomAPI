/***********************************************************************
 * <copyright file="ReturnWarehouseApp.cs" company="Foxconn">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  Hoang Bich Son 
 * Email:    bi-shan.huang@foxconn.com - bichson2002@gmail.com
 * Phone:    0961.948.868
 * Create Date: 4/1/2021 8:18:59 AM
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

    public class ReturnWarehouseAppModel : BaseModel
    {        
		public string AppId { get; set; }
        
		[MaxLength(50)]
		public string AppNum { get; set; }
        
		[MaxLength(10)]
		public string EquipmentId { get; set; }
        
		[MaxLength(10)]
		public string EquipmentName { get; set; }
        
		public int? Quantity { get; set; }
        
		public DateTime? AppCreateDate { get; set; }
        
		[MaxLength(100)]
		public string AppReason { get; set; }
        
		[MaxLength(50)]
		public string ApproveReject { get; set; }
        
		public DateTime? ApproveRejectDate { get; set; }
        
		[MaxLength(100)]
		public string EmpComment { get; set; }
        
		[MaxLength(50)]
		public string CreateById { get; set; }
        
		[MaxLength(50)]
		public string CreateByName { get; set; }
        
		[MaxLength(50)]
		public string EmpId { get; set; }
        
		[MaxLength(50)]
		public string EmpName { get; set; }
        
		[MaxLength(500)]
		public string Remark { get; set; }
        
    }
}
