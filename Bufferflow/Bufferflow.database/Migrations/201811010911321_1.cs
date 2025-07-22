namespace Bufferflow.database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ans = c.String(nullable: false),
                        Netvotes = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        UserEmailAddress = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Question", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserEmailAddress, cascadeDelete: true)
                .Index(t => t.QuestionID)
                .Index(t => t.UserEmailAddress);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        UserEmailAddress = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserEmailAddress, cascadeDelete: false)
                .Index(t => t.UserEmailAddress);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        EmailAddress = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        ProfilePic = c.Binary(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmailAddress);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        EmailAddress = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmailAddress)
                .ForeignKey("dbo.User", t => t.EmailAddress)
                .Index(t => t.EmailAddress);
            
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsVoted = c.Boolean(nullable: false),
                        IsUpvoted = c.Boolean(nullable: false),
                        UserEmailAddress = c.String(nullable: false, maxLength: 128),
                        AnswerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Answer", t => t.AnswerID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserEmailAddress, cascadeDelete: false)
                .Index(t => t.UserEmailAddress)
                .Index(t => t.AnswerID);
            
            CreateTable(
                "dbo.TagQuestion",
                c => new
                    {
                        Tag_ID = c.Int(nullable: false),
                        Question_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_ID, t.Question_ID })
                .ForeignKey("dbo.Tag", t => t.Tag_ID, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.Question_ID, cascadeDelete: true)
                .Index(t => t.Tag_ID)
                .Index(t => t.Question_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vote", "UserEmailAddress", "dbo.User");
            DropForeignKey("dbo.Vote", "AnswerID", "dbo.Answer");
            DropForeignKey("dbo.Login", "EmailAddress", "dbo.User");
            DropForeignKey("dbo.Answer", "UserEmailAddress", "dbo.User");
            DropForeignKey("dbo.Question", "UserEmailAddress", "dbo.User");
            DropForeignKey("dbo.TagQuestion", "Question_ID", "dbo.Question");
            DropForeignKey("dbo.TagQuestion", "Tag_ID", "dbo.Tag");
            DropForeignKey("dbo.Answer", "QuestionID", "dbo.Question");
            DropIndex("dbo.TagQuestion", new[] { "Question_ID" });
            DropIndex("dbo.TagQuestion", new[] { "Tag_ID" });
            DropIndex("dbo.Vote", new[] { "AnswerID" });
            DropIndex("dbo.Vote", new[] { "UserEmailAddress" });
            DropIndex("dbo.Login", new[] { "EmailAddress" });
            DropIndex("dbo.Question", new[] { "UserEmailAddress" });
            DropIndex("dbo.Answer", new[] { "UserEmailAddress" });
            DropIndex("dbo.Answer", new[] { "QuestionID" });
            DropTable("dbo.TagQuestion");
            DropTable("dbo.Vote");
            DropTable("dbo.Login");
            DropTable("dbo.User");
            DropTable("dbo.Tag");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
