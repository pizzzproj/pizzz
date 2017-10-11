//Data
var cities = [
    {
        
        city: 'Tampa',
        desc: 'In Florida',
            lat: 27.9506,
            long: -82.4572
    },
    {
        city: 'Sarasota',
        desc: 'The Heart of India!',
            lat: 27.3364,
            long: -82.5307
    },
    {
        
        city: 'Miami',
        desc: 'Bollywood city!',
            lat: 25.7617,
            long: -80.1918
    },
    {
        
        city: 'Tristan da Cunha',
        desc: 'Howrah Bridge!',
            lat: -37.1052,
            long: -12.2777
    }
];

//Angular App Module and Controller
var sampleApp = angular.module('mapsApp', []);
sampleApp.controller('MapCtrl', function ($scope) {

    var mapOptions = {
        zoom: 4,
        center: new google.maps.LatLng(27, -82),
        mapTypeId: google.maps.MapTypeId.TERRAIN
    }

    $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

    $scope.markers = [];

    var infoWindow = new google.maps.InfoWindow();

    var createMarker = function (info) {

        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(info.lat, info.long),
            title: info.city
        });
        marker.content = '<div class="infoWindowContent">' + info.desc + '</div>';

        google.maps.event.addListener(marker, 'click', function () {
            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);

    }

    for (i = 0; i < cities.length; i++) {
        createMarker(cities[i]);
    }

    $scope.openInfoWindow = function (e, selectedMarker) {
        e.preventDefault();
        google.maps.event.trigger(selectedMarker, 'click');
    }

});