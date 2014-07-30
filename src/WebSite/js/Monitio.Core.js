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
    
    $scope.isUserLogged = function()
    {
        if($rootScope.currentUser) return true;
        return false;
    }
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

MonitioApp.controller('HomeController', ['$scope', '$rootScope', function($scope, $rootScope) {
    initializeFullCalendar();
    $scope.addNewEventWindow = initializeDialogs();
    $rootScope.fullCalendar = $('#calendar').data("fullCalendar").getCalendar();
    var addEvent = function() {
        $rootScope.fullCalendar.addEventSource([{title: 'event2', start: '2014-07-29'}]);
    };
    
    var bindDayClickEvent = function() {
        $rootScope.fullCalendar.options.dayClick = function() {$scope.addNewEventWindow.dialog("open");}
    };
    
    addEvent();
    bindDayClickEvent();
}]);

MonitioApp.factory('AuthService', function() {
    this.login = function(credentials) {
    }
});

function initializeFullCalendar()
{
    $('#calendar').fullCalendar({
        header: {
				left: 'prev,next',
				center: 'title',
				right: 'month,agendaWeek,agendaDay'
			},
        events:[{title: 'event1', start : '2014-07-30'}],
        dayClick: function() { alert('day click');}
        
    });
}

function initializeDialogs() {
var dialog = $( "#eventForm" ).dialog({
      autoOpen: false,
      height: 300,
      width: 350,
      modal: true,
      buttons: {
        "Add new event": function() { return true; },
        Cancel: function() {
          dialog.dialog( "close" );
        }
      },
      close: function() {
        //form[ 0 ].reset();
        //allFields.removeClass( "ui-state-error" );
      }
    });
    return dialog;
}