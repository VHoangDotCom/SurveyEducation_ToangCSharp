namespace SurveyAdminAuthen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswerSubmits", "Survey_ID", "dbo.Surveys");
            DropIndex("dbo.AnswerSubmits", new[] { "Survey_ID" });
            RenameColumn(table: "dbo.AnswerSubmits", name: "Survey_ID", newName: "SurveyID");
            AlterColumn("dbo.AnswerSubmits", "SurveyID", c => c.Int(nullable: false));
            CreateIndex("dbo.AnswerSubmits", "SurveyID");
            AddForeignKey("dbo.AnswerSubmits", "SurveyID", "dbo.Surveys", "ID", cascadeDelete: true);
            DropColumn("dbo.AnswerSubmits", "QuestionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnswerSubmits", "QuestionID", c => c.Int(nullable: false));
            DropForeignKey("dbo.AnswerSubmits", "SurveyID", "dbo.Surveys");
            DropIndex("dbo.AnswerSubmits", new[] { "SurveyID" });
            AlterColumn("dbo.AnswerSubmits", "SurveyID", c => c.Int());
            RenameColumn(table: "dbo.AnswerSubmits", name: "SurveyID", newName: "Survey_ID");
            CreateIndex("dbo.AnswerSubmits", "Survey_ID");
            AddForeignKey("dbo.AnswerSubmits", "Survey_ID", "dbo.Surveys", "ID");
        }
    }
}
