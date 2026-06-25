using System;


namespace TaxiApp.Exceptions
{
    public class NoAvailableDriveExeption: Exception
    {
        public NoAvailableDriveExeption()
        {

        }

        public NoAvailableDriveExeption(string messsage): base(messsage)
        {

        }
    }
}
