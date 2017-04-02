using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAssetTechnicalTest.Controllers;
using IAssetTechnicalTest.Models;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;
using IAssetTechnicalTest.Services;
using System.Collections.Generic;
using IAssetTechnicalTest.Constants;

namespace IAssetTechnicalTest.Tests.Controllers
{
    [TestClass]
    public class WeatherControllerTest
    {
        public Mock<IGlobalWeatherService> globalWeatherService;
        string returnString = string.Empty;

        [TestInitialize]
        public void Init()
        {
            globalWeatherService = new Mock<IGlobalWeatherService>();
            returnString = "<string xmlns=\"http://www.webserviceX.NET\">\r\n<NewDataSet> <Table> <Country>British Indian Ocean Territory</Country> <City>Diego Garcia</City> </Table> <Table> <Country>India</Country> <City>Ahmadabad</City> </Table> <Table> <Country>India</Country> <City>Akola</City> </Table> <Table> <Country>India</Country> <City>Aurangabad Chikalthan Aerodrome</City> </Table> <Table> <Country>India</Country> <City>Bombay / Santacruz</City> </Table> <Table> <Country>India</Country> <City>Bilaspur</City> </Table> <Table> <Country>India</Country> <City>Bhuj-Rudramata</City> </Table> <Table> <Country>India</Country> <City>Belgaum / Sambra</City> </Table> <Table> <Country>India</Country> <City>Bhopal / Bairagarh</City> </Table> <Table> <Country>India</Country> <City>Bhaunagar</City> </Table> <Table> <Country>India</Country> <City>Goa / Dabolim Airport</City> </Table> <Table> <Country>India</Country> <City>Indore</City> </Table> <Table> <Country>India</Country> <City>Jabalpur</City> </Table> <Table> <Country>India</Country> <City>Khandwa</City> </Table> <Table> <Country>India</Country> <City>Kolhapur</City> </Table> <Table> <Country>India</Country> <City>Nagpur Sonegaon</City> </Table> <Table> <Country>India</Country> <City>Rajkot</City> </Table> <Table> <Country>India</Country> <City>Sholapur</City> </Table> <Table> <Country>India</Country> <City>Agartala</City> </Table> <Table> <Country>India</Country> <City>Siliguri</City> </Table> <Table> <Country>India</Country> <City>Bhubaneswar</City> </Table> <Table> <Country>India</Country> <City>Calcutta / Dum Dum</City> </Table> <Table> <Country>India</Country> <City>Car Nicobar</City> </Table> <Table> <Country>India</Country> <City>Gorakhpur</City> </Table> <Table> <Country>India</Country> <City>Gauhati</City> </Table> <Table> <Country>India</Country> <City>Gaya</City> </Table> <Table> <Country>India</Country> <City>Imphal Tulihal</City> </Table> <Table> <Country>India</Country> <City>Jharsuguda</City> </Table> <Table> <Country>India</Country> <City>Jamshedpur</City> </Table> <Table> <Country>India</Country> <City>North Lakhimpur</City> </Table> <Table> <Country>India</Country> <City>Dibrugarh / Mohanbari</City> </Table> <Table> <Country>India</Country> <City>Port Blair</City> </Table> <Table> <Country>India</Country> <City>Patna</City> </Table> <Table> <Country>India</Country> <City>M. O. Ranchi</City> </Table> <Table> <Country>India</Country> <City>Agra</City> </Table> <Table> <Country>India</Country> <City>Allahabad / Bamhrauli</City> </Table> <Table> <Country>India</Country> <City>Amritsar</City> </Table> <Table> <Country>India</Country> <City>Varanasi / Babatpur</City> </Table> <Table> <Country>India</Country> <City>Bareilly</City> </Table> <Table> <Country>India</Country> <City>Kanpur / Chakeri</City> </Table> <Table> <Country>India</Country> <City>New Delhi / Safdarjung</City> </Table> <Table> <Country>India</Country> <City>New Delhi / Palam</City> </Table> <Table> <Country>India</Country> <City>Gwalior</City> </Table> <Table> <Country>India</Country> <City>Hissar</City> </Table> <Table> <Country>India</Country> <City>Jhansi</City> </Table> <Table> <Country>India</Country> <City>Jodhpur</City> </Table> <Table> <Country>India</Country> <City>Jaipur / Sanganer</City> </Table> <Table> <Country>India</Country> <City>Kota Aerodrome</City> </Table> <Table> <Country>India</Country> <City>Lucknow / Amausi</City> </Table> <Table> <Country>India</Country> <City>Satna</City> </Table> <Table> <Country>India</Country> <City>Udaipur Dabok</City> </Table> <Table> <Country>India</Country> <City>Bellary</City> </Table> <Table> <Country>India</Country> <City>Vijayawada / Gannavaram</City> </Table> <Table> <Country>India</Country> <City>Coimbatore / Peelamedu</City> </Table> <Table> <Country>India</Country> <City>Cochin / Willingdon</City> </Table> <Table> <Country>India</Country> <City>Cuddapah</City> </Table> <Table> <Country>India</Country> <City>Hyderabad Airport</City> </Table> <Table> <Country>India</Country> <City>Madurai</City> </Table> <Table> <Country>India</Country> <City>Mangalore / Bajpe</City> </Table> <Table> <Country>India</Country> <City>Madras / Minambakkam</City> </Table> <Table> <Country>India</Country> <City>Tiruchchirapalli</City> </Table> <Table> <Country>India</Country> <City>Thiruvananthapuram</City> </Table> <Table> <Country>India</Country> <City>Vellore</City> </Table> </NewDataSet>\r\n</string>";
        }

        [TestMethod]
        public void Test_CitiesByCountry_WithNonNullCountry()
        {
            // Arrange
            globalWeatherService.Setup(x => x.GetCitiesByCountry(It.IsAny<string>())).Returns(returnString);
            WeatherController controller = new WeatherController(globalWeatherService.Object);
            Country country = new Country()
            {
                CountryName = "Australia"
            };

            // Act
            IHttpActionResult result = controller.CitiesByCountry(country);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<string>>));
        }

        [TestMethod]
        public void Test_CitiesByCountry_WithNullCountry()
        {
            // Arrange
            globalWeatherService.Setup(x => x.GetCitiesByCountry(It.IsAny<string>())).Returns(returnString);
            WeatherController controller = new WeatherController(globalWeatherService.Object);
            Country country = new Country()
            {
                CountryName = null
            };

            controller.ModelState.AddModelError("countryError", "countryError");

            // Act
            IHttpActionResult result = controller.CitiesByCountry(country);

            // Assert
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void Test_WeatherByCity_WithNonNullWeather_Success()
        {
            // Arrange
            globalWeatherService.Setup(x => x.GetWeather(It.IsAny<string>(), It.IsAny<string>())).Returns(Constant.NotFound);
            WeatherController controller = new WeatherController(globalWeatherService.Object);
            string countryName = "Australia";
            string city = "Sydney";
            WeatherViewModel weather = new WeatherViewModel()
            {
                CountryName = countryName,
                SelectedCity = city,
                Location = "test",
                Time = "test",
                Wind = "test",
                SkyCondition = "test",
                Temprature = "test",
                DewPoint = "test",
                RelativeHumidity = "test",
                Pressure = "test"
            };

            // Act
            IHttpActionResult result = controller.WeatherByCity(weather);

            var contentResult = result as OkNegotiatedContentResult<WeatherViewModel>;

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<WeatherViewModel>));
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("Success", contentResult.Content.Pressure);
        }

        [TestMethod]
        public void Test_WeatherByCity_WithNonNullWeather_BadResuest()
        {
            // Arrange
            globalWeatherService.Setup(x => x.GetWeather(It.IsAny<string>(), It.IsAny<string>())).Returns("something else");
            WeatherController controller = new WeatherController(globalWeatherService.Object);
            WeatherViewModel weather = new WeatherViewModel()
            {
                CountryName = null,
                SelectedCity = null,
                Location = "test",
                Time = "test",
                Wind = "test",
                SkyCondition = "test",
                Temprature = "test",
                DewPoint = "test",
                RelativeHumidity = "test",
                Pressure = "test"
            };

            // Act
            IHttpActionResult result = controller.WeatherByCity(weather);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}
