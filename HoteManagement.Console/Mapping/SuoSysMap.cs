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
    
    
    public class SuoSysMap : BaseEntityTypeConfiguration<HoteManagement.Domain.SuoSys>
    {
       public SuoSysMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.SuoTypeName).HasMaxLength(50);
          this.Property(t => t.IsComm);
          this.Property(t => t.IsBackSuo);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}