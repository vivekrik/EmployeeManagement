namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        FDepartementId = c.Int(nullable: false),
                        FGenderId = c.Int(nullable: false),
                        Designation = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departements", t => t.FDepartementId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.FGenderId, cascadeDelete: true)
                .Index(t => t.FDepartementId)
                .Index(t => t.FGenderId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderName = c.String(),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "FGenderId", "dbo.Genders");
            DropForeignKey("dbo.Employees", "FDepartementId", "dbo.Departements");
            DropIndex("dbo.Employees", new[] { "FGenderId" });
            DropIndex("dbo.Employees", new[] { "FDepartementId" });
            DropTable("dbo.Genders");
            DropTable("dbo.Employees");
            DropTable("dbo.Departements");
        }
    }
}
