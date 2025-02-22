namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "FDepartementId", "dbo.Departements");
            DropIndex("dbo.Employees", new[] { "FDepartementId" });
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "FDepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "FDepartmentId");
            AddForeignKey("dbo.Employees", "FDepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropColumn("dbo.Employees", "FDepartementId");
            DropTable("dbo.Departements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartementName = c.String(),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "FDepartementId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "FDepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "FDepartmentId" });
            DropColumn("dbo.Employees", "FDepartmentId");
            DropTable("dbo.Departments");
            CreateIndex("dbo.Employees", "FDepartementId");
            AddForeignKey("dbo.Employees", "FDepartementId", "dbo.Departements", "Id", cascadeDelete: true);
        }
    }
}
