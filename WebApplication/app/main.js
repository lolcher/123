/// <reference path="../node_modules/@types/jquery/index.d.ts"/>
define(["require", "exports", "knockout"], function (require, exports, ko) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    class MainViewModel {
        constructor() {
            this.test = ko.observable('nothing');
            let vm = this;
            $.getJSON('/webapplication.api/api/values', (data) => {
                return vm.test(data[0]);
            });
        }
    }
    ko.applyBindings(new MainViewModel());
});
//# sourceMappingURL=main.js.map