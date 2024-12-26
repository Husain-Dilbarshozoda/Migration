using FluentMigrator;

namespace Infastructure.Migrations;

[Migration(2024122502)]
public class CreateBooksTable:Migration
{
    public override void Up()
    {
        Create.Table("Books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(200)
            .WithColumn("PublishedYear").AsInt32()
            .WithColumn("Genre").AsString(50)
            .WithColumn("IsAvailable").AsBoolean()
            .WithColumn("AuthorId").AsInt32().ForeignKey("Authors","Id");
    }

    public override void Down()
    {
        Delete.Table("Books");
    }
}