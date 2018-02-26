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
    
    
    public class order_inforMap : BaseEntityTypeConfiguration<HoteManagement.Domain.order_infor>
    {
       public order_inforMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.order_no).HasMaxLength(50);
          this.Property(t => t.room_id).HasMaxLength(50);
          this.Property(t => t.occ_id);
          this.Property(t => t.order_money);
          this.Property(t => t.return_money);
          this.Property(t => t.order_state).HasMaxLength(50);
          this.Property(t => t.order_time);
          this.Property(t => t.remark);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}