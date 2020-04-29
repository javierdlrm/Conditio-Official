import { NgModule } from '@angular/core';

import { SharedModule } from '@shared/shared.module';

import { InfoAboutComponent } from '@info/about/info-about.component';
import { InfoContactComponent } from './contact/info-contact.component';

@NgModule({
  imports: [SharedModule],
  exports: [],
  declarations: [InfoAboutComponent, InfoContactComponent],
  providers: []
})
export class InfoModule { }
