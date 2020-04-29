import { NgModule } from '@angular/core';

import { HomeModule } from '@home/home.module';
import { TermsModule } from '@features/terms/terms.module';
import { InfoModule } from '@info/info.module';
import { UserModule } from '@user/user.module';

@NgModule({
  imports: [HomeModule, TermsModule, InfoModule, UserModule],
  exports: [],
  declarations: [],
  providers: []
})
export class FeaturesModule { }
