namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFootballersAndManagersTables : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Teams");
            CreateTable(
                "dbo.Footballers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Country_ID = c.Int(),
                        Team_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.Country_ID)
                .ForeignKey("dbo.Teams", t => t.Team_ID)
                .Index(t => t.Country_ID)
                .Index(t => t.Team_ID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.Country_ID)
                .Index(t => t.Country_ID);
            
            CreateTable(
                "dbo.Stadia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .Index(t => t.City_ID);
            
            AddColumn("dbo.Teams", "Stadium_ID", c => c.Int());
            AlterColumn("dbo.Teams", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Teams", "ID");
            CreateIndex("dbo.Teams", "ID");
            CreateIndex("dbo.Teams", "Stadium_ID");
            AddForeignKey("dbo.Teams", "ID", "dbo.Managers", "ID");
            AddForeignKey("dbo.Teams", "Stadium_ID", "dbo.Stadia", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Stadium_ID", "dbo.Stadia");
            DropForeignKey("dbo.Stadia", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Teams", "ID", "dbo.Managers");
            DropForeignKey("dbo.Managers", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.Footballers", "Team_ID", "dbo.Teams");
            DropForeignKey("dbo.Footballers", "Country_ID", "dbo.Countries");
            DropIndex("dbo.Stadia", new[] { "City_ID" });
            DropIndex("dbo.Managers", new[] { "Country_ID" });
            DropIndex("dbo.Teams", new[] { "Stadium_ID" });
            DropIndex("dbo.Teams", new[] { "ID" });
            DropIndex("dbo.Footballers", new[] { "Team_ID" });
            DropIndex("dbo.Footballers", new[] { "Country_ID" });
            DropPrimaryKey("dbo.Teams");
            AlterColumn("dbo.Teams", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Teams", "Stadium_ID");
            DropTable("dbo.Stadia");
            DropTable("dbo.Managers");
            DropTable("dbo.Footballers");
            AddPrimaryKey("dbo.Teams", "ID");
        }
    }
}
