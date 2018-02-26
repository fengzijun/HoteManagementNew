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
    
    
    public class EntryMap : BaseEntityTypeConfiguration<HoteManagement.Domain.Entry>
    {
       public EntryMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.entry_name).HasMaxLength(50);
          this.Property(t => t.entry_num);
          this.Property(t => t.entry_time);
          this.Property(t => t.entry_unit).HasMaxLength(50);
          this.Property(t => t.entry_price);
          this.Property(t => t.entry_room).HasMaxLength(50);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
