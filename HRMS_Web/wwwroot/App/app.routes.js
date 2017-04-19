/// <reference path="angular.js" />
/// <reference path="app.module.js" />

(function () {
    
    app.config(['$routeProvider', '$locationProvider',
function ($routeProvider, $locationProvider) {

    $locationProvider.hashPrefix('');

    //================================================
    // Routes
    //================================================
    $routeProvider.when('/templatesMaster', {
        templateUrl: 'App/Components/Templates/templatesMaster.html',
        controller: 'templatesMasterController'
    }).when('/templateCreate', {
        templateUrl: 'App/Components/Templates/templateCreate.html',
        controller: 'templateCreateController'
    }).when('/employee/:empId', {
        templateUrl: 'App/Components/Employee/EmployeeDetails.html',
        controller: 'EmployeeDetailController'
    }).otherwise({
        redirectTo: '/'
    });
}]);

})();
