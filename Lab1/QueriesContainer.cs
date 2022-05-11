using System;
using System.Collections.Generic;
using System.Linq;
using Lab1.Models;

namespace Lab1
{
    internal class QueriesContainer
    {
        public List<LicensedDriver> Drivers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Model> Models { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<VehicleDriver> VehicleDrivers { get; set; }
        public void GetAllVehicles() //Вивести список усіх автомобілів
        {
            var allVehicles =
                from vehicle in Vehicles
                select vehicle;
            Console.WriteLine("\nQuery 1");
            foreach (var info in allVehicles)
            {
                Console.WriteLine($"{info.Id} {info.LicencePlate} {info.Condition}");
            }
        }

        public void GetFullInfoAboutVehicles() //Вивести повну інформацію про автомобілі
        {

            var vehiclesList =
                from vehicle in Vehicles
                join model in Models on vehicle.ModelId equals model.Id
                join manufacturer in Manufacturers on model.ManufacturerId equals manufacturer.Id
                select new { vehicle, model, manufacturer };

            Console.WriteLine("Query 2");
            foreach (var info in vehiclesList)
            {
                Console.WriteLine($"{info.vehicle.LicencePlate} {info.model.Name} " +
                                  $"{info.model.BrandName} {info.manufacturer.Name} " +
                                  $"{info.vehicle.Colour}");
            }
        }

        public void GetDriversWithNameStartingWithA() //Вивести перелік водіїв, у котрих імена починаються з літери «А»
        {
            var driversList =
                from driver in Drivers
                where driver.Name.StartsWith("A")
                select driver;
            Console.WriteLine("\nQuery 3");
            foreach (var variable in driversList)
            {
                Console.WriteLine($"{variable.Name} {variable.Surname} {variable.Patronymic}");
            }
        }

        public void GetVehicleOwnersWithModelNames() //Вивести власників авто та модель їх авто
        {
            var ownersAndCars =
                from driver in Drivers
                join vehicleDriver in VehicleDrivers on driver.LicenseId equals vehicleDriver.DriverId
                join vehicle in Vehicles on vehicleDriver.VehicleId equals vehicle.Id
                join model in Models on vehicle.ModelId equals model.Id
                where vehicleDriver.IsOwner
                select new { driver, model };
            Console.WriteLine("\nQuery 4");
            foreach (var info in ownersAndCars)
            {
                Console.WriteLine($"{info.driver.Name} {info.driver.Surname} {info.model.BrandName} {info.model.Name}");
            }
        }

        public void GetVehiclesGroupedByCondition() //Вивести перелік авто згрупувавши по стану
        {
            var vehiclesGroupedByCondition =
                from vehicle in Vehicles
                group vehicle by vehicle.Condition into newVehicle
                select newVehicle;
            Console.WriteLine("\nQuery 5");
            foreach (var info in vehiclesGroupedByCondition)
            {
                Console.Write("Key: ");
                Console.WriteLine(info.Key);
                foreach (var vehicle in info)
                {
                    Console.WriteLine($"\t{vehicle.Id} {vehicle.LicencePlate} ");//{vehicle.Condition}
                }
            }
        }

        public void GetNotOwnersOrderedByAge() //Вивести не власників авто, відсортувати їх по віку
        {
            var vehicleOwners =
                from driver in Drivers
                join vehicleDriver in VehicleDrivers on driver.LicenseId equals vehicleDriver.DriverId
                where !vehicleDriver.IsOwner
                orderby driver.DateOfBirth
                select driver;
            Console.WriteLine("\nQuery 6");
            foreach (var info in vehicleOwners)
            {
                Console.WriteLine($"{info.Name} {info.Surname} {info.DateOfBirth:dd/MM/yyyy}");
            }
        }

        public void GetRedAndBlackVehiclesWithDrivers() //Вивести червоні та чорні автомобілі та усіх їх водіїв
        {
            var vehiclesAndDrivers =
                from vehicle in Vehicles
                join vehicleDriver in VehicleDrivers on vehicle.Id equals vehicleDriver.VehicleId
                join driver in Drivers on vehicleDriver.DriverId equals driver.LicenseId
                where (vehicle.Colour == "Black" || vehicle.Colour == "Red")
                select new { vehicle, driver };
            Console.WriteLine("\nQuery 7");
            foreach (var info in vehiclesAndDrivers)
            {
                Console.WriteLine($"{info.vehicle.LicencePlate} {info.vehicle.Colour} {info.driver.Name} {info.driver.Surname}");
            }
        }

        public void GetVehiclesOlderThan3Years() //Вивести к-сть машин віком не менше 3х років
        {
            var vehiclesOlderThan = (from vehicle in Vehicles
                                     where vehicle.YearOfIssue <= 2019
                                     select vehicle).Count();
            Console.WriteLine("\nQuery 8");
            Console.WriteLine($"Count of cars: {vehiclesOlderThan}");
        }

        public void GetDriversWithoutLicense() //Вивести усіх водіїв що не мають прав на жодну машину
        {
            var driversWithoutLicenseList = Drivers.Except(
                Drivers.Join(VehicleDrivers, driver => driver.LicenseId, vehicleDriver => vehicleDriver.DriverId,
                    (driver, vehicleDriver) => driver)
                );

            Console.WriteLine("\nQuery 9");
            foreach (var info in driversWithoutLicenseList)
            {
                Console.WriteLine($"{info.Name} {info.Surname} {info.LicenseId}");
            }
        }

        public void GetAllAudiExceptBlack() //Вивести усі авто бренду Audi окрім чорних
        {
            var vehicleAudiList = Vehicles.Join(Models, vehicle => vehicle.ModelId, model => model.Id,
                    (vehicle, model) => new { vehicle, model })
                .Where(car => car.model.BrandName == "Audi" && car.vehicle.Colour != "Black");
            Console.WriteLine("\nQuery 10");
            foreach (var info in vehicleAudiList)
            {
                Console.WriteLine($"{info.vehicle.Colour} {info.vehicle.LicencePlate} {info.model.BrandName}");
            }
        }

        public void GetManufacturerAndModelsQuantity() //Вивести виробника та кількість моделей, що були ними вироблені
        {
            var manufacturerWithModelsCountList = Manufacturers
                .Join(Models, manufacturer => manufacturer.Id, model => model.ManufacturerId, (manufacturer, model) => (manufacturer, model))
                .GroupBy(manufacturer => manufacturer.manufacturer)
                .Select(x => new { Manufacturer = x.Key, Count = x.Count() });
            Console.WriteLine("\nQuery 11");
            foreach (var info in manufacturerWithModelsCountList)
            {
                Console.WriteLine($"{info.Manufacturer.Name} {info.Count}");
            }
        }

        public void GetAverageVehiclesYearOfIssueAndQuantity() //Вивести середній рік випуску авто та їх загальну кількість
        {
            var averageVehicleYearOfIssueAndCount = Vehicles
                .Select(x => new { Count = Vehicles.Count(), Average = Vehicles.Average(y => y.YearOfIssue) })
                .FirstOrDefault();
            Console.WriteLine("\nQuery 12");
            Console.WriteLine($"Count: {averageVehicleYearOfIssueAndCount.Count} Average year of issue: {averageVehicleYearOfIssueAndCount.Average:0000.00}");
        }

        public void GetDriversWith2AndMoreVehicles() //Вивести водіїв, котрі володіють двома або більше авто
        {
            var driversWithVehiclesCountMoreThanOne = Drivers
                .Join(VehicleDrivers, driver => driver.LicenseId, vehicleDriver => vehicleDriver.DriverId,
                    (driver, vehicleDriver) => (driver, vehicleDriver))
                .GroupBy(x => (x.driver))
                .Select(x => new { Driver = x.Key, Count = x.Count() })
                .Where(x => x.Count > 1);
            Console.WriteLine("\nQuery 13");
            foreach (var info in driversWithVehiclesCountMoreThanOne)
            {
                Console.WriteLine($"{info.Driver.Name} {info.Driver.Surname} {info.Count}");
            }
        }

        public void GetAllColorsOfVolkswagen() //Вивести усі можливі кольори авто виробника Volkswagen
        {
            var manufacturerVolkswagenAndColors = Manufacturers
                .Join(Models, manufacturer => manufacturer.Id, model => model.ManufacturerId,
                    (manufacturer, model) => (manufacturer, model))
                .Join(Vehicles, tuple => tuple.model.Id, vehicle => vehicle.ModelId,
                    (tuple, vehicle) => (tuple.manufacturer, vehicle))
                .Where(x => x.manufacturer.Name.Contains("Volkswagen"))
                .Select(x => x.vehicle.Colour);
            Console.WriteLine("\nQuery 14\nVolkswagen colours:");
            foreach (var info in manufacturerVolkswagenAndColors)
            {
                Console.WriteLine(info);
            }
        }

        public void GetUniqueModelOfManufacturer() //Вивести тільки модель авто з унікальним виробником
        {
            var uniqueModels = Models
                .GroupBy(model => model.ManufacturerId)
                .Select(x => new { ModelName = x.FirstOrDefault(), Count = x.Count() })
                .Where(x => x.Count == 1);
            Console.WriteLine("\nQuery 15:");
            foreach (var info in uniqueModels)
            {
                Console.WriteLine(info.ModelName.Name);
            }
        }
    }
}