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
    
    
    public class FtSetMap : BaseEntityTypeConfiguration<HoteManagement.Domain.FtSet>
    {
       public FtSetMap()
       {
          this.HasKey(t => t.Id);
          this.Property(t => t.hotelid);
          this.Property(t => t.Lwidth);
          this.Property(t => t.Lhieght);
          this.Property(t => t.Lfontf).HasMaxLength(50);
          this.Property(t => t.Fontsize);
          this.Property(t => t.Lmargin);
          this.Property(t => t.Backcolor).HasMaxLength(50);
          this.Property(t => t.Bordercolor).HasMaxLength(50);
          this.Property(t => t.showType);
          this.Property(t => t.showPrice);
          this.Property(t => t.orderLC);
          this.Property(t => t.ftNum);
          this.Property(t => t.zzShowType);
          this.Property(t => t.zzShowPrice);
          this.Property(t => t.showFormTime);
          this.Property(t => t.showLFico);
          this.Property(t => t.showBmico);
          this.Property(t => t.showyjb);
          this.Property(t => t.showday);
          this.Property(t => t.daynum);
          this.Property(t => t.showyue);
          this.Property(t => t.moneyNum);
          this.Property(t => t.showcf);
          this.Property(t => t.showThem);
          this.Property(t => t.Themtext).HasMaxLength(10);
          this.Property(t => t.showMember);
          this.Property(t => t.memberText).HasMaxLength(10);
          this.Property(t => t.showXy);
          this.Property(t => t.showYuli);
          this.Property(t => t.yuliDay);
          this.Property(t => t.showDayTime);
          this.Property(t => t.dayNumYl);
          this.Property(t => t.showxz);
          this.Property(t => t.showSf);
          this.Property(t => t.showYuee);
          this.Property(t => t.Showzdftime);
          this.Property(t => t.Showbooktime);
          this.Property(t => t.Showzf);
          this.Property(t => t.Showlc);
          this.Property(t => t.showPeoNum);
          this.Property(t => t.showRk);
          this.Property(t => t.showWupi);
          this.Property(t => t.Showyz);
          this.Property(t => t.Showmf);
          this.Property(t => t.Showzdf);
          this.Property(t => t.Beiy);
          this.Property(t => t.Beiy2);
          this.Property(t => t.numSize);
          this.Property(t => t.numColor).HasMaxLength(10);
          this.Property(t => t.fxSize);
          this.Property(t => t.fxColor).HasMaxLength(10);
          this.Property(t => t.yueSize);
          this.Property(t => t.yueColor).HasMaxLength(10);
          this.Property(t => t.nameSize);
          this.Property(t => t.nameColor).HasMaxLength(10);
          this.Property(t => t.priceSize);
          this.Property(t => t.priceColor).HasMaxLength(10);
          this.Property(t => t.TotimeSize);
          this.Property(t => t.TotimeColor).HasMaxLength(10);
          this.Property(t => t.zdSize);
          this.Property(t => t.zdColor).HasMaxLength(10);
          this.Property(t => t.icoColor);
          this.HasRequired(t => t.UserHotel).WithMany().HasForeignKey(t => t.hotelid);
       }
    }
}
