using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Food
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public double _price { get ; set;}
        public string _foodType { get; set; }

        public Food()
        {
            _id = 0;
            _name = "";
            _price = 0;
            _foodType = "";
        }


    }
}
