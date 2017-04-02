app.service("WeatherService", function ($http) {
    //Function to get all cities of the country
    this.getCitiesByCountry = function (Country) {
        var request = $http({
            method: "post",
            url: "api/Weather/CitiesByCountry",
            data: Country
        });
        return request;
    };

    //Function to get the weather info for a city
    this.getWeatherByCity = function (Weather) {
        var request = $http({
            method: "post",
            url: "api/Weather/WeatherByCity",
            data: Weather
        });
        return request;
    };
});








