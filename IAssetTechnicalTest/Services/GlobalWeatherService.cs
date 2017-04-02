using IAssetTechnicalTest.GlobalWeatherServiceRef;

namespace IAssetTechnicalTest.Services
{
    /// <summary>
    /// this class is created to show the dependency Injection using Ninject Module and to enable mocking for Unit testing
    /// </summary>
    public class GlobalWeatherService : IGlobalWeatherService
    {
        GlobalWeatherSoapClient globalWeatherService = new GlobalWeatherSoapClient("GlobalWeatherSoap");
        public string GetCitiesByCountry(string country)
        {
            return globalWeatherService.GetCitiesByCountry(country);
        }

        public string GetWeather(string city, string country)
        {
            return globalWeatherService.GetWeather(city, country);
        }
    }
}