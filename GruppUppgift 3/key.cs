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
       
        public Exit OpenExits { get; set; }
        public bool OpensExits { get; set; }

       

        public Key(string name, string description, string function, bool opensExists) : base(name, description, function)
        {

            OpensExits = opensExists;
        }

    


        }
        
        
        
    




    }

