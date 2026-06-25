using System;


namespace TaxiApp.Models
{
    public class Drive: IComparable
    {
        public Guid RouteId { get; set; }
        public Guid DriverId { get; set; }
        public DateTime Time { get; set; }
        public double Distance { get; set; }
        public int EstimatedTotalTravelTimeInMinutes { get; set; }
        public int EstimatedStopTimeInMinutes { get; set; }
        public int EstimatedWaitTimeInMinutes { get; set; }
        public double StartingPrice { get; set; }
        public bool Assigned { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 0;
            Drive otherDrive = obj as Drive;
            return EstimatedWaitTimeInMinutes - otherDrive.EstimatedWaitTimeInMinutes;
        }

    }
}
