var menu = angular.module('pizzz', []);
menu.controller('menuListCtrl', function ($scope, $http) {
	$http.get('http://ec2-34-207-116-9.compute-1.amazonaws.com/logic/item/item/')
		.then(function (response) {
			$scope.jsondata = response.data;
			console.log("status:" + response.status);
		}).catch(function (response) {
			console.error('Error occurred:', response.status, response.data);
		}).finally(function () {
			console.log("Task Finished.");
		});
});