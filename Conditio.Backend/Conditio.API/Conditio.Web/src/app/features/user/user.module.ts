import { NgModule } from '@angular/core';
import { UserAccountComponent } from '@user/account/user-account.component';
import { UserService } from '@core/user/user.service';

@NgModule({
  imports: [],
  exports: [],
  declarations: [UserAccountComponent],
  providers: [UserService]
})
export class UserModule { }
