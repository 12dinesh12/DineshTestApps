app.controller("WeatherController", function ($scope, $http, WeatherService) {

    $scope.showWeatherTable = false;
    $scope.error = "";

    //This method will fetch the cities for country
    $scope.GetAllCitiesByCountry = function () {

        if ($scope.CountryName === undefined) return;

        var Country = {
            CountryName: $scope.CountryName,
        };
        
        var promisePost = WeatherService.getCitiesByCountry(Country);
        promisePost.then(function (data) {
            if (data.data.includes('Not able to fetch record')){
                $scope.error = "No Data Found";
                return;
            }
            $scope.Cities = data.data;
            $scope.error = "";
        },
         function (errorPl) {
             $scope.error = 'failure loading Cities', errorPl;
         });

    };

    //This method will fetch the weather info for city of a country on combo box value changed
    $scope.CityValueChanged = function (city) {
        
        if (city === null) {
            $scope.showWeatherTable = false;
            return;
        }
        
        var Weather = {  
            CountryName: $scope.CountryName,
            SelectedCity : city
        };

        var promise = WeatherService.getWeatherByCity(Weather);
        promise.then(function (data) {
            PopulateWeatherData(data)
            $scope.showWeatherTable = true;
            $scope.error = "";
        },
        function (errorPl) {
             $scope.error = 'failure loading weather Info', errorPl;
         });
    };

    function PopulateWeatherData(data) {
       $scope.Location = data.data.Location;
       $scope.Time = data.data.Time
       $scope.Wind = data.data.Wind;
       $scope.SkyCondition = data.data.SkyCondition;
       $scope.Temprature =data.data.Temprature;
       $scope.DewPoint = data.data.DewPoint;
       $scope.RelativeHumidity = data.data.RelativeHumidity;
       $scope.Pressure = data.data.Pressure;
    }
});