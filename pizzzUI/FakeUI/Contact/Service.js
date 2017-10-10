(function (na) {
	'use strict';

	na.service('contactSvc', ['$http', function ($http) {
		return function(pass, fail) {
		var obj = $http({
			method: 'get',
			url: 'ec2-34-207-116-9.compute-1.amazonaws.com/logic/item/item',
			headers: {
				'Allow': 'GET'
			}
		})

		obj.then(pass, fail);
	}
	}]);
})(window.ngApp);