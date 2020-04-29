import { Component, Input, OnInit } from '@angular/core';
import { TaskService } from '@core/state/task.service';

@Component({
    selector: 'core-loader',
    templateUrl: './loader.component.html',
    styleUrls: ['./loader.component.scss']
})
export class LoaderComponent implements OnInit {

    @Input() facade: boolean;
    @Input() loading: boolean;

    constructor(private taskService: TaskService) { }

    ngOnInit(): void {
        if (this.facade) {
            this.taskService.loading$.subscribe((value) => { this.loading = value; });
        }
    }
}
