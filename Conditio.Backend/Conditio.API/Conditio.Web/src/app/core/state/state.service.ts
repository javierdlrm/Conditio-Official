import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { TermsSearchQuery } from '@core/components/terms-search-form/terms-search-query.model';

@Injectable({
  providedIn: 'root',
})
export class StateService {

  termsQuery$: Subject<TermsSearchQuery> = new Subject<TermsSearchQuery>();

  constructor() { }

}
