namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientVisit",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        HospitalId = c.String(nullable: false, maxLength: 128),
                        PatientId = c.String(nullable: false, maxLength: 128),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        SpecializationId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Hospital", t => t.HospitalId, cascadeDelete: true)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Specialization", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.HospitalId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.SpecializationId);
            
            CreateTable(
                "dbo.Hospital",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientVisit", "SpecializationId", "dbo.Specialization");
            DropForeignKey("dbo.PatientVisit", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.PatientVisit", "HospitalId", "dbo.Hospital");
            DropForeignKey("dbo.PatientVisit", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.PatientVisit", new[] { "SpecializationId" });
            DropIndex("dbo.PatientVisit", new[] { "DoctorId" });
            DropIndex("dbo.PatientVisit", new[] { "PatientId" });
            DropIndex("dbo.PatientVisit", new[] { "HospitalId" });
            DropTable("dbo.Specialization");
            DropTable("dbo.Patient");
            DropTable("dbo.Hospital");
            DropTable("dbo.PatientVisit");
            DropTable("dbo.Doctor");
        }
    }
}
