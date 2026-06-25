using System;
using System.Collections.Generic;
using TaxiApp.Exceptions;
using TaxiApp.Models;

namespace TaxiApp.Services
{
    public class TaxiService
    {
        private readonly IDriveService _driveService;
        private readonly IZoneService _zoneService;
        private readonly IDriverService _driverService;


        public TaxiService(IZoneService zoneService, IDriveService driveService, IDriverService driverService)
        {
            _zoneService = zoneService;
            _driveService = driveService;
            _driverService = driverService;
        }

        public TaxiService()
        {

        }

        public void AssignDrive(Address from, Address to, DateTime time)
        {
            List<Drive> availableDrives = _driveService.GetAvalilableDrives(from.Id, to.Id, time);
            if(availableDrives.Count == 0)
            {
                throw new NoAvailableDriveExeption("[AssignDrive] No available drivers for the drive.");
            }
            availableDrives.Sort();
            Drive shortestWaitDrive = availableDrives[0];
            Zone driveZone = _zoneService.CheckZone(from.Id, to.Id);

            
            if(driveZone.Equals(Zone.Blue) && shortestWaitDrive.Distance > 1000.0) 
            {
                if(shortestWaitDrive.EstimatedWaitTimeInMinutes > 5) 
                {
                    shortestWaitDrive.StartingPrice = 3.5;
                }
                else
                {
                    shortestWaitDrive.StartingPrice = 3.0;
                }
            }

            else if (driveZone.Equals(Zone.Green)) 
            {
                if(shortestWaitDrive.EstimatedTotalTravelTimeInMinutes > 20 || shortestWaitDrive.Distance >= 1300) 
                {
                    shortestWaitDrive.StartingPrice = 4.0;
                }
                else
                {
                    shortestWaitDrive.StartingPrice = 3.5;
                }
            }
            else
            {
                shortestWaitDrive.StartingPrice = 2.0;
            }

            _driverService.AssignDriveToDriver(shortestWaitDrive);

        }


        public int CalculateCrowdFactor(Zone zone, int hour, int numOfInterections, WeatherConditions weatherConditions, bool railwayCrossing)
        {
            if (weatherConditions.Equals(WeatherConditions.Rainy))
            {
                if(zone.Equals(Zone.Red) && numOfInterections > 10)
                {
                    if(railwayCrossing)
                        return 45;
                    return 40;
                }
                else if (zone.Equals(Zone.Blue) && hour >= 7 && hour <= 9)
                {
                    return 35;
                }
                return 30;
            }
            else if (weatherConditions.Equals(WeatherConditions.Stormy))
            {
                if(zone.Equals(Zone.Green) && numOfInterections >= 3)
                    return 50;
                return 45;
            }
            
            return 0;
        }


        

        
    }
}
