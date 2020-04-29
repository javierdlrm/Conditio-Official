import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { routes as HomeRoutes } from '@home/home.routes';
import { routes as TermsRoutes } from '@features/terms/terms.routes';
import { routes as UserRoutes } from '@user/user.routes';
import { routes as InfoRoutes } from '@info/info.routes';
import { routes as AuthRoutes } from '@features/auth/auth.routes';

const routes: Routes = [
  ...HomeRoutes,
  ...TermsRoutes,
  ...UserRoutes,
  ...InfoRoutes,
  ...AuthRoutes
];

@NgModule({
  imports: [RouterModule.forRoot(routes,
    { enableTracing: false } // <-- debugging purposes only
  )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
