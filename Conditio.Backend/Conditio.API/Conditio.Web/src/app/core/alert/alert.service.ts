import { Injectable } from '@angular/core';
import { Alert, ALERT, ALERTS } from '@core/alert/alert';
import { Subject, BehaviorSubject } from 'rxjs';
import { debounceTime, timeout } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class AlertService {

    alerts$: Subject<Alert[]> = new BehaviorSubject<Alert[]>([]);

    private alerts: Alert[] = [];

    constructor() { }

    show(alert: ALERT): void {
        const al = ALERTS[ALERT[alert]];
        const idx = this.alerts.indexOf(al);

        if (idx >= 0) {
            this.alerts.splice(idx, 1);
        }
        this.alerts.push(al);
        this.alerts$.next(this.alerts);
        // setTimeout(() => {
        //     this.hide(al);
        // }, 5000);
    }

    hide(alert: Alert): void {
        const idx = this.alerts.indexOf(alert);
        if (idx >= 0) {
            this.alerts.splice(idx, 1);
            this.alerts$.next(this.alerts);
        }
    }
}
