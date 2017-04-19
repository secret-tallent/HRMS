/// <reference path="../../angular.js" />
/// <reference path="../../app.module.js" />
const Templates_API_PATH = 'http://localhost:56977/api/templates/';
const TemplateColumns_API_PATH = 'http://localhost:56977/api/templateColumns/';

app.service('templateService', function ($http) {

    this.message = '';

    this.getAllTemplates = function () {
        return $http.get(Templates_API_PATH);
    }

    //Get All Template Columns
    this.getTemplateColumns = function (templateId) {
        return $http.get(TemplateColumns_API_PATH + templateId );
    }


    //Update template Columns
    this.updateTemplateColumns = function (UITemplates) {
        var request = $http({
            method: "put",
            url: TemplateColumns_API_PATH,
            data: UITemplates
        });
        return request;
    }
});
