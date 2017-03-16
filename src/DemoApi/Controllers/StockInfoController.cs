using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Web.Http;

namespace DemoApi.Controllers
{
    public class StockInfoController : ApiController
    {
        // GET: http://localhost:30321/OrchardLocal/api/DemoApi/StockInfo/A
        public IEnumerable<LocationStockInfo> Get(string id)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5)); // So we can see what's going on in the browser.

            switch (id)
            {
                case "A":
                    return new[]
                    {
                        new LocationStockInfo("Gothenburg", "Sweden", 5),
                        new LocationStockInfo("Stockholm", "Sweden", 36),
                        new LocationStockInfo("Malmö", "Sweden", 10),
                        new LocationStockInfo("New York", "United States", 75),
                        new LocationStockInfo("Atlanta", "United States", 20),
                        new LocationStockInfo("Munich", "Germany", 0)
                    };
                case "B":
                    return new[]
                    {
                        new LocationStockInfo("Gothenburg", "Sweden", 0),
                        new LocationStockInfo("Stockholm", "Sweden", 0),
                        new LocationStockInfo("Malmö", "Sweden", 2),
                        new LocationStockInfo("New York", "United States", 0),
                        new LocationStockInfo("Atlanta", "United States", 0),
                        new LocationStockInfo("Munich", "Germany", 5)
                    };
                default:
                    throw new Exception($"Unrecognized product ID '{id}'.");
            }
        }
    }

    [DataContract]
    public class LocationStockInfo
    {
        public LocationStockInfo(string city, string country, int unitsInStock)
        {
            City = city;
            Country = country;
            UnitsInStock = unitsInStock;
        }

        [DataMember]
        public string City;
        [DataMember]
        public string Country;
        [DataMember]
        public int UnitsInStock;
    }
}