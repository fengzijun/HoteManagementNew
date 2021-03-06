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
    
    
    public class GoodsMap : BaseEntityTypeConfiguration<HoteManagement.Domain.Goods>
    {
       public GoodsMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.Goods_number).HasMaxLength(50);
          this.Property(t => t.Goods_name).HasMaxLength(50);
          this.Property(t => t.Goods_price);
          this.Property(t => t.Goods_unit).HasMaxLength(50);
          this.Property(t => t.Goods_state).HasMaxLength(50);
          this.Property(t => t.Goods_spell).HasMaxLength(50);
          this.Property(t => t.Goods_ifType);
          this.Property(t => t.Goods_categories);
          this.Property(t => t.Goods_Remaker);
          this.Property(t => t.Goods_jf);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
