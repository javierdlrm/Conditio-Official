import { Routes } from '@angular/router';

import { InfoAboutComponent } from '@info/about/info-about.component';
import { InfoContactComponent } from '@info/contact/info-contact.component';

export const routes: Routes = [
  { path: 'about-us', component: InfoAboutComponent },
  { path: 'contact-us', component: InfoContactComponent }
];
