namespace SurveyAdminAuthen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextAnswers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TextAnswers", "Email");
        }
    }
}
