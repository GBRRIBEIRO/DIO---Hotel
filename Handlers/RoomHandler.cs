using Hotel_Hosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Hosting.Handlers
{
    public static class RoomHandler
    {
        public static int Counter { get; set; } = 0;
        public static List<Room> Rooms { get; set; } = new List<Room>();
    }
}
