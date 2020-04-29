import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';
import { RegisterComponent } from '@features/auth/register/register.component';
import { SignInComponent } from '@features/auth/sign-in/sign-in.component';

@NgModule({
  imports: [SharedModule],
  exports: [],
  declarations: [RegisterComponent, SignInComponent],
  providers: []
})
export class AuthModule { }
