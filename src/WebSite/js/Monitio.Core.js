/// <reference path="./angular.min.js" />

var MonitioApp = angular.module('MonitioApp', ['ngRoute', 'ngResource']);

MonitioApp.config(['$routeProvider',
function($routeProvider) {
	$routeProvider.when('/', {
	   templateUrl : 'home.html',
		controller : 'HomeController'
    }).when('/home', {
		templateUrl : 'home.html',
		controller : 'HomeController'
	}).when('/logon', {
		templateUrl : 'logon.html',
		controller : 'LogonController'
	}).otherwise({
		redirectTo : '/logon'
	});
}]);

MonitioApp.controller('MonitioAppController', ['$scope', '$location', '$rootScope', function($scope, $location, $rootScope) { 
    $rootScope.setCurrentUser = function(user){
        $rootScope.currentUser = user;
    };
    
    $rootScope.$on('$routeChangeStart', function(scope, next, current) {
        if ($rootScope.currentUser) {
        } else {
            $location.path('/logon');
        }
    });
}]);

MonitioApp.controller('LogonController', ['$scope', '$rootScope', '$location', 'AuthService', function($scope, $rootScope, $location, AuthService) {
  $scope.credentials = {
    username: '',
    password: ''
  };

  $scope.login = function (credentials) {
      if (credentials.username && credentials.password)
      {
        // mock only
        if (credentials.username == "test" && credentials.password == "test")
        {
            $rootScope.setCurrentUser(credentials);
            $location.path('/home');
        }
      }
  };
}]);

MonitioApp.controller('HomeController', ['$scope', function($scope) {}]);

MonitioApp.factory('AuthService', function() {
    this.login = function(credentials) {
    }
});

MonitioApp.factory('Session', function($http) {
  var Session = {
    data: {}
  };
  Session.updateSession();
  return Session; 
});

$(function() {
    $("input[type='submit']").click(function(event) { event.preventDefault(); });
});