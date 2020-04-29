import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { DomainService } from '@core/domain/domain.service';
import { DomainUrls } from '@core/domain/domain.urls';

@NgModule({
  imports: [SharedModule, RouterModule],
  providers: [DomainService, DomainUrls]
})
export class DomainModule { }
