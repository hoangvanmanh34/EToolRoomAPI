/***********************************************************************
 * <copyright file="OrderDetail.cs" company="Foxconn">
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

    public class OrderDetailModel : BaseModel
    {        
		public string OrderId { get; set; }
        
		[Required]
		[MaxLength(50)]
		public string AppId { get; set; }
        
		//[Required]
		[MaxLength(50)]
		public string EquipmentId { get; set; }
        
		[Required]
		public int Quantity { get; set; }
        
		[MaxLength(50)]
		public string StationName { get; set; }
        
		[MaxLength(50)]
		public string ModelName { get; set; }
        
		[MaxLength(50)]
		public string LineName { get; set; }
        
		[MaxLength(5)]
		public string FactoryName { get; set; }
        
		[MaxLength(10)]
		public string AppType { get; set; }
        
		public int? RealExport { get; set; }
        
		public DateTime? FromDate { get; set; }
        
		public DateTime? DueDate { get; set; }
        
		[MaxLength(10)]
		public string ApproveReject { get; set; }
        
		[MaxLength(30)]
		public string Statuss { get; set; }
        
		public DateTime? SignDate { get; set; }
        
		[MaxLength(100)]
		public string Remark { get; set; }
        
		[MaxLength(50)]
		public string EquipmentName { get; set; }
        
		[MaxLength(15)]
		public string EquipmentType { get; set; }

        [MaxLength(50)]
        public string CreateBy { get; set; }

        [MaxLength(50)]
        public string SignBy { get; set; }

        [MaxLength(15)]
        public string ExportBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ExportDate { get; set; }

        public int? LastExport { get; set; }
        //[Required]
        [MaxLength(300)]
        public string Specification { get; set; }

        public int? RemainWarehouse { get; set; }

        [MaxLength(3)]
        public string Endoforder { get; set; }

    }
}
