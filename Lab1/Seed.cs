using System;
using System.Collections.Generic;
using Lab1.Models;

namespace Lab1
{
    public class Seed
    {
        public static List<LicensedDriver> Drivers =>
            new List<LicensedDriver>
            {
                new LicensedDriver()
                {
                    LicenseId = 1,
                    Surname = "Kalchenko",
                    Name = "Yehor",
                    Patronymic = "Oleksandrovich",
                    DateOfBirth = Convert.ToDateTime("29.09.2003"),
                    RegistrationAddress = "Poltava"
                },
                new LicensedDriver()
                {
                    LicenseId = 2,
                    Surname = "Proshchenko",
                    Name = "Alisa",
                    Patronymic = "Genadievna",
                    DateOfBirth = Convert.ToDateTime("30.10.2000"),
                    RegistrationAddress = "Kyiv"
                },
                new LicensedDriver()
                {
                    LicenseId = 3,
                    Surname = "Stankov",
                    Name = "Artem",
                    Patronymic = "Batkovych",
                    DateOfBirth = Convert.ToDateTime("12.01.2001"),
                    RegistrationAddress = "Sarny"
                },
                new LicensedDriver()
                {
                    LicenseId = 4,
                    Surname = "Vynnyk",
                    Name = "Vitaly",
                    Patronymic = "Vadymovich",
                    DateOfBirth = Convert.ToDateTime("25.01.2005"),
                    RegistrationAddress = "Birky"
                }
            };

        public static List<Vehicle> Vehicles =>
            new List<Vehicle>
            {
                new Vehicle()
                {
                    Id = 1,
                    BodyType = BodyType.Coupe,
                    Colour = "Black",
                    Condition = "Good",
                    LicencePlate = "AA1337AA",
                    ModelId = 1,
                    VinCode = "21314125151521",
                    YearOfIssue = 2017
                },
                new Vehicle()
                {
                    Id = 2,
                    BodyType = BodyType.Minivan,
                    Colour = "Red",
                    Condition = "Normal",
                    LicencePlate = "BB3525AA",
                    ModelId = 2,
                    VinCode = "1242141241251251",
                    YearOfIssue = 2020
                },
                new Vehicle()
                {
                    Id = 3,
                    BodyType = BodyType.Pickup,
                    Colour = "Gold",
                    Condition = "Good",
                    LicencePlate = "AA1532513BF",
                    ModelId = 1,
                    VinCode = "2312412414121",
                    YearOfIssue = 2019
                },
            };

        public static List<Model> Models =>
            new List<Model>
            {
                new Model()
                {
                    Id = 1,
                    BrandName = "Audi",
                    ManufacturerId = 1,
                    Name = "A8"
                },
                new Model()
                {
                    Id = 2,
                    BrandName = "Tesla",
                    ManufacturerId = 2,
                    Name = "Model J"
                },
                new Model()
                {
                    Id = 3,
                    BrandName = "Tesla",
                    ManufacturerId = 2,
                    Name = "Model B"
                },
                new Model()
                {
                    Id = 4,
                    BrandName = "Tuskla",
                    ManufacturerId = 3,
                    Name = "Model Xi"
                }
            };

        public static List<Manufacturer> Manufacturers =>
            new List<Manufacturer>
            {
                new Manufacturer()
                {
                    Id = 1,
                    Name = "Volkswagen Group"
                },
                new Manufacturer()
                {
                    Id = 2,
                    Name = "Elon Musk"
                },
                new Manufacturer()
                {
                    Id = 3,
                    Name = "Elon Ma"
                }
            };

        public static List<VehicleDriver> VehicleDrivers =>
            new List<VehicleDriver>()
            {
                new VehicleDriver()
                {
                    DriverId = 1,
                    IsOwner = true,
                    VehicleId = 2
                },
                new VehicleDriver()
                {
                    DriverId = 2,
                    IsOwner = true,
                    VehicleId = 1
                },
                new VehicleDriver()
                {
                    DriverId = 1,
                    IsOwner = false,
                    VehicleId = 1
                },
                new VehicleDriver()
                {
                    DriverId = 3,
                    IsOwner = false,
                    VehicleId = 3
                }
            };
    }
}
