import { NgModule } from '@angular/core';

import { AppRoutingModule } from '@app/app-routing.module';
import { CoreModule } from '@core/core.module';
import { SharedModule } from '@shared/shared.module';
import { FeaturesModule } from '@features/features.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { EnsureHttpsInterceptor } from '@core/interceptors/ensure-https.interceptor';
import { CacheRequestsInterceptor } from '@core/interceptors/cache-requests.interceptor';
import { AddAuthInterceptor } from '@core/interceptors/add-auth.interceptor';

// Interceptors
export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: EnsureHttpsInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: CacheRequestsInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: AddAuthInterceptor, multi: true }
];

@NgModule({
  imports: [
    AppRoutingModule,
    CoreModule,
    SharedModule,
    FeaturesModule
  ],
  exports: [
    AppRoutingModule,
    CoreModule,
    SharedModule
  ],
  providers: [httpInterceptorProviders]
})
export class AppCommonModule { }
