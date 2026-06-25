using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Exceptions;
using TaxiApp.Models;
using TaxiApp.Services;

namespace TaxiApp.Fakes
{
    public class FakeDriveService : IDriveService
    {
        public NoAvailableDriveExeption ex {  get; set; }
        public List<Drive> GetAvalilableDrives(Guid addressFrom, Guid addressTo, DateTime time)
        {
            if(ex == null)
            {
                ex = new NoAvailableDriveExeption();
            }
            Drive drive = new Drive();
            drive.RouteId = Guid.Parse("c35651de-9294-4ddf-92ad-31e2836cac52");
            drive.DriverId = Guid.Parse("c664abb5-096b-4770-8461-60ec4edd9d67");
            drive.Time = time;
            drive.Distance = 20;
            drive.EstimatedWaitTimeInMinutes = 15;
            drive.EstimatedStopTimeInMinutes = 10;
            drive.StartingPrice = 100;
            drive.Assigned = true;
            List<Drive> drives = new List<Drive>((IEnumerable<Drive>)drive);
            return drives;
        }
    }
}
