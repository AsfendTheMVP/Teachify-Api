namespace TeachifyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CitiesAndCoursesAdded : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cities");
            DropTable("dbo.Courses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
        }
    }
}
