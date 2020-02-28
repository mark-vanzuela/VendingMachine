using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachine
    {
        public VendingMachine()
        {
            Balance = 0;
            SelectedProduct = string.Empty;
            _products = new Dictionary<string, decimal>()
            {
                {"Coke", 25.0M },
                {"Pepsi", 35.0M },
                {"Soda", 45.0M },
                {"ChocolateBar", 20.25M },
                {"ChewingGum", 10.50M },
                {"BottledWater", 15.0M },
            };
        }

        private decimal Balance { get; set;  }
        private string SelectedProduct { get; set; }

        private readonly Dictionary<string, decimal> _products;

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

        public  string GetSelectedProduct()
        {
            return SelectedProduct;
        }

        public void SelectProduct(string name)
        {
            if (_products.ContainsKey(name))
            {
                SelectedProduct = name;
            }
            else
            {
                throw new InvalidOperationException("Invalid Product");
            }
        }

        public decimal Refund()
        {
            var refund = Balance;
            Balance = 0;
            SelectedProduct = string.Empty;
            return refund;
        }

        public  Tuple<string, decimal> Purchase()
        {
            if(Balance < _products[SelectedProduct])
                throw new InvalidOperationException("Insufficient balance to purchase selected product.");
            var change = Balance - _products[SelectedProduct];
            var result =  new Tuple<string, decimal>(SelectedProduct, change);
            Balance = 0;
            SelectedProduct = string.Empty;
            return result;
        }
    }
}
