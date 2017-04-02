using IAssetTechnicalTest.GlobalWeatherServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAssetTechnicalTest.Services
{
    //Created rhis interaface so that i can show dependency injection using Ninject.
    //ALso it would be easy to mock this service when writing the unit tests.
    public interface IGlobalWeatherService
    {
        string GetCitiesByCountry(string country);

        string GetWeather(string city, string country);
    }
}
