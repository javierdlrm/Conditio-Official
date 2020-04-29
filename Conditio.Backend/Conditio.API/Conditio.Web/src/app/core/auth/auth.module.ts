import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { AuthService } from '@core/auth/auth.service';
import { AuthUrls } from '@core/auth/auth.urls';

@NgModule({
  imports: [SharedModule, RouterModule],
  providers: [AuthService, AuthUrls]
})
export class AuthModule { }
