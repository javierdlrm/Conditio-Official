import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { AuthModule } from '@features/auth/auth.module';
import { StateModule } from '@core/state/state.module';
import { AssetModule } from '@core/asset/asset.module';
import { EntityModule } from '@core/entity/entity.module';
import { NavMenuComponent } from '@core/components/nav-menu/nav-menu.component';
import { FooterComponent } from '@core/components/footer/footer.component';
import { TermsSearchFormComponent } from '@core/components/terms-search-form/terms-search-form.component';
import { LoaderComponent } from '@core/components/loader/loader.component';
import { SettingsService } from './settings/settings.service';
import { BootstrapperService } from './bootstrapper/bootstrapper.service';
import { DomainModule } from '@core/domain/domain.module';
import { AlertService } from '@core/alert/alert.service';
import { AlertComponent } from '@core/components/alert/alerts.component';

@NgModule({
  imports: [
    CommonModule, RouterModule, SharedModule,
    AssetModule, EntityModule, DomainModule, AuthModule, StateModule
  ],
  exports: [
    AssetModule, EntityModule, AuthModule, StateModule,
    /* Components */
    TermsSearchFormComponent, LoaderComponent, AlertComponent, NavMenuComponent, FooterComponent
  ],
  declarations: [
    /* Components */
    TermsSearchFormComponent, LoaderComponent, AlertComponent, NavMenuComponent, FooterComponent
  ],
  providers: [BootstrapperService, SettingsService, AlertService]
})
export class CoreModule { }
