import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
    selector: 'app-terms',
    templateUrl: 'terms.component.html',
    styleUrls: ['terms.component.scss']
})
export class TermsComponent {
    constructor(private _location: Location) {
    }

    public back() {
        this._location.back();
    }
}