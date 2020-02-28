using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class VendingMachine
    {
        private decimal Balance { get; set;  }

        public  decimal GetBalance()
        {
            return Balance;
        }

        public  void AddCash(decimal value)
        {
            switch (value)
            {
                case 100.0M:
                case 50.0M:
                case 20.0M:
                case 10.0M:
                case 5.0M:
                case 1.0M:
                case 0.50M:
                case 0.25M:
                    Balance += value;
                    break;
                default:
                    throw new InvalidOperationException("Invalid value");

            }

            
        }
    }
}
