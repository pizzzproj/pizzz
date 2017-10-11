angular
	.module('pizzz', [])
	.controller('menuCtrl', function ($scope, $http, $log) {

	var successCallBack = function (response) {
		$scope.employees = response.data;
	};

	var errorCallBack = function (response) {
		$scope.error = response.data;
	}

	$http({
		method: 'GET',
		url: 'http://ec2-34-207-116-9.compute-1.amazonaws.com/logic/item/item/'
	})
		.then(successCallBack, errorCallBack);
})(window.ngApp);