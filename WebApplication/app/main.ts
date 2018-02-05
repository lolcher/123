/// <reference path="../node_modules/@types/jquery/index.d.ts"/>

import * as ko from "knockout";

class MainViewModel {
    public test: KnockoutObservable<string> = ko.observable('nothing');
    
    constructor() {

        let vm = this;
        $.getJSON('/webapplication.api/api/values', (data: string) => {
            return vm.test(data[0]);
        });
    }
}

ko.applyBindings(new MainViewModel());