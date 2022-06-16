using System;

namespace RestaurantAPI.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string m) : base(m)
        {

        }
    }
}
