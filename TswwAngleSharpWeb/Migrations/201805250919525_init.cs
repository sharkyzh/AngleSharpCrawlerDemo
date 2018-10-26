namespace TswwAngleSharpWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgentList",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.String(),
                        HeadImg = c.String(),
                        Name = c.String(maxLength: 60),
                        Mobile = c.String(maxLength: 30),
                        Level = c.String(maxLength: 60),
                        TotalAmount = c.String(maxLength: 200),
                        CurrentMothlAmount = c.String(maxLength: 200),
                        FirstAgentTime = c.String(maxLength: 120),
                        LastUpDateTime = c.String(maxLength: 120),
                        BelongTuan = c.String(maxLength: 200),
                        TuanIds = c.String(maxLength: 120),
                        ShopId = c.String(),
                        IsUpdated = c.Boolean(nullable: false),
                        UpdatedTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TuanList",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TuanId = c.String(maxLength: 120),
                        HeadImg = c.String(),
                        Name = c.String(maxLength: 60),
                        TuanRenShu = c.String(),
                        TuanType = c.String(maxLength: 120),
                        TuanZhang = c.String(maxLength: 120),
                        FanLiType = c.String(maxLength: 120),
                        TotalAmount = c.String(maxLength: 120),
                        TotalSaleCount = c.String(maxLength: 120),
                        TuanCreateTime = c.String(maxLength: 120),
                        CreateTime = c.DateTime(nullable: false),
                        IsUpdate = c.Boolean(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TuanList");
            DropTable("dbo.AgentList");
        }
    }
}
