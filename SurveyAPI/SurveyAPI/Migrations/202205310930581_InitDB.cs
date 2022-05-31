namespace SurveyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerSubmits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        Required = c.String(),
                        SurveyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Surveys", t => t.SurveyID, cascadeDelete: true)
                .Index(t => t.SurveyID);
            
            CreateTable(
                "dbo.OptionQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OptionType = c.String(),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Status = c.Int(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserSurveys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        SurveyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Surveys", t => t.SurveyID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SurveyID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Role = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TextAnswers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        AnswerID = c.Int(nullable: false),
                        AnswerSubmit_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnswerSubmits", t => t.AnswerSubmit_ID)
                .Index(t => t.AnswerSubmit_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TextAnswers", "AnswerSubmit_ID", "dbo.AnswerSubmits");
            DropForeignKey("dbo.UserSurveys", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserSurveys", "SurveyID", "dbo.Surveys");
            DropForeignKey("dbo.Questions", "SurveyID", "dbo.Surveys");
            DropForeignKey("dbo.Surveys", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.OptionQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.AnswerSubmits", "QuestionID", "dbo.Questions");
            DropIndex("dbo.TextAnswers", new[] { "AnswerSubmit_ID" });
            DropIndex("dbo.UserSurveys", new[] { "SurveyID" });
            DropIndex("dbo.UserSurveys", new[] { "UserID" });
            DropIndex("dbo.Surveys", new[] { "CategoryID" });
            DropIndex("dbo.OptionQuestions", new[] { "QuestionID" });
            DropIndex("dbo.Questions", new[] { "SurveyID" });
            DropIndex("dbo.AnswerSubmits", new[] { "QuestionID" });
            DropTable("dbo.TextAnswers");
            DropTable("dbo.Users");
            DropTable("dbo.UserSurveys");
            DropTable("dbo.Categories");
            DropTable("dbo.Surveys");
            DropTable("dbo.OptionQuestions");
            DropTable("dbo.Questions");
            DropTable("dbo.AnswerSubmits");
        }
    }
}
