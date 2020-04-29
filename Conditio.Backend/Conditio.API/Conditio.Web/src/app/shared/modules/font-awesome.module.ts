import { NgModule } from '@angular/core';

import { FontAwesomeModule as AngularFontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';

// Icons
import { faCircle, faQuoteLeft, faQuoteRight, faChevronDown, faChevronUp } from '@fortawesome/free-solid-svg-icons';

library.add(faCircle, faQuoteLeft, faQuoteRight, faChevronDown, faChevronUp);

@NgModule({
  imports: [AngularFontAwesomeModule],
  exports: [AngularFontAwesomeModule]
})
export class FontAwesomeModule { }
