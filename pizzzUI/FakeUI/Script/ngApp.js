window.ngApp = (function () {
	'use strict';

	var na = angular.module('Pizzza', ['ngRoute']);

	na.config(['$routeProvider', '$locationProvider', function (pizz) {
		pizz
			.when('/home', {
			
}