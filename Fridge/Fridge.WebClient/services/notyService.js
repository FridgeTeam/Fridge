(function () {
    angular.module('app')

    .factory('notyService', function () {
        var notyService = {}

        function generate(type, text, time) {
            var n = noty({
                text: text,
                type: type,
                dismissQueue: true,
                layout: 'topCenter',
                theme: 'relax',
                maxVisible: 10,
                timeout: time
            });
        }

        function errorParse(errorObject) {
            var errorMessage = "";
            errorMessage += errorObject.Message + "</br>";

            for (var prop in errorObject.ModelState) {
                errorMessage += errorObject.ModelState[prop] + " "
            }

            return errorMessage;
        }

        notyService = {
            success: function success(text) {
                generate('success', text, 3000);
            },
            error: function error(textOrObject) {
                var isObject = angular.isObject(textOrObject);

                if (isObject) {
                    textOrObject = errorParse(textOrObject);
                }

                generate('error', textOrObject, 7000);
            },
            information: function (text) {
                generate('information', text, 7000);
            }
        }

        return notyService;
    })
}())