namespace VoteSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialScript : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "Region_Id", "dbo.Region");
            DropIndex("dbo.User", new[] { "Region_Id" });
            CreateTable(
                "dbo.RegionPolicy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PollId = c.Int(),
                        Region_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.Region_Id, cascadeDelete: true)
                .Index(t => t.Region_Id);
            
            CreateTable(
                "dbo.UserPolicy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PollId = c.Int(),
                        user_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.user_Id, cascadeDelete: true)
                .Index(t => t.user_Id);
            
            AddColumn("dbo.User", "RegionId", c => c.Int(nullable: false));
            DropColumn("dbo.User", "Region_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Region_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserPolicy", "user_Id", "dbo.User");
            DropForeignKey("dbo.RegionPolicy", "Region_Id", "dbo.Region");
            DropIndex("dbo.UserPolicy", new[] { "user_Id" });
            DropIndex("dbo.RegionPolicy", new[] { "Region_Id" });
            DropColumn("dbo.User", "RegionId");
            DropTable("dbo.UserPolicy");
            DropTable("dbo.RegionPolicy");
            CreateIndex("dbo.User", "Region_Id");
            AddForeignKey("dbo.User", "Region_Id", "dbo.Region", "Id", cascadeDelete: true);
        }
    }
}
