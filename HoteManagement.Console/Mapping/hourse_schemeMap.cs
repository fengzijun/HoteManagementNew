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
    
    
    public class hourse_schemeMap : BaseEntityTypeConfiguration<HoteManagement.Domain.hourse_scheme>
    {
       public hourse_schemeMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.hs_room);
          this.Property(t => t.hs_name).HasMaxLength(50);
          this.Property(t => t.hs_psmoney);
          this.Property(t => t.hs_Discount).HasMaxLength(10);
          this.Property(t => t.hs_type);
          this.Property(t => t.hs_jgtype);
          this.Property(t => t.hs_source_id);
          this.Property(t => t.Hs_isAll);
          this.Property(t => t.Hs_Strat);
          this.Property(t => t.Hs_End);
          this.Property(t => t.Hs_zdr);
          this.Property(t => t.Hs_Reamrk).HasMaxLength(500);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
