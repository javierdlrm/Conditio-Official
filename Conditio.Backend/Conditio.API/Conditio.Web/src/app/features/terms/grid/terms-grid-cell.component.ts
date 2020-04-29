import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { TermsCategory } from '@core/entity/models/terms-category.model';

@Component({
    selector: 'terms-grid-cell',
    templateUrl: './terms-grid-cell.component.html',
    styleUrls: ['./terms-grid-cell.component.scss'],
})
export class TermsGridCellComponent implements OnInit {

    @Input() category: TermsCategory;
    @Input() maxItems = 2;

    @Output() selected = new EventEmitter<TermsCategory>();

    icon: string;
    diffItems = {};

    ngOnInit(): void {
        this.icon = `assets/svg/${this.category.name}.svg`;
        this.diffItems = { numItems: this.category.concepts.length - this.maxItems };
    }

    onClick(): void {
        this.selected.emit(this.category);
    }
}
