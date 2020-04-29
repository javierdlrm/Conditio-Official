import { Injectable, Inject } from '@angular/core';
import { SettingsService } from '@core/settings/settings.service';
import { Bootable } from '@core/bootstrapper/bootable';
import { AppInsightsLoggerService } from '@core/logger/appinsights.logger.service';

@Injectable({
  providedIn: 'root',
})
export class BootstrapperService {

  constructor(@Inject(SettingsService) private settingsService: Bootable, @Inject(AppInsightsLoggerService) private appInsightsLoggerService: Bootable) { }

  async init(): Promise<void> {

    await this.settingsService.init();
    await this.appInsightsLoggerService.init();
  }
}
