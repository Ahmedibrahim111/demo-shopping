using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.VM
{
    public class ItemVm
    {

        public string name { get; set; } 
        public string price { get; set; }
        public string size { get; set; }
        public int id { get; set; }
        public string attachement { get; set; }

        
    }
    public class ItemEditVm
    {

        public string name { get; set; }
        public string price { get; set; }
        public string size { get; set; }
        public int id { get; set; }
        public string attachement { get; set; }


    }
}
