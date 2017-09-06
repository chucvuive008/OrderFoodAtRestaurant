using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Table
    {
        public List<Customer> _customer = new List<Customer>();
        public int _tableNumber { set; get; }

        public Table(int tNumber)
        {
            _tableNumber = tNumber;
        }

        public double TableReceipt()
        {
            double total = 0;
            for (int i = 0; i < _customer.Count(); i++)
            {
                total = _customer[i].FoodCost() + total;
            }

            return total;
        }
    }
}
