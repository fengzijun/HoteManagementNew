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
    
    
    public class Accounts_UsersMap : BaseEntityTypeConfiguration<HoteManagement.Domain.Accounts_Users>
    {
       public Accounts_UsersMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.UserID).HasMaxLength(50);
          this.Property(t => t.UserName).HasMaxLength(50);
          this.Property(t => t.Password).HasMaxLength(50);
          this.Property(t => t.TrueName).HasMaxLength(50);
          this.Property(t => t.Sex).HasMaxLength(2);
          this.Property(t => t.Phone).HasMaxLength(20);
          this.Property(t => t.Email).HasMaxLength(100);
          this.Property(t => t.EmployeeID);
          this.Property(t => t.DepartmentID).HasMaxLength(15);
          this.Property(t => t.Activity);
          this.Property(t => t.UserType).HasMaxLength(2);
          this.Property(t => t.Style);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
