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
    
    
    public class roommanMap : BaseEntityTypeConfiguration<HoteManagement.Domain.roomman>
    {
       public roommanMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.bookid);
          this.Property(t => t.roomnum).HasMaxLength(50);
          this.Property(t => t.roomprice);
          this.Property(t => t.usertype).HasMaxLength(50);
          this.Property(t => t.checkintype).HasMaxLength(50);
          this.Property(t => t.breakfirstnum);
          this.Property(t => t.personnum);
          this.Property(t => t.remark).HasMaxLength(250);
          this.Property(t => t.mobile).HasMaxLength(50);
          this.Property(t => t.cardnum);
          this.Property(t => t.memberid);
          this.Property(t => t.creator).HasMaxLength(50);
          this.Property(t => t.createtime);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
