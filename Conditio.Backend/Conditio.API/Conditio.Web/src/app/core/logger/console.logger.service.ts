import { Injectable } from '@angular/core';
import { LoggerService } from './logger.service';
import { SeverityLevel } from '@core/logger/severity-level';

@Injectable({
  providedIn: 'root',
})
export class ConsoleLoggerService implements LoggerService {

  //#region LoggerService

  trackEvent(eventName: string, eventProperties?: { [name: string]: string; }, metricProperty?: { [name: string]: number; }): void {
    console.log(`[${eventName}]`);
  }
  startTrackEvent(name: string): void {
    console.log(`[${name}] Start ${Date.now}`);
  }
  stopTrackEvent(name: string, properties?: { [p: string]: string; }, measurements?: { [p: string]: number; }): void {
    console.log(`[${name}] Stop ${Date.now}`);
  }
  trackPageView(name?: string, url?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }, duration?: number): void {
    console.log(`[${name}] Track page`);
  }
  startTrackPage(name?: string): void {
    console.log(`[${name}] Start track page ${Date.now}`);
  }
  stopTrackPage(name?: string, url?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }): void {
    console.log(`[${name}] Stop track page ${Date.now}`);
  }
  trackMetric(name: string, average: number, sampleCount?: number, min?: number, max?: number, properties?: { [name: string]: string; }): void {
    console.log(`[${name}] Start track page ${Date.now}`);
  }
  trackException(exception: Error, handledAt?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; },
                 severityLevel?: SeverityLevel | AI.SeverityLevel): void {
    console.error(exception);
  }
  trackTrace(message: string, properties?: { [name: string]: string; }, severityLevel?: SeverityLevel | AI.SeverityLevel): void {
    console.log(message);
  }
  trackDependency(id: string, method: string, absoluteUrl: string, pathName: string, totalTime: number, success: boolean, resultCode: number,
                  properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }): void {
    console.log(`[${id}] Dependency: ${method}`);
  }
  flush(): void {
    console.clear();
  }
  setAuthenticatedUserContext(authenticatedUserId: string, accountId?: string, storeInCookie?: boolean): void {
    throw new Error('Method not implemented.');
  }
  clearAuthenticatedUserContext(): void {
    throw new Error('Method not implemented.');
  }

  //#endregion
}
