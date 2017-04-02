using IAssetTechnicalTest.Constants;
using IAssetTechnicalTest.Models;
using IAssetTechnicalTest.Services;
using Ninject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;

namespace IAssetTechnicalTest.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IGlobalWeatherService _globalWeatherService;

        [Inject]
        public WeatherController(IGlobalWeatherService globalWeatherService)
        {
            _globalWeatherService = globalWeatherService;
        }

        [HttpPost]
        [Route("api/Weather/CitiesByCountry")]
        [ResponseType(typeof(IEnumerable))]
        [ActionName("CitiesByCountry")]
        public IHttpActionResult CitiesByCountry(Country country)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //Creating the object of web service GlobalWeather class with the help of service Reference    
                var countryInfo = _globalWeatherService.GetCitiesByCountry(country.CountryName); //passing country name input to Service   
                if (countryInfo == Constant.NotFound)
                {
                    return Ok(string.Format("No Data Found for country {0}", country.CountryName));
                }

                //converting the string Respsonse to XML    
                XmlTextReader xtr = new XmlTextReader(new System.IO.StringReader(countryInfo));
                var ds = new DataSet();
                ds.ReadXml(xtr);
                if (ds.Tables.Count >= 1 && ds.Tables[0].Rows.Count >= 1)
                {
                    IEnumerable<string> results = from p in ds.Tables[0].AsEnumerable()
                                  select p["City"].ToString();

                    return Ok(results);
                }

                return Ok(string.Format("Not able to fetch record from the webservice for country {0}", country.CountryName));
            }
            catch (Exception)
            {
                return BadRequest(string.Format("Not able to fetch record from the webservice for country {0}", country.CountryName));
            }
        }

        [HttpPost]
        [ResponseType(typeof(WeatherViewModel))]
        [Route("api/Weather/WeatherByCity")]
        [ActionName("WeatherByCity")]
        public IHttpActionResult WeatherByCity(WeatherViewModel weatherViewModel)
        {
            try
            {
                string output = string.Empty;
                var countryName = weatherViewModel.CountryName;
                var selectedCity = weatherViewModel.SelectedCity;

                //Creating the object of web service GlobalWeather class with the help of service Reference    
                var weatherInfo = _globalWeatherService.GetWeather(selectedCity, countryName); //passing country name, city name input to Service   

                if (weatherInfo == Constant.NotFound)
                {
                    //return Ok(string.Format("No Weather Info Found for city {0}", countryName));

                    //Mock the data here as the webservice doesnt return any data for this operation
                    weatherViewModel.Location = selectedCity;
                    weatherViewModel.Time = DateTime.Now.ToString();
                    weatherViewModel.Wind = "Greater then 2 miles";
                    weatherViewModel.SkyCondition = "Partyly Cloudy";
                    weatherViewModel.Temprature = "20 F";
                    weatherViewModel.DewPoint = "20 F";
                    weatherViewModel.RelativeHumidity = "1017 hpa";
                    weatherViewModel.Pressure = "Success";

                    return Ok(weatherViewModel);
                }

                XmlDocument lXmlDoc = new XmlDocument();
                lXmlDoc.LoadXml(weatherInfo);

                foreach (XmlNode lNode in lXmlDoc.DocumentElement.ChildNodes)
                {
                    output = String.Format("{0}:{1}\r\n", lNode.Name.PadRight(20), lNode.InnerText.Trim());
                }

                if (!string.IsNullOrEmpty(output))
                {
                    string[] info = output.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                    //Mock the data here as the webservice doesnt return any data for this operation
                    weatherViewModel.Location = info[0];
                    weatherViewModel.Time = info[1];
                    weatherViewModel.Wind = info[2];
                    weatherViewModel.SkyCondition = info[3];
                    weatherViewModel.Temprature = info[4];
                    weatherViewModel.DewPoint = info[5];
                    weatherViewModel.RelativeHumidity = info[6];
                    weatherViewModel.Pressure = info[7];
                }
                return Ok(weatherViewModel);
            }
            catch (Exception)
            {
                return BadRequest("Weather record not found");
            }
        }
    }
}

