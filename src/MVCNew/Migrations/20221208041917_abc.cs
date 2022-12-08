using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCNew.Migrations
{
    /// <inheritdoc />
    public partial class abc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "8d097ec0-bc4f-4551-8750-89442711d2ff", "28f31d6e-b85c-4aa6-a6ac-0579c1b96544" });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "8d097ec0-bc4f-4551-8750-89442711d2ff");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "28f31d6e-b85c-4aa6-a6ac-0579c1b96544");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "b85e9289-784a-48e5-91ce-9e9942f252cf", null, "admin", null });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { "c4c4faf0-3f6e-443d-80ef-3598e8db7854", 0, "02b5b586-bc5e-470c-bc37-115f757e5756", "admin1@gmail.com", true, false, null, "admin1@gmail.com", "admin", "AQAAAAIAAYagAAAAEDhdQHZCaPprHhdqiZGVKliF9bUzZX1fkcpmC36T8v7y4AgFRuP5eXAzJOoSuxnXUg==", "0987654321", false, "ce5afa15-c4c9-431f-a0f4-34cf5ae0e66a", false, "admin" });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { "b85e9289-784a-48e5-91ce-9e9942f252cf", "c4c4faf0-3f6e-443d-80ef-3598e8db7854" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "b85e9289-784a-48e5-91ce-9e9942f252cf", "c4c4faf0-3f6e-443d-80ef-3598e8db7854" });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "b85e9289-784a-48e5-91ce-9e9942f252cf");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "c4c4faf0-3f6e-443d-80ef-3598e8db7854");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "8d097ec0-bc4f-4551-8750-89442711d2ff", null, "admin", null });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { "28f31d6e-b85c-4aa6-a6ac-0579c1b96544", 0, "5752cb4c-9720-4463-89b3-26d9f9bc3250", "admin@gmail.com", true, false, null, "admin@gmail.com", "admin", "AQAAAAIAAYagAAAAEEVPmMz7kWEJ2XqWPxGqwxqb0OvieG8Rz1Va9wGkJGC5K2x83c884UMNgtQb2naF/g==", "0987654321", false, "afc78e5e-d75c-4ec1-ba60-a068f63d5ccf", false, "admin" });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { "8d097ec0-bc4f-4551-8750-89442711d2ff", "28f31d6e-b85c-4aa6-a6ac-0579c1b96544" });
        }
    }
}
