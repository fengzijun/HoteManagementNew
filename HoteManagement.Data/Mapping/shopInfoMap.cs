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
    
    
    public class shopInfoMap : BaseEntityTypeConfiguration<HoteManagement.Domain.shopInfo>
    {
       public shopInfoMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.shop_Name).HasMaxLength(50);
          this.Property(t => t.shop_LxMan).HasMaxLength(50);
          this.Property(t => t.Shop_Telphone).HasMaxLength(50);
          this.Property(t => t.Shop_chuanzen).HasMaxLength(50);
          this.Property(t => t.Shop_Province).HasMaxLength(50);
          this.Property(t => t.Shop_City).HasMaxLength(50);
          this.Property(t => t.Shop_Area).HasMaxLength(50);
          this.Property(t => t.Shop_Address);
          this.Property(t => t.Shop_x).HasMaxLength(50);
          this.Property(t => t.Shop_y).HasMaxLength(50);
          this.Property(t => t.Shop_Remaker);
          this.Property(t => t.Shop_date);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
