using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Customer
    {
        public List<Food> _foodItem = new List<Food>();

        public double FoodCost()
        {
            double total = 0;
            for (int i = 0; i < _foodItem.Count(); i++)
            {
                total = _foodItem[i]._price + total;
            }

            return total;

        }
    }
}
