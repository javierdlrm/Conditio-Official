import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'shared-rating',
    templateUrl: './rating.component.html',
    styleUrls: ['./rating.component.scss'],
})
export class RatingComponent implements OnInit {

    @Input() rate: 1 | 2 | 3 | 4 | 5;
    @Input() size: 'small' | 'medium' | 'large' = 'medium';

    starSize: number;

    ngOnInit(): void {
        switch (this.size) {
            case 'small':
                this.starSize = 16;
                break;
            case 'medium':
                this.starSize = 24;
                break;
            case 'large':
                this.starSize = 30;
        }
    }
}
