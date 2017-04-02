using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAssetTechnicalTest.Controllers
{
    public class WeatherViewModel
    {
        public string CountryName { get; set; }
        public string SelectedCity { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Wind { get; set; }
        public string SkyCondition { get; set; }
        public string Temprature { get; set; }
        public string DewPoint { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
    }
}