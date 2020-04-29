import { Component } from '@angular/core';
import { AlertService } from '@core/alert/alert.service';
import { Alert } from '@core/alert/alert';

@Component({
    selector: 'core-alert',
    templateUrl: './alert.component.html',
    styleUrls: ['./alert.component.scss']
})
export class AlertComponent {

    alerts: Alert[] = [];

    constructor(private alertService: AlertService) {
        this.alertService.alerts$.subscribe((als: Alert[]) => {
            this.alerts = [...als];
        });
    }

    close(alert: Alert) {
        this.alertService.hide(alert);
    }
}
