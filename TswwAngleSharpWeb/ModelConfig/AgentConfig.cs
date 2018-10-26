using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TswwAngleSharpWeb.Models;

namespace TswwAngleSharpWeb.ModelConfig
{
    public class AgentConfig : EntityTypeConfiguration<Agent>
    {
        public AgentConfig()
        {
            this.ToTable("AgentList");
            this.Property(s => s.Name).HasMaxLength(60);
            this.Property(s => s.Mobile).HasMaxLength(30);
            this.Property(s => s.Level).HasMaxLength(60);
            this.Property(s => s.TotalAmount).HasMaxLength(200);
            this.Property(s => s.CurrentMothlAmount).HasMaxLength(200);
            this.Property(s => s.FirstAgentTime).HasMaxLength(120);
            this.Property(s => s.LastUpDateTime).HasMaxLength(120);
            this.Property(s => s.TuanIds).HasMaxLength(120);
            this.Property(s => s.BelongTuan).HasMaxLength(200);
        }
    }
}