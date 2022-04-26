using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examino.Infrastructure.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("15268796-ee21-482c-8f68-fdec407de8ae"), "1", "Doctor", "DOCTOR" },
                    { new Guid("7d6f59b9-3f81-4678-9a40-f1d018e711ca"), "1", "Admin", "ADMIN" },
                    { new Guid("c8b28366-811a-4c6f-9838-f603c452d37e"), "1", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDay", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PESEL", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { new Guid("8931ce67-348b-48b6-96fc-6fc47a74311e"), 0, "Miejska 10", new DateTime(1988, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kraków", "d73621af-f4d6-403e-9a65-dbe8905e4440", "Admin@gmail.com", true, false, null, "Antek", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", 99101912345L, "AQAAAAEAACcQAAAAENmur9tGyuLBQyu8sxpNdcYfPknQmGq9D7qQDtX+wwhaM2R/QNt9uldTq5h8aakInw==", "999111222", true, "30-004", "eb874b3e-21f9-4129-869a-6b934d18d76a", "Kowalski", false, "Admin@gmail.com", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDay", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PESEL", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Qualification", "SecurityStamp", "Specialization", "Surname", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138"), 0, "Baciarego 10", new DateTime(1966, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kraków", "b1e655b0-d7a4-483e-98d4-32c4961360f9", "WitoldMajewski@gmail.com", true, false, null, "Witold", "WITOLDMAJEWSKI@GMAIL.COM", "WITOLDMAJEWSKI@GMAIL.COM", 66030280889L, "AQAAAAEAACcQAAAAEC2GO3klewDFS2SoPk/t6dT4olrUoaHvsp2+SepovOP30SdaZd19VBk3gJQ8Gcp9Vw==", "999321933", true, "30-001", "Cardiologist,Internist", "334cec6e-d359-49eb-9840-e8fe10a1722f", "cardiology,internal diseases", "Majewski", false, "WitoldMajewski@gmail.com", "Doctor" },
                    { new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"), 0, "Bliska 20", new DateTime(1960, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kraków", "3d7da63a-60f0-4ea6-8764-79617417faab", "WGwinciarz@gmail.com", true, false, null, "Wojciech", "WGWINCIARZ@GMAIL.COM", "WGWINCIARZ@GMAIL.COM", 60070111229L, "AQAAAAEAACcQAAAAEIYhM3YORQKJm0k7N5cqKnSbhC96Pq9RmXrxc4CnLTqoBTZuYzAQztZySAQeQW/pIg==", "129888777", true, "30-003", "Oncologist,Laryngologist", "d6656279-db07-475a-992c-c28e809ea181", "oncological radiotherapy,otolaryngology ", "Gwinciarz", false, "WGwinciarz@gmail.com", "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDay", "BloodType", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Height", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PESEL", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "UserType", "Weight" },
                values: new object[,]
                {
                    { new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"), 0, "Kwiatowa 20", new DateTime(1978, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "B-", "Jeleśnia", "1b754a0b-8f4f-4aaa-9c55-2894eead6de6", "BartekSkrzypek@gmail.com", true, 175, false, null, "Bartek", "BARTEKSKRZYPEK@GMAIL.COM", "BARTEKSKRZYPEK@GMAIL.COM", 78032180802L, "AQAAAAEAACcQAAAAEF9wZ88YNAt9H+3WLmOt+zKGWNOcWIJaZ55GLpwJBUNQkCVXR9QaYbZS3Qpw9LWXSQ==", "999111333", true, "34-331", "b4f9496b-eca1-4b64-9ab6-46cfba528706", "Skrzypek", false, "BartekSkrzypek@gmail.com", "Patient", 80 },
                    { new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f"), 0, "Morksa 20", new DateTime(1990, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "B+", "Gdańsk", "5b911963-272f-4e78-b743-189eb5a85003", "MichalGwizd@gmail.com", true, 172, false, null, "Michał", "MICHALGWIZD@GMAIL.COM", "MICHALGWIZD@GMAIL.COM", 90042182882L, "AQAAAAEAACcQAAAAEDiothikNCKx8TYJg7G/RZcmv+gkd60YgwgUyl9bjy0px28NX1nCw0nldF/+95LuEQ==", "999888777", true, "80-001", "59839d0e-1ba4-45ac-9477-b5f715566585", "Gwizd", false, "MichalGwizd@gmail.com", "Patient", 70 },
                    { new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6"), 0, "Wiejska 50", new DateTime(1999, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "A+", "Zakopane", "ffcbc1e7-5df3-45f4-86b7-a20a010c9bc3", "Jakub1999@gmail.com", true, 192, false, null, "Jakub", "JAKUB1999@GMAIL.COM", "JAKUB1999@GMAIL.COM", 99042382888L, "AQAAAAEAACcQAAAAECv20NXPrrfxjAEHUnwTNO9uDE4KgfugG9CxjET0omEU4pGNgv/9ahR86vfNvw4Egg==", "992488111", true, "34-500", "380391c6-6adf-4dc2-b4f1-c79f9689b044", "Kwiatowski", false, "Jakub1999@gmail.com", "Patient", 90 }
                });

            migrationBuilder.InsertData(
                table: "Raports",
                columns: new[] { "Id", "Comment", "Diagnosis", "DoctorId", "Examination", "PatientId", "RaportTime", "Recommendation", "Symptoms" },
                values: new object[,]
                {
                    { new Guid("a34d644f-55fc-4a39-addd-a8cc07f89c34"), " do cholesterol tests", " there are needed cholesterol tests ", new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138"), "checking pulse, checking sound of lungs", new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"), new DateTimeOffset(new DateTime(2022, 4, 26, 16, 42, 12, 158, DateTimeKind.Unspecified).AddTicks(1011), new TimeSpan(0, 2, 0, 0, 0)), "increase potassium income", " heart pain,pain in middle of chest,lazziness " },
                    { new Guid("b03172a3-fc8f-4419-a63e-618359d4cd99"), "there is need for rendgen photo", "curve septum", new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"), "after checking nose i saw curve in bones", new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f"), new DateTimeOffset(new DateTime(2022, 4, 26, 16, 42, 12, 158, DateTimeKind.Unspecified).AddTicks(1067), new TimeSpan(0, 2, 0, 0, 0)), "using nasonex twice a day  at 7 AM and at 9PM", " runny nose " },
                    { new Guid("c72b703e-21f0-45ea-9323-e1362b494cb1"), "there are needed allergy tests", "allergy to dust mites", new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"), "runny nose", new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"), new DateTimeOffset(new DateTime(2022, 4, 26, 16, 42, 12, 158, DateTimeKind.Unspecified).AddTicks(1074), new TimeSpan(0, 2, 0, 0, 0)), "bed cleaning, xyzal once a day", "runny nose after night's sleep  " },
                    { new Guid("fd01f84e-8917-461a-8d6d-b5758a6065b2"), "", "just cold", new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"), "he has temperature ", new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6"), new DateTimeOffset(new DateTime(2022, 4, 26, 16, 42, 12, 158, DateTimeKind.Unspecified).AddTicks(1080), new TimeSpan(0, 2, 0, 0, 0)), "stay at home and take aspiryn  ", "runny nose,cough   " }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c8b28366-811a-4c6f-9838-f603c452d37e"), new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca") },
                    { new Guid("7d6f59b9-3f81-4678-9a40-f1d018e711ca"), new Guid("8931ce67-348b-48b6-96fc-6fc47a74311e") },
                    { new Guid("15268796-ee21-482c-8f68-fdec407de8ae"), new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138") },
                    { new Guid("c8b28366-811a-4c6f-9838-f603c452d37e"), new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f") },
                    { new Guid("15268796-ee21-482c-8f68-fdec407de8ae"), new Guid("d9339e74-284d-46f4-ad46-b13269c4900e") },
                    { new Guid("c8b28366-811a-4c6f-9838-f603c452d37e"), new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6") }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "Medicines", "RaportId" },
                values: new object[] { new Guid("33842c30-c6b2-4dab-87a6-9e71e4bb0250"), "potassium suplement", new Guid("a34d644f-55fc-4a39-addd-a8cc07f89c34") });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "Medicines", "RaportId" },
                values: new object[] { new Guid("9d092a09-ae05-4333-9872-a5c35727f4f5"), "xyzal 5mg film-coated tablets ", new Guid("c72b703e-21f0-45ea-9323-e1362b494cb1") });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "Medicines", "RaportId" },
                values: new object[] { new Guid("aca33117-640a-47f5-b3d8-2739a7698042"), "nasonex 18g ", new Guid("b03172a3-fc8f-4419-a63e-618359d4cd99") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("33842c30-c6b2-4dab-87a6-9e71e4bb0250"));

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("9d092a09-ae05-4333-9872-a5c35727f4f5"));

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: new Guid("aca33117-640a-47f5-b3d8-2739a7698042"));

            migrationBuilder.DeleteData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("fd01f84e-8917-461a-8d6d-b5758a6065b2"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8b28366-811a-4c6f-9838-f603c452d37e"), new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d6f59b9-3f81-4678-9a40-f1d018e711ca"), new Guid("8931ce67-348b-48b6-96fc-6fc47a74311e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("15268796-ee21-482c-8f68-fdec407de8ae"), new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8b28366-811a-4c6f-9838-f603c452d37e"), new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("15268796-ee21-482c-8f68-fdec407de8ae"), new Guid("d9339e74-284d-46f4-ad46-b13269c4900e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c8b28366-811a-4c6f-9838-f603c452d37e"), new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6") });

            migrationBuilder.DeleteData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("a34d644f-55fc-4a39-addd-a8cc07f89c34"));

            migrationBuilder.DeleteData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("b03172a3-fc8f-4419-a63e-618359d4cd99"));

            migrationBuilder.DeleteData(
                table: "Raports",
                keyColumn: "Id",
                keyValue: new Guid("c72b703e-21f0-45ea-9323-e1362b494cb1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("15268796-ee21-482c-8f68-fdec407de8ae"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d6f59b9-3f81-4678-9a40-f1d018e711ca"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c8b28366-811a-4c6f-9838-f603c452d37e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8931ce67-348b-48b6-96fc-6fc47a74311e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f43c4920-a607-4d32-a937-ba324e07ebd6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae47d26c-b934-4057-8d05-dfd78ea1a138"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9339e74-284d-46f4-ad46-b13269c4900e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c394c3c5-3727-4b3b-999f-de8180edf15f"));
        }
    }
}
