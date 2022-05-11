using System;

namespace Lab1
{
    internal class Program
    {
        private static void Main()
        {
            var queries = new QueriesContainer()
            {
                Drivers = Seed.Drivers,
                Vehicles = Seed.Vehicles,
                Models = Seed.Models,
                VehicleDrivers = Seed.VehicleDrivers,
                Manufacturers = Seed.Manufacturers
            };
            Console.WriteLine("Kalchenko Yehor IS-02, Variant 7 - Vehicle registration\n");
            //Вивести список усіх автомобілів
            queries.GetAllVehicles();

            //Вивести повну інформацію про автомобілі
            queries.GetFullInfoAboutVehicles();

            //Вивести перелік водіїв, у котрих імена починаються з літери «А»
            queries.GetDriversWithNameStartingWithA();

            //Вивести власників авто та модель їх авто
            queries.GetVehicleOwnersWithModelNames();

            //Вивести перелік авто згрупувавши по стану
            queries.GetVehiclesGroupedByCondition();

            //Вивести не власників авто, відсортувати їх по віку
            queries.GetNotOwnersOrderedByAge();

            //Вивести червоні та чорні автомобілі та усіх їх водіїв
            queries.GetRedAndBlackVehiclesWithDrivers();

            //Вивести к-сть машин віком не менше 3х років
            queries.GetVehiclesOlderThan3Years();

            //Вивести усіх водіїв що не мають прав на жодну машину
            queries.GetDriversWithoutLicense();

            //Вивести усі авто бренду Audi окрім чорних
            queries.GetAllAudiExceptBlack();

            //Вивести виробника та кількість моделей, що були ними вироблені
            queries.GetManufacturerAndModelsQuantity();

            //Вивести середній рік випуску авто та їх загальну кількість
            queries.GetAverageVehiclesYearOfIssueAndQuantity();

            //Вивести водіїв, котрі володіють двома або більше авто
            queries.GetDriversWith2AndMoreVehicles();

            //Вивести усі можливі кольори авто виробника Volkswagen
            queries.GetAllColorsOfVolkswagen();

            //Вивести тільки модель авто з унікальним виробником
            queries.GetUniqueModelOfManufacturer();
            Console.ReadKey();
        }
    }
}