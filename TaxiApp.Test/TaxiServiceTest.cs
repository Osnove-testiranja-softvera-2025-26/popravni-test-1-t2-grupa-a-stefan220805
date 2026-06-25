using NUnit.Framework;
using System;
using TaxiApp.Exceptions;
using TaxiApp.Fakes;
using TaxiApp.Models;
using TaxiApp.Services;

namespace TaxiApp.Test
{
    [TestFixture]
    public class TaxiServiceTest
    {
        [Test]
        public void AssignDrive_Count0()
        {
            FakeDriverService driverService = new FakeDriverService();
            FakeDriveService driveService = new FakeDriveService();
            FakeZoneService zoneService = new FakeZoneService();
            TaxiService taxiService = new TaxiService(zoneService, driveService, driverService);
            Address address1 = new Address();
            Address address2 = new Address();
            DateTime time1 = DateTime.UtcNow;


            Assert.Throws<NoAvailableDriveExeption>((TestDelegate)(() => taxiService.AssignDrive(address1, address2, time1)));
           
        }

        [Test]
        public void CalculateCrowdFactor_Rainy()
        {
            FakeDriverService driverService = new FakeDriverService();
            FakeDriveService driveService = new FakeDriveService();
            FakeZoneService zoneService = new FakeZoneService();
            TaxiService taxiService = new TaxiService(zoneService, driveService, driverService);

            int result = taxiService.CalculateCrowdFactor(Zone.Red, 14, 2, WeatherConditions.Rainy, false);

            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void CalculateCrowdFactor_Rainy_AndRed_AndNumOfInteractionsGreaterThan10()
        {
            FakeDriverService driverService = new FakeDriverService();
            FakeDriveService driveService = new FakeDriveService();
            FakeZoneService zoneService = new FakeZoneService();
            TaxiService taxiService = new TaxiService(zoneService, driveService, driverService);

            int result = taxiService.CalculateCrowdFactor(Zone.Red, 14, 12, WeatherConditions.Rainy, true);

            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void CalculateCrowdFactor_Rainy_AndRed_AndNumOfInteractionsGreaterThan10_AndRailwayCrossingTrue()
        {
            FakeDriverService driverService = new FakeDriverService();
            FakeDriveService driveService = new FakeDriveService();
            FakeZoneService zoneService = new FakeZoneService();
            TaxiService taxiService = new TaxiService(zoneService, driveService, driverService);

            int result = taxiService.CalculateCrowdFactor(Zone.Red, 14, 12, WeatherConditions.Rainy, false);

            Assert.That(result, Is.EqualTo(45));
        }

        [Test]
        public void CalculateCrowdFactor_Rainy_AndBlue_AndHourGreaterThen7_AndLessThen9()
        {
            FakeDriverService driverService = new FakeDriverService();
            FakeDriveService driveService = new FakeDriveService();
            FakeZoneService zoneService = new FakeZoneService();
            TaxiService taxiService = new TaxiService(zoneService, driveService, driverService);

            int result = taxiService.CalculateCrowdFactor(Zone.Blue, 7, 12, WeatherConditions.Rainy, false);

            Assert.That(result, Is.EqualTo(35));
        }

        [Test]
        public void CalculateCrowdFactor_Stormy()
        {
            FakeDriverService driverService = new FakeDriverService();
            FakeDriveService driveService = new FakeDriveService();
            FakeZoneService zoneService = new FakeZoneService();
            TaxiService taxiService = new TaxiService(zoneService, driveService, driverService);

            int result = taxiService.CalculateCrowdFactor(Zone.Red, 14, 12, WeatherConditions.Stormy, false);

            Assert.That(result, Is.EqualTo(45));
        }

        [Test]
        public void CalculateCrowdFactor_Stormy_AndZoneGreen_AndNumOfInteractionsGreaterThen3()
        {
            FakeDriverService driverService = new FakeDriverService();
            FakeDriveService driveService = new FakeDriveService();
            FakeZoneService zoneService = new FakeZoneService();
            TaxiService taxiService = new TaxiService(zoneService, driveService, driverService);

            int result = taxiService.CalculateCrowdFactor(Zone.Green, 14, 4, WeatherConditions.Stormy, false);

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void AssignDrive_Test()
        {
            FakeDriverService driverService = new FakeDriverService();
            FakeDriveService driveService = new FakeDriveService();
            FakeZoneService zoneService = new FakeZoneService();
            TaxiService taxiService = new TaxiService(zoneService, driveService, driverService);
            //Zone driveZone1 = zoneService.ServiceType();
            DateTime time1 = DateTime.UtcNow;

            //Assert.That(taxiService.AssignDrive())
        }
    }
}
