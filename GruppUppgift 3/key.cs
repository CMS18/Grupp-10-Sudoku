using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppUppgift_3
{
    public class Key : Item
    {
        Item keys = new Item();

        public Door OpenExits { get; set; }
        public int Id { get; set; }



        public Key(string name, string description, string function,
            int id) : base(name, description, function)
        {

            Id = id;
        }

    }

}

