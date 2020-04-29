import { SeverityLevel } from '@core/logger/severity-level';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export abstract class LoggerService {
    abstract trackEvent(eventName: string, eventProperties?: { [name: string]: string; }, metricProperty?: { [name: string]: number; }): void;
    abstract startTrackEvent(name: string): void;
    abstract stopTrackEvent(name: string, properties?: { [p: string]: string; }, measurements?: { [p: string]: number; }): void;
    abstract trackPageView(name?: string, url?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }, duration?: number): void;
    abstract startTrackPage(name?: string): void;
    abstract stopTrackPage(name?: string, url?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }): void;
    abstract trackMetric(name: string, average: number, sampleCount?: number, min?: number, max?: number, properties?: { [name: string]: string; }): void;
    abstract trackException(exception: Error, handledAt?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; },
                            severityLevel?: SeverityLevel | AI.SeverityLevel): void;
    abstract trackTrace(message: string, properties?: { [name: string]: string; }, severityLevel?: SeverityLevel | AI.SeverityLevel): void;
    abstract trackDependency(id: string, method: string, absoluteUrl: string, pathName: string, totalTime: number, success: boolean, resultCode: number,
                             properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }): void;
    abstract flush(): void;
    abstract setAuthenticatedUserContext(authenticatedUserId: string, accountId?: string, storeInCookie?: boolean): void;
    abstract clearAuthenticatedUserContext(): void;
}
