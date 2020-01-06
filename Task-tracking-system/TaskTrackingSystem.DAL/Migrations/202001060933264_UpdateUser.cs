namespace TaskTrackingSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectTasks", "UserProfile_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProjectTasks", "UserProfile_Id");
            AddForeignKey("dbo.ProjectTasks", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTasks", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.ProjectTasks", new[] { "UserProfile_Id" });
            DropColumn("dbo.ProjectTasks", "UserProfile_Id");
        }
    }
}
