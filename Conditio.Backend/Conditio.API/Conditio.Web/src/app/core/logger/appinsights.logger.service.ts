import { Injectable, Injector } from '@angular/core';
import { AppInsightsService, SeverityLevel } from '@markpieszak/ng-application-insights';
import { SettingsService } from '@core/settings/settings.service';
import { Bootable } from '@core/bootstrapper/bootable';
import { Router, ResolveEnd, ActivatedRouteSnapshot } from '@angular/router';
import { filter } from 'rxjs/operators';
import { LoggerService } from './logger.service';

@Injectable({
  providedIn: 'root',
})
export class AppInsightsLoggerService implements Bootable, LoggerService {

  private router: Router;
  private routerSubscription: any;

  constructor(private settingsService: SettingsService, private appInsightsService: AppInsightsService, private injector: Injector) { }

  async init(): Promise<void> {
    this.router = this.injector.get(Router); // Inject router here -> Avoid cyclic dependency
    this.appInsightsService.config = {
      instrumentationKey: this.settingsService.api.appInsights.instrumentationKey
    };
    this.appInsightsService.init();
    this.trackRouteEvents();
  }

  private trackRouteEvents(): void {
    this.routerSubscription = this.router.events.pipe(filter(event => event instanceof ResolveEnd))
      .subscribe((event: ResolveEnd) => {
        const activatedComponent = this.getActivatedComponent(event.state.root);
        if (activatedComponent) {
          this.trackPageView(`${activatedComponent.name} ${this.getRouteTemplate(event.state.root)}`, event.urlAfterRedirects);
        }
      });
  }

  private getActivatedComponent(snapshot: ActivatedRouteSnapshot): any {
    if (snapshot.firstChild) {
      return this.getActivatedComponent(snapshot.firstChild);
    }
    return snapshot.component;
  }

  private getRouteTemplate(snapshot: ActivatedRouteSnapshot): string {
    let path = '';
    if (snapshot.routeConfig) {
      path += snapshot.routeConfig.path;
    }
    if (snapshot.firstChild) {
      return path + this.getRouteTemplate(snapshot.firstChild);
    }
    return path;
  }

  //#region LoggerService

  trackEvent(eventName: string, eventProperties?: { [name: string]: string; }, metricProperty?: { [name: string]: number; }): void {
    this.appInsightsService.trackEvent(eventName, eventProperties, metricProperty);
  }

  startTrackEvent(name: string): void {
    this.appInsightsService.startTrackEvent(name);
  }

  stopTrackEvent(name: string, properties?: { [p: string]: string; }, measurements?: { [p: string]: number; }): void {
    this.appInsightsService.stopTrackEvent(name, properties, measurements);
  }

  trackPageView(name?: string, url?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }, duration?: number): void {
    this.appInsightsService.trackPageView(name, url, properties, measurements, duration);
  }

  startTrackPage(name?: string): void {
    this.appInsightsService.startTrackPage(name);
  }

  stopTrackPage(name?: string, url?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }): void {
    this.appInsightsService.stopTrackPage(name, url, properties, measurements);
  }

  trackMetric(name: string, average: number, sampleCount?: number, min?: number, max?: number, properties?: { [name: string]: string; }): void {
    this.appInsightsService.trackMetric(name, average, sampleCount, min, max, properties);
  }

  trackException(exception: Error, handledAt?: string, properties?: { [name: string]: string; }, measurements?: { [name: string]: number; },
    severityLevel?: SeverityLevel | AI.SeverityLevel): void {
    this.appInsightsService.trackException(exception, handledAt, properties, measurements, severityLevel);
  }

  trackTrace(message: string, properties?: { [name: string]: string; }, severityLevel?: SeverityLevel | AI.SeverityLevel): void {
    this.appInsightsService.trackTrace(message, properties, severityLevel);
  }

  trackDependency(id: string, method: string, absoluteUrl: string, pathName: string, totalTime: number, success: boolean, resultCode: number,
    properties?: { [name: string]: string; }, measurements?: { [name: string]: number; }): void {
    this.appInsightsService.trackDependency(id, method, absoluteUrl, pathName, totalTime, success, resultCode, properties, measurements);
  }

  flush(): void {
    this.appInsightsService.flush();
  }

  setAuthenticatedUserContext(authenticatedUserId: string, accountId?: string, storeInCookie?: boolean): void {
    this.appInsightsService.setAuthenticatedUserContext(authenticatedUserId, accountId, storeInCookie);
  }

  clearAuthenticatedUserContext(): void {
    this.appInsightsService.clearAuthenticatedUserContext();
  }

  //#endregion
}
