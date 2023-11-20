using Hotel_Hosting.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Hosting.Models
{
    public class Room
    {
        public Room(string name, int quantityOfBeds)
        {
            RoomHandler.Counter++;
            Id = RoomHandler.Counter;
            Name = name;
            QuantityOfBeds = quantityOfBeds;
            RoomHandler.Rooms.Add(this);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityOfBeds { get; set; }

    }
}
