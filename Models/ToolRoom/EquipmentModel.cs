/***********************************************************************
 * <copyright file="Equipment.cs" company="Foxconn">
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

    public class EquipmentModel : BaseModel
    {
        public int Eid { get; set; }
        [Required]
        public string EquipmentId { get; set; }
        public string EquipmentSn { get; set; }

        [Required]
		[MaxLength(50)]
		public string EquipmentName { get; set; }
        
		[Required]
		[MaxLength(15)]
		public string EquipmentType { get; set; }
        
		[Required]
		public int Quantity { get; set; }
        
		[Required]
		public double Price { get; set; }
        
		//[Required]
		public DateTime? ImportDate { get; set; }
        
		//[Required]
		[MaxLength(300)]
		public string Specification { get; set; }
        
		//[MaxLength(100)]
		public string Storagespace { get; set; }
        
		[MaxLength(100)]
		public string Remark { get; set; }
        
		
		//[MaxLength(100)]
		public string PurchaseId { get; set; }

        [Required]
        [MaxLength(100)]
		public string UnitType { get; set; }

        [Required]
        [MaxLength(50)]
		public string VenderName { get; set; }

        public int Lend { get; set; }

        public int Export { get; set; }

        public int Remain { get; set; }

        public string ModelName { get; set; }

        public string StationName { get; set; }

        public string LineName { get; set; }

        public string FactoryName { get; set; }

        public string FourId { get; set; }

        public string EquipmentIdnew { get; set; }
        public string Currency { get; set; }

    }
}
