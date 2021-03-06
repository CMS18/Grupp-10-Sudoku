﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> roomItems { get; set; } = new List<Item>();
        public List<Door> Exits { get; set; } = new List<Door>();

        public Room()
        {

        }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddExit(Door exit)
        {
            Exits.Add(exit);
        }

        public void AddItem(Item item)
        {
            roomItems.Add(item);
        }

      
    }
}
