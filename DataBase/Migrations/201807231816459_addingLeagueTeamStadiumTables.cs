namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingLeagueTeamStadiumTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.Country_ID)
                .Index(t => t.Country_ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City_ID = c.Int(),
                        League_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .ForeignKey("dbo.Leagues", t => t.League_ID)
                .Index(t => t.City_ID)
                .Index(t => t.League_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "League_ID", "dbo.Leagues");
            DropForeignKey("dbo.Teams", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Leagues", "Country_ID", "dbo.Countries");
            DropIndex("dbo.Teams", new[] { "League_ID" });
            DropIndex("dbo.Teams", new[] { "City_ID" });
            DropIndex("dbo.Leagues", new[] { "Country_ID" });
            DropTable("dbo.Teams");
            DropTable("dbo.Leagues");
        }
    }
}
