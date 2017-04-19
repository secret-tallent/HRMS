/// <reference path="../../angular.js" />
/// <reference path="../../app.module.js" />
/// <reference path="templateService.js" />
//The controller is having 'EmployeeService' dependency.
//This controller makes call to methods from the service 

function UITemplates(templateId, templateName, templateColumns) {
    this.TemplateId = templateId;
    this.TemplateName = templateName;
    this.TemplateColumns = templateColumns;
}

app.controller('templatesMasterController', function ($scope, $location, templateService) {

    //$scope.IsNewRecord = 1; //The flag for the new record
    //$scope.Message = employeeService.message;
    loadRecords();

    //Function to load all Employee records
    function loadRecords() {
        var promiseGet = templateService.getAllTemplates(); //The MEthod Call from service

        promiseGet.then(function (templates) {
            $scope.Templates = templates.data;
            $scope.item = $scope.Templates[0].Id;
        },function (errorPl) {
                  $log.error('failure loading Employee', errorPl);
              });
    }

    $scope.updateColumns = function () {
        var templateId = $scope.item;
        templateService.getTemplateColumns(templateId).then(function (templates) {
            $scope.TemplateColumns = templates.data;
            $scope.UITemplates = new UITemplates($scope.item, '', $scope.TemplateColumns);
        }, function () { });
    }
    //Method to Get Single Employee based on EmpNo
    $scope.save = function () {
        templateService.updateTemplateColumns($scope.UITemplates);
        
    }

});