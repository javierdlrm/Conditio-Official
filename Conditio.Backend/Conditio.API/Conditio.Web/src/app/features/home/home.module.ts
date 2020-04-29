import { NgModule } from '@angular/core';
import { CoreModule } from '@core/core.module';
import { SharedModule } from '@shared/shared.module';
import { HomeIntroComponent } from '@home/intro/home-intro.component';

@NgModule({
  imports: [SharedModule, CoreModule],
  declarations: [HomeIntroComponent]
})
export class HomeModule { }
