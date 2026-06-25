using System;


namespace TaxiApp.Models
{
    public class Route
    {
        public Guid Id { get; set; }
        public Guid StartingAddress { get; set; }
        public Guid DestinationAdress { get; set; }


    }
}
