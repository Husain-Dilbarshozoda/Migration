using FluentMigrator;

namespace Infastructure.Migrations;

[Migration(2024122501)]
public class CreateAuthorTable:Migration
{
    public override void Up()
    {
        Create.Table("Authors")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100)
            .WithColumn("Country").AsString(50);
    }   

    public override void Down()
    {
        Delete.Table("Authors");
    }
}