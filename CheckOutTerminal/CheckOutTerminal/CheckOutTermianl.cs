using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CheckOutTerminal

{
    public interface ICheckOutTerminalService
    {
        string CheckOut(string products);
    }
    public class CheckOutTerminalService : ICheckOutTerminalService
    {
        private readonly IPricingRepo _pricingRepo;
        private readonly IDictionary<string, int> _productDict;
        private IDictionary<string, PricingModel> _pricingDict;
        string message;

        public CheckOutTerminalService(IPricingRepo pricingRepo)
        {
            _pricingRepo = pricingRepo;
            _productDict = new Dictionary<string, int>();
            SetPricing();
            _productDict.Add("A", 0);
            _productDict.Add("B", 0);
            _productDict.Add("C", 0);
            _productDict.Add("D", 0);
        }

        Dictionary<string, decimal> productOrder = new Dictionary<string, decimal>();
        private void SetPricing()
        {
            _pricingDict = _pricingRepo.GetPricing();
        }

        public string CheckOut(string products)
        {
            if (string.IsNullOrWhiteSpace(products))
            {
                message = "sorry whitespace has been entered";
                return message;
            }
            checkRegex(products);
            countProducts(products);
            return ($" ${calculateTotal().ToString()} NZD");
        }

        private void checkRegex(string products)
        {
            string Pattern = "^[A-D][a-dA-D]*$";
            if (Regex.Match(products, Pattern).Success)
            {
                return;
            }
            else
            {
                Console.WriteLine("looks like an invalid char has been entered");
                
            }
        }

        private void countProducts(string products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                var pCode = products[i].ToString();
                switch (pCode)
                {
                    case "A":
                        if (_productDict.ContainsKey("A"))
                        {
                            _productDict[pCode]++;
                        }
                        break;
                    case "B":
                        if (_productDict.ContainsKey("B"))
                        {
                            _productDict[pCode]++;
                        }
                        break;
                    case "C":
                        if (_productDict.ContainsKey("C"))
                        {
                            _productDict[pCode]++;
                        }
                        break;
                    case "D":
                        if (_productDict.ContainsKey("D"))
                        {
                            _productDict[pCode]++;
                        }
                        break;
                }
            }
        }

        private decimal calculateTotal()
        {
            var total = 0m;

            foreach (var product in _productDict)
            {
                if (_pricingDict.TryGetValue(product.Key, out PricingModel price))
                {
                    var volumedTotal = (product.Value / price.VolumeSize) * price.VolumePrice;
                    var unitTotal = (product.Value % price.VolumeSize) * price.UnitPrice;
                    total += volumedTotal + unitTotal;
                }
            }
            return total;
        }

    }
}
