import { Component, Input, Output, EventEmitter } from '@angular/core';
import { TermsCategory } from '@core/entity/models/terms-category.model';

@Component({
    selector: 'terms-grid',
    templateUrl: './terms-grid.component.html',
    styleUrls: ['./terms-grid.component.scss'],
})
export class TermsGridComponent {

    @Input() terms: TermsCategory[];
    @Input() oneColumn: boolean;
    @Output() categorySelected = new EventEmitter<TermsCategory>();

    select(category: TermsCategory): void {
        this.categorySelected.emit(category);
    }
}
