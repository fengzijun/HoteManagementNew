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
    
    
    public class ExceedSchemeMap : BaseEntityTypeConfiguration<HoteManagement.Domain.ExceedScheme>
    {
       public ExceedSchemeMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.TypeRoom);
          this.Property(t => t.GraceTime);
          this.Property(t => t.Earlyapart);
          this.Property(t => t.EarlyapartAddP);
          this.Property(t => t.EarlyInsufficient);
          this.Property(t => t.EarlyInExceed);
          this.Property(t => t.EarlyInAddPri);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
