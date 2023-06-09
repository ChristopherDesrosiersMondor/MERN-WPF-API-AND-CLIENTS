﻿namespace EmployeesSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeCodesToDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InscriptionCode = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeCodes");
        }
    }
}
