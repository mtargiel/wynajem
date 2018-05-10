using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MistrzowieWynajmu.Migrations
{
    public partial class SeedingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Owners(Name, LastName, PhoneNumber) VALUES ('Marian', 'Kowalski', '51587954')");
            migrationBuilder.Sql("Insert into Owners(Name, LastName, PhoneNumber) VALUES ('Andrzej', 'Kwiatkowski', '51587954')");
            migrationBuilder.Sql("Insert into Owners(Name, LastName, PhoneNumber) VALUES ('Krzysztof', 'Malinowski', '51587954')");
            migrationBuilder.Sql("Insert into Owners(Name, LastName, PhoneNumber) VALUES ('Katarzyna', 'Słowacka', '51587954')");

            migrationBuilder.Sql("Insert into Addresses(City, Street, PostCode) VALUES ('Kraków', 'Mariacka', '42-123')");
            migrationBuilder.Sql("Insert into Addresses(City, Street, PostCode) VALUES ('Bieruń', 'Łysionowa', '41-123')");
            migrationBuilder.Sql("Insert into Addresses(City, Street, PostCode) VALUES ('Tychy', 'Targiela', '22-123')");
            migrationBuilder.Sql("Insert into Properties(NumberOfRooms, Area, Type, Rooms, Washer, Refrigerator, Iron, OwnerId, AddressId) VALUES (1, 50, 1, 2, 1,1,1,1,1)");
            migrationBuilder.Sql("Insert into Properties(NumberOfRooms, Area, Type, Rooms, Washer, Refrigerator, Iron, OwnerId, AddressId) VALUES (1, 100, 1, 3, 0,1,1,2,2)");
            migrationBuilder.Sql("Insert into Properties(NumberOfRooms, Area, Type, Rooms, Washer, Refrigerator, Iron, OwnerId, AddressId) VALUES (0, 200, 1, 3, 0,1,1,3,3)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from OWNERS");
            migrationBuilder.Sql("DELETE FROM Address");
            migrationBuilder.Sql("DELETE FROM Properties");
        }
    }
}
