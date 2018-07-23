namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPositionsAndSupporterGroupsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupporterGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Team_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.Team_ID)
                .Index(t => t.Team_ID);
            
            AddColumn("dbo.Footballers", "Position_ID", c => c.Int());
            CreateIndex("dbo.Footballers", "Position_ID");
            AddForeignKey("dbo.Footballers", "Position_ID", "dbo.Positions", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupporterGroups", "Team_ID", "dbo.Teams");
            DropForeignKey("dbo.Footballers", "Position_ID", "dbo.Positions");
            DropIndex("dbo.SupporterGroups", new[] { "Team_ID" });
            DropIndex("dbo.Footballers", new[] { "Position_ID" });
            DropColumn("dbo.Footballers", "Position_ID");
            DropTable("dbo.SupporterGroups");
            DropTable("dbo.Positions");
        }
    }
}
