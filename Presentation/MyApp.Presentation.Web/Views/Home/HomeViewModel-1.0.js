/// <reference path="../../Scripts/uiframework-1.0.js" />

(function (global) {
    "use strict";
   
    // Private
    function HomeViewModel() {
        var that = this;

        this.billingHistory = ko.observableArray();

        // Init
        global.MyApp.UIFramework.invokeAction("billing", "list").done(function(results) {
            that.billingHistory(results);
        });
    }

    // Exports
    global.MyApp.ViewModels.HomeViewModel = HomeViewModel;

})(this);
