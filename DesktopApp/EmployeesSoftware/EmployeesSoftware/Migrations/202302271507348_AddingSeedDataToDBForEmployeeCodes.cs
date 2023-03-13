namespace EmployeesSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSeedDataToDBForEmployeeCodes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('opacity-selected-briskly');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('contempt-chalice-turbofan');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('crank-trailside-glaring');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('antics-dispersal-undoing');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('gills-sister-oversized');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('shortcut-idealness-regress');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('prelaunch-freewill-drowsily');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('dreamboat-crayfish-task');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('banner-kebab-thorn');");
            Sql("INSERT INTO EmployeeCodes (InscriptionCode) VALUES ('shrubbery-uncurled-refined');");
        }
        
        public override void Down()
        {
            // On ajoute le contraire pour pouvoir rollback migrations
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='opacity-selected-briskly';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='contempt-chalice-turbofan';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='crank-trailside-glaring';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='antics-dispersal-undoing';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='gills-sister-oversized'';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='shortcut-idealness-regress';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='prelaunch-freewill-drowsily';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='dreamboat-crayfish-task';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='banner-kebab-thorn';");
            Sql("DELETE FROM EmployeeCodes WHERE InscriptionCode='shrubbery-uncurled-refined';");
        }
    }
}
