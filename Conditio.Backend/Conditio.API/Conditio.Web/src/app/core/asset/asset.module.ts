import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { AssetService } from '@core/asset/asset.service';
import { AssetUrls } from '@core/asset/asset.urls';

@NgModule({
  imports: [SharedModule, RouterModule],
  providers: [AssetService, AssetUrls]
})
export class AssetModule { }
