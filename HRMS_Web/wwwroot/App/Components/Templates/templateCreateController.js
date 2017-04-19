/// <reference path="../../angular.js" />
/// <reference path="../../app.module.js" />
/// <reference path="templateService.js" />
//The controller is having 'EmployeeService' dependency.
//This controller makes call to methods from the service 

function UITemplates(templateId, templateName, templateColumns)
{
    this.TemplateId = templateId;
    this.TemplateName = templateName;
    this.TemplateColumns = templateColumns;
}

app.controller('templateCreateController', function ($scope, $location, templateService) {
    
    //$scope.IsNewRecord = 1; //The flag for the new record
    //$scope.Message = employeeService.message;
    loadRecords();

    //Function to load all Employee records
    function loadRecords() {
        var promiseGet = templateService.getTemplateColumns(); //The MEthod Call from service

        promiseGet.then(function (templates) {
            $scope.TemplateColumns = templates.data;
            $scope.UITemplates = new UITemplates(0, '', $scope.TemplateColumns);
        },
              function (errorPl) {
                  $log.error('failure loading Employee', errorPl);
              });
    }

    //Method to Get Single Employee based on EmpNo
    $scope.save = function () {
        if ($scope.UITemplates.TemplateName != "" && $scope.UITemplates.TemplateName != null) {
            templateService.updateTemplateColumns($scope.UITemplates);
        }
        else {
            $scope.Message = 'Template Name is required';
        }
        
    }

});