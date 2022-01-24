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

    public class LineEquipmentModel : BaseModel
    {
        public string LineEquipmentId { get; set; }

        public string EquipmentSn { get; set; }

        public string EquipmentId { get; set; }

        public string Station { get; set; }

        public string Machinename { get; set; }

        public string Type { get; set; }

        public string Ip { get; set; }

        public DateTime? Datetime { get; set; }

        public string Version { get; set; }

        public string IdDecrypt { get; set; }

    }
}
