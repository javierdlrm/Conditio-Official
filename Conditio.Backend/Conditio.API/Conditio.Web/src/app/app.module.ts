import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER, ErrorHandler } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ApplicationInsightsModule, AppInsightsService } from '@markpieszak/ng-application-insights';

import { AppCommonModule } from '@app/app-common.module';
import { AppComponent } from '@app/app.component';
import { BootstrapperService } from '@core/bootstrapper/bootstrapper.service';
import { environment } from '@src/environments/environment';
import { AppInsightsLoggerService } from '@core/logger/appinsights.logger.service';
import { ConsoleLoggerService } from '@core/logger/console.logger.service';
import { LoggerService } from '@core/logger/logger.service';
import { ErrorHandlerLoggerService } from '@core/logger/error-handler.logger.service';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

// Base url
export function getBaseUrl() { return document.getElementsByTagName('base')[0].href; }
const BaseUrlProvider = { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] };

// Internationalization
export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient, getBaseUrl() + 'assets/i18n/', '-lang.json');
}

// Bootstrapper
export function boot(bootstrapper: BootstrapperService) {
  return (): Promise<any> => {
    return bootstrapper.init();
  };
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AppCommonModule,
    ApplicationInsightsModule.forRoot({
      instrumentationKeySetLater: true
    }),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    BaseUrlProvider, AppInsightsService,
    { provide: APP_INITIALIZER, useFactory: boot, deps: [BootstrapperService], multi: true },
    { provide: ErrorHandler, useClass: ErrorHandlerLoggerService },
    { provide: LoggerService, useClass: environment.production ? AppInsightsLoggerService : ConsoleLoggerService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
