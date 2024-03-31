using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsApp.Migrations
{
    /// <inheritdoc />
    public partial class FnGetAllContactsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION FnGetAllContacts()
                RETURNS TABLE (
                    Id integer,
                    Name character varying(200),
                    PhoneNumber character varying(45),
                    Email character varying(255),
                    CreationDate timestamp with time zone
                )
                AS $$
                BEGIN
                    RETURN QUERY SELECT ""Id"", ""Name"", ""PhoneNumber"", ""Email"", ""CreationDate"" FROM ""Contact"";
                END;
                $$
                LANGUAGE plpgsql;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION FnGetAllContacts;");
        }
    }
}
