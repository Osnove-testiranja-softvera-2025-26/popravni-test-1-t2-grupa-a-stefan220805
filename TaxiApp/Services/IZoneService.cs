using System;
using TaxiApp.Models;

namespace TaxiApp.Services
{
    public interface IZoneService
    {
        Zone CheckZone(Guid addressFrom, Guid addressTo);
    }
}
