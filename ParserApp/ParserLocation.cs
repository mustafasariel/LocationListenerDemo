using CoreApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParserApp
{
    public class ParserLocation : IParser
    {
        public IEntity GetParser(byte[] byteData)
        {
            var message = Encoding.UTF8.GetString(byteData);
            Location location = new Location();

            location.Description = message;
            location.Lan = 41;
            location.Lat = 28;
            return location;
        }
    }
}
