namespace Projekt.NETStrona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostContent = c.String(),
                        DateCreated = c.DateTime(),
                        Edited = c.Boolean(nullable: false),
                        DateEdited = c.DateTime(),
                        LikesCount = c.Int(nullable: false),
                        UserName = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeIds = c.Int(nullable: false, identity: true),
                        LikedBy_Id = c.String(maxLength: 128),
                        Post_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.LikeIds)
                .ForeignKey("dbo.AspNetUsers", t => t.LikedBy_Id)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .Index(t => t.LikedBy_Id)
                .Index(t => t.Post_PostId);
            
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Likes", "LikedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Likes", new[] { "Post_PostId" });
            DropIndex("dbo.Likes", new[] { "LikedBy_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id");
            DropTable("dbo.Likes");
            DropTable("dbo.Posts");
        }
    }
}
