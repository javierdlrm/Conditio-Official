import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { TermsCategory } from '@core/entity/models/terms-category.model';

@Component({
    selector: 'terms-detail',
    templateUrl: './terms-detail.component.html',
    styleUrls: ['./terms-detail.component.scss'],
})
export class TermsDetailComponent implements OnInit {

    @Input() category: TermsCategory;
    @Output() close = new EventEmitter();

    icon: string;

    ngOnInit(): void {
        this.icon = `assets/svg/${this.category.name}.svg`;
    }

    closeDetail(): void {
        this.close.emit();
    }
}
