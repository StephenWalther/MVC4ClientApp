/// <reference path="../../Scripts/uiframework-1.0.js" />

(function (global) {
    "use strict";
   
    // Private
    function AccountViewModel() {
        var that = this;

        this.userName = ko.observable("");
        this.password = ko.observable("");

        this.login = function () {
            var data = {
                userName: this.userName(),
                password: this.password()
            };
            global.MyApp.UIFramework.invokeAction(
                "Account",
                "Authenticate",
                "POST",
                data
            ).done(function(result) {
                window.location.href = "/home/index";
            });
        }
    }

    // Exports
    global.MyApp.ViewModels.AccountViewModel = AccountViewModel;

})(this);
