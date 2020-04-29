import { NgModule } from '@angular/core';
import { NgbTypeaheadModule, NgbAlertModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    imports: [NgbTypeaheadModule, NgbAlertModule, NgbModalModule],
    exports: [NgbTypeaheadModule, NgbAlertModule, NgbModalModule]
})
export class NgBootstrapModule { }
