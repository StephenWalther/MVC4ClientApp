
(function (global) {
    "use strict";




    /* Knockout Extensions */
    // http://www.aaronkjackson.com/2012/04/formatting-dates-with-knockoutjs/
    global.ko.bindingHandlers.dateString = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var value = valueAccessor(),
                allBindings = allBindingsAccessor();
            var valueUnwrapped = ko.utils.unwrapObservable(value);
            var pattern = allBindings.datePattern || 'MM/dd/yyyy';
            var dateValue = Date.parse(valueUnwrapped);
            $(element).text(dateValue.toString(pattern));
        }
    }


    /* Private */
    
    function invokeAction(controller, action, httpMethod, data) {
    ///<summary>Invokes an API Controller Action</summary>

        var dfd = new $.Deferred();
        var url = "/api/" + controller + "/" + action

        $.ajax({
            url: url,
            data: JSON.stringify(data),
            type: httpMethod,
            contentType: "application/json",
            dataType: "json",
            timeout: 15 * 1000,
            error: function (xhr, status, error) {
                if (error === "timeout") {
                    alert("timed out");
                }
            },
            statusCode: {
                // Success
                200: function (result) {
                    dfd.resolve(result);
                },
                // Validation error
                400: function (xhr) {
                    var result = JSON.parse(xhr.responseText);
                    var message = result.Message + "\n";
                    for (var key in result.ModelState) {
                        message += result.ModelState[key] + "\n";
                    };
                    alert(message);
                },
                // Unauthorized
                401: function (xhr) {
                    window.location.href = "/account/login"
                }
            }
        });

        return dfd.promise();
    }

    // Exports
    global.MyApp = {}; // Create MyApp namespace
    global.MyApp.ViewModels = {}; // Create ViewModels namespace
    global.MyApp.UIFramework = {
        invokeAction: invokeAction
    };

})(this);
