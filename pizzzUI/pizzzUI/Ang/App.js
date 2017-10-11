var App = angular.module('App', ['ngRoute']);

App.controller('menuListCtrl', MenuListCtrl);

var configure = function ($routeProvider, $httpProvider) {
	$routeProvider.
		when('/menu', {
			templateUrl: 'menu.html',
			controller: menuListCtrl
		});
}

App.config(configure);

