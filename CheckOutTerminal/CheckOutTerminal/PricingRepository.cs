using System.Collections.Generic;

namespace CheckOutTerminal
{
    public interface IPricingRepo
    {
        IDictionary<string, PricingModel> GetPricing();
    }
    public class PricingRepository : IPricingRepo
    {
        //implement interfaces for loose coupling
        public IDictionary<string, PricingModel> GetPricing()
        {
            //pricing dictionary - product letter is the key with value being the pricing object
            var pricing = new Dictionary<string, PricingModel>();
            pricing.Add("A", new PricingModel { ProductCode = "A", UnitPrice = 1.25m, VolumeSize = 3, VolumePrice = 3m });
            pricing.Add("B", new PricingModel { ProductCode = "B", UnitPrice = 4.25m, VolumeSize = 1, VolumePrice = 4.25m });
            pricing.Add("C", new PricingModel { ProductCode = "C", UnitPrice = 1.00m, VolumeSize = 6, VolumePrice = 5m });
            pricing.Add("D", new PricingModel { ProductCode = "D", UnitPrice = 0.75m, VolumeSize = 1, VolumePrice = 0.75m });
            return pricing;

        }
    }
}
