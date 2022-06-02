namespace SurveyAdminAuthen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateANSWER : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TextAnswers", "TokenID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TextAnswers", "TokenID");
        }
    }
}
