//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HoteManagement.Console.Model
{
    
    public partial class memberDto : BaseDtoEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public string Mid { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Sex { get; set; }
        public Nullable<int> Zjtype { get; set; }
        public string ZjNumber { get; set; }
        public Nullable<int> Mtype { get; set; }
        public Nullable<int> sales { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> Baithday { get; set; }
        public string Pwd { get; set; }
        public string Likes { get; set; }
        public string Address { get; set; }
        public string Ramrek { get; set; }
        public Nullable<int> Integration { get; set; }
        public Nullable<int> IntegraDh { get; set; }
        public Nullable<int> IntegraDj { get; set; }
        public Nullable<int> Stored { get; set; }
        public Nullable<int> Statid { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string addUser { get; set; }
        public Nullable<System.DateTime> XqTime { get; set; }
    		public virtual HotelDto UserHotel { get; set; }
    		}
}
