namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewWatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFavorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.UserWatchlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFavorites", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserWatchlists", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserWatchlists", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.UserFavorites", "MovieId", "dbo.Movies");
            DropIndex("dbo.UserWatchlists", new[] { "MovieId" });
            DropIndex("dbo.UserWatchlists", new[] { "UserId" });
            DropIndex("dbo.UserFavorites", new[] { "MovieId" });
            DropIndex("dbo.UserFavorites", new[] { "UserId" });
            DropTable("dbo.UserWatchlists");
            DropTable("dbo.UserFavorites");
        }
    }
}
