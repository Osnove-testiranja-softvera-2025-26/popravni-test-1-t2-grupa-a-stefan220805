using System;
using System.Collections.Generic;
using TaxiApp.Models;

namespace TaxiApp.Services
{
    public interface IDriveService
    {
        List<Drive> GetAvalilableDrives(Guid addressFrom, Guid addressTo, DateTime time);
    }
}
