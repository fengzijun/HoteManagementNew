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

namespace HoteManagement.Data.Mapping
{
    
    
    public class SysParamterMap : BaseEntityTypeConfiguration<HoteManagement.Domain.SysParamter>
    {
       public SysParamterMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.CancellMin);
          this.Property(t => t.IsDeposit);
          this.Property(t => t.Deposit);
          this.Property(t => t.IsEarlyRoom);
          this.Property(t => t.EarlyStart);
          this.Property(t => t.EarlyEnd);
          this.Property(t => t.EarlyOutTime);
          this.Property(t => t.EarlyFee);
          this.Property(t => t.EarlyFeeSel);
          this.Property(t => t.EarlyOutTimes);
          this.Property(t => t.EarlyFeeTwo);
          this.Property(t => t.DayOutTime);
          this.Property(t => t.DayFee);
          this.Property(t => t.DayFeeTwo);
          this.Property(t => t.DayTime);
          this.Property(t => t.istype);
          this.Property(t => t.ysTime);
          this.Property(t => t.isOcczf);
          this.Property(t => t.isCy);
          this.Property(t => t.MarkSuo).HasMaxLength(50);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
