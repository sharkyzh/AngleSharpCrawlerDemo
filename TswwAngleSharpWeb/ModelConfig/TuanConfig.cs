using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TswwAngleSharpWeb.Models;

namespace TswwAngleSharpWeb.ModelConfig
{
    public class TuanConfig : EntityTypeConfiguration<Tuan>
    {
        public TuanConfig()
        {
            this.ToTable("TuanList");
            this.Property(s => s.Name).HasMaxLength(60);
            this.Property(s => s.TuanType).HasMaxLength(120);
            this.Property(s => s.TuanZhang).HasMaxLength(120);
            this.Property(s => s.FanLiType).HasMaxLength(120);
            this.Property(s => s.TuanId).HasMaxLength(120);
            this.Property(s => s.TotalAmount).HasMaxLength(120);
            this.Property(s => s.TotalSaleCount).HasMaxLength(120);
            this.Property(s => s.TuanCreateTime).HasMaxLength(120);
        }
    }
}