namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Director = c.String(nullable: false, maxLength: 100),
                        ReleaseDate = c.DateTime(nullable: false),
                        TrailerLink = c.String(maxLength: 1000),
                        ReviewLink = c.String(maxLength: 1000),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.UserReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(),
                        Rating = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserReviews", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.UserReviews", new[] { "MovieId" });
            DropIndex("dbo.UserReviews", new[] { "UserId" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserReviews");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
