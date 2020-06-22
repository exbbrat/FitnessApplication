namespace CodeBlogFitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControllerBase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Gender_Id", newName: "GenderId");
            RenameIndex(table: "dbo.Users", name: "IX_Gender_Id", newName: "IX_GenderId");
            AddColumn("dbo.Eatings", "Food_Id", c => c.Int());
            CreateIndex("dbo.Exercises", "UserId");
            CreateIndex("dbo.Eatings", "Food_Id");
            AddForeignKey("dbo.Exercises", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.Exercises", "UserId", "dbo.Users");
            DropIndex("dbo.Eatings", new[] { "Food_Id" });
            DropIndex("dbo.Exercises", new[] { "UserId" });
            DropColumn("dbo.Eatings", "Food_Id");
            RenameIndex(table: "dbo.Users", name: "IX_GenderId", newName: "IX_Gender_Id");
            RenameColumn(table: "dbo.Users", name: "GenderId", newName: "Gender_Id");
        }
    }
}
