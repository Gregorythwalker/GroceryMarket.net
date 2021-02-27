using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CheckOutTerminal
{
    public interface ICheckOutTermainal
    {
        string CheckOut(string products);
    }
    public class CheckOutTerminal : ICheckOutTermainal
    {
        private readonly IPricingRepo _pricingRepo;
        private readonly IDictionary<string, int> _productDict;
        private IDictionary<string, PricingModel> _pricingDict;


        public CheckOutTerminal(IPricingRepo pricingRepo)
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
            ;
            if (string.IsNullOrWhiteSpace(products))
            {
                throw new NullReferenceException("Whitespace found");
            }
            checkRegex(products);
            countProducts(products);
            return calculateTotal().ToString();
        }

        private string checkRegex(string products)
        {
            string Pattern = "^[A-D][a-dA-D]*$";
            if (Regex.Match(products, Pattern).Success)
            {
                return Pattern;
            }
            else
            {
                Console.WriteLine("Invalid Character");
                throw new NullReferenceException("Invalid Character");
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
                    //calculate volumed total base on the total number of code and the volume size
                    var volumedTotal = (product.Value / price.VolumeSize) * price.VolumePrice;
                    var unitTotal = (product.Value % price.VolumeSize) * price.UnitPrice;

                    total += volumedTotal + unitTotal;
                }
            }
            return total;
        }

    }
}
