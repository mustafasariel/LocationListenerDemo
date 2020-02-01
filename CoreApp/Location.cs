using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lan { get; set; }
        public string Description { get; set; }
    }
}
